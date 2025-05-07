using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private Transform _camera;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _lookLeftAction; 
    private InputAction _lookRightAction;
    private InputAction _pointAction;
    private InputAction _interactAction;
    private Interactable _lastHighlighted;

    
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _lookLeftAction = _playerInput.actions.FindAction("LookLeft"); 
        _lookRightAction = _playerInput.actions.FindAction("LookRight");
        _pointAction = _playerInput.actions.FindAction("Point");
        _interactAction = _playerInput.actions.FindAction("Interact");
        
        if (_interactAction != null)
        {
            _interactAction.performed += OnInteract;
        }
        else
        {
            Debug.Log("No interact");
        }

    }

    void OnEnable()
    {
        _playerInput.actions.Enable();
    }

    void OnDisable()
    {
        _playerInput.actions.Disable();
        _interactAction.performed -= OnInteract;
    }

    void FixedUpdate()
    {
        Move();
        Look();
    }

    private void Update()
    {
        Point();
    }

    private void Move()
    {
        Vector2 direction = _moveAction.ReadValue<Vector2>();
        float scaledSpeed = _movementSpeed * Time.fixedDeltaTime;
        Vector3 cameraForward = _camera.forward;
        cameraForward.y = 0f; 
        cameraForward.Normalize();

        Vector3 cameraRight = _camera.right;
        cameraRight.y = 0f; 
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * direction.y + cameraRight * direction.x) * scaledSpeed;

        _rb.MovePosition(_rb.position + movement);
    }

    private void Look()
    {
        float lookInput = 0f;

        if (_lookLeftAction.IsPressed())
        {
            lookInput = -1f; 
        }
        else if (_lookRightAction.IsPressed())
        {
            lookInput = 1f; 
        }

        float angle = lookInput * _rotationSpeed * Time.fixedDeltaTime;
        _camera.Rotate(Vector3.up, angle, Space.World);
    }
    
    private void Point()
    {
        
        Vector2 position = _pointAction.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(position); 
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (_lastHighlighted != null && _lastHighlighted != interactable)
                {
                    _lastHighlighted.RemoveHighlight();
                }

                interactable.Highlight();
                _lastHighlighted = interactable; 
            }

        }
        else
        {
            if (_lastHighlighted != null)
            {
                _lastHighlighted.RemoveHighlight();
            }
            _lastHighlighted = null;
        }
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        
        Vector2 position = _pointAction.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                    {
                        Debug.Log("Raycast hit: " + hit.collider.name);
                        interactable.Interact();
                    }
            }
        }
    }

}

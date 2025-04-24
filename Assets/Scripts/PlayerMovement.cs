using System.Linq;
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

    
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _lookLeftAction = _playerInput.actions.FindAction("LookLeft"); 
        _lookRightAction = _playerInput.actions.FindAction("LookRight");
    }

    void FixedUpdate()
    {
        Move();
        Look();
    }
    
    private void Move()
    {
        Vector2 direction = _moveAction.ReadValue<Vector2>();
        float scaledSpeed = _movementSpeed * Time.fixedDeltaTime;
        Vector3 movement = new Vector3(direction.x * scaledSpeed, 0f, direction.y * scaledSpeed);

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
}

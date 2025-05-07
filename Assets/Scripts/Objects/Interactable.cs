using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool turnOnHighlight = false;
    
    private MeshRenderer _renderer;
    private Material _material;
    private Color _color;
    private bool _emissionOn = false;
    private float _emissionIntensity = 2f;

    protected virtual void Awake()
    {
        if (turnOnHighlight)
        {
            _renderer = GetComponent<MeshRenderer>() ?? GetComponentInChildren<MeshRenderer>();
            if (_renderer != null)
            {
                _material = _renderer.material;

                if (_material.HasProperty("_EmissionColor"))
                {
                    _color = _material.GetColor("_EmissionColor");
                }
            }
        }
    }


    public void Highlight()
    {
        if (!turnOnHighlight || _material == null || !_material.HasProperty("_EmissionColor")) return;
        
        Color baseColor;
        if (_material.HasProperty("_BaseColor")) {
            baseColor = _material.GetColor("_BaseColor");
        }
        else
        {
            baseColor = _material.color;
        }
            
        Color emissionColor = baseColor * _emissionIntensity;
            
        _material.EnableKeyword("_EMISSION");
        _material.SetColor("_EmissionColor", emissionColor);
        _emissionOn = true;
        
    }

    public void RemoveHighlight()
    {
        if (!turnOnHighlight || _material == null || !_material.HasProperty("_EmissionColor")) return;
        
        if (_emissionOn && _material.HasProperty("_EmissionColor"))
        {
            _material.SetColor("_EmissionColor", _color);
            _emissionOn = false;
        }
    }

    public virtual void Interact(){}
}

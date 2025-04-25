using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Material _material;
    private Color _color;
    private bool _emissionOn = false;
    private float _emissionIntensity = 2f;

    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _material = _meshRenderer.material;

        if (_material.HasProperty("_EmissionColor"))
        {
            _color = _material.GetColor("_EmissionColor");
        }
    }
    
    public void Highlight()
    {
        if (_material.HasProperty("_EmissionColor"))
        {
            Color baseColor;
            if (_material.HasProperty("_BaseColor"))
            {
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
    }

    public void RemoveHighlight()
    {
        if (_emissionOn && _material.HasProperty("_EmissionColor"))
        {
            _material.SetColor("_EmissionColor", _color);
            _emissionOn = false;
        }
    }

    public abstract void Interact();
}

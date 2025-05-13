using UnityEngine;

public class Highlightable : Interactable
{
    private const string EmissionColor = "_EmissionColor";
    private const string BaseColor = "_BaseColor";
    private const string Emission = "_EMISSION";
    
    protected MeshRenderer meshRenderer;
    protected Material material;
    protected Color color;
    private float _emissionIntensity = 2f;
    
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>() ?? GetComponentInChildren<MeshRenderer>();
        if (meshRenderer != null)
        {
            material = meshRenderer.material;

            if (material.HasProperty(EmissionColor))
            {
                color = material.GetColor(EmissionColor);
            }
        }
    }

    protected override void OnHighlight()
    {
        if (material == null || !material.HasProperty(EmissionColor)) return;
        
        Color baseColor;
        if (material.HasProperty(BaseColor)) {
            baseColor = material.GetColor(BaseColor);
        }
        else
        {
            baseColor = material.color;
        }
            
        Color emissionColor = baseColor * _emissionIntensity;
            
        material.EnableKeyword(Emission);
        material.SetColor(EmissionColor, emissionColor);
    }
    
    protected override void OnRemoveHighlight()
    {
        if (material == null || !material.HasProperty(EmissionColor)) return;
        
        material.SetColor(EmissionColor, color);
    }
}

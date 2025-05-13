using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool turnOnHighlight = false;
    
    public void Highlight()
    {
        if (!turnOnHighlight)
        {
            return;
        }
        OnHighlight();
    }

    public void RemoveHighlight()
    {
        if (!turnOnHighlight)
        {
            return;
        }
        OnRemoveHighlight();
    }

    protected virtual void OnHighlight(){}

    protected virtual void OnRemoveHighlight(){}

    public virtual void Interact(){}
}

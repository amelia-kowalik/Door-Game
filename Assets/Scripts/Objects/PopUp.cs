using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public string Text { get; protected set; }

    public virtual void SetText(string text)
    {
        Text = text;
    }
    public virtual void OnYesPressed(){}

    public void OnNoPressed()
    {
        gameObject.SetActive(false);
    }
}

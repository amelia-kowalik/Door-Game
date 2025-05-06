using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopUp : PopUp
{
    [SerializeField] private Button okButton;
    [SerializeField] private TextMeshProUGUI popupText;
    
    public void SetUp(string text)
    {
        base.SetText(text);
        popupText.text = text;
        if (okButton != null)
        {
            okButton.onClick.RemoveAllListeners();
            okButton.onClick.AddListener(OnOkPressed);
            okButton.gameObject.SetActive(true); 
        }
    }

    public void OnOkPressed()
    {
        gameObject.SetActive(false);
    }
    public override void OnYesPressed()
    {
        OnOkPressed();
    }
}

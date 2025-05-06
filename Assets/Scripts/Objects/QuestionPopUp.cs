using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPopUp : PopUp
{
    private static Action OnYesAction;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private TextMeshProUGUI popupText;
    

    public void SetUp(string text,Action yesAction)
    {
        base.SetText(text);
        popupText.text = text;
        OnYesAction = yesAction;
        
        if (yesButton != null)
        {
            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(OnYesPressed); 
            yesButton.gameObject.SetActive(true); 
        }

        if (noButton != null)
        {
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(OnNoPressed);  
            noButton.gameObject.SetActive(true); 
        }
    }

    public override void OnYesPressed()
    {
        base.OnYesPressed();
        OnYesAction?.Invoke();
        gameObject.SetActive(false);
    }
}

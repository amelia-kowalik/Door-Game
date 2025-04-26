using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public TextMeshProUGUI text;

    public void SetUp(PopUp popUp)
    {
        if (yesButton != null)
        {
            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(popUp.OnYesPressed);
        }
        if (noButton != null)
        {
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(popUp.OnNoPressed);
        }
        if (text != null)
        {
            text.text = popUp.Text;
        }
        
    }
}

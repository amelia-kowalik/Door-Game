using System;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject infoPopUpPrefab;
    [SerializeField] private GameObject questionPopUpPrefab;
    [SerializeField] private GameObject canvas;
    private PopUp _currentPopUp;
    

    public void ShowQuestionPopUp(string text, Action onYes)
    {
        if (_currentPopUp != null)
        {
            Destroy(_currentPopUp.gameObject);
        }

        GameObject popItUp = Instantiate(questionPopUpPrefab, canvas.transform
        );

        QuestionPopUp questionPopUp = popItUp.GetComponent<QuestionPopUp>();
        questionPopUp.SetUp(text, onYes);
        _currentPopUp = questionPopUp;
    }

    public void ShowInfoPopUp(string text)
    {
        if (_currentPopUp != null)
        {
            Destroy(_currentPopUp.gameObject);
        }
        
        GameObject popItUp = Instantiate(infoPopUpPrefab,canvas.transform);

        InfoPopUp infoPopUp = popItUp.GetComponent<InfoPopUp>();
        infoPopUp.SetUp(text);
        infoPopUp.gameObject.SetActive(true);
        _currentPopUp = infoPopUp;
    }
}

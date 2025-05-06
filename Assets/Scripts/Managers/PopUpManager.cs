using System;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject infoPopUpPrefab;
    [SerializeField] private GameObject questionPopUpPrefab;
    private PopUp _currentPopUp;
    private PopUpUI _view;
    
    void Start()
    {
        _view = GetComponent<PopUpUI>();
    }

    public void ShowQuestionPopUp(string text, Action onYes)
    {
        if (_currentPopUp != null)
        {
            Destroy(_currentPopUp.gameObject);
        }

        GameObject popItUp = Instantiate(questionPopUpPrefab, FindObjectOfType<Canvas>().transform
        );

        QuestionPopUp questionPopUp = popItUp.GetComponent<QuestionPopUp>();
        questionPopUp.SetUp(text, onYes);
        //view.SetUp(questionPopUp);
       // questionPopUp.gameObject.SetActive(true);
        _currentPopUp = questionPopUp;
    }

    public void ShowInfoPopUp(string text)
    {
        if (_currentPopUp != null)
        {
            Destroy(_currentPopUp.gameObject);
        }
        
        GameObject popItUp = Instantiate(infoPopUpPrefab,FindObjectOfType<Canvas>().transform);

        InfoPopUp infoPopUp = popItUp.GetComponent<InfoPopUp>();
        infoPopUp.SetUp(text);
        //view.SetUp(infoPopUp);
        infoPopUp.gameObject.SetActive(true);
        _currentPopUp = infoPopUp;
    }
}

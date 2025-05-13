using System;
using UnityEngine;

public class Door : Highlightable
{
    private const string OpenDoorQuestion = "Open the door?";
    private const string NeedKeyInfo = "You need a key!";
    
    private bool _hasKey = false;
    
    private void KeyAdded()
    {
        _hasKey = true;
    }
    
    public override void Interact()
    {
        _hasKey = Inventory.Instance.HasKey();
        if (_hasKey)
        {
            GameManager.Instance.PopUpManager.ShowQuestionPopUp(OpenDoorQuestion, 
                () => 
                {
                    OpenDoor();
                }
            );
        } else 
        {
            GameManager.Instance.PopUpManager.ShowInfoPopUp(NeedKeyInfo);
        }
    }

    private void OpenDoor() 
    {
        GameManager.Instance.CompleteGameplay();
    }
}

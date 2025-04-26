using System;
using UnityEngine;

public class Door : Interactable
{
    private bool _hasKey = false;

    private void OnEnable()
    {
        Inventory.OnKeyAdded += KeyAdded;
    }

    private void OnDisable()
    {
        Inventory.OnKeyAdded -= KeyAdded;
    }

    private void KeyAdded()
    {
        _hasKey = true;
    }
    public override void Interact()
    {
        if (_hasKey)
        {
            PopUpManager.Instance.ShowQuestionPopUp("Open the door?", 
                () => 
                {
                    OpenDoor();
                }
            );
        } else 
        {
            PopUpManager.Instance.ShowInfoPopUp("You need a key!");
        }
    }

    private void OpenDoor()
    {
        GameManager.Instance.CompleteGameplay();
    }
}

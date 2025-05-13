using System;
using UnityEngine;

public class Chest : Highlightable
{
    private const string OpenChestQuestion = "Open the chest?";
    private const string FoundKeyInfo = "You found a key!";
    
    private bool _isChestOpen = false;
    
    public override void Interact()
    {
        Debug.Log("Chest clicked");
        if (!_isChestOpen)
        {
            GameManager.Instance.PopUpManager.ShowQuestionPopUp(OpenChestQuestion,
                () =>
            {
                OpenChest();
            }
            );
        }
    }

    private void OpenChest()
    {
        _isChestOpen = true;
        
        Inventory.Instance.AddKey();
        
        GameManager.Instance.PopUpManager.ShowInfoPopUp(FoundKeyInfo);
    }
}

using System;
using UnityEngine;

public class Chest : Interactable
{
    private bool _isChestOpen = false;
    
    public override void Interact()
    {
        Debug.Log("Chest clicked");
        if (!_isChestOpen)
        {
            PopUpManager.Instance.ShowQuestionPopUp("Open the chest?",
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
        
        PopUpManager.Instance.ShowInfoPopUp("You found a key!");
    }
}

using System;
using UnityEngine;

public class Chest : Interactable
{
    private const string OpenChestQuestion = "Open the chest?";
    private const string FoundKeyInfo = "You found a key!";
    
    private bool _isChestOpen = false;


    protected override void Awake()
    {
        base.Awake();
    }
    
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

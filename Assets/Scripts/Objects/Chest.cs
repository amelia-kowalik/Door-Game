using System;
using UnityEngine;

public class Chest : Interactable
{
    public static event Action onChestClicked;
    
    public GameObject keyPrefab;
    private bool _isChestOpen = false;
    
    public override void Interact()
    {
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
        keyPrefab = Instantiate(keyPrefab);
        onChestClicked?.Invoke();
    }
}

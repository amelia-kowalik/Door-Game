using System;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject keyPrefab;
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
        animator.SetBool("IsClicked", true);
        _isChestOpen = true;
        keyPrefab = Instantiate(keyPrefab, gameObject.transform);
    }
}

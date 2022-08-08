using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : IInteractable
{
    [SerializeField] public DialogueContent dialogueContent;
    
    public InteractableType GetInteractableType()
    {
        return InteractableType.SHOP;
    }

    public DialogueContent GetMessage()
    {
        return dialogueContent;
    }

    public void OpenShop()
    {
        GameManager.Instance.stageManager.ToggleShopScreen();
    }

    public Collectable PickUp()
    {
        return null;
    }
}

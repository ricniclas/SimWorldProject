using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : MonoBehaviour, IInteractable
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
        GameManager.Instance.stageManager.ActivateShopScreen(dialogueContent);
    }

    public Collectable PickUp()
    {
        return null;
    }
}

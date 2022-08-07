using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public InteractableType GetInteractableType();
    public DialogueContent GetMessage();
    public Collectable PickUp();
    public void OpenShop();

}

public enum InteractableType
{
    TEXT,
    PICKUP,
    SHOP
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public InteractableType GetInteractableType();
    public string GetMessage();
    public void OpenShop();

}

public enum InteractableType
{
    TEXT,
    SHOP
}

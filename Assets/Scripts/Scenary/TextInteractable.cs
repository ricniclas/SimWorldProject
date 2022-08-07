using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string message;
    InteractableType interactableType = InteractableType.TEXT;

    public InteractableType GetInteractableType()
    {
        return interactableType;
    }

    public string GetMessage()
    {
        return message;
    }

    public void OpenShop()
    {
    }
}

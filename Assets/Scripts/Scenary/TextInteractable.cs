using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueContent interactableContent;

    public InteractableType GetInteractableType()
    {
        return InteractableType.TEXT;
    }

    public DialogueContent GetMessage()
    {
        return interactableContent;
    }

    public void OpenShop()
    {
    }

    public Collectable PickUp()
    {
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractable : MonoBehaviour, IInteractable
{
    public Collectable collectable;
    public DialogueContent dialogueContent;
    [SerializeField] private float respawnTime = 30f;
    [SerializeField] private Collider2D rigidbodyCollider;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D boxCollider;

    public InteractableType GetInteractableType()
    {
        return InteractableType.PICKUP;
    }

    public DialogueContent GetMessage()
    {
        return dialogueContent;
    }

    public void OpenShop()
    {
    }

    public Collectable PickUp()
    {
        StartCoroutine(respawnObject());
        return collectable;
    }

    private IEnumerator respawnObject()
    {
        yield return new WaitForFixedUpdate();
        rigidbodyCollider.enabled = false;
        sprite.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        rigidbodyCollider.enabled = true;
        sprite.enabled = true;
        boxCollider.enabled = true;
    }
}

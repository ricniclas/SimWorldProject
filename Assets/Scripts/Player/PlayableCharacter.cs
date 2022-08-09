using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayableCharacter : MonoBehaviour, IInputReceiver
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteLibrary spriteLibrary;
    private Rigidbody2D rigidBody2D;
    private Vector2 currentDirection;
    private IInteractable currentInteractable;

    private InputPackage inputPackage => new InputPackage(Movement, PressInteract, ReleaseInteract, Cancel, PressStart);


    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        setSpriteLibrary();
    }

    private void Update()
    {
        rigidBody2D.velocity = currentDirection * speed;
        setAnimator();
    }


    private void setAnimator()
    {
        Vector2 velocity = rigidBody2D.velocity;
        playerAnimator.SetFloat(Constants.ANIMATOR_PLAYER_PARAM_SPEED, velocity.magnitude);
        if (velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(velocity.x, velocity.y) * (180 / Mathf.PI);

            if (angle <= 45 && angle >= -45)
            {
                playerAnimator.SetFloat(Constants.ANIMATOR_PLAYER_PARAM_LAST_DIRECTION, 1);
                return;
            }
            if (angle < 135 && angle > 45)
            {
                playerAnimator.SetFloat(Constants.ANIMATOR_PLAYER_PARAM_LAST_DIRECTION, 3);
                return;
            }
            if (angle >= 135 || angle <= -135)
            {
                playerAnimator.SetFloat(Constants.ANIMATOR_PLAYER_PARAM_LAST_DIRECTION, 0);
                return;
            }
            else
            {
                playerAnimator.SetFloat(Constants.ANIMATOR_PLAYER_PARAM_LAST_DIRECTION, 2);
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TAG_INTERACTABLE))
        {
            GameManager.Instance.stageManager.ShowAlert(true);
            currentInteractable = collision.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameManager.Instance.stageManager.ShowAlert(false);
        currentInteractable = null;
    }

    public InputPackage GetInputPackage()
    {
        return inputPackage;
    }

    public void Movement(Vector2 movement)
    {
        currentDirection = movement;
    }

    public void Cancel()
    {
        Debug.Log("Pressed Cancel");
    }

    public void PressInteract()
    {
        if (currentInteractable != null)
        {
            currentDirection = Vector2.zero;
            switch (currentInteractable.GetInteractableType())
            {
                case InteractableType.TEXT:
                    GameManager.Instance.stageManager.ShowDialogue(currentInteractable.GetMessage());
                    break;
                case InteractableType.PICKUP:
                    GameManager.Instance.stageManager.PickUpItem(currentInteractable.PickUp(),currentInteractable.GetMessage());
                    break;
                case InteractableType.SHOP:
                    currentInteractable.OpenShop();
                    break;
            }
        }
    }

    public void ReleaseInteract()
    {
    }

    public void PressStart()
    {
        GameManager.Instance.stageManager.TogglePause(true);
        currentDirection = Vector2.zero;
    }

    public void setSpriteLibrary()
    {
        switch (GameManager.Instance.inventaryManager.GetCurrentlyUsing())
        {
            case CostumeType.WHITE:
                spriteLibrary.spriteLibraryAsset = GameManager.Instance.stageManager.GetSpriteLibraryHolder().whiteSpriteLibrary;
                break;
            case CostumeType.BLUE:
                spriteLibrary.spriteLibraryAsset = GameManager.Instance.stageManager.GetSpriteLibraryHolder().blueSpriteLibrary;
                break;
            case CostumeType.GREEN:
                spriteLibrary.spriteLibraryAsset = GameManager.Instance.stageManager.GetSpriteLibraryHolder().greenSpriteLibrary;
                break;
            case CostumeType.ORANGE:
                spriteLibrary.spriteLibraryAsset = GameManager.Instance.stageManager.GetSpriteLibraryHolder().orangeSpriteLibrary;
                break;
            case CostumeType.PURPLE:
                spriteLibrary.spriteLibraryAsset = GameManager.Instance.stageManager.GetSpriteLibraryHolder().purpleSpriteLibrary;
                break;
            case CostumeType.BLACK:
                spriteLibrary.spriteLibraryAsset = GameManager.Instance.stageManager.GetSpriteLibraryHolder().blackSpriteLibrary;
                break;
            default:
                break;
        }
    }
}

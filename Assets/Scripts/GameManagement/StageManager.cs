using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject playableCharacterPrefab;
    [SerializeField] private GameObject cameraObject;
    [Header("Interface")]
    [SerializeField] private GameObject alertGameObject;
    [SerializeField] private DialogueWindow dialogueWindow;
    [SerializeField] private DisplayWindow pauseScreen;
    [SerializeField] private DisplayWindow shopScreen;
    [SerializeField] private EventSystem eventSystem;
    private PlayableCharacter playableCharacter;
    private SpriteLibraryHolder spriteLibraryHolder;

    private void Start()
    {
        spriteLibraryHolder = GetComponent<SpriteLibraryHolder>();
        GameManager.Instance.stageManager = this;
        playableCharacter = Instantiate(playableCharacterPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).GetComponent<PlayableCharacter>();
        cameraObject.transform.SetParent(playableCharacter.transform);
        GameManager.Instance.inputAction.replaceInputEvents(playableCharacter.GetInputPackage());

        pauseScreen.gameObject.SetActive(false);
        shopScreen.gameObject.SetActive(false);
    }

    public void ShowDialogue(DialogueContent dialogueContent)
    {
        dialogueWindow.gameObject.SetActive(true);
        GameManager.Instance.inputAction.replaceInputEvents(dialogueWindow.GetInputPackage());
        dialogueWindow.ShowDialogue(dialogueContent);
    }


    public void PickUpItem(Collectable collectable, DialogueContent dialogueContent)
    {
        dialogueWindow.gameObject.SetActive(true);
        GameManager.Instance.inputAction.replaceInputEvents(dialogueWindow.GetInputPackage());
        GameManager.Instance.inventaryManager.StoreItem(collectable);
        pauseScreen.pocketHandler.UpdateCollectables();
        dialogueWindow.ShowDialogue(dialogueContent);
    }

    public void CloseDialogue()
    {
        dialogueWindow.gameObject.SetActive(false);
        GameManager.Instance.inputAction.replaceInputEvents(playableCharacter.GetInputPackage());
    }

    public void ShowAlert(bool active)
    {
        alertGameObject.SetActive(active);
    }

    public void TogglePause(bool activate)
    {
        pauseScreen.gameObject.SetActive(activate);
        if (activate)
        {
            GameManager.Instance.inputAction.replaceInputEvents(pauseScreen.GetInputPackage());
            eventSystem.SetSelectedGameObject(pauseScreen.firstSelected.gameObject);
        }
        else
            GameManager.Instance.inputAction.replaceInputEvents(playableCharacter.GetInputPackage());
    }

    public void DeactivateShopScreen()
    {
        GameManager.Instance.inputAction.replaceInputEvents(playableCharacter.GetInputPackage());
        shopScreen.gameObject.SetActive(false);
        dialogueWindow.gameObject.SetActive(false);
    }

    public void ActivateShopScreen(DialogueContent dialogueContent)
    {
        GameManager.Instance.inputAction.replaceInputEvents(shopScreen.GetInputPackage());
        shopScreen.gameObject.SetActive(true);
        dialogueWindow.gameObject.SetActive(true);
        dialogueWindow.ShowDialogue(dialogueContent);
        eventSystem.SetSelectedGameObject(shopScreen.firstSelected.gameObject);
    }

    public void UpdateCostumes()
    {
        shopScreen.pocketHandler.UpdateCostumes();
        pauseScreen.pocketHandler.UpdateCostumes();
    }

    public void UpdateCollectables()
    {
        shopScreen.pocketHandler.UpdateCollectables();
        pauseScreen.pocketHandler.UpdateCollectables();
    }

    public void UpdateMoney()
    {
        shopScreen.pocketHandler.UpdateMoney();
        pauseScreen.pocketHandler.UpdateMoney();
    }

    public SpriteLibraryHolder GetSpriteLibraryHolder()
    {
        return spriteLibraryHolder;
    }

    public void SetNewCostume()
    {
        playableCharacter.setSpriteLibrary();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject playableCharacterPrefab;
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private GameObject alertGameObject;
    [SerializeField] private DialogueWindow dialogueWindow;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private PocketHandler pocketHandler;
    private PlayableCharacter playableCharacter;

    private void Start()
    {
        GameManager.Instance.stageManager = this;
        playableCharacter = Instantiate(playableCharacterPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).GetComponent<PlayableCharacter>();
        cameraObject.transform.SetParent(playableCharacter.transform);
        GameManager.Instance.inputAction.replaceInputEvents(playableCharacter.GetInputPackage());
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
        pocketHandler.UpdateCollectables();
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

    public void TogglePause()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }


}

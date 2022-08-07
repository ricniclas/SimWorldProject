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
    private PlayableCharacter playableCharacter;




    private void Start()
    {
        GameManager.Instance.stageManager = this;
        playableCharacter = Instantiate(playableCharacterPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).GetComponent<PlayableCharacter>();
        cameraObject.transform.SetParent(playableCharacter.transform);
        GameManager.Instance.inputAction.replaceInputEvents(playableCharacter.GetInputPackage());
    }

    public void ShowDialogue(string message)
    {
        dialogueWindow.gameObject.SetActive(true);
        GameManager.Instance.inputAction.replaceInputEvents(dialogueWindow.GetInputPackage());
        dialogueWindow.ShowDialogue(message);

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
}

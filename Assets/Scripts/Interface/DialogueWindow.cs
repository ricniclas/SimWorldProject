using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour, IInputReceiver
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float timeBetweenLetters = 0.5f;
    private Coroutine typeTextCorroutine;
    private string currentText;
    private bool completedMessage = false;
    private InputPackage inputPackage => new InputPackage(Movement, PressInteract, ReleaseInteract,
        Cancel, PressStart);

    public void ShowDialogue(string text)
    {
        if (typeTextCorroutine != null)
        {
            StopCoroutine(typeTextCorroutine);
        }
        typeTextCorroutine = StartCoroutine(TypeTextCorroutine(text));
    }

    private IEnumerator TypeTextCorroutine(string text)
    {
        messageText.text = "";
        currentText = text;
        completedMessage = false;

        foreach (char letter in currentText.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
        }

        completedMessage = true;
    }

    public void CompleteDialogue()
    {
        if (!completedMessage)
        {
            if (typeTextCorroutine != null)
            {
                StopCoroutine(typeTextCorroutine);
            }
            messageText.text = currentText;
            completedMessage = true;
        }
    }

    public InputPackage GetInputPackage()
    {
        return inputPackage;
    }


    public void Movement(Vector2 movement)
    {
    }

    public void PressInteract()
    {
        if (!completedMessage)
            CompleteDialogue();
        else
            GameManager.Instance.stageManager.CloseDialogue();
    }

    public void ReleaseInteract()
    {
    }

    public void Cancel()
    {
        GameManager.Instance.stageManager.CloseDialogue();
    }

    public void PressStart()
    {
    }
}

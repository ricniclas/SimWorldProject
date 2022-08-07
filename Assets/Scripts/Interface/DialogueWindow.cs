using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float timeBetweenLetters = 0.5f;
    private Coroutine typeTextCorroutine;

    public void showDialogue(string text)
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

        foreach (char letter in text.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}

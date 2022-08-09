using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [Header("Buttons")]
    public Button pocketButton;
    public Button optionsButton;
    public Button creditsButton;
    public Button exitButton;


    [Header("Windows")]
    public GameObject pocketGameObject;
    public GameObject OptionsGameObject;
    public GameObject creditsGameObject;

    [Header("First Selecteds")]
    public GameObject optionsFirstButton;

    public void resetPauseScreen()
    {
        pocketGameObject.SetActive(true);
        OptionsGameObject.SetActive(false);
        creditsGameObject.SetActive(false);
    }

    public void deactivateAllScreens()
    {
        pocketGameObject.SetActive(false);
        OptionsGameObject.SetActive(false);
        creditsGameObject.SetActive(false);
    }

}

public enum ButtonType
{
    POCKET,
    OPTIONS,
    CREDITS,
    EXIT
}

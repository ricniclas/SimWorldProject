using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalControlsManager : MonoBehaviour, IDigitalController
{
    [SerializeField] private GameObject leftStick, faceButtons;
    public void activateControls()
    {
        leftStick.SetActive(true);
        faceButtons.SetActive(true);
    }

    public void deactivateControlls()
    {
        leftStick.SetActive(false);
        faceButtons.SetActive(false);
    }
}

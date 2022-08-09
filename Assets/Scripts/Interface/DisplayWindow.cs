using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWindow : MonoBehaviour, IInputReceiver
{

    public Button firstSelected;
    public PocketHandler pocketHandler;
    private InputPackage inputPackage => new InputPackage(Movement, PressInteract, ReleaseInteract,
        Cancel, PressStart);
    public void Cancel()
    {
        if (pocketHandler.isInShop)
        {
            GameManager.Instance.stageManager.DeactivateShopScreen();
        }
        else
        {
            GameManager.Instance.stageManager.TogglePause(false);
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
    }

    public void PressStart()
    {
        if (!pocketHandler.isInShop)
        {
            GameManager.Instance.stageManager.TogglePause(false);
        }
    }

    public void ReleaseInteract()
    {
    }
}

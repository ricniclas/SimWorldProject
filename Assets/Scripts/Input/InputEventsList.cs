using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEventsList : MonoBehaviour
{
    public MovementEvent movementEvent;
    public PressedInteractEvent pressedInteractEvent;
    public ReleasedInteractEvent releasedInteractEvent;
    public PressedCancelEvent pressedCancelEvent;
    public PressedStartEvent pressedStartEvent;

    private void cleanEvents()
    {
        movementEvent.RemoveAllListeners();
        pressedInteractEvent.RemoveAllListeners();
        releasedInteractEvent.RemoveAllListeners();
        pressedCancelEvent.RemoveAllListeners();
        pressedStartEvent.RemoveAllListeners();
    }

    private void addListeners(InputPackage inputPackage)
    {
        movementEvent.AddListener(inputPackage.GetMovementAction());
        pressedInteractEvent.AddListener(inputPackage.GetPressInteractAction());
        releasedInteractEvent.AddListener(inputPackage.GetReleaseInteractAction());
        pressedCancelEvent.AddListener(inputPackage.GetCancelAction());
        pressedStartEvent.AddListener(inputPackage.GetPressStartAction());
    }

    public void setNewControls(bool removeListeners,InputPackage inputPackage)
    {
        if (removeListeners)
            cleanEvents();
        addListeners(inputPackage);
    }
}

[System.Serializable]
public class MovementEvent : UnityEvent<Vector2> { }

[System.Serializable]
public class PressedInteractEvent : UnityEvent { }

[System.Serializable]
public class ReleasedInteractEvent : UnityEvent { }

[System.Serializable]
public class PressedCancelEvent : UnityEvent { }

[System.Serializable]
public class PressedStartEvent : UnityEvent { }
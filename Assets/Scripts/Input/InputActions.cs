using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{
    [SerializeField] private InputEventsList inputEventsList;

    public void replaceInputEvents(InputPackage inputPackage)
    {
        inputEventsList.setNewControls(true, inputPackage);
    }

    public void addInputEvents(InputPackage inputPackage)
    {
        inputEventsList.setNewControls(false, inputPackage);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        inputEventsList.movementEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if(context.started)
            inputEventsList.pressedInteractEvent?.Invoke();
        else if(context.canceled)
            inputEventsList.releasedInteractEvent?.Invoke();
    }

    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.started)
            inputEventsList.pressedCancelEvent?.Invoke();
    }

    public void StartButton(InputAction.CallbackContext context)
    {
        if (context.started)
            inputEventsList.pressedStartEvent?.Invoke();
    }
}

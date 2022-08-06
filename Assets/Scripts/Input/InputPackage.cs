using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InputPackage
{
    private UnityAction<Vector2> movementAction;

    private UnityAction pressInteractAction;

    private UnityAction releaseInteractAction;

    private UnityAction cancelAction;

    private UnityAction pressStartAction;

    public InputPackage(
        UnityAction<Vector2> movementAction,
        UnityAction pressInteractAction,
        UnityAction releaseInteractAction,
        UnityAction cancelAction,
        UnityAction pressStartAction)
    {
        this.movementAction = movementAction;
        this.pressInteractAction = pressInteractAction;
        this.releaseInteractAction = releaseInteractAction;
        this.cancelAction = cancelAction;
        this.pressStartAction = pressStartAction;
    }


    public UnityAction<Vector2> GetMovementAction()
    {
        return movementAction;
    }

    public UnityAction GetPressInteractAction()
    {
        return pressInteractAction;
    }

    public UnityAction GetReleaseInteractAction()
    {
        return releaseInteractAction;
    }

    public UnityAction GetCancelAction()
    {
        return cancelAction;
    }

    public UnityAction GetPressStartAction()
    {
        return pressStartAction;
    }
}

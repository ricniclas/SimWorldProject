using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputReceiver
{
    void Movement(Vector2 movement);
    void PressInteract();
    void ReleaseInteract();
    void Cancel();
    void PressStart();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour, IInputReceiver
{
    [SerializeField] private float speed = 5;
    private Rigidbody2D rigidBody2D;
    private Vector2 currentDirection;
    private InputPackage inputPackage => new InputPackage(Movement, PressInteract, ReleaseInteract,
            Cancel, PressStart);


    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.Instance.inputAction.addInputEvents(inputPackage);

    }

    private void Update()
    {
        rigidBody2D.velocity = currentDirection * speed;
    }

    public InputPackage getInputPackage()
    {
        return inputPackage;
    }

    public void Movement(Vector2 movement)
    {
        currentDirection = movement;
    }

    public void Cancel()
    {
        Debug.Log("Pressed Cancel");
    }

    public void PressInteract()
    {
        Debug.Log("Pressed Interact");
    }

    public void ReleaseInteract()
    {
        Debug.Log("Released Interact");
    }

    public void PressStart()
    {
        Debug.Log("Pressed Start");
    }
}

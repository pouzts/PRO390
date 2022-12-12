using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReassigner : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject prompt;

    private string controlScheme;
    private PlayerControls playerControls;

    private InputAction movementAction;
    private InputAction fireAction;

    private void Awake()
    {
        playerControls = new();
    }

    private void OnEnable()
    {
        movementAction = playerControls.Player.Movement;
        fireAction = playerControls.Player.Shoot;

        movementAction.Enable();
        fireAction.Enable();
    }

    private void OnDisable()
    {
        movementAction.Disable();
        fireAction.Disable();
    }

    private void Update()
    {
        
    }

    public void ReassignFire()
    {
        ReassignInput(fireAction, controlScheme, 0f);
    }

    private void ReassignInput(InputAction action, string controlScheme, float waitTime)
    {
        InputManager.ChangeBinding(action, controlScheme, _ => OnDone(action), waitTime);
    }

    private void OnDone(InputAction action)
    { 
        action.Dispose();
        button.SetActive(true);
    }
}

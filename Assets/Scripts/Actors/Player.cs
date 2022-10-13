using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ShipController))]
public class Player : MonoBehaviour, IDestructable
{
    private Vector3 movement = Vector3.zero;

    private ShipController shipController;

    private void Start()
    {
        shipController = GetComponent<ShipController>();
    }

    private void Update()
    {
        shipController.Move(movement);
    }

    public void DestroyObject()
    {
        throw new System.NotImplementedException();
    }

    // These methods are for input via the Input System
    private void OnMovement(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();

        movement.x = inputValue.x;
        movement.y = inputValue.y;
    }

    private void OnShoot()
    {
        
    }
}

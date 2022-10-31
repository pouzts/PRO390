using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ShipController))]
public class Player : MonoBehaviour, IDestructable
{
    [SerializeField] private Weapon weapon;

    private Vector2 movement = Vector2.zero;
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
        print("I am dead");
    }

    // These methods are for input via the Input System
    private void OnMovement(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        movement = inputValue;
    }

    private void OnShoot()
    {
        weapon.Shoot();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ShipController))]
public class Player : MonoBehaviour, IDestructable
{
    [SerializeField] private Weapon weapon;

    private ShipController shipController;
    private Vector2 movement = Vector2.zero;

    private Coroutine fireCoroutine;

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
    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        movement = inputValue;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            fireCoroutine = StartCoroutine(Shoot());
        }
        else
        {
            if (fireCoroutine != null)
                StopCoroutine(fireCoroutine);
        }
    }

    private IEnumerator Shoot()
    {
        if (AccessibilityManager.Instance.RapidFireMode)
        {
            while (true)
            {
                weapon.Shoot();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            weapon.Shoot();
            yield return null;
        }
    }
}

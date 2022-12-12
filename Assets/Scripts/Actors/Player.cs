using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ShipController))]
public class Player : MonoBehaviour, IDestructable
{
    [SerializeField] private GameObject deathPrefab;
    [SerializeField] private Weapon weapon;
    
    [SerializeField] private float fireRate = 0.2f;

    private ShipController shipController;
    private PlayerControls playerControls;

    private InputAction moveAction;
    private InputAction shootAction;

    private Coroutine fireCoroutine;

    private void Awake()
    {
        playerControls = new();
        shipController = GetComponent<ShipController>();
    }

    private void OnEnable()
    {
        moveAction = playerControls.Player.Movement;
        moveAction.Enable();

        shootAction = playerControls.Player.Shoot;
        shootAction.Enable();
        shootAction.started += OnShoot;
        shootAction.performed += OnShoot;
        shootAction.canceled += OnShoot;
    }

    private void OnDisable()
    {
        moveAction.Disable();

        shootAction.started -= OnShoot;
        shootAction.performed -= OnShoot;
        shootAction.canceled -= OnShoot;
        shootAction.Disable();
    }

    private void Update()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>();
        shipController.Move(movement);
    }

    public void DestroyObject()
    {
        StartCoroutine(OnDeath());
    }

    // These methods are for input via the Input System

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

    // Methods for coroutines
    private IEnumerator Shoot()
    {
        if (AccessibilityManager.Instance.RapidFireMode)
        {
            while (true)
            {
                weapon.Shoot();
                yield return new WaitForSeconds(fireRate);
            }
        }
        else
        {
            weapon.Shoot();
            yield return null;
        }
    }

    private IEnumerator OnDeath()
    {
        if (deathPrefab != null)
            Instantiate(deathPrefab, gameObject.transform);
        
        yield return new WaitForSeconds(5.0f);
        
        GameManager.Instance.GameState = GameState.PlayerDead;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ShipController))]
public class Player : MonoBehaviour, IDestructable
{
    [Header("Bullet Reference and Fields")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private int bulletLimit = 5;

    private float fireTime = 0;
    private Vector2 movement = Vector2.zero;
    
    private ShipController shipController;

    private void Start()
    {
        shipController = GetComponent<ShipController>();
    }

    private void Update()
    {
        fireTime -= Time.deltaTime;

        shipController.Move(movement);
    }

    public void DestroyObject()
    {
        
    }

    // These methods are for input via the Input System
    private void OnMovement(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();
        movement = inputValue;
    }

    private void OnShoot()
    {
        if (bulletPrefab != null && fireTime <= 0)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            
            var bullets = FindObjectsOfType<Bullet>().Where(x => CompareTag(x.bulletTag));

            if (bullets.Count() >= bulletLimit)
                fireTime = fireRate;
        }
    }
}

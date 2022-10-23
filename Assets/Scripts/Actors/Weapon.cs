using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Bullet Reference and Fields")]
    public Transform[] bulletSpawn;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 5f;

    private float fireTime = 0f;

    void Update()
    {
        fireTime -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (bulletPrefab != null && fireTime <= 0)
        {
            foreach (var b in bulletSpawn)
                Instantiate(bulletPrefab, b.position, b.rotation);

            fireTime = fireRate;
        }
    }
}

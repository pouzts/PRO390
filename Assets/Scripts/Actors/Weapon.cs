using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Bullet References")]
    public Transform[] bulletSpawn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource bulletSound;

    [Header("Bullet Fields")]
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
            bulletSound.Play();

            foreach (var b in bulletSpawn)
                Instantiate(bulletPrefab, b.position, b.rotation);

            fireTime = fireRate;
        }
    }
}

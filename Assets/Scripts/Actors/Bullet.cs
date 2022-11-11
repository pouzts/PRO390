using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDestructable
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private Space space;

    [SerializeField] private Vector3 direction = Vector3.zero;

    private float time = 0f;

    private void Start()
    {
        time = lifeTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        transform.Translate(bulletSpeed * Time.deltaTime * direction, space);

        if (time <= 0f)
            DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

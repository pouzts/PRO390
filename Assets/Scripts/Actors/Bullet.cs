using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDestructable
{
    public string bulletTag;

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private Space space;

    private float time = 0f;

    private void Start()
    {
        time = lifeTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward, space);

        if (time <= 0f)
            DestroyObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag(bulletTag))
            DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

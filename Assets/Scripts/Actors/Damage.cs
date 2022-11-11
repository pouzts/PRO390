using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damageDealt = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health health) && !other.gameObject.CompareTag(gameObject.tag))
            health.Damage(damageDealt);
    }
}

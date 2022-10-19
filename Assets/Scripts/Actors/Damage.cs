using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damageDealt = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
            health.Damage(damageDealt);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private bool destroyObject = true;
    [SerializeField] private bool destroyRoot = false;

    public float CurHealth { get; set; }
    private bool isDead = false;

    private void Start()
    {
        CurHealth = maxHealth;
    }

    public void Heal(float health)
    {
        CurHealth += health;

        if (CurHealth >= maxHealth)
            CurHealth = maxHealth;
    }

    public void Damage(float health)
    { 
        CurHealth -= health;

        if (!isDead && CurHealth <= 0f)
        { 
            CurHealth = 0f;
            isDead = true;

            if (TryGetComponent(out IDestructable destructable))
                destructable.DestroyObject();

            if (destroyObject) 
            {
                if (destroyRoot)
                    Destroy(gameObject.transform.root.gameObject);
                else
                    Destroy(gameObject);
            }
        }
    }
}

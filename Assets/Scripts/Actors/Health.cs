using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float invincableTime = 10f;

    [SerializeField] private bool destroyObject = true;
    [SerializeField] private bool destroyRoot = false;

    [SerializeField] private Collider invinCollider;

    public float CurHealth { get; set; }
    
    private bool isDead = false;
    private float timer = 0f;

    private void Start()
    {
        CurHealth = maxHealth;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {   
            if (invinCollider != null)
                invinCollider.enabled = true;
        }

        print(CurHealth);
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

            return;
        }

        timer = invincableTime;
        if (invinCollider != null)
            invinCollider.enabled = false;
    }
}

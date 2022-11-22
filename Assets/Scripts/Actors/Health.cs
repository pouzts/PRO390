using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float invincableTime = 10f;

    [SerializeField] private bool destroyObject = true;
    [SerializeField] private bool destroyRoot = false;

    [SerializeField] private Collider invinCollider;
    [SerializeField] private Slider healthBar;

    public float CurHealth { get; set; }
    
    private bool isDead = false;
    private float timer = 0f;

    private void Start()
    {
        CurHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = CurHealth;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {   
            if (invinCollider != null)
                invinCollider.enabled = true;
        }
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

        if (healthBar != null)
            healthBar.value = CurHealth;

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

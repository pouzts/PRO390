using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] private Sprite defaultCrosshair;
    [SerializeField] private Sprite targetCrosshair;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float targetDistance = 10f;

    [SerializeField] private SpriteRenderer spriteRenderer1;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer1.sprite = defaultCrosshair;
        spriteRenderer2.sprite = defaultCrosshair;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, targetDistance, targetLayer))
        {
            spriteRenderer1.enabled = false;
            spriteRenderer2.sprite = targetCrosshair;
            if (audioSource != null)
                audioSource.Play();
        }
        else
        {
            spriteRenderer1.enabled = true;
            spriteRenderer2.sprite = defaultCrosshair;
        }
    }
}

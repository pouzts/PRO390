using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] private Sprite defaultCrosshair;
    [SerializeField] private Sprite targetCrosshair;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float targetDistance = 10f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultCrosshair;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, targetDistance, targetLayer))
            spriteRenderer.sprite = targetCrosshair;
        else
            spriteRenderer.sprite = defaultCrosshair;
    }
}

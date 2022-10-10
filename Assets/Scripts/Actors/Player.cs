using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDestructable
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float shipSpeed = 30f;

    [SerializeField] private Vector2 frameOffset;

    [SerializeField] private Transform aimObject;
    [SerializeField] private Transform playerObject;

    private Vector3 movement = Vector3.zero;

    private void Start()
    {
    }

    private void Update()
    {
        Move(speed * Time.deltaTime * movement);
    }

    public void DestroyObject()
    {
        throw new System.NotImplementedException();
    }

    private void Move(Vector3 movement)
    {
        aimObject.position += movement;
        KeepInFrame(aimObject);
        playerObject.LookAt(aimObject);
        MoveTowardsObjectXY(playerObject, aimObject);
        KeepInFrame(playerObject);
    }

    private void KeepInFrame(Transform transform)
    { 
        Vector3 framePosition = Camera.main.WorldToViewportPoint(transform.position);
        framePosition.x = Mathf.Clamp01(framePosition.x);
        framePosition.y = Mathf.Clamp01(framePosition.y);
        transform.position = Camera.main.ViewportToWorldPoint(framePosition);
    }

    private void MoveTowardsObjectXY(Transform obj, Transform target)
    { 
        Vector2 targetPos = target.position;
        obj.position = Vector2.MoveTowards(obj.position, targetPos, shipSpeed * Time.deltaTime);
    }

    private void OnMovement(InputValue value)
    {
        Vector2 inputValue = value.Get<Vector2>();

        movement.x = inputValue.x;
        movement.y = inputValue.y;
    }
}

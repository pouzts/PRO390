using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private SpaceCharacterController s_controller;

    [SerializeField]
    private float speed = 10f;

    private Vector3 movement = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        s_controller.Move(movement * speed);
    }
}

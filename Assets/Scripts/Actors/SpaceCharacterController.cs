using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SpaceCharacterController : MonoBehaviour, IDestructable
{
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }

    public void Move(Vector3 motion)
    {
        controller.Move(motion * Time.deltaTime);
    }

    public void DestroyObject()
    {
        throw new System.NotImplementedException();
    }
}

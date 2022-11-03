using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateAgent, IDestructable
{
    [SerializeField] RefValue<int> test;

    protected override void OnStart()
    {
        
    }

    protected override void OnUpdate()
    {
        
    }

    public void DestroyObject()
    {
        //throw new System.NotImplementedException();
    }
}

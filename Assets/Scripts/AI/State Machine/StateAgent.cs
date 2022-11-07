using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateAgent : MonoBehaviour
{
    public GameObject Target { get; set; }

    protected StateMachine stateMachine = new();

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        stateMachine.Update();
        OnUpdate();
    }

    protected abstract void OnStart();
    protected abstract void OnUpdate();
}

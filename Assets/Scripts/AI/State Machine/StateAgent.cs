using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateAgent : MonoBehaviour
{
    public Movement movement;

    public GameObject Target { get; set; }

    public RefValue<bool> HasSpawned { get; set; } = new RefValue<bool>();
    public RefValue<float> Timer { get; set; } = new RefValue<float>();
    public RefValue<float> TargetDistance { get; set; } = new RefValue<float>();

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

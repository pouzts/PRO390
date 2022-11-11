using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : State
{
    public SpawnState(StateAgent agent, string name) : base(agent, name)
    {
    }

    public override void OnEnter()
    {
        Agent.TargetDistance.value = (Agent.Target != null) ? Vector3.Distance(Agent.transform.position, Agent.Target.transform.position) : float.MinValue;
        Agent.HasSpawned.value = true;
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}

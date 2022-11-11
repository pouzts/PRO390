using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnState : State
{
    public DespawnState(StateAgent agent, string name) : base(agent, name)
    {
    }

    public override void OnEnter()
    {
        Object.Destroy(Agent.gameObject);
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}

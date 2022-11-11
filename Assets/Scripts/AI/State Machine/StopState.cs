using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopState : State
{
    public StopState(StateAgent agent, string name) : base(agent, name)
    {
    }

    public override void OnEnter()
    {
        Agent.movement.Stop();
        Agent.Timer.value = 2f;
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
    }
}

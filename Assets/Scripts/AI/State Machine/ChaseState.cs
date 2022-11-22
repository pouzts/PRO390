using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(StateAgent agent, string name) : base(agent, name) { }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        
        if (Agent.Target != null)
            Agent.movement.MoveTowards(Agent.Target.transform.position);

        if (Agent.TryGetComponent(out Weapon weapon))
            weapon.Shoot();
    }
}

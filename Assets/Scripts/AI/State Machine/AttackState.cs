using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(string name, StateAgent agent) : base(name, agent) { }

    private Weapon weapon;

    public override void OnEnter()
    {
        weapon = GetComponent<Weapon>();
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        if (weapon != null)
            weapon.Shoot();
    }
}

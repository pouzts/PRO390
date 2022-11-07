using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateAgent, IDestructable
{
    [SerializeField] private Weapon weapon;

    protected override void OnStart()
    {
        Target = FindObjectOfType<Player>().gameObject;

        stateMachine.AddState(new SpawnState(this, typeof(SpawnState).Name));
        stateMachine.AddState(new ChaseState(this, typeof(ChaseState).Name));
        stateMachine.AddState(new FleeState(this, typeof(FleeState).Name));
        stateMachine.AddState(new DespawnState(this, typeof(DespawnState).Name));
        stateMachine.AddState(new DeathState(this, typeof(DeathState).Name));

        stateMachine.SetState(stateMachine.GetState(typeof(SpawnState).Name));
    }

    protected override void OnUpdate()
    {
        weapon.Shoot();
    }

    public void DestroyObject()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateAgent, IDestructable
{
    [SerializeField] public RefValue<bool> hasStopped = new();
    protected override void OnStart()
    {
        Target = FindObjectOfType<Player>().gameObject;

        stateMachine.AddState(new SpawnState(this, typeof(SpawnState).Name));
        stateMachine.AddState(new ChaseState(this, typeof(ChaseState).Name));
        stateMachine.AddState(new StopState(this, typeof(StopState).Name)); 
        stateMachine.AddState(new DespawnState(this, typeof(DespawnState).Name));

        stateMachine.AddTransition(typeof(SpawnState).Name, new Transition(new BoolCondition(HasSpawned, true)), typeof(ChaseState).Name);
        stateMachine.AddTransition(typeof(ChaseState).Name, new Transition(new BoolCondition(hasStopped, true)), typeof(StopState).Name);
        stateMachine.AddTransition(typeof(StopState).Name, new Transition(new FloatCondition(Timer, Condition.Predicate.LessOrEqual, 0f)), typeof(DespawnState).Name);

        stateMachine.SetState(stateMachine.GetState(typeof(SpawnState).Name));
    }

    protected override void OnUpdate()
    {
        Timer.value -= Time.deltaTime;
    }

    public void DestroyObject()
    {
        
    }
}

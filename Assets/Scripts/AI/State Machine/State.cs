using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public StateAgent Agent { get; private set; }
    public string Name { get; private set; }

    public State(StateAgent agent, string name)
    { 
        Agent = agent;
        Name = name;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}

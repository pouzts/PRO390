using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateAgent Agent { get; private set; }
    public string Name { get; private set; }

    public State(string name, StateAgent agent)
    { 
        Name = name;
        Agent = agent;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}

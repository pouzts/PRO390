using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    // create a private dictionary that holds a state and a
    // list that has a key value pair of transitions and states
    private readonly Dictionary<State, List<KeyValuePair<Transition, State>>> stateTransitions = new Dictionary<State, List<KeyValuePair<Transition, State>>>(); 

    // create a private state that holds the current state
    private State curState;

    public void Update()
    {
        // if the current state is null, return
        if (curState == null)
            return;

        // check all transitions of the current state
        var transitions = stateTransitions[curState];
        foreach (var transition in transitions)
        {
            // if we can transition
            if (transition.Key.ToTransition())
            {
                // set the state and return
                SetState(transition.Value);
                return;
            }
        }

        // update the current state
        curState.OnUpdate();
    }

    public void SetState(State state)
    {
        // if the current state is state or state is null, return
        if (curState == state || state == null)
            return;

        // exit out of the state if it exists
        curState?.OnExit();
        // set the state to the current state
        curState = state;
        // enter the current state
        curState.OnEnter();
    }

    public void AddState(State state)
    {
        // check if the dictionary does not contain state
        if (!stateTransitions.ContainsKey(state))
            // set the value to a new list of transition and state
            stateTransitions[state] = new List<KeyValuePair<Transition, State>>();
    }

    public void AddTransition(State stateFrom, Transition transition, State stateTo) 
    {
        // check if the dictionary contain a key of state from 
        if (stateTransitions.ContainsKey(stateFrom))
        {
            // get the list of key-value pairs from the state from
            var transitions = stateTransitions[stateFrom];
            // add the transition and state to key value pair to the list
            transitions.Add(new KeyValuePair<Transition, State>(transition, stateTo));
        }
    }

    public void AddTransition(string stateFrom, Transition transition, string stateTo)
    {
        // check if the dictionary contain a key of state from string
        if (stateTransitions.ContainsKey(GetState(stateFrom)))
        {
            // get the list of key-value pairs from the state from
            var transitions = stateTransitions[GetState(stateFrom)];
            // add the transition and state to key value pair to the list
            transitions.Add(new KeyValuePair<Transition, State>(transition, GetState(stateTo)));
        }
    }

    public State GetState(string name)
    {
        // iterate through all states
        foreach (var state in stateTransitions)
        {
            // check if the key is equal to the state
            if (string.Equals(state.Key.Name, name, System.StringComparison.OrdinalIgnoreCase))
                // return key
                return state.Key;
        }

        // return null
        return null;
    }

    public string GetStateName()
    { 
        return curState?.Name;
    }
}

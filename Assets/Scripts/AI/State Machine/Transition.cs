using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    private readonly Condition[] conditions;

    public Transition(params Condition[] conditions)
    {
        this.conditions = conditions;
    }

    public bool ToTransition()
    {
        foreach (var condition in conditions)
        {
            if (!condition.IsTrue())
                return false;
        }

        return true;
    }
}

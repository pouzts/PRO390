using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition
{
    public enum Predicate
    {
        Less,
        LessOrEqual,
        Equals,
        NotEquals,
        Greater,
        GreaterOrEqual,
    }

    public abstract bool IsTrue();
}

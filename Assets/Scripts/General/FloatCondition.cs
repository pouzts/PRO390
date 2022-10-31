using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCondition : Condition
{
    private readonly RefValue<float> left;
    private readonly Predicate predicate;
    private readonly float right;

    public FloatCondition(RefValue<float> left, Predicate predicate, float right)
    { 
        this.left = left;
        this.predicate = predicate;
        this.right = right;
    }

    public override bool IsTrue()
    {
        bool result = false;

        switch (predicate)
        {
            case Predicate.Less:
                result = left.Value < right;
                break;
            case Predicate.LessOrEqual:
                result = left.Value <= right;
                break;
            case Predicate.Equals:
                result = left.Value == right;
                break;
            case Predicate.NotEquals:
                result = left.Value != right;
                break;
            case Predicate.Greater:
                result = left.Value > right;
                break;
            case Predicate.GreaterOrEqual:
                result = left.Value >= right;
                break;
            default:
                break;
        }

        return result;
    }
}

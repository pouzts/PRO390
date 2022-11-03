using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntCondition : Condition
{
    private readonly RefValue<int> left;
    private readonly Predicate predicate;
    private readonly int right;

    public IntCondition(RefValue<int> left, Predicate predicate, int right)
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
                result = left.value < right;
                break;
            case Predicate.LessOrEqual:
                result = left.value <= right;
                break;
            case Predicate.Equals:
                result = left.value == right;
                break;
            case Predicate.NotEquals:
                result = left.value != right;
                break;
            case Predicate.Greater:
                result = left.value > right;
                break;
            case Predicate.GreaterOrEqual:
                result = left.value >= right;
                break;
            default:
                break;
        }

        return result;
    }
}

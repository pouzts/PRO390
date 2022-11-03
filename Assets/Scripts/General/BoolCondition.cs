using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCondition : Condition
{
    private readonly RefValue<bool> left;
    private readonly bool right;

    public BoolCondition(RefValue<bool> left, bool right)
    {
        this.left = left;
        this.right = right;
    }

    public override bool IsTrue()
    {
        return left.value == right;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static float ClampAngle(float angle, float min, float max) {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
} 

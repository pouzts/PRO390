using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector3 Clamp(Vector3 vector, Vector3 min, Vector3 max)
    {
        Vector3 result = Vector3.zero;

        result.x = Mathf.Clamp(vector.x, min.x, max.x);
        result.y = Mathf.Clamp(vector.y, min.y, max.y);
        result.z = Mathf.Clamp(vector.z, min.z, max.z);

        return result;
    }

    public static Vector2 Clamp(Vector2 vector, Vector2 min, Vector2 max)
    {
        Vector2 result = Vector3.zero;

        result.x = Mathf.Clamp(vector.x, min.x, max.x);
        result.y = Mathf.Clamp(vector.y, min.y, max.y);

        return result;
    }
} 

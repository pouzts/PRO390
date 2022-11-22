using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RefValue<T> where T : struct
{
    public T value;

    public static implicit operator T(RefValue<T> refValue) { return refValue.value; }
}

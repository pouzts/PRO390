using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AccessibilityManager : Singleton<AccessibilityManager>
{
    public bool ColorBlindMode { get; set; } = false;
    public bool HighContrastMode { get; set; } = false;
    public bool RapidFireMode {get; set;} = false;
}

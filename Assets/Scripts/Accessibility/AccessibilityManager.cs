using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class AccessibilityManager : Singleton<AccessibilityManager>
{
    // Visiblity Modes
    public bool ColorBlindMode { get; set; } = false;
    public bool HighContrastMode { get; set; } = false;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevAccessibilityControl : MonoBehaviour
{
    public void OnColorBlindMode()
    {
        AccessibilityManager.Instance.ColorBlindMode = !AccessibilityManager.Instance.ColorBlindMode;
    }

    public void OnHiContrastMode()
    {
        AccessibilityManager.Instance.HighContrastMode = !AccessibilityManager.Instance.HighContrastMode;
    }

    public void OnRapidFireMode()
    { 
        AccessibilityManager.Instance.RapidFireMode = !AccessibilityManager.Instance.RapidFireMode;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DevAccessibilityControl : MonoBehaviour
{
    private PlayerControls playerControls;

    private InputAction colorBlindAction;
    private InputAction hiContrastAction;
    private InputAction rapidFireAction;

    private void Awake()
    {
        playerControls = new();
    }

    private void OnEnable()
    {
        colorBlindAction = playerControls.DevShortcuts.ColorBlindMode;
        hiContrastAction = playerControls.DevShortcuts.HiContrastMode;
        rapidFireAction = playerControls.DevShortcuts.RapidFireMode;
    
        colorBlindAction.Enable();
        hiContrastAction.Enable();
        rapidFireAction.Enable();

        colorBlindAction.performed += OnColorBlindMode;
        hiContrastAction.performed += OnHiContrastMode;
        rapidFireAction.performed += OnRapidFireMode;
    }

    private void OnDisable()
    {
        colorBlindAction.performed -= OnColorBlindMode;
        hiContrastAction.performed -= OnHiContrastMode;
        rapidFireAction.performed -= OnRapidFireMode;
    
        colorBlindAction.Disable();
        hiContrastAction.Disable();
        rapidFireAction.Disable();
    }

    public void OnColorBlindMode(InputAction.CallbackContext context)
    {
        AccessibilityManager.Instance.ColorBlindMode = !AccessibilityManager.Instance.ColorBlindMode;
    }

    public void OnHiContrastMode(InputAction.CallbackContext context)
    {
        AccessibilityManager.Instance.HighContrastMode = !AccessibilityManager.Instance.HighContrastMode;
    }

    public void OnRapidFireMode(InputAction.CallbackContext context)
    { 
        AccessibilityManager.Instance.RapidFireMode = !AccessibilityManager.Instance.RapidFireMode;
    }
}

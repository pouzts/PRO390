using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    // ChangeBinding(actionRef, controlType, waitTime)
    public static void ChangeBinding(InputActionReference actionRef, string controlType, System.Action<InputActionRebindingExtensions.RebindingOperation> complete, float waitTime = 0f)
    {
        // start interactive rebinding with the controlType and waitTime
        actionRef.action.PerformInteractiveRebinding()
            .WithExpectedControlType(controlType)
            .OnMatchWaitForAnother(waitTime)
            .OnComplete(complete).Start();
    }

    // ChangeBinding(action, controlType, waitTime)
    public static void ChangeBinding(InputAction action, string controlType, System.Action<InputActionRebindingExtensions.RebindingOperation> complete, float waitTime = 0f)
    {
        // start interactive rebinding with the controlType and waitTime
        action.PerformInteractiveRebinding()
            .WithExpectedControlType(controlType)
            .OnMatchWaitForAnother(waitTime)
            .OnComplete(complete).Start();
    }

    public static string GetBindingString(InputAction action, InputBinding.DisplayStringOptions option = 0, string group = null)
    {
        return action.GetBindingDisplayString(option, group);
    }
}

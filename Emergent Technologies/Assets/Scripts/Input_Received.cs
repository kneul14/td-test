using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Input_Received : MonoBehaviour
{
    public bool right_activate = false;
    public bool left_activate = false;

    public void OnActivate(InputAction.CallbackContext ctx)
    {
        string name = ctx.action.activeControl.ToString();

        if (name.Contains("Left"))
        {
            left_activate = ctx.ReadValue<float>() == 1;
        }

        if (name.Contains("Right"))
        {
            right_activate = ctx.ReadValue<float>() == 1;
        }
    }
}

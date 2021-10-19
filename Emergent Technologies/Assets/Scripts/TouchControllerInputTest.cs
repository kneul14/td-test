using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class TouchControllerInputTest : MonoBehaviour
{
    public InputActionReference triggerAmount;
    public ActionBasedController leftController;
    void Start()
    {
        triggerAmount.action.performed += TriggerPressedDown;
        triggerAmount.action.canceled += TriggerPressedDown;
    }
    void TriggerPressedDown(InputAction.CallbackContext context)
    {
        float triggerValue = context.ReadValue<float>();
        Debug.Log("Left trigger value: " + triggerValue);
        if (triggerValue > 0.5f)
            leftController.SendHapticImpulse(0.5f, 0.1f);
    }
}

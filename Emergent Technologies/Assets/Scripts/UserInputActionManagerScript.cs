using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UserInputActionManagerScript : MonoBehaviour
{
    public Renderer cubeRend;
    public InputActionProperty testProp; //will **InputActionProperty** need to be changed if not working

    public bool triggerPressed;

    public GameObject rightController;
    public GameObject leftController;

    //public GameObject node;
    
    
    void Awake()
    {
        testProp.action.started += OnTrigger; //will need to be changed if not working
    }


    void OnTrigger(InputAction.CallbackContext context) //will need to be changed if not working
    {
        Debug.Log("Trigger pulled");
        GetComponent<Renderer>().material.color = new Color(255, 255, 255); //C sharp
        triggerPressed = context.ReadValue<float>() == 1f;
    }    

    void Update()
    {
        if (triggerPressed == true)
        {
            Vector3 posOfLeft = leftController.transform.position;
            var screenPos = Camera.main.ScreenPointToRay(posOfLeft);
            Debug.DrawRay(screenPos.origin, screenPos.direction, Color.green);
            RaycastHit rh;
            if(Physics.Raycast(screenPos, out rh))
            {
                if(rh.collider != null && rh.collider.tag == "Node")
                {
                    Vector3 pointOfHit = rh.point;
                    GameObject hitObject = rh.collider.gameObject;
                    var r = hitObject.GetComponent<Renderer>();
                    if (r.material.HasProperty("_Color"))
                    {
                        r.material.SetColor("_Color", Color.red);
                    }
                }
            }
            triggerPressed = false;
        }


    }
}

//Change some things if the HTC Vive doesnt work with these controlls Inputs can be started with menu systems now 
//dont forget to drag the input maps/ select the input map in the inspector under the Player under the Main character.s

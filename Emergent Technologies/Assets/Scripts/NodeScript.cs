using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public Color mouseInteractColor;

    public Renderer render;
    private Color startColour;


    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        startColour = render.material.color;
    }

    // Update is called once per frameS
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        Debug.Log("hello");
        render.material.color = mouseInteractColor;
    }

    void OnMouseExit()
    {
        render.material.color = startColour;
    }
}

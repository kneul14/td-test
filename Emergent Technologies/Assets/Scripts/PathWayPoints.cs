using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWayPoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        //Counts the children and creates that many children in the array and then loops through them
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

    }
}


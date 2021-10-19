using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManagementScript : MonoBehaviour
{

    public GameObject policeManOne, policeManTwo, policeManThree;
        

    public enum TurretType { policeMan1, policeMan2, policeMan3 }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePrimitive(TurretType turret)
    {
        switch (turret)
        {
            case TurretType.policeMan1:
                GameObject policeManOne = GameObject.FindGameObjectWithTag("PoliceStage1");
                policeManOne.transform.position = Vector3.zero;
                break;
            case TurretType.policeMan2:
                GameObject policeManTwo = GameObject.FindGameObjectWithTag("PoliceStage2");
                policeManTwo.transform.position = Vector3.zero;
                break;
            case TurretType.policeMan3:
                GameObject policeManThree = GameObject.FindGameObjectWithTag("PoliceStage3");
                policeManThree.transform.position = Vector3.zero;
                break;
            default:
                Debug.Log("not recognised");
                break;
        }
    }

}


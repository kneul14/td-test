using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed = 10f;

    private Transform target;
    private int wavePointIndex = 0;
    public int playerHealth = 3;
    public int zombieHealth = 5;

    

    private void Start()
    {
        target = PathWayPoints.points[0];

    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPathWayPoint();
        }
        
    }

    public void FixedUpdate()
    {
        //PlayerHealth();
    }

    void GetNextPathWayPoint() //cycles through the PathWayPoints in the world 
    {
        if (wavePointIndex >= PathWayPoints.points.Length - 1) //If the enemy reaches the end pont then the Gameobject gets destroyed.
        {                  
            Destroy(gameObject);           

            return;
        }

        wavePointIndex++;
        target = PathWayPoints.points[wavePointIndex];
    }
   

}

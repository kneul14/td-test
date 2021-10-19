using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManScript : MonoBehaviour
{
    private Transform target;

    [Header("Gun properties")]
    public float rangeofturret = 3f;
    public float bulletRate = 1f;
    private float bulletRateCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform pointOfFire;

    public Transform policePositionRotator;

    public string zombieTag = "Enemy";



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //few times a second
    }

    void UpdateTarget()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag(zombieTag);
        float smallestDistance = Mathf.Infinity;
        GameObject closestZombie = null;
                

        foreach (GameObject zombie in zombies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, zombie.transform.position);
            if (distanceToEnemy < smallestDistance) //finds realtime closest enemy to the turret
            {
                smallestDistance = distanceToEnemy;
                closestZombie = zombie;
            }
        }

        if (closestZombie != null && smallestDistance <= rangeofturret) //if there is a zombie close and within range of the police the zombie becomes a target.
        {
            target = closestZombie.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) //nO TARGET? Do nothing!!
        {
            return;
        }

        //now to actually rotate the policemen to rotate with the direction of the movement of the enemies

        Vector3 dir = target.position - transform.position;
        Quaternion lockOn = Quaternion.LookRotation(dir); //refers to the rotation
        Vector3 rotationOfPoliceMan = lockOn.eulerAngles;
        policePositionRotator.rotation = Quaternion.Euler(0f, rotationOfPoliceMan.y, 0f);

        /*policePositionRotator.rotation = rotationOfPoliceMan;*/

        if(bulletRateCountDown <= 0f)
        {
            ShootBullets();
            bulletRateCountDown = 1f / bulletRate;            
        }

        bulletRateCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected() //makes it so I can visually see the turret's/policeman's range.
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeofturret);
    }

    void ShootBullets()
    {
        Debug.Log("PEWPEW");
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, pointOfFire.position, pointOfFire.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.FindEnemy(target);
        }
    }
}

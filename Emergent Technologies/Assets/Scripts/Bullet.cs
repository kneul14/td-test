using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 20f;
    //public EnemyScript enemyScript;
    //public int zombieHealth;
    
    public void FindEnemy(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceInThisFrame = bulletSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceInThisFrame)
        {
            HitTarget();
            return;
        }
        

        transform.Translate(dir.normalized * distanceInThisFrame, Space.World); //we want it to be moving at a constant speed
    }

    void HitTarget()
    {
        Debug.Log("PEW PEW HIT");
        Destroy(target.gameObject);
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShootingEnemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public float LineofSite;   
  
    
    public float shootingRange;
    public GameObject bullet;

    private float fireRate;
    private float nextFire;


    void Start()
    {
            fireRate = 1f;
            nextFire = Time.time;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    float distanceFromPlayer = Vector2.Distance(player.position, transform.position); 
    if (distanceFromPlayer < LineofSite && distanceFromPlayer >= shootingRange) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            CheckIfTimeToFire();
       } 
        else if (distanceFromPlayer <= shootingRange)
        {
            CheckIfTimeToFire();
        }
        
    }


    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            GameObject tempObject = BPS.instance.GetPooledObject("EBullet");
            //tempObject.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position, Quaternion.identity);

            nextFire = Time.time + fireRate;
        }
    }

    private void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, LineofSite);
      
    }
}

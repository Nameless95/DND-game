using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform player;
   
    private float distToPlayer;
    public float speed; 
    public Patrol StopMoving;
    public float damage; 
   private float fireRate;
    private float nextFire;

    public float shootingRange;
    public GameObject EnemyBullet;
    
    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time; 
    }

    private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position); ///calculates the two game objects (player and enemy) 
        if ((player.transform.position - this.transform.position).sqrMagnitude < 6 * 6 && distToPlayer > shootingRange)
        {
            CheckIfTimeToFire(); 
            StopMoving.speed = 0;  //makes the enemy stop moving 

        }
        else
        {
            StopMoving.speed = speed;  //sets speed back to normal 
            transform.Translate(Vector2.right * StopMoving.speed * 1 * Time.deltaTime);
        }



    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            GameObject tempObject = BPS.instance.GetPooledObject("EBullet");
            tempObject.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position, Quaternion.identity);
            
            nextFire = Time.time + fireRate; 
        }
    }


}



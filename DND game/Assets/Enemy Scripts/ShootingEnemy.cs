using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform player;
   
   
    public float speed; 
    public Patrol StopMoving;
    public float damage; 
   private float fireRate;
    private float nextFire;
    

    public float shootingRange;
    public GameObject bullet;
    public int BulletType;

    [SerializeField]
    private Vector2 offset; 
    [HideInInspector]
    public bool IsShooting;


    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time; 
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       
        if ((distanceFromPlayer < shootingRange))
        {
            CheckIfTimeToFire(); 
            StopMoving.speed = 0;  //makes the enemy stop moving 
          //  Debug.Log("Shoot"); 

        }
        else if (distanceFromPlayer > shootingRange)
        {
            //Debug.Log(StopMoving);
            StopMoving.speed = speed;  //sets speed back to normal 
            transform.Translate(Vector2.right * StopMoving.speed * 1 * Time.deltaTime);
            IsShooting = false;

        }
      



    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            switch (BulletType) { //this switch statement is made in order to make sure that the right bullet is being used by the BPS 
                case 1: 
                    GameObject tempObject = BPS.instance.GetPooledObject("EBullet");
                    tempObject.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position + offset, Quaternion.identity);
              break;
                case 2:
                    GameObject tempObject2 = BPS.instance.GetPooledObject("BookBullet");
                    tempObject2.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position + offset, Quaternion.identity);
              break;
            } 

            nextFire = Time.time + fireRate;
            IsShooting = true;
        }
    }

   

}



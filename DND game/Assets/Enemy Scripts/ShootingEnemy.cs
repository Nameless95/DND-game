using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    // public Transform player;

    private GameObject player; 
   
    public float speed; 
    public Patrol StopMoving;
    public float damage; 
   private float fireRate;
    private float nextFire;
    

  
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
        player = GameObject.Find("Player");
    }

    private void Update()
    {

        if ((player.transform.position - this.transform.position).sqrMagnitude < 8 * 8)
        {
            CheckIfTimeToFire();
            StopMoving.speed = 0;  
        }
        else
        {
            StopMoving.speed = speed;  //sets speed back to normal 
            transform.Translate(Vector2.right * StopMoving.speed * 1 * Time.deltaTime);
            IsShooting = false;
        }
       



    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            switch (BulletType)
            { //this switch statement is made in order to make sure that the right bullet is being used by the BPS 
                case 1:
                    GameObject tempObject = BPS.instance.GetPooledObject("EBullet");
                    tempObject.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position + offset, Quaternion.identity);
                    break;
                case 2:
                    GameObject tempObject2 = BPS.instance.GetPooledObject("BookBullet");
                    tempObject2.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position + offset, Quaternion.identity);
                    break;
                case 3:
                    GameObject tempObject3 = BPS.instance.GetPooledObject("LightingBullet");
                    tempObject3.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position + offset, Quaternion.identity);
                    break;
            }

            nextFire = Time.time + fireRate;
            IsShooting = true;
        }
    }




}



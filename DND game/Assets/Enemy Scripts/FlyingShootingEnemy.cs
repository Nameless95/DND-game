﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FlyingShootingEnemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public float LineofSite;   
  
    
    public float shootingRange;
    public GameObject bullet;

    public float fireRate;
    private float nextFire;
    public float BulletType; 
    [HideInInspector]
    public bool IsShooting;

    [SerializeField]
    private Vector2 offset; 

    void Start()
    {
           // fireRate = 1f;
            nextFire = Time.time;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    float distanceFromPlayer = Vector2.Distance(player.position, transform.position); 
    if (distanceFromPlayer < LineofSite && distanceFromPlayer >= shootingRange) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            CheckIfTimeToFire();
        } 
    else if (distanceFromPlayer <= shootingRange)
        {
            CheckIfTimeToFire();
        }
    else
        {
            IsShooting = false; 
        }
    
        
    }


    public void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Vector2 direction = player.position - transform.position;
            Quaternion Rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.down, direction * 5f));
          

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
                        tempObject3.GetComponent<EnemyBullet>().WakeUp((Vector2)transform.position + offset, Rotation);
                    break;
            }

            nextFire = Time.time + fireRate * (1/2f);
            IsShooting = true; 
           
        }
   


    }

    
}

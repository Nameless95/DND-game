using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private GameObject player;
    public Patrol PatrolScript;
    [HideInInspector]
    public bool IsAttacking;

    public AudioClip attackSound;
    public AudioSource triggerSource;
    public AudioSource idleSource;

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {

        if ((player.transform.position - this.transform.position).sqrMagnitude < 7 * 7)
        {
            idleSource.Stop();

            if (!triggerSource.isPlaying)
            {
                triggerSource.Play();
            }

            transform.Translate(Vector2.right * PatrolScript.speed * 3 * Time.deltaTime * PatrolScript.distance);
            IsAttacking = true; 
        }
        else
        {
            if (!idleSource.isPlaying)
            {
                idleSource.Play();
            }

            IsAttacking = false; 
        }
        
    }
}

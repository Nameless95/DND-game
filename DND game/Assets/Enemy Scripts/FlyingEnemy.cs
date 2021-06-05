using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;

    public float playerRange;
    public LayerMask playerLayer;
    public bool playerInRange;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer); 
        
        
        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            //the enemy moves toward the player 
        } 
    }
    private void OnDrawGizmoSelected()
    {
        Gizmos.DrawWireSphere(transform.position, playerRange); 
        
    }
}

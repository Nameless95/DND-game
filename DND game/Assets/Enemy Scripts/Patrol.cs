using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;
    //public Transform player; 

    private bool movingRight = true;
   // private bool FoundPlayer = false;
    public Transform groundDetection;
    
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }



void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, LayerMask.GetMask("Platform"));
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                movingRight = true;
            }
           
          

        }
        this.spriteRenderer.flipX = playerCharacter.transform.position.x < this.transform.position.x; //this will flip the sprite towards the player 

    }
}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;


    private bool movingRight = true;
   // private bool FoundPlayer = false;
    public Transform groundDetection;

 

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
      
    }
}






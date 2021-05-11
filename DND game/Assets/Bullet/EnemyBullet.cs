using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 5f;
    Rigidbody2D rb;

    private GameObject player;

    Vector2 moveDirection;

        

  
   public void WakeUp(Vector2 location, Quaternion direction) //BPS 
    {
        transform.position = location;
        transform.rotation = direction; 
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x * 3, moveDirection.y * 3);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Bullet")) 
        {
            gameObject.SetActive(false);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //make a line here to make sure the player takes damage 

            // collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);

        }
        Debug.Log("Help!" + collision.gameObject.tag+collision.gameObject.name);
    }
}

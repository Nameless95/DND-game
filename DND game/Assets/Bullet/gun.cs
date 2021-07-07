using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    Rigidbody2D rb;
    public int damage; 
    private void Awake(){
        rb = this.GetComponent<Rigidbody2D>();
    }


    public void WakeUp(Vector2 location, Vector2 direction, int BulletDam){
        transform.position = location;
        transform.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.right, direction));
        gameObject.SetActive(true);
        damage = BulletDam; 
    }

    void Update(){  //makes the bullet go in the straight line (speeds too) 
        rb.velocity = transform.right * -10;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("EBullet") || collision.gameObject.CompareTag("BookBullet")
            || collision.gameObject.CompareTag("LightingBullet"))
        {
            gameObject.SetActive(false);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
                gameObject.SetActive(false);
              
               collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);

        }

       }
}

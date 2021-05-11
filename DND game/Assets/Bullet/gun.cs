using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake(){
        rb = this.GetComponent<Rigidbody2D>();
    }


    public void WakeUp(Vector2 location, Vector2 direction){
        transform.position = location;
        transform.rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.right, direction));
        gameObject.SetActive(true);
    }

    void Update(){
        rb.velocity = transform.right * -10;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Floor"){
            gameObject.SetActive(false);
        }
    }
}

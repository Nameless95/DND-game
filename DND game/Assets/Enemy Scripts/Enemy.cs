using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;

    public bool isBoss;

    private void Update()
    {
        if (health <= 0)
        {
           // Debug.Log("Death");
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            if (isBoss)
                SceneManager.LoadScene("EndingDialogue");

            Destroy(this.gameObject);
        }
        
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage; 

    }
}

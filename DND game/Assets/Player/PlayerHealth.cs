using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 40;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject deathEffect;

    private int bufferHealth; 
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {

        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            FindObjectOfType<LevelManager>().GameOver();
            Destroy(gameObject); 
        }
    }


    void GainHeath()
    {
        currentHealth += 10;
        if (currentHealth >= 40)
        {
            bufferHealth = currentHealth;
            bufferHealth -= 5;
            currentHealth = bufferHealth;
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }

    }

  
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5); 

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPickUp"))
        {
            GainHeath(); 
        }
    }
}


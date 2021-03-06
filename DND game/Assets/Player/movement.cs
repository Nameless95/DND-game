using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;



public class movement : MonoBehaviour
{
    Control left;
    Rigidbody2D rb;
    public Camera cm;
    public GunTemplate gun;
    float gunCooldown;
    public Slider slideCooldown; 
    public GameObject bulletPrefab;

    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        gunCooldown = gun.fireRate;
        Debug.Log("working");

    }

    private void Update()
    {
        gunCooldown = (gunCooldown >=0) ? (gunCooldown-Time.deltaTime): 0 ;
        slideCooldown.value = gunCooldown/gun.fireRate ;
    }

    void shoot()
    {
        Debug.Log(  gunCooldown/gun.fireRate);
        if (gunCooldown > 0) 
            return;
        gunCooldown = gun.fireRate;
        Vector2 power;
        power = this.transform.position - cm.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log(gun.gunName + " was used");
        power.Normalize();
        power *= gun.knockBack;
        rb.velocity = power;

        //Bulletstuff
        GameObject tempObject = BPS.instance.GetPooledObject("Bullet");
        if(tempObject == null) Debug.Log("OWfjeo");
        tempObject.GetComponent<gun>().WakeUp((Vector2)transform.position, power);
    }


    private void OnEnable()
    {
        left.cont.Enable(); 
    }

    private void OnDisable()
    {
        left.cont.Disable();
    }

}

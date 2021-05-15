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
    public GameObject GunSprite; 

    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        gunCooldown = gun.fireRate;
        GunSprite.GetComponent<SpriteRenderer>().sprite=gun.GunSprite;
        Debug.Log("working");

    }

    private void Update()
    {
        gunCooldown = (gunCooldown >=0) ? (gunCooldown-Time.deltaTime): 0 ;
        slideCooldown.value = gunCooldown/gun.fireRate;
        Vector3 targetPostion = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
            //Position.current.postion.currentvalue);
        targetPostion.z = 0; 
        GunSprite.transform.rotation = Quaternion.Euler(new Vector3 (0,0,Vector3.SignedAngle(Vector3.right, targetPostion - this.transform.position, Vector3.forward))); 

    }

    void shoot()
    {
       // Debug.Log(  gunCooldown/gun.fireRate);
        if (gunCooldown > 0) 
            return;
        gunCooldown = gun.fireRate;
        Vector2 power;
        power = this.transform.position - cm.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Debug.Log(gun.gunName + " was used");
        power.Normalize();
        power *= gun.knockBack;
        rb.velocity = power;

        //Bulletstuff
        GameObject tempObject = BPS.instance.GetPooledObject("Bullet");
        tempObject.GetComponent<gun>().WakeUp((Vector2)transform.position, power, gun.damage);
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

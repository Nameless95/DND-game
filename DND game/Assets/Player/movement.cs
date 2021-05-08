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
    public Camera cam;
    public float aimOffset; 

    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        gunCooldown = gun.fireRate;
        GunSprite.GetComponent<SpriteRenderer>().sprite=gun.GunSprite;
        GunSprite.transform.position = new Vector3(GunSprite.transform.position.x + gun.offset.x, GunSprite.transform.position.y + gun.offset.y); 
        Debug.Log("working");

    }

    private void Update()
    {
        gunCooldown = (gunCooldown >=0) ? (gunCooldown-Time.deltaTime): 0 ;
        slideCooldown.value = gunCooldown/gun.fireRate;

        Vector3 mousePos = Mouse.current.position.ReadValue(); 
        mousePos.z = -20;
        Vector3 objectPos = cam.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        GunSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + aimOffset));

        //Vector3 targetPostion = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
        //    //Position.current.postion.currentvalue);
        //targetPostion.z = -20; 
        //GunSprite.transform.rotation = Quaternion.Euler(new Vector3 (0,0,Vector3.SignedAngle(Vector3.right, targetPostion - this.transform.position, Vector3.forward) + aimOffset)); 

    }

    void shoot()
    {
       // Debug.Log(  gunCooldown/gun.fireRate);
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

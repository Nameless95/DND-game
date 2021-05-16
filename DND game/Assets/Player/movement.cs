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
    bool reload=false;
    bool knockback=true;

    // Function run on startup
    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        left.cont.Holdback.performed += ctx => knockback=false;
        left.cont.Holdback.canceled += ctx => knockback=true;
        left.cont.reload.performed += ctx => {
            if(reload==false){
                Debug.Log("STOP");
                gunCooldown = gun.reloadTime;
                reload=true;
            }
        };
        gunCooldown = gun.fireRate;
        GunSprite.GetComponent<SpriteRenderer>().sprite=gun.GunSprite;
        Debug.Log("working");

    }

    private void Update()
    {
        // GUN LOGIC
        gunCooldown = (gunCooldown >=0) ? (gunCooldown-Time.deltaTime): 0 ;
        // Gun doens't got ammo: so do this instead
        if(reload){
            slideCooldown.value = gunCooldown/gun.reloadTime;
            Debug.Log("reload");
            bool onGround = true;
            if(onGround){
                // Ready to reload
                if(gunCooldown == 0){
                    Debug.Log("COOLDOWN");
                    gun.ammo = gun.magSize;
                    reload = false;
                }
            }
            // If not ground, then player isn't reloading: as such, just set the cooldown to this to rset it.
            else {
            slideCooldown.value = gunCooldown/gun.fireRate;
                Debug.Log("Not on ground");
                gunCooldown = gun.reloadTime;
            }
        }

        // Displaying crap logic
        Vector3 targetPostion = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
        //Position.current.postion.currentvalue);
        targetPostion.z = 0; 
        GunSprite.transform.rotation = Quaternion.Euler(new Vector3 (0,0,Vector3.SignedAngle(Vector3.right, targetPostion - this.transform.position, Vector3.forward))); 

    }

    void shoot()
    {
        Debug.Log(knockback);
        if (gunCooldown > 0 && reload) {
            return;
        }
        // else if (gun.ammo <=0){
        //     Debug.Log("NICE");
        //     gunCooldown = gun.reloadTime;
        //     reload=true;
        //     return;
        // }
            
        // Do I got ammo to shoot?
        // If so, shoot
        // Else, am I on ground?
        // If so, run reload time
        // If running reload time, if time 
        if(gun.ammo >0){
            gun.ammo--;
            gunCooldown = gun.fireRate;
            Vector2 power;
            power = this.transform.position - cm.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.Log(gun.gunName + " was used");
            power.Normalize();
            power *= gun.knockBack;
            if(knockback){
                rb.velocity = power;
            }

            //Bulletstuff
            GameObject tempObject = BPS.instance.GetPooledObject("Bullet");
            tempObject.GetComponent<gun>().WakeUp((Vector2)transform.position, power, gun.damage);
        }
        
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

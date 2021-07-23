using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using UnityEditor.PackageManager;


public class movement : MonoBehaviour
{
    Control left;
    Rigidbody2D rb;
    public Camera cm;
   public List<GunTemplate> guns;
   GunTemplate gun; 
    private int select_gun_index = 0;
    float gunCooldown;
    public Slider slideCooldown; 
    public GameObject bulletPrefab;
    public GameObject GunSprite;
    public Camera cam;
    public SpriteRenderer sprite;

    bool ishold = false;

    void weaponswitch(bool isLeft) {
        Debug.Log(select_gun_index.ToString());
        if (isLeft)
        {
            select_gun_index--;
        }
        else
        {
        select_gun_index++;

        }

        if (select_gun_index < 0)
            select_gun_index = guns.Count-1;
        select_gun_index%= guns.Count;
        gun = guns[select_gun_index];
        sprite.sprite = gun.GunSprite;
        sprite.size = new Vector2(gun.GunSprite.rect.width, gun.GunSprite.rect.height);

    }
    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        
        left.cont.wpn_left.performed += ctx => weaponswitch(true);
        left.cont.wpn_right.performed += ctx => weaponswitch(false);

         left.cont.hold.started += ctx => ishold = true;
         left.cont.hold.canceled += ctx => ishold = false;
        
        gun = guns[0];
        gunCooldown = gun.fireRate;
        GunSprite.GetComponent<SpriteRenderer>().sprite=gun.GunSprite;
        
        Debug.Log(gun.ToString());
        Debug.Log("working");

    }

    private void Update()
    {
        gunCooldown = (gunCooldown >=0) ? (gunCooldown-Time.deltaTime): 0 ;
        slideCooldown.value = gunCooldown/gun.fireRate;
        Vector3 targetPostion = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
            //Position.current.postion.currentvalue);
        targetPostion.z = 0; 
        GunSprite.transform.rotation = Quaternion.Euler(new Vector3 (0,0,Vector3.SignedAngle(Vector3.right, targetPostion - this.transform.position, Vector3.forward))); 

    }

    void shoot()
    {
        if (gunCooldown > 0)
            return;
        gunCooldown = gun.fireRate;
        Vector2 trajectory = cm.ScreenToWorldPoint(Mouse.current.position.ReadValue())-  this.transform.position ;
        //Debug.Log(gun.gunName + " was used");
        trajectory.Normalize();
        double trajectory_angle = (double) Mathf.Rad2Deg*Math.Atan2(trajectory.y, trajectory.x); 
        double[] angels = Enumerable.Range(1, 4).Select(x => (double)((trajectory_angle + x * 30 / 4) * Mathf.Deg2Rad)).ToArray();
        //double[] angels = {trajectory_angle} ;
        //Vector2 power = gun.knockBack;
        //var power = trajectory * gun.knockBack;
        if (!ishold)
            rb.velocity = trajectory*gun.knockBack;

        //Bulletstuff
        Debug.ClearDeveloperConsole();
        foreach (double angle in angels)
        {
            Debug.Log("ANGLE TO FIRE AT "+ math.cos(angle).ToString() +  "\t" +   math.sin(angle).ToString() + "\t" + "TRAJECTORY \t" + trajectory_angle + " THE TRAJECTORY ITSLEF " + trajectory.x.ToString() + " " + trajectory.y.ToString());
            Vector2 tmpVect = new Vector2(-(float)math.cos(angle) , -(float) math.sin(angle) );
            //Vector2 tmpVect = new Vector2(1,0);
            GameObject tempObject = BPS.instance.GetPooledObject("Bullet");
            //Debug.Log("ANGLE" + trajectory_angle.ToString()+"POWER"+ power.ToString()+ "POS".ToString()+ this.transform.position.ToString());
            tempObject.GetComponent<gun>().WakeUp((Vector2) this.transform.position, tmpVect, gun.damage);
    }
}

    // Game Engine
    private void OnEnable()
    {
        left.cont.Enable(); 
    }

    private void OnDisable()
    {
        left.cont.Disable();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.PackageManager;


public class movement : MonoBehaviour
{
    Control left;
    Rigidbody2D rb;
    public Camera cm;
    public static List<GunTemplate> guns;
   GunTemplate gun; 
    private int select_gun_index = 0;
    float gunCooldown;
    public Slider slideCooldown; 
    public GameObject bulletPrefab;
    public GameObject GunSprite;
    public Camera cam;
    public SpriteRenderer sprite;
    public GunTemplate[] _gun;

    bool ishold = false;

    void weaponswitch(bool isLeft) {
        
        if (isLeft) {
            select_gun_index--;
        }
        else {
            select_gun_index++;

        }

        if (select_gun_index < 0)
            select_gun_index = guns.Count-1;
        select_gun_index%= guns.Count;
        gun = guns[select_gun_index];
        sprite.sprite = gun.GunSprite;
        sprite.size = new Vector2(gun.GunSprite.rect.width, gun.GunSprite.rect.height);
        Debug.Log("Switch to gun" + select_gun_index.ToString());

    }
    void Awake()
    {
        if (guns == null)
        {
            guns = _gun.ToList();
        }

        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => Shoot();
        
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

    private void Shoot()
    {
        if (gunCooldown > 0)
        { return; }
        gunCooldown = gun.fireRate;
        Vector2 trajectory =  this.transform.position - cm.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log("FUCKKKKKKKKKKKKKKKKKK");
        trajectory.Normalize();
        if (!ishold)
            rb.velocity = trajectory*gun.knockBack;

        Func<Vector2, float, Vector2> rotate = (path, angle) => new Vector2(path.x*Mathf.Cos(angle) - path.y *Mathf.Sin(angle), path.x * Mathf.Sin(angle) + path.y * Mathf.Cos(angle)) ;
        var tmp = Enumerable.Range(1, gun.lineCount - 1);
            //.Select(x => rotate(trajectory, Mathf.Deg2Rad * (float) gun.spread * x));
            Vector2[] paths = tmp.Select(x => rotate(trajectory, Mathf.Deg2Rad * (float)gun.spread * x))
                .Concat(tmp.Select(x=>rotate(trajectory, Mathf.Deg2Rad * (float)gun.spread * -x)))
                .Concat(new[] {trajectory}).ToArray();


            //Bulletstuff
        foreach (Vector2 path in paths)
        {
            Debug.Log("RUNNING\t " + path.ToString());
            GameObject tempObject = BPS.instance.GetPooledObject("Bullet");
            tempObject.GetComponent<gun>().WakeUp((Vector2) this.transform.position, path, gun.damage);
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

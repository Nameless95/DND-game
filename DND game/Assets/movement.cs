using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class movement : MonoBehaviour
{
    Control left;
    Rigidbody2D rb;
    public Camera cm;
    public GunTemplate gun;
    float gunCooldown;

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
        gunCooldown -= Time.deltaTime;
    }

    void shoot()
    {
        Debug.Log(gunCooldown);
        if (gunCooldown > 0) 
            return;
        gunCooldown = gun.fireRate;
        Vector2 power;
        power = this.transform.position - cm.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log(gun.gunName + " was used");
        power.Normalize();
        power *= gun.knockBack;
        rb.AddForce(power);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class movement : MonoBehaviour
{
    Control left;
    Rigidbody2D rb;
   public Camera cm;

    public float mag;
    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        Debug.Log("working");
    }

    void shoot()
    {
        Vector2 power;
        power = this.transform.position - cm.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        power.Normalize();
        power *= mag;
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

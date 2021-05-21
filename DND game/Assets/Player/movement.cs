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
    public LayerMask groundLayer;
    public BoxCollider2D boxCollider;
    public ParticleSystem slideParticles;

    void Awake()
    {
        left = new Control();
        rb = this.GetComponent<Rigidbody2D>();
        left.cont.shoot.performed += ctx => shoot();
        gunCooldown = gun.fireRate;
        GunSprite.GetComponent<SpriteRenderer>().sprite=gun.GunSprite;
        Debug.Log("working");
        boxCollider = GetComponent<BoxCollider2D>();
        slideParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        gunCooldown = (gunCooldown >=0) ? (gunCooldown-Time.deltaTime): 0 ;
        slideCooldown.value = gunCooldown/gun.fireRate;
        Vector3 targetPostion = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); 
            //Position.current.postion.currentvalue);
        targetPostion.z = 0; 
        GunSprite.transform.rotation = Quaternion.Euler(new Vector3 (0,0,Vector3.SignedAngle(Vector3.right, targetPostion - this.transform.position, Vector3.forward)));

        if (rb.velocity.sqrMagnitude > 0 && OnGround())
        {
            slideParticles.Play();
           //slideParticles.emissionRate *= rb.velocity.sqrMagnitude;
        }
        else
            slideParticles.Stop();

    }

    private bool OnGround()
    {
        float extraHeightText = .5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down,
            extraHeightText, groundLayer);

        if (raycastHit.collider != null)
            return true;
        else
            return false;
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

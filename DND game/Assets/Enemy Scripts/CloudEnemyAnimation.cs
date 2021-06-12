using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnemyAnimation : MonoBehaviour
{
    public Animator anim;
    public FlyingShootingEnemy CloudShot;

    private void Update()
    {
        if (CloudShot.IsShooting == true) 
        {
            anim.SetBool("IsAttacking", true); 
        }
        else 
        {
            anim.SetBool("IsAttacking", false);
        }
    }




}

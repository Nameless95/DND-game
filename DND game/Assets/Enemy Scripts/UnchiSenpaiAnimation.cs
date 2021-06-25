using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnchiSenpaiAnimation : MonoBehaviour
{
    public Animator anim;
    public ShootingEnemy Shooting;

    private void Update()
    {
        if (Shooting.IsShooting == true)
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }


}

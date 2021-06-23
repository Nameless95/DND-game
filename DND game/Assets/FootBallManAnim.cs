using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallManAnim : MonoBehaviour
{
    public Animator anim;
    public PatrolEnemy Attack;

    private void Update()
    {
        if (Attack.IsAttacking == true)
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }
}

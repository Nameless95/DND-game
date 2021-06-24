using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private GameObject player;
    public enemyscript PatrolScript;
    [HideInInspector]
    public bool IsAttacking;

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {

        if ((player.transform.position - this.transform.position).sqrMagnitude < 7 * 7)
        {
            transform.Translate(Vector2.right * PatrolScript.speed * 3 * Time.deltaTime * PatrolScript.distance);
            IsAttacking = true; 
        }
        else
        {
            IsAttacking = false; 
        }
        
    }
}

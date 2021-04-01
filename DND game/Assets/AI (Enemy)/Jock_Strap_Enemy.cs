using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jock_Strap_Enemy : MonoBehaviour
{
    private GameObject player;
    public Patrol PatrolScript;
   

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {

        if ((player.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
        {
            transform.Translate(Vector2.right * PatrolScript.speed * 3 * Time.deltaTime);

        }
        
    }
}

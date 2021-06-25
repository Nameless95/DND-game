using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float finalPosition;
    public float time;
    void Start()
    {
       LeanTween.moveX(gameObject, finalPosition, time); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

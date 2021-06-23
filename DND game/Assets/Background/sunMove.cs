using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunMove : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] int yPlayerMax;
    [SerializeField] int yPlayerMin;
    [SerializeField] Material sky;
    float currentMin = 0;

    private void Awake() {
        currentMin = player.position.y;
    }

    private void Update() {
        if(currentMin > player.position.y){
            currentMin = player.position.y;
            float pos = getPos();
            transform.localPosition = new Vector3(0, pos*10-5, 0);
            sky.SetFloat("_Location", 1-pos);
        }
    }
    float getPos(){
        float max = yPlayerMax + Mathf.Abs(yPlayerMin);
        float playerPos = player.position.y + Mathf.Abs(yPlayerMin);
        return (playerPos/max);
    }
}

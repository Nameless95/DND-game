using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKeyboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.escape)){
            Debug.Log("pressed");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEditor.PackageManager;


public class Vendor : MonoBehaviour{
   
   public List<GunTemplate> guns;
   public int choices = 2;
    void Start()
    {

        Debug.Log(guns.Count);

    }

    // Update is called once per frame
    void Update() {
        
    }
}

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
using UnityEngine.SceneManagement;


public class Vendor : MonoBehaviour{
   
   public List<GunTemplate> guns;
   public int choices = 1;
    void Start()
    {
        //GunTemplate[] choices = gun_selection();
        movement.guns = gun_selection();
        //movement.guns = guns.ToList();
        SceneManager.LoadScene("Scenes/Game");
    }

    /// <summary>
    ///  Function get list of guns
    /// I made a function sort of like the itnerface: in case we decide to chagne the method we can just change it here
    /// and make development smoother
    /// </summary>
    /// <returns></returns>
    public List<GunTemplate> gun_selection()
    {
        
        System.Random rnd=new System.Random();
        return guns.OrderBy(x => rnd.Next()).Take(choices).ToList();

    }
    
    

    // Update is called once per frame
    void Update() {
        
    }
}

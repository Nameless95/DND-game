using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
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
   public int choices;
   public TextMeshProUGUI Name;
   public TextMeshProUGUI Description;
   public SpriteRenderer sprite;
   
   IEnumerator ExampleCoroutine(List<GunTemplate> guns) {
        for (int i = 0; i < guns.Count; i++)
        {
            var gun = guns[i];
              display_gun(gun);
              yield return new WaitForSeconds(1);
        }
        //movement.guns = guns.ToList();
        SceneManager.LoadScene("Scenes/Game");

   }


    void Start()
    {
        //GunTemplate[] choices = gun_selection();
        //movement.guns = gun_selection();
        movement.guns = gun_selection();
        StartCoroutine(ExampleCoroutine(movement.guns));
    }

    public void display_gun(GunTemplate gun)
    {
        Name.text = gun.gunName;
        Description.text = String.Format( "Damage per bullet: {0}\n"+
                                          "Fire Rate: {1}\n"+
                                          "Bullets per fire: {2}\n"+
                                          "Gun spread: {3}\n", gun.damage, gun.fireRate, gun.lineCount, gun.spread);
        sprite.sprite = gun.GunSprite;
        sprite.size = new Vector2(gun.GunSprite.rect.width, gun.GunSprite.rect.height);
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
    
    
    public 

    // Update is called once per frame
    void Update() {
    }
}

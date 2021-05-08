using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "New Gun")]
public class GunTemplate : ScriptableObject
{
    public string gunName;
    public int damage;
    public int bullet;
    public float fireRate;
    public float knockBack;
    public Sprite GunSprite;
    public Vector2 offset; 

    }

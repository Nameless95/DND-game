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
    // Sorry to any gun heads, I don't know the term for
    // number of bullets in a gun. If you can correct me
    // so this term can work for shotguns, pistols, and RPGS
    public uint magSize;
    public uint ammo;
    // time to reload: it is in seconds.
    public float reloadTime;

    }

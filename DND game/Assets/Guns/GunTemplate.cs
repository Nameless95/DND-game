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
    // Line count is 2*linecount + 1 of bullets that will appear
    // Reason 2*linecount + 1 is 1 is for the center, aka where the mouse is pointing, and 2*linecount is to be symetrical
    public int lineCount;
    public double spread;

}

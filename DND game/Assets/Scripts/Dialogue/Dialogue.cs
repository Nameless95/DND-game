using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    [Header("Dialogue")]
    public string dialogue;
    public Sprite protait;
    [Space]
    [Header("Settings")]
    public bool lastInOrder;
    public bool loadNewestScene;
    public string loadScene;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Dialogue", order = 1)]
public class DialogueObj : ScriptableObject
{
    public Dialogue[] dialogues;
}

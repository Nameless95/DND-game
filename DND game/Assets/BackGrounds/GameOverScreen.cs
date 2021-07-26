﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOverScreen : MonoBehaviour
{
  public void Setup()
    {
        gameObject.SetActive(true); 
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<LevelManager>().Restart();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Lobby"); 
    }
  

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI toggleText;
   
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void startLobby(){
        SceneManager.LoadScene(0);
    }

   
    public void Toggle(){
        if(toggleText.text == "On"){
            toggleText.text = "Off";
        }
        else{
            toggleText.text = "On";
        }
    }
}

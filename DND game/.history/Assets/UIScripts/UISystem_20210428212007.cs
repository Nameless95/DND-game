using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI toggleText;
    new boolean a = 1;

    public void StartGame(){
        SceneManager.LoadScene(1);
    }
    public void QuitGame(){
        if(a=1){
            System.out.println("Quit Game?");
            toggleText.text = "U Sure?";
            a = 0;
            Application.Quit();
        }
    }
    public void startLobby(){
        SceneManager.LoadScene(0);
    }
    public void startSettings(){
        
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

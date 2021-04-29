using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI toggleText;
    public AudioMixer mixer;

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

    public void Volume(float volume){
        Debug.Log(volume);
        mixer.SetFloat("VolumeLevel", volume);
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

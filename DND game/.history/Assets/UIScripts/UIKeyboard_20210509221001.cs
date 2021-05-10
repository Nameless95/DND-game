using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKeyboard : MonoBehaviour
{
    public static bool curPaus = false;
    public GameObject pauseMenu;
    public GameObject headMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("pressed");
            if (curPaus){
                Resume();
            } else {
                Pause();
            }
        }
    }
    void Resume(){
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale = 1f;
        curPaus = false;
    }
    void Pause(){
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        Time.timeScale = 0f;
        curPaus = true;
    }
}

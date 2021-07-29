using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    private Toggle toggle;
    private void OnEnable()
    {
        if (toggle == null)
            toggle = GetComponent<Toggle>();

        toggle.isOn = Screen.fullScreen;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FullscreenCheck(bool boolean)
    {
        Screen.fullScreen = boolean;
    }

}

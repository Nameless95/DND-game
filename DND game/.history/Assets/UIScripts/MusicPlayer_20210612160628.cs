using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Musi;

    private float musicVolume = 10f;
    void Start()
    {
       Musi.Play();
    }

    // Update is called once per frame
    
    public void updateVolume(float volume ){
        musicVolume = volume;
    }
    void Update()
    {
        Debug.Log(musicVolume);
        Musi.volume = musicVolume;
    }
}

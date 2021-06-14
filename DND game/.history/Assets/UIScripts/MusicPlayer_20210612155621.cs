using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;

    private float musicVolume = 1f;
    void Start()
    {
       audioSource.Play();
    }

    // Update is called once per frame
    
    public void updateVolume(float volume ){
        audioSource = musicVolume;
    }
    void Update()
    {
        //Debug.Log(musicVolume);
        musicVolume = volume;
    }
}

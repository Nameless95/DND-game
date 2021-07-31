using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Musi;
    public AudioSource Steps;
    public AudioSource PauseMusi;
    public Slider volumer;
    private float musicVolume;
    public bool firstPlay;
    public bool curPause = false;

    void Start()
    {
    
        musicVolume = PlayerPrefs.GetFloat("volume");
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        volumer.value = musicVolume;
        Musi.volume = musicVolume;
        Steps.volume = musicVolume;
        PauseMusi.volume = musicVolume;
        Steps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Steps.isPlaying == false && firstPlay == false){
            Musi.Play();
            firstPlay = true;
        }
        //Debug.Log(volumer.value);
        //Debug.Log(Musi.volume);
        Musi.volume = volumer.value;
        PlayerPrefs.SetFloat("volume", volumer.value);
       if(Input.GetKeyDown(KeyCode.Escape)){
            if (curPause){
                Resume();
            } else {
                Pause();
            }
        }
    }
    void Pause(){
        PauseMusi.Play();
        Musi.Pause();
        curPause = true;
    }
    void Resume(){
        PauseMusi.Stop();
        Musi.Play();
        curPause = false;
    }
    public void updateVolume(float volume ){
        volumer.value = volume;
    }
}

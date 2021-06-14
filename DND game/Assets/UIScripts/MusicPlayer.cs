using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Musi;
    public Slider volumer;
    private float musicVolume = 1f;

    void Start()
    {
       Musi.Play();
       musicVolume = PlayerPrefs.GetFloat("volume");
       Musi.volume = musicVolume;
       volumer.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(musicVolume);
        Musi.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

        public void updateVolume(float volume ){
        musicVolume = volume;
    }
}

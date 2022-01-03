using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    // Reference to Audio Source component
    public AudioSource audioSrc;
   // public AudioMixer audioMixer;
    //public AudioClip bgMusic;
    /*
    public Toggle musicToggleBtn;
    public Toggle soundToggleBtn;*/
    public Toggle musicToggle;

    /*public AudioMixer soundMute;
    public AudioMixer musicMute;*/

    //static MusicSetting instance = null;
    // Music volume variable that will be modified
    // by dragging slider knob
    //private float musicVolume = 1f;


    // Use this for initialization
    void Start()
    {
        // Assign Audio Source component to control it
        audioSrc =  GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>();
        
        //musicToggle = GameObject.FindGameObjectWithTag("MusicToggle").GetComponent<Toggle>();
        //audioSrc.PlayOneShot(bgMusic);
        CheckMuteOrUnMute();

    }

    // Update is called once per frame
    void Update()
    {

        // Setting volume option of Audio Source to be equal to musicVolume
       // audioSrc.volume = musicVolume;
    }

    /* Method that is called by slider game object
     This method takes vol value passed by slider
     and sets it as musicValue*/
   /* public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }*/
    void CheckMuteOrUnMute()
    {
        if (PlayerPrefs.GetInt("MusicMute", 0) == 0)
        {
           //Debug.Log("Music Un Mute");
            audioSrc.mute = false;
            musicToggle.isOn = false;
        }
        else
        {
            //Debug.Log("Music Mute");
            audioSrc.mute = true;
            musicToggle.isOn = true;
        }
    }
    public void MuteMusic(bool muteMusic)// Update player prefrences
    {
        if (PlayerPrefs.GetInt("MasterMute", 0) == 0)
        {
            //Debug.Log("Master music is unmute");
            audioSrc.mute = muteMusic;
            if (muteMusic)
            {
                PlayerPrefs.SetInt("MusicMute", 1); //music is mute
                //AudioListener.volume = 1;
            }
            else
            {
                PlayerPrefs.SetInt("MusicMute", 0); // Music is unmute
            }
        }
       
        else
        {
           /* Debug.Log("Master music is mute");
            Debug.Log("so music is mute");*/
            PlayerPrefs.SetInt("MusicMute", 1); // Music is mute
            //AudioListener.volume = 0;
        }
    }
    public void VolumeofMusic(float volume)
    {
       float VolumeSliderGet = GameObject.FindGameObjectWithTag("Master volume slider").GetComponent<Slider>().value;
        Slider musicVolumeSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        musicVolumeSlider.maxValue = VolumeSliderGet;
        audioSrc.volume = volume;
    /*    Debug.Log("audioS.name " + audioSrc.name);
        Debug.Log("audioS.volume " + audioSrc.volume);
        Debug.Log("volume " + volume);*/
    }
        
}

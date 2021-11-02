using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    // Reference to Audio Source component
    private AudioSource audioSrc;
    public AudioMixer audioMixer;
    public Toggle musicToggleBtn;
    public Toggle soundToggleBtn;
    /*public AudioMixer soundMute;
    public AudioMixer musicMute;*/

    static MusicSetting instance = null;
    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 1f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
        UpdateIcon();
        if(AudioListener.volume == 0)
        {
            musicToggleBtn.isOn = false;
        }
        else
        {
            musicToggleBtn.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void MuteMusic()// Update player prefrences
    {
        if(PlayerPrefs.GetInt("Mute",0 )==0)
        {
            PlayerPrefs.SetInt("Mute", 1);
            //AudioListener.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 0);
            //AudioListener.volume = 0;

        }
        UpdateIcon();
    }
   
    void UpdateIcon()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            //change the Toggle
        }
        else
        {
            AudioListener.volume = 0;
            //change the Toggle
        }
    }
}

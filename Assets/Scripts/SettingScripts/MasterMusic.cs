using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMusic : MonoBehaviour
{
    public AudioSource audioSrcMusic;
    public AudioSource audioSrcSound;
    public Toggle masterToggle;
    public Toggle musicToggle;
    public Toggle soundToggle;

    //public AudioClip giftSound;
    public static MasterMusic mmInstance;
    private void Awake()
    {
        if (mmInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            mmInstance = this;
           // GameObject.DontDestroyOnLoad(gameObject);
           
        }
        DontDestroyOnLoad(gameObject);
        //masterToggle.onValueChanged.AddListener(MuteMaster(masterToggle.isOn));

    }
    private void Start()
    {
        CheckMuteOrUnMute();/*
        masterToggle =  GameObject.Find("MasterToggle").GetComponent<Toggle>();
        musicToggle =  GameObject.Find("MusicToggle ").GetComponent<Toggle>();
        soundToggle =  GameObject.Find("SoundToggle").GetComponent<Toggle>();*/
    }
    void CheckMuteOrUnMute()
    {
        if (PlayerPrefs.GetInt("MasterMute", 0) == 0)
        {
            Debug.Log("Master Un Mute");
            masterToggle.isOn = false;
            audioSrcMusic.mute = false;
            musicToggle.isOn = false;
            audioSrcSound.mute = false;
            soundToggle.isOn = false;
        }

        else
        {
            Debug.Log("Master Mute");
            masterToggle.isOn = true;
           audioSrcMusic.mute = true;
            musicToggle.isOn = true;
            audioSrcSound.mute = true;
            soundToggle.isOn = true;
        }
    }
    public void VolumeofMaster(float volume)
    {
        audioSrcMusic.volume = volume;
        audioSrcSound.volume = volume;
        Debug.Log("audioSrcSound.volume " + audioSrcSound.volume);
    }
    public void MuteMaster(bool muteMusic)// Update player prefrences
    {
        audioSrcMusic.mute = muteMusic;
        audioSrcSound.mute = muteMusic;
        if (muteMusic)
        {
            PlayerPrefs.SetInt("MasterMute", 1);
            PlayerPrefs.SetInt("SoundMute", 1);
            PlayerPrefs.SetInt("MusicMute", 1);
            //AudioListener.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("MasterMute", 0);
            PlayerPrefs.SetInt("SoundMute", 0);
            PlayerPrefs.SetInt("MusicMute", 0);
            //AudioListener.volume = 0;

        }
        CheckMuteOrUnMute();
    }

    public void ChangeBGMusic(AudioClip music)
    {
        audioSrcMusic.Stop();
        audioSrcMusic.clip = music;
        audioSrcMusic.Play();

    }
}

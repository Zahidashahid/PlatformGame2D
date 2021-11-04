using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMusic : MonoBehaviour
{
    public AudioSource audioSrcMusic;
    public AudioSource audioSrcSound;
    //public AudioClip giftSound;
    public static MasterMusic mmInstance;
    private void Awake()
    {
        if (mmInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            mmInstance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
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
        if (PlayerPrefs.GetInt("Mute", 0) == 0)
        {
            PlayerPrefs.SetInt("Mute", 1);
            //AudioListener.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 0);
            //AudioListener.volume = 0;

        }
        //UpdateIcon();
    }
}

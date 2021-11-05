using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffect : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip arrowHitSound;
    public AudioClip giftSound;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip meleeAttackSound;
    //public AudioClip giftSound;
    public static SoundEffect sfInstance;
    public Toggle soundEffectToggle;
    private void Awake()
    {
        // CheckMuteOrUnMute();
        if (sfInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            sfInstance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        CheckMuteOrUnMute();
    }
    void CheckMuteOrUnMute()
    {
        if (PlayerPrefs.GetInt("SoundMute", 1) == 1 && PlayerPrefs.GetInt("MasterMute", 1) == 1)
        {
            Debug.Log("Sound Mute");
            audioS.mute = true;
            soundEffectToggle.isOn = true;
        }
        else
        {
            Debug.Log("Sound Un Mute");
            audioS.mute = false;
            soundEffectToggle.isOn = false;
        }
    }
    public void MuteSound(bool muteSound)
    {
        if (PlayerPrefs.GetInt("MasterMute", 0) == 0)
        {
            Debug.Log("Master music is unmute So can sound");
            audioS.mute = muteSound;
            if (muteSound)
            {
                PlayerPrefs.SetInt("SoundMute", 1); //sound effect  is mute
                //AudioListener.volume = 1;
            }
            else
            {
                PlayerPrefs.SetInt("SoundMute", 0); // sound effect  is unmute
            }
        }

        else
        {
            Debug.Log("Master music is mute");
            Debug.Log("so sound is mute");
            PlayerPrefs.SetInt("SoundMute", 1); // sound effect  is mute
            //AudioListener.volume = 0;
        }
    }
    
    public void VolumeofSound(float volume)
    {
        audioS.volume = volume;
        Debug.Log("audioS.volume " + audioS.volume);
    }
   
}

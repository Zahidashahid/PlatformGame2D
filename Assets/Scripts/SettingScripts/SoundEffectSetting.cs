using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectSetting : MonoBehaviour
{

    public AudioSource audioS;
    //public AudioClip giftSound;
    public static SoundEffectSetting sfSettingInstance;
    public Toggle soundEffectToggle;
   
    private void Start()
    {
        audioS = GameObject.FindGameObjectWithTag("SoundEffectGameObject").GetComponent<AudioSource>();
        //soundEffectToggle = GameObject.FindGameObjectWithTag("SoundToggle").GetComponent<Toggle>();
        CheckMuteOrUnMute();
    }
    void CheckMuteOrUnMute()
    {
        if (PlayerPrefs.GetInt("SoundMute", 1) == 1 && PlayerPrefs.GetInt("MasterMute", 1) == 1)
        {
            //Debug.Log("Sound Mute");
            audioS.mute = true;
            soundEffectToggle.isOn = true;
        }
        else
        {
           // Debug.Log("Sound Un Mute");
            audioS.mute = false;
            soundEffectToggle.isOn = false;
        }
    }
    public void MuteSound(bool muteSound)
    {
        if (PlayerPrefs.GetInt("MasterMute", 0) == 0)
        {
            //Debug.Log("Master music is unmute So can sound");
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
            /*Debug.Log("Master music is mute");
            Debug.Log("so sound is mute")*/;
            PlayerPrefs.SetInt("SoundMute", 1); // sound effect  is mute
            //AudioListener.volume = 0;
        }
    }

    public void VolumeofSound(float volume)
    {
        audioS.volume = volume;
       // Debug.Log("audioS.volume " + audioS.volume);
    }
}

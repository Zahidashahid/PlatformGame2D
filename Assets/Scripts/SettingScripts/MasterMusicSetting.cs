using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MasterMusicSetting : MonoBehaviour
{
    public AudioSource audioSrcMusic;
    public AudioSource audioSrcSound;
    public Toggle masterToggle;
    public Toggle musicToggle;
    public Toggle soundToggle;
    private void Start()
    {
        
        audioSrcSound = GameObject.FindGameObjectWithTag("SoundEffectGameObject").GetComponent<AudioSource>();
        audioSrcMusic = GameObject.FindGameObjectWithTag("BGmusicGameObject").GetComponent<AudioSource>(); ;
      /*  masterToggle =  GameObject.FindGameObjectWithTag("MasterMusicToggle").GetComponent<Toggle>();
        musicToggle =  GameObject.FindGameObjectWithTag("MusicToggle").GetComponent<Toggle>();
        soundToggle =  GameObject.FindGameObjectWithTag("SoundToggle").GetComponent<Toggle>();*/
        CheckMuteOrUnMute();
    }
    void CheckMuteOrUnMute()
    {
        if (PlayerPrefs.GetInt("MasterMute", 0) == 0)
        {
            //Debug.Log("Master Un Mute");
            masterToggle.isOn = false;
            /*audioSrcMusic.mute = false;
            musicToggle.isOn = false;
            audioSrcSound.mute = false;
            soundToggle.isOn = false;*/

            if (PlayerPrefs.GetInt("MusicMute", 0) == 0)
            {
                audioSrcMusic.mute = false;
                musicToggle.isOn = false;
            }
            else
            {
                audioSrcMusic.mute = true;
                musicToggle.isOn = true;
            }
            if (PlayerPrefs.GetInt("SoundMute", 0) == 0)
            {
                audioSrcSound.mute = false;
                soundToggle.isOn = false;
            }
            else
            {
                audioSrcSound.mute = true;
                soundToggle.isOn = true;
            }
        }

        else
        {
            //Debug.Log("Master Mute");

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
        //Debug.Log("audioSrcSound.volume " + audioSrcSound.volume);
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

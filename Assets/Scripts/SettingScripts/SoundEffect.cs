using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
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
    }
    public void MuteSound(bool muteSound)
    {
        audioS.mute = muteSound;
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
        UpdateIcon();
        /* if (audioSrc.isPlaying)
         {
             //audioSrc.Pause();
             Debug.Log(audioSrc);
             audioSrc.mute = true;
         }
         else
         {
             audioSrc.Play();
         }*/
    }
    void UpdateIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
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

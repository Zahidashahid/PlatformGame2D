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
    public AudioClip missionCompletetSound;
    //public AudioClip giftSound;
    public static SoundEffect sfInstance;
    private void Awake()
    {
        // CheckMuteOrUnMute();
        if (sfInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            sfInstance = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }
   
   
}

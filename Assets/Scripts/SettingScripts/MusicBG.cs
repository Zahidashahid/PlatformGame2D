using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicBG : MonoBehaviour
{
    static MusicBG instance = null;
    

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
}

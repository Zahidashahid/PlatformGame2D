using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMusic : MonoBehaviour
{
    
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
            DontDestroyOnLoad(gameObject);

        }
        
        //masterToggle.onValueChanged.AddListener(MuteMaster(masterToggle.isOn));

    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAvatar : MonoBehaviour
{
  
    private void Start()
    {
        CheckAvatar();
    }
    void CheckAvatar()
    {
        if (PlayerPrefs.GetInt("AvatarSelected", 1) == 1)
        {
            PlayerPrefs.SetInt("AvatarSelected", 1);
        }

        else
        {
            PlayerPrefs.SetInt("AvatarSelected", 2);
        }
    }
    public void SelectAvatarOne()
    {
        PlayerPrefs.SetInt("AvatarSelected", 1);
    }
    public void SelectAvatarTwo()
    {
        PlayerPrefs.SetInt("AvatarSelected", 2);
    }
   

  /*  public void ChangeAvatar(Image img)
    {
        audioSrcMusic.Stop();
        audioSrcMusic.clip = music;
        audioSrcMusic.Play();

    }*/

}

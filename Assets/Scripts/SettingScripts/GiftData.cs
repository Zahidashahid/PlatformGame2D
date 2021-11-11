using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GiftData : MonoBehaviour
{
    //Display data on setting
    public static int gemCount;//Amount of gems in prefrences
    public static int cherryCount;//Amount of cherry in prefrences
    public TMP_Text gemText;
    public TMP_Text cherryText;
    void Start()
    {
        gemCount = PlayerPrefs.GetInt("CherryCollected");
        cherryCount = PlayerPrefs.GetInt("GemCollected");
    }

    // Update is called once per frame
    public void UpdateGiftsData()
    {
        gemText.text = "" + gemCount;
        cherryText.text = "" + cherryCount;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager obj;
    public TMP_Text gemText;
    public TMP_Text cherryText;
   // public TextMeshPro cherryText;
    int gemCollected;
    int cherryCollected;
    private void Start()
    {

        gemCollected =  PlayerPrefs.GetInt("RecentGemCollected");
        cherryCollected =  PlayerPrefs.GetInt("RecentCherryCollected");
        gemText.text = "X" + gemCollected;
        cherryText.text = "X" + cherryCollected;
    }
    public void GemCollect()
    {
        gemCollected += 1;
        gemText.text = "X" + gemCollected;
        Debug.Log("Gem = " + gemCollected);

    }
    public void CherryCollect()
    {
        cherryCollected += 1;
        cherryText.text = "X" + cherryCollected;
        Debug.Log("Cherry = " + cherryCollected);
    }
}

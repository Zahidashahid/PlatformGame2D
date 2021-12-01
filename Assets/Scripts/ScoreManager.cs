
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
        UpdateGemText(gemCollected);
    }
    public void CherryCollect()
    {
        cherryCollected += 1;
        UpdateCherryText(cherryCollected);
    }
    public void UpdateGemText(int count)
    {
        gemText.text = "X" + count;
        Debug.Log("Gem = " + count);
    }
    public void UpdateCherryText(int count)
    {
        cherryText.text = "X" + count;
        Debug.Log("Cherry = " + count);
    }
}

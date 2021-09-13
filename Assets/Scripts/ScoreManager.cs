using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager obj;
    public TextMeshPro textGem;
    public TextMeshPro textCherry;
  
    int gemCollected;
    int cherryCollected;

    public void GemCollect()
    {
        gemCollected += 1;
       // textGem.text = "X" + gemCollected.ToString();
        Debug.Log("Gem = "+ gemCollected);

    }
    public  void CherryCollect()
    {
        cherryCollected += 1;
        //textCherry.text = "X" + cherryCollected.ToString();
        Debug.Log("Cherry = " +cherryCollected);
    }
}

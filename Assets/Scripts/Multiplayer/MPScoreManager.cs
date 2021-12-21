
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MPScoreManager : MonoBehaviour
{
    public static ScoreManager obj;
    public TMP_Text player1gemText;
    public TMP_Text player1cherryText; 
    public TMP_Text player2gemText;
    public TMP_Text player2cherryText;
    // public TextMeshPro cherryText;
    int player1gemCollected;
    int player1cherryCollected;
    int player2gemCollected;
    int player2cherryCollected;
    private void Start()
    {

        /*gemCollected = PlayerPrefs.GetInt("RecentGemCollected");
        cherryCollected = PlayerPrefs.GetInt("RecentCherryCollected");*/
        player1gemText.text = "X" + player1gemCollected;
        player1cherryText.text = "X" + player1cherryCollected;
        player2gemText.text = "X" + player2gemCollected;
        player2cherryText.text = "X" + player2cherryCollected;
    }
    public void GemCollect(string playerName, int amountGem)
    {
        //player1gemCollected += amountGem;
        if (playerName == "Player1")
        {
            UpdatePlayer1GemText(amountGem);
        }
        else if (playerName == "Player2")
        {
            UpdatePlayer2GemText(amountGem);
        }
    }
    public void CherryCollect(string playerName, int amountCherry)
    {
        //player1cherryCollected += amountCherry;
        if (playerName == "Player1")
        {
            UpdatePlayer1CherryText(amountCherry);
        }
        else if (playerName == "Player2")
        {
            UpdatePlayer2CherryText(amountCherry);
        }
    }
    public void UpdatePlayer1GemText(int count)
    {
        player1gemText.text = "X" + count;
        Debug.Log("Gem = " + count);
    } 
    public void UpdatePlayer2GemText(int count)
    {
        player2gemText.text = "X" + count;
        Debug.Log("Gem = " + count);
    }
    public void UpdatePlayer1CherryText(int count)
    {
        
        player1cherryText.text = "X" + count;
        Debug.Log("Cherry = " + count);
    }
    public void UpdatePlayer2CherryText(int count)
    {
        player2cherryText.text = "X" + count;
        Debug.Log("Cherry = " + count);
    }
}

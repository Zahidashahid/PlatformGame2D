using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") )
        {
            gm.lastCheckPointPos = transform.position;
            Debug.Log("Last Check point changed" + gm.lastCheckPointPos);
            PlayerPrefs.SetFloat("LastcheckPointX", gm.lastCheckPointPos.x);
            PlayerPrefs.SetFloat("LastcheckPointy", gm.lastCheckPointPos.y);
            PlayerPrefs.SetInt("GemCollectedTillLastCheckPoint", PlayerPrefs.GetInt("RecentGemCollected"));
            PlayerPrefs.SetInt("CherryCollectedTillLastCheckPoint", PlayerPrefs.GetInt("RecentCherryCollected"));
            
            

        }
    }
}

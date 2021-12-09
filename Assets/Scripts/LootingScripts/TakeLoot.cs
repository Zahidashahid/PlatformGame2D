using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLoot : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ArrowStore arrowStore;
    public HealthBar healthBar;
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBar>();
        arrowStore = GameObject.FindGameObjectWithTag("ArrowStore").GetComponent<ArrowStore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        
        if (collision.tag == "Player")
        {
            //if (Input.GetKey(KeyCode.L))
           // {
                if (this.tag == "HealthLoot")
                {
                    Debug.Log(this.tag);
                    playerMovement.currentHealth = 100;
                    PlayerPrefs.SetInt("CurrentHealth", 100);
                    healthBar.SetHealth(100);
                    Destroy(gameObject);
                }
                else if (this.tag == "ArrowLoot")
                {
                    Debug.Log(this.tag);
                    int arrowCount = PlayerPrefs.GetInt("ArrowPlayerHas") + 5;
                
                    PlayerPrefs.SetInt("ArrowPlayerHas", arrowCount);
                    arrowStore.arrowPlayerHas = arrowCount;
                    arrowStore.UpdateArrowText();
                    Destroy(gameObject);
                }
                else 
                {
                    return;
                }


           // }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLoot : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public ArrowStore arrowStore;
    public HealthBar healthBar;
    int valueOfThisLoot;
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        healthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBar>();
        arrowStore = GameObject.FindGameObjectWithTag("ArrowStore").GetComponent<ArrowStore>();
        if (this.tag == "HealthLoot")
        {
            valueOfThisLoot = 50;
            
        }
        else if (this.tag == "ArrowLoot")
        {
            valueOfThisLoot = 5;
        }
     }
    private void Update()
    {
       if ( valueOfThisLoot <= 0)
            Destroy(gameObject);
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
                    int healthValuePlayerHas = PlayerPrefs.GetInt("CurrentHealth");
                    /*
                       ---------------------- Logic if player has full health  
                    */
                    Debug.Log(this.tag);
                    if (healthValuePlayerHas >= 100)
                    {
                        return;
                    }
                    else
                    {
                        int healthToAddInStore = 100 - healthValuePlayerHas;
                        if (healthToAddInStore <= valueOfThisLoot)
                        {
                            valueOfThisLoot = valueOfThisLoot - healthToAddInStore;
                            int healthCount = healthValuePlayerHas + healthToAddInStore;

                        playerMovement.currentHealth = 100;
                        PlayerPrefs.SetInt("CurrentHealth", 100);
                        Debug.Log("numOfArrowsPlayerHas  " + healthValuePlayerHas);
                            Debug.Log("healthToAddInStore " + healthToAddInStore);
                            Debug.Log("valueOfThisLoot  left " + valueOfThisLoot);
                            Debug.Log(" new CurrentHealth" + healthCount);
                            PlayerPrefs.SetInt("CurrentHealth", healthCount);
                            healthBar.SetHealth(healthCount);
                       
                        }
                        else
                        {
                           
                            int healthCount = healthValuePlayerHas + valueOfThisLoot;
                            PlayerPrefs.SetInt("CurrentHealth", healthCount);
                            healthBar.SetHealth(healthCount);
                            valueOfThisLoot = valueOfThisLoot - valueOfThisLoot;
                           
                        }
                        if (healthToAddInStore == 50)
                        {

                            Destroy(gameObject);
                        }

                    }

            }
            else if (this.tag == "ArrowLoot")
                {
                    int numOfArrowsPlayerHas = PlayerPrefs.GetInt("ArrowPlayerHas");
                    /*
                        ---------------------- Logic if player has 10 arrow i.e store is full
                     */
                    Debug.Log(this.tag);
                    if (numOfArrowsPlayerHas >= 10)
                    {
                        return;
                    }
                    else
                    {
                        int arrowsToAddInStore = 10 - numOfArrowsPlayerHas;
                        if(arrowsToAddInStore <= valueOfThisLoot)
                        {
                            valueOfThisLoot = valueOfThisLoot - arrowsToAddInStore;
                            int arrowCount = numOfArrowsPlayerHas + arrowsToAddInStore;
                            Debug.Log("numOfArrowsPlayerHas  " + numOfArrowsPlayerHas);
                            Debug.Log("arrowsToAddInStore " + arrowsToAddInStore);
                            Debug.Log("valueOfThisLoot  left" + valueOfThisLoot);
                            Debug.Log(" new arrowCount" + arrowCount);
                            PlayerPrefs.SetInt("ArrowPlayerHas", arrowCount);
                            arrowStore.arrowPlayerHas = arrowCount;
                            arrowStore.UpdateArrowText();
                        }
                        else
                        {
                            int arrowCount = numOfArrowsPlayerHas + valueOfThisLoot;
                            PlayerPrefs.SetInt("ArrowPlayerHas", arrowCount);
                            valueOfThisLoot = valueOfThisLoot - valueOfThisLoot;
                            arrowStore.arrowPlayerHas = arrowCount;
                            arrowStore.UpdateArrowText();
                        }
                        if (arrowsToAddInStore == 5)
                        {
                            Destroy(gameObject);
                        }
                       
                    }
                    
                }
                else 
                {
                    return;
                }


           // }
        }

    }
}

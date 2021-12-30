using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPTakeLoot : MonoBehaviour
{
    public MultiPlayer1 multiPlayer1;
    public MultiPlayer2 multiPlayer2;
    public MPArrowStore mPArrowStoreP1;
    public MPArrowStore mPArrowStoreP2;
    public HealthBar healthBarP1;
    public HealthBar healthBarP2;
    private void Awake()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.name == "Player1")
        {

            multiPlayer1 = GameObject.Find("Player1").GetComponent<MultiPlayer1>();
            healthBarP1 = GameObject.FindGameObjectWithTag("P1HealthBar").GetComponent<HealthBar>();
            mPArrowStoreP1 = GameObject.FindGameObjectWithTag("ArrowStoreP1").GetComponent<MPArrowStore>();
            if (this.tag == "HealthLoot")
            {
                Debug.Log(this.tag);
                multiPlayer1.currentHealth = 100;
               // PlayerPrefs.SetInt("CurrentHealth", 100);
                healthBarP1.SetHealth(100);
                Destroy(gameObject);
            }
            else if (this.tag == "ArrowLoot")
            {
                Debug.Log(this.tag);
                //int arrowCount = PlayerPrefs.GetInt("ArrowPlayerHas") + 5;
                //PlayerPrefs.SetInt("ArrowPlayerHas", arrowCount);
                mPArrowStoreP1.arrowPlayer1Has += 5;
                mPArrowStoreP1.UpdateArrowText();
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
        
        if (collision.name == "Player2")
        {
            multiPlayer2 = GameObject.Find("Player2").GetComponent<MultiPlayer2>();
            healthBarP2 = GameObject.FindGameObjectWithTag("P2HealthBar").GetComponent<HealthBar>();
            mPArrowStoreP2 = GameObject.FindGameObjectWithTag("ArrowStoreP2").GetComponent<MPArrowStore>();
            if (this.tag == "HealthLoot")
            {
                Debug.Log(this.tag);
                multiPlayer2.currentHealth = 100;
                healthBarP2.SetHealth(100);
                Destroy(gameObject);
            }
            else if (this.tag == "ArrowLoot")
            {
                Debug.Log(this.tag);
                mPArrowStoreP2.arrowPlayer2Has += 5;
                mPArrowStoreP2.UpdateArrowText();
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }

    }
}

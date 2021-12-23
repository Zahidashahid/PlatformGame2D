using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MPArrowStore : MonoBehaviour
{
    public int arrowPlayer1Has;
    public int arrowPlayer2Has;
    public TMP_Text arrowStoreP1Text;
    public TMP_Text arrowStoreP2Text;
    private void Awake()
    {
        arrowPlayer1Has = 10;
        arrowPlayer2Has = 10;
    }
    void Start()
    {

        arrowPlayer1Has = 10;
        arrowPlayer2Has = 10;
        /*PlayerPrefs.SetInt("ArrowPlayerHas", 10);
        arrowPlayerHas = PlayerPrefs.GetInt("ArrowPlayerHas");*/
        arrowStoreP1Text.text = "X " + arrowPlayer1Has;
        arrowStoreP2Text.text = "X " + arrowPlayer2Has;
    }

    // Update is called once per frame
    public void ArrowUsed()
    {
        if(this.tag == "ArrowStoreP1")
            arrowPlayer1Has -= 1;
        else if (this.tag == "ArrowStoreP2")
            arrowPlayer2Has -= 1;
        UpdateArrowText();


    }
    public void UpdateArrowText()
    {
        if (this.tag == "ArrowStoreP1")
            arrowStoreP1Text.text = "X " + arrowPlayer1Has;
        else if (this.tag == "ArrowStoreP2")
            arrowStoreP2Text.text = "X " + arrowPlayer2Has;


    }
}

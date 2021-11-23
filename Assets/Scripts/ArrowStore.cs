using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArrowStore : MonoBehaviour
{
    public int arrowPlayerHas;
    public TMP_Text arrowStoreText;
    private void Awake()
    {
        
    }
    void Start()
    {
        arrowPlayerHas = 10;
        arrowPlayerHas = PlayerPrefs.GetInt("ArrowPlayerHas");
        /*PlayerPrefs.SetInt("ArrowPlayerHas", 10);
        arrowPlayerHas = PlayerPrefs.GetInt("ArrowPlayerHas");*/
        arrowStoreText.text = "X " + arrowPlayerHas;
    }

    // Update is called once per frame
    public void ArrowUsed()
    {
        arrowPlayerHas -= 1;
        PlayerPrefs.SetInt("ArrowPlayerHas" , arrowPlayerHas);
        arrowStoreText.text = "X " + arrowPlayerHas;
        
    }
}

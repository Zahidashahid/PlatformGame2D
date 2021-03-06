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
        arrowPlayerHas = 10;
        PlayerPrefs.SetInt("ArrowPlayerHas",10);
    }
    void Start()
    {
        
        arrowPlayerHas = PlayerPrefs.GetInt("ArrowPlayerHas");
        /*PlayerPrefs.SetInt("ArrowPlayerHas", 10);
        arrowPlayerHas = PlayerPrefs.GetInt("ArrowPlayerHas");*/
        arrowStoreText.text = "X " + arrowPlayerHas;
    }

    private void Update()
    {
        /*Debug.Log("arrowPlayerHas " + arrowPlayerHas);
        Debug.Log("PlayerPrefs.GetInt(ArrowPlayerHas) " + PlayerPrefs.GetInt("ArrowPlayerHas"));*/
    }
    public void ArrowUsed()
    {
        arrowPlayerHas -= 1;
        PlayerPrefs.SetInt("ArrowPlayerHas", arrowPlayerHas);
        UpdateArrowText();


    }
    public void UpdateArrowText()
    {
        arrowStoreText.text = "X " + arrowPlayerHas;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldGO;
    private bool activeShield;
    void Start()
    {
        activeShield = false;
        shieldGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(!activeShield)
            {
                shieldGO.SetActive(true);
                activeShield = true;
            }
            else
            {
                shieldGO.SetActive(false);
                activeShield = false;
            }
        }
    }
    public bool ActiveShield
    {
        get{
            return activeShield;
        }
        set
        {
            activeShield = value;
        }
    }
}

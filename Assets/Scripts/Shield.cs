using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    PlayerController controls;
    public GameObject shieldGO;
    private  bool activeShield;
    private void Awake()
    {
        controls = new PlayerController(); 
        controls.Gameplay.Shield.performed += ctx => SetShield();
    }
    void Start()
    {
        activeShield = false;
        shieldGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.S))
        {
            shieldGO.SetActive(true);
            activeShield = true; 
            *//*if (!activeShield)
            {
                
            }
            else
            {
                
            }*//*
        }
        else
        {
            shieldGO.SetActive(false);
            activeShield = false;
        }*/
    }
    void SetShield()
    {
         
        if (!activeShield)
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

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}

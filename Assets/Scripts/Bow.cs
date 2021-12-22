using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    //Bow of the Player
    PlayerController controls;
    Vector2 rotateBow;
    public Transform shotPoint;
    public GameObject projectile;

    public float offset;
    public float timeBtwShots;
    public float startTimeBtwShots;
    int arrowLeft;
    public ArrowStore arrowStore;

    private void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.ArowHit.performed += ctx => ArrowShoot();
        controls.Gameplay.RangeAttackGP.performed += ctx => rotateBow = ctx.ReadValue<Vector2>();
        controls.Gameplay.RangeAttackGP.canceled += ctx => rotateBow = Vector2.zero;
  
    }
    void Update()
    {
        Vector3 r = new Vector3(rotateBow.x, rotateBow.y) * 100f * Time.deltaTime;
        transform.Rotate(0f,0f,r.z, Space.World);
        //transform.rotation = Quaternion.Euler(0f, 0f, r.z );
        /*Vector2 difference = Camera.main.ScreenToWorldPoint(m) - transform.position;
        float rotZ = Mathf.Atan2(m.y, m.x) * Mathf.Rad2Deg;
        *//*
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Debug.Log("" + rotZ + offset);*/
        /*Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
         
         arrowLeft = PlayerPrefs.GetInt("ArrowPlayerHas");

         if (arrowLeft > 0)
         {
             if (Input.GetMouseButtonDown(0))
             {
                 arrowStore.ArrowUsed();
                 Instantiate(projectile, shotPoint.position, transform.rotation);

             }
         }*/

    }
    void BowRotate()
    {
        /*Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        // Debug.Log("" + rotZ + offset);
        arrowLeft = PlayerPrefs.GetInt("ArrowPlayerHas");*/
    }
    void ArrowShoot()
    {
        arrowLeft = PlayerPrefs.GetInt("ArrowPlayerHas");

        if (arrowLeft > 0)
        {
            arrowStore.ArrowUsed();
            Instantiate(projectile, shotPoint.position, transform.rotation);
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

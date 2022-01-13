using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    //Bow of the Player
    PlayerController controls;
    Vector3 rotateBow;
    public Transform shotPoint;
    public GameObject projectile;

    public float offset;
    public float timeBtwShots;
    public float startTimeBtwShots;
    public float nextAttackTime;
    bool canAttack;
    int arrowLeft;
    public ArrowStore arrowStore;

    private void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.ArowHit.performed += ctx => ArrowShoot();
        controls.Gameplay.RangeAttackGP.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Gameplay.RangeAttackGP.canceled += ctx => rotateBow = Vector2.zero;



        controls.Gameplay.MouseDirection.performed += ctx => BowRotate(ctx.ReadValue<Vector2>());
        controls.Gameplay.MouseDirection.canceled += ctx => rotateBow = Vector2.zero;

    }
    private void Start()
    {
        nextAttackTime = -1;
        canAttack = true;

    }
    void FixedUpdate()
    {
        if (nextAttackTime <= -1)
        {
            canAttack = true;
        }
        else
        {
            nextAttackTime -= Time.deltaTime;
            canAttack = false;
        }

        Debug.Log("PauseGame.isGamePaused ==  " + PauseGame.isGamePaused);
           
        /* Vector3 r = new Vector3(rotateBow.x, rotateBow.y, rotateBow.z) * 100f * Time.deltaTime;
         Debug.Log("rotateBow.z"+ rotateBow.z);
         Debug.Log("rotateBow.y"+ rotateBow.y);
         transform.Rotate(r ,Space.World);*/
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
    private void Move(Vector2 vector)
    {
        transform.Rotate(vector.x * Vector3.forward + vector.y * Vector3.forward);
    }
    void BowRotate(Vector2 vector)
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.MouseDirection) - transform.position;
        if (PauseGame.isGamePaused == false)
        {
            float rotZ = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            // Debug.Log("" + rotZ + offset);
            arrowLeft = PlayerPrefs.GetInt("ArrowPlayerHas");
        }
            
    }
    void ArrowShoot()
    {
        if (PauseGame.isGamePaused == false)
        {
            arrowLeft = PlayerPrefs.GetInt("ArrowPlayerHas");

            if (arrowLeft > 0 && canAttack)
            {
                arrowStore.ArrowUsed();
                Instantiate(projectile, shotPoint.position, transform.rotation);
                nextAttackTime = 1;
            }
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

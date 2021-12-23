using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MPPlayer1Bow : MonoBehaviour
{
    //Bow of the Player
    PlayerController controls;
    Vector3 rotateBow;
    public Transform shotPoint;
    public GameObject projectile;

    public float offset;
    public float timeBtwShots;
    public float startTimeBtwShots;
    int arrowLeft;
    public MPArrowStore arrowStore;

    private void Awake()
    {
        
        controls = new PlayerController();
        controls.Gameplay.ArrowShootP1.performed += ctx => ArrowShoot();
        controls.Gameplay.RangeAttackPlayer1.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Gameplay.RangeAttackPlayer1.canceled += ctx => rotateBow = Vector2.zero;

    }
    /*void Start()
    {
        arrowStore = GameObject.FindGameObjectWithTag("ArrowStoreP1").GetComponent<MPArrowStore>();
    }*/
    private void Move(Vector2 vector)
    {
        transform.Rotate(vector.x * Vector3.forward + vector.y * Vector3.forward);
    }
  
    void ArrowShoot()
    {
        arrowLeft = arrowStore.arrowPlayer1Has;

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

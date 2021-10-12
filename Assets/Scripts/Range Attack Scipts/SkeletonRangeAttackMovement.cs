using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRangeAttackMovement : MonoBehaviour
{


    private BoxCollider2D boxCollider2d;

    #region Public Variables;
    public GameObject playerObject;
   
    int direction = 1;
    #endregion

    #region Private Variables
    private Transform target;
    private float distance;
    #endregion
    public float nextAttackTime; // after every 2 sec
    public float damage;

    /*private void Awake()
    {
      
    }*/
    private void Start()
    {
        /* currentHealth = maxHealth;
         healthBar.SetMaxHealth(maxHealth);*/
        playerObject = GameObject.Find("Player_Goblin");
        target = playerObject.transform;

    }
    // Update is called once per frame
    void Update()
    {
        Flip();
    }

   
    void Flip()
    {
        distance = Vector2.Distance(transform.position, target.position);
        //Debug.Log(transform.position + "!! " + target.position);
        //Debug.Log("Flip called" + distance);
        Vector3 rotation = transform.eulerAngles;
        rotation.x *= -1;
      /*  if ( transform.position.x == target.position.x )
        {
            Debug.Log("Zero rotaion");
            rotation.y = 0f;
           
        }
        else*/ 
        if ( transform.position.x > target.position.x)//&& direction == 1
        {
           // Debug.Log("180 rotaion");
            rotation.y = 180f;
            direction = 2;

        }
        else if ( transform.position.x < target.position.x)//&& direction == 2
        {
            //Debug.Log("flip");
            rotation.y = 0;
            direction = 1;
        }
        else
        {
            Debug.Log("None rotaion");
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPEnemyShield : MonoBehaviour
{
    public Animator animator;
    private Transform player;
    private float distance;
    public bool activeShield;
    public MPCameraController mPCameraController;
    void Start()
    {
        mPCameraController = GameObject.Find("Camera").GetComponent<MPCameraController>();
        animator = GetComponent<Animator>();
        player = mPCameraController.targets[0].transform;
        activeShield = false;
        animator.SetBool("Sheild", false);
        
        distance = 7;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    private void LateUpdate()
    {
        if (mPCameraController.targets.Count < 1 )
        {
            FindObjectOfType<MPGameOver>().GameOver();
        }
        else
        {
             if (mPCameraController.targets.Count > 1)
            {
                var distanceBtwP2AndEnemy = Vector3.Distance(mPCameraController.targets[1].transform.position, transform.position);
                var distanceBtwP1AndEnemy = Vector3.Distance(mPCameraController.targets[0].transform.position, transform.position);
                if (distanceBtwP1AndEnemy > distanceBtwP2AndEnemy)
                {

                    player = mPCameraController.targets[1].transform;
                }
                else
                {
                    player = mPCameraController.targets[0].transform;
                }

            }
            else if (mPCameraController.targets.Count == 1)
                player = mPCameraController.targets[0].transform;
            if (Vector2.Distance(transform.position, player.position) < distance && animator.GetBool("Attack") == false)
            {
                //Debug.Log("sheild Active !! "  );
                animator.SetBool("Sheild", true);
                activeShield = true;

            }
            else
            {
                animator.SetBool("Sheild", false);
                activeShield = false;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Collision " + collision);
            if (!activeShield)
            {
                animator.SetBool("Sheild", true);
                activeShield = true;
            }

        }
    }

    public bool ActiveShield
    {
        get
        {
            return activeShield;
        }
        set
        {
            activeShield = value;
        }
    }
}


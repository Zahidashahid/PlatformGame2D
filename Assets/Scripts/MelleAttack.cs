using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Attack();
        }
    }
    void Attack()
    {
        //play an attack animation
        //deteck enemies in range of attack
        // demage them
    }
}

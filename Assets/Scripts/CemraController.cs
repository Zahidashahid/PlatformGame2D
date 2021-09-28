using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemraController : MonoBehaviour
{
    public Transform player;
    //public GameObject camera;
   
    private void Update()
    {
        transform.position = new Vector3(player.position.x , player.position.y, transform.position.z);
    }
}

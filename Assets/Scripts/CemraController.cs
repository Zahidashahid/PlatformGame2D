using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemraController : MonoBehaviour
{
    public Transform player;
    //public GameObject camera;
   
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = new Vector3(player.position.x + 8 , player.position.y +5, transform.position.z);
    }
}

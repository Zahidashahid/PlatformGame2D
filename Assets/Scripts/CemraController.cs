using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemraController : MonoBehaviour
{
    public Transform player;
    float smoothSpeed = 0.125f;
    //public GameObject camera;
    private void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosiiton = new Vector3(player.position.x + 8 , player.position.y +5, transform.position.z);
        Vector3 smoothedPosiiton = Vector3.Lerp(transform.position, desiredPosiiton, smoothSpeed);
        transform.position = smoothedPosiiton;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gifts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if ( collision.tag == "Cherry")
        {
            Destroy(collision.gameObject);
        }
        if ( collision.tag == "Gem")
        {
            Destroy(collision.gameObject);
        }

    }
     
}

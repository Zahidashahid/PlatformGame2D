using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpwaner : MonoBehaviour
{
    public GameObject skeletonSpwan;
    float randX;
    Vector2 whereToSpwan;
    float spwanRate = 45f;
    float nextSpwan = 0.0f;
  
    void Update()
    {
        if(Time.time > nextSpwan)
        {
            nextSpwan = Time.time + spwanRate;
            randX = Random.Range( 158 , 184);
            whereToSpwan = new Vector2(randX, transform.position.y);
            Instantiate(skeletonSpwan, whereToSpwan, Quaternion.identity);
        }
    }
    
}

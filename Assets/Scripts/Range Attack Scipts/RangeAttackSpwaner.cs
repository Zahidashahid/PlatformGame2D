using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackSpwaner : MonoBehaviour
{
    public GameObject skeletonRangeAttackSpwan;
    float randX;
    Vector2 whereToSpwan;
    float spwanRate = 45f;
    float nextSpwan = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpwan)
        {
            nextSpwan = Time.time + spwanRate;
            randX = Random.Range(transform.position.x -10, transform.position.x);
            whereToSpwan = new Vector2(randX, transform.position.y);
            Instantiate(skeletonRangeAttackSpwan, whereToSpwan, Quaternion.identity);
        }
    }
}

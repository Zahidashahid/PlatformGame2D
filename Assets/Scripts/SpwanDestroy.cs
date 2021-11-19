using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanDestroy : MonoBehaviour
{
    public float lifeTime = 40f;
    void Start()
    {
        Invoke("DestroyEnemy", lifeTime);
    }

    // Update is called once per frame
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

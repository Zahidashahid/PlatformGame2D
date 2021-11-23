using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    //Bow of the Player
    public Transform shotPoint;
    public GameObject projectile;

    public float offset;
    public float timeBtwShots;
    public float startTimeBtwShots;
    int arrowLeft;
    public ArrowStore arrowStore;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        // Debug.Log("" + rotZ + offset);
        arrowLeft = PlayerPrefs.GetInt("ArrowPlayerHas");

        if (arrowLeft > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                arrowStore.ArrowUsed();
                Instantiate(projectile, shotPoint.position, transform.rotation);

            }
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public float offset;
    public Transform shotPoint;
    public GameObject projectile;

    public float timeBtwShots;
    public float startTimeBtwShots;

    // Update is called once per frame
    void Update()
    {

        Vector3 bowPosition = transform.position;
        //Vector3 mousePosition = Camera.main.ViewportToScreenPoint(Input.GetKey(KeyCode.RightArrow));
        Vector3 mousePosition = Camera.main.ViewportToScreenPoint(Input.mousePosition); // when we use mouse
        Vector3 difference = mousePosition - bowPosition;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Debug.Log(" Z Rotation of arrow " + rotZ);
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ );

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
        }

        /*if (timeBtwShots <= 1)
        {
            
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }*/
        
     /*   if (canRotate == true)
        {

            myTransform.Rotate(0, (mousePoint.y / 10) * Time.deltaTime * rotationSpeed, 0);

        }

        if (canTranslate == true)
        {

            myTransform.Translate(new Vector2(-1,  0) * arrowSpeed * Time.deltaTime);

        }*/

    }
}


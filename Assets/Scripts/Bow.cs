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

    /*PlayerMovement playerMovement; // Refer to script
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    public float speed;*/
    // Update is called once per frame
    void Update()
    {

        Vector3 bowPosition = transform.position;
        //Vector3 mousePosition = Camera.main.ViewportToScreenPoint(Input.GetKey(KeyCode.RightArrow));
       // Vector3 mousePosition = Camera.main.ViewportToScreenPoint(Input.mousePosition); // when we use mouse
       // Vector3 difference = mousePosition - bowPosition;
        Vector3 difference = Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        Debug.Log("" + rotZ + offset);
        if (Input.GetMouseButtonDown(0))
        {/*
            if (playerMovement.PlayerMovingDirection() == 1)
            {
                spriteRenderer.flipX = true;
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            else
            {
                spriteRenderer.flipX = false;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }*/
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

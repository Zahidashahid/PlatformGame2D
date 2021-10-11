using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{/*
    #region Public variables;
    public GameObject arrow;
    public LayerMask rayCastMask;
    public Rigidbody2D rigidBody;
    public Transform shotPoint;
    public Transform rayCast;
    public float damage;
    public float rayCastLength;
    public float nextAttackTime; // after every 2 sec
    public float attackDistance; // arrow will be possible when   distance is 7.5 b/w arrow and player
    public float launchForce ;
    public bool hasHit;
    #endregion
 
    #region private variables;
    private bool inRange; // check player in range
    private GameObject target;
    private float distance; // stores distance btw player and arrrow
    #endregion

    *//*public string enemyTag;
    public float torque;*//*
    void Update()
    {
        //Check for the wait time that is 2 seconds 
        if(nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }
        else
            nextAttackTime = 2f;
        if (inRange && nextAttackTime < 0) // if player is in arrow zone it will continue instantiating arrows after every 2 seconds.
        {
            ArrowLogic();
            inRange = true;
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
            newArrow.GetComponent<Rigidbody2D>().AddRelativeForce( new Vector2(0f, -900f)); // -900f is  speed of arrow 

           // GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }
       
                Vector2 bowPosition = transform.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) ;
                Vector2 direction = mousePosition - bowPosition;
                transform.right = direction;
         if(Input.GetMouseButtonDown(0))
         {
             Shoot();
         }
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rigidBody.velocity.y, rigidBody.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
       
    }
    void ArrowLogic() // Arrow attack and instantiate
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log("Value of distance is " + distance);
        if (attackDistance >= distance)
        {

            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation); // Instantiate arrow 
            newArrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -900f)); //-900f is speed of arrow 
            inRange = true;
        }
        else
            inRange = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) // Start throwning arrow when player entered in arrow zone i.e trigger area
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
            Debug.Log("player entred in arrow danger zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            ArrowLogic();
        }
    }

    void Fly()
    {
        rigidBody.isKinematic = false;  

    } 
    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rigidBody.velocity = Vector2.zero;  
        rigidBody.isKinematic = true;
            
    }*/
}

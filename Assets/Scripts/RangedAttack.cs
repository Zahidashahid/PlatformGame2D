using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject arrow;

    private bool inRange; // check player in range
    public float damage;
    public float attackDistance; // arrow will be possible when   distance is 7.5 b/w arrow and player
    private float distance; // stores distance btw player and arrrow
    public float rayCastLength;
    public float nextAttackTime; // after every 2 sec

    private RaycastHit2D hit;
    private GameObject target;
    public Transform rayCast;
    public LayerMask rayCastMask;
  
    // Update is called once per frame
    void Update()
    {
        //Check for the wait time that is 2 seconds 
        if(nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }
        if (inRange && nextAttackTime < 0) // if player is in arrow zone it will continue instantiating arrows after every 2 seconds.
        {
           
            ArrowLogic();
            inRange = true;
            nextAttackTime = 2f ;
            Debug.Log(" hit is " + hit.collider != null);
        }
        
        /*if (Input.GetKeyDown(KeyCode.I)) 
        {

            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
            newArrow.GetComponent<Rigidbody2D>().AddRelativeForce( new Vector2(0f, -900f));
        }*/
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
}

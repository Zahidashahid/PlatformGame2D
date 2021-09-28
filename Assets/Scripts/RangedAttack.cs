using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject arrow;

    private bool inRange; // check player in range
    public float damage;
    private float attackDistance; 
    private float distance; // stores distance btw player and arrrow
    public float rayCastLength;

    private RaycastHit2D hit;
    private GameObject target;
    public Transform rayCast;
    public LayerMask rayCastMask;
  
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
           

        }
        //When Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
            inRange = true;
        }
        // Arrow attack
        if (Input.GetKeyDown(KeyCode.I))
        {

            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
            newArrow.GetComponent<Rigidbody2D>().AddRelativeForce( new Vector2(0f, -900f));
        }
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
      /*  if (attackDistance >= distance )
        {*/

            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation); // Instantiate arrow 
            newArrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -900f)); //-900f is speed of arrow 

       // }
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision) // Start throwning arrow when player entered in arrow zone i.e trigger area
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
            Debug.Log("player entred in arrow danger zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            EnemyLogic();

        }
    }
}

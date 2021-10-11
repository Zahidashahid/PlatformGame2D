using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBow : MonoBehaviour
{
    public float offset;
    public float timeBtwShots;
    public float startTimeBtwShots;
    public float damage;
    public float attackDistance; // arrow will be possible when   distance is 7.5 b/w arrow and player
    public float nextAttackTime; // after every 2 sec

    public Transform shotPoint;
    Vector3 playerPosition;
    Vector3 BowPosition;
    GameObject playerObject;
    public GameObject projectile;
    public GameObject bowObj;
    private GameObject target;
    public GameObject arrow;
    #region private variables;
    private bool inRange; // check player in range
    private float distance; // stores distance btw player and arrrow
    #endregion
    private void Start()
    {
        playerObject = GameObject.Find("Player_Goblin");
        playerPosition = playerObject.transform.position;
        BowPosition = bowObj.transform.position;
    }
    void Update()
     {
        if(inRange)
        {
            if(nextAttackTime < 0)
            {
                nextAttackTime = 2;
                ArrowLogic();
            }
            else
            {
                nextAttackTime -= Time.deltaTime;
                       
            }
        }
        // Debug.Log("" + rotZ + offset);
      /*  if (Input.GetMouseButtonDown(0))
        {
            

        }
*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
     {
       //  StartCoroutine(Attack());
        if (collision.tag == "Player")
        {
            Debug.Log("Enter in Range attack zone");
            target = collision.gameObject;
            Debug.Log("player entred in arrow danger zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            inRange = true;
            ArrowLogic();
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
     {
        if (collision.tag == "Player")
        {
            Debug.Log("player exiting in arrow danger zone");
            inRange = false;
        }
    }
    void ArrowLogic() // Arrow attack and instantiate
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log("Value of distance is " + distance);
        if (attackDistance >= distance)
        {
            inRange = true;
            ShootArrow();
        }
        else
            inRange = false;
    }
    void ShootArrow()
    {
        Debug.Log("In shoot function");
        Instantiate(projectile, shotPoint.position, playerObject.transform.rotation);

       // GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation); // Instantiate arrow 
        //newArrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, -900f));
    }

}

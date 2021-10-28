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
    Vector3 targetDirection;
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
        nextAttackTime = -1; 
        playerObject = GameObject.Find("Player_Goblin");
        playerPosition = playerObject.transform.position;
        BowPosition = bowObj.transform.position;
       
    }
    void Update()
    {
        if (inRange)
        {
            //Debug.Log("inRange" + inRange);
            if (nextAttackTime <= -1)
            {
                ArrowLogic();
                // Debug.Log("nextAttackTime" + nextAttackTime);
            }
            else
            {
                nextAttackTime -= Time.deltaTime;
            }
        }
        targetDirection = playerObject.transform.position - transform.position;
         float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        /*Debug.Log("Direction" + targetDirection);
        Debug.Log("rot" + rotZ);*/
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    private void OnTriggerEnter2D(Collider2D collision)
     {
       //  StartCoroutine(Attack());
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
            Debug.Log("player entred in arrow danger zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            inRange = true;
            nextAttackTime = -1;
            //ArrowLogic();
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
     {
        if (collision.tag == "Player")
        {
            Debug.Log("player exiting in arrow danger zone");
            inRange = false;
            nextAttackTime = -1;
        }
     }
    void ArrowLogic() // Arrow attack and instantiate
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log("Value of distance is " + distance);
        attackDistance = 13;
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
        Debug.Log("In shoot function" + transform.rotation);
        Debug.Log("nextAttackTime :-" +  nextAttackTime);
   
        nextAttackTime = 2;
        Debug.Log("nextAttackTime :-" + nextAttackTime);
        if (transform.position.x >= target.transform.position.x)
        {
            /*
             *  when player is at left side of ranged attack emeny;
             *  taeget direction will be change to enemy(self/skeleton) subtract target(Player) if player is at right side of enemy vise versa.
             */
            targetDirection =   transform.position - playerObject.transform.position;
            float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Debug.Log(rotZ + "Rotation");
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            Debug.Log(transform.rotation + " new");
           // Instantiate(projectile, shotPoint.position,  transform.rotation);
        }
        Instantiate(projectile, shotPoint.position, transform.rotation);
        Debug.Log("Arrow instantiated");
    }
}

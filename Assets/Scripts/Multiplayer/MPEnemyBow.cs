using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPEnemyBow : MonoBehaviour
{
    /*
       The bow contoller of range attack by skeleton for multiplayer 
     */
    public float offset;
    public float timeBtwShots;
    public float startTimeBtwShots;
    public float damage;
    public float attackDistance; // arrow will be possible when   distance is 7.5 b/w arrow and player
    public float nextAttackTime; // after every 2 sec
    public MPRangeAttackMovement mPRangeAttackMovement; 
    public MPCameraController mPCameraController; 

    public Transform shotPoint;
    public GameObject target;
    // public List<GameObject> player;
    Vector3 BowPosition;
    Vector3 targetDirection;
    //GameObject playerObject;
    public GameObject projectile;
    public GameObject bowObj;
    public GameObject arrow;
    #region private variables;
    public bool inRange; // check player in range
    private float distance; // stores distance btw player and arrrow
    #endregion
    private void Start()
    {
        nextAttackTime = -1;
        BowPosition = bowObj.transform.position;
        mPCameraController = GameObject.Find("Camera").GetComponent<MPCameraController>();

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
       
    }
    private void LateUpdate()
    {
        for (int a = 0; a < mPCameraController.targets.Count; a++)
        {
            if (mPCameraController.targets.Count > 1)
            {
                var distanceBtwP2AndEnemy = Vector3.Distance(mPCameraController.targets[a + 1].transform.position, transform.position);
                var distanceBtwP1AndEnemy = Vector3.Distance(mPCameraController.targets[a].transform.position, transform.position);
                if (distanceBtwP1AndEnemy > distanceBtwP2AndEnemy)
                {

                    targetDirection = mPCameraController.targets[1].transform.position - transform.position;
                }
                else
                {
                    targetDirection = mPCameraController.targets[0].transform.position - transform.position;
                }
                break;
            }
        }

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
            // Debug.Log("player entred in arrow danger zone");
            //collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            inRange = true;
            Debug.Log("Inrage =" + inRange);
            //nextAttackTime = -1;
            //ArrowLogic();
        }
    }
    /* private void OnTriggerExit2D(Collider2D collision)
     {
        if (collision.tag == "Player")
        {
            Debug.Log("player exiting in arrow danger zone");
            inRange = false;
            Debug.Log("Inrage =" + inRange);
            nextAttackTime = -1;
        }
     }*/
    void ArrowLogic() // Arrow attack and instantiate
    {
        Debug.Log("null =" + target  != null);
        if (target  != null)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);
            Debug.Log("target is " + target.name);
            Debug.Log("Value of distance is " + distance);
            attackDistance = 40;
            if (attackDistance >= distance)
            {
                inRange = true;
                // Debug.Log("Inrage =" + inRange);
                ShootArrow();
            }
            else
            {
                inRange = false;
                //Debug.Log("Inrage =" + inRange);
            }
        }
        else
        {
            //Select new enemy(player) as a target
            var distanceBtwP1AndEnemy = Vector3.Distance(mPCameraController.targets[0].transform.position, transform.position);
            var distanceBtwP2AndEnemy = Vector3.Distance(mPCameraController.targets[1].transform.position, transform.position);
            if (distanceBtwP1AndEnemy > distanceBtwP2AndEnemy)
            {
                target = mPCameraController.targets[1];
            }
            else
            {
                target = mPCameraController.targets[0];
            }
            
        }
    }
    void ShootArrow()
    {
        Debug.Log("In shoot function" + transform.rotation);
        Debug.Log("nextAttackTime :-" +  nextAttackTime);

        nextAttackTime = 2;
        //Debug.Log("nextAttackTime :-" + nextAttackTime);

        var distanceBtwP1AndEnemy = Vector3.Distance(mPCameraController.targets[0].transform.position, transform.position);
        var distanceBtwP2AndEnemy = Vector3.Distance(mPCameraController.targets[1].transform.position, transform.position);
        Debug.Log(transform.position.x + "  :-" + mPCameraController.targets[1].transform.position.x);
        if (distanceBtwP1AndEnemy > distanceBtwP2AndEnemy)
        {
            /*--------------- If Player 2 is near enemy -------------------- */
            /* Debug.Log( " P2 selected :-"  );
             Debug.Log(transform.position.x + " Distance :-" + player[1].transform.position.x);
              Debug.Log("nextAttackTime :-" + nextAttackTime);*/
                mPRangeAttackMovement.direction = 2;
                /*
                 *  when player is at left side of ranged attack emeny
                 *  target direction will be change to enemy(self/skeleton) subtract target(Player) if player is at right side of enemy vise versa.
                 */
                target = mPCameraController.targets[1];
                targetDirection = transform.position - mPCameraController.targets[1].transform.position;
                float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                //Debug.Log(rotZ + "Rotation");
                transform.rotation = Quaternion.Euler(0f, 180f, -rotZ + offset);
                /*
                 * "-" is used to rotation towards player so that collider also change with arrow left moving
                 * 180f to change arrow towards left 
                 */
                /**/
                //Debug.Log(transform.rotation + " new");
            Instantiate(projectile, shotPoint.position, transform.rotation);
        }
        else
        {
            /*Debug.Log("In else  :-");
            Debug.Log(" P1 selected :-");*/
            //Debug.Log(transform.position.x +"In   :-" + player[0].transform.position.x);

            
                /*
                 *  when player is at left side of ranged attack emeny
                 *  target direction will be change to enemy(self/skeleton) subtract target(Player) if player is at right side of enemy vise versa.
                 */
                mPRangeAttackMovement.direction = 2;
                targetDirection = transform.position - mPCameraController.targets[0].transform.position;
                float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                Debug.Log(rotZ + "Rotation");
                transform.rotation = Quaternion.Euler(0f, 180f, -rotZ + offset);
                target = mPCameraController.targets[0];
                /*
                 * "-" is used to rotation towards player so that collider also change with arrow left moving
                 * 180f to change arrow towards left 
                 */
                /**/
            Instantiate(projectile, shotPoint.position, transform.rotation); 
        }
    }
}

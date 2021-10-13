using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask playerLayers;
    public AudioSource meleeAttackSound;
    private bool inRange; // check player in range
    public float damage;
    public float attackDistance; // arrow will be possible when   distance is 7.5 b/w arrow and player
    private float distance; // stores distance btw player and arrrow
    public float nextAttackTime; // after every 2 sec
    private bool cooling;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        nextAttackTime = -1;
        /* if (nextAttackTime > 0)
         {
             nextAttackTime -= Time.deltaTime;
         }
         else
             nextAttackTime = 2f;
         if (inRange && nextAttackTime < 0) // if player is in range of skeleton it will atack
         {

             MelleAttackLogic();
             inRange = true;

         }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if (nextAttackTime <= -1)
            {
                MelleAttackLogic();
                nextAttackTime = 2;
                // Debug.Log("nextAttackTime" + nextAttackTime);
            }
            else
            {
                nextAttackTime -= Time.deltaTime;
            }
        }
        else
        {
            nextAttackTime = -1;
        }
    }
    void MelleAttackLogic() // melle attack 
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log("Value of distance is " + distance);
        Debug.Log("Value of attack distance is " + attackDistance);
        attackDistance = 6;
        if (attackDistance >= distance)
        {
            inRange = true;
            StartCoroutine(Attack());
        }
        else
            inRange = false;
    }

    IEnumerator Attack()
    {
        animator.SetBool("Attack2", true);
      //  animator.SetBool("CanWalk", false);
        yield return new WaitForSeconds(0.2f);
        meleeAttackSound.Play();
        animator.SetBool("Attack2", false);
       // animator.SetBool("CanWalk", true);
        Debug.Log("In Attack function ");
        //deteck enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        // demage them
        foreach(Collider2D player in hitEnemies)
        {
            // Destroy();
            Debug.Log("Skelton hit " + player.name);
            if (player.tag == "Player")
            {
                Debug.Log("We hit player");
                player.GetComponent<PlayerMovement>().TakeDemage(40);
                break;
            }
           
           
        }
    }
    void OnDrawGizmoSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
            Debug.Log("player entred in Skeleton zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
           // MelleAttackLogic();
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
            nextAttackTime = -1;
        }
    }
    /*   public void TriggerCooling()
       {
           cooling = true;

       }*/
}

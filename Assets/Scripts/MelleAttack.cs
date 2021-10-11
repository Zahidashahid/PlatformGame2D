using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask playerLayers;

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
        if (nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }
        else
            nextAttackTime = 2f;
        if (inRange && nextAttackTime < 0) // if player is in range of skeleton it will atack
        {

            MelleAttackLogic();
            inRange = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
         
        

        
    }
    void MelleAttackLogic() // melle attack 
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log("Value of distance is " + distance);
        Debug.Log("Value of attack distance is " + attackDistance);
      
    }

    IEnumerator Attack()
    {
        animator.SetBool("Attack", true);
      //  animator.SetBool("CanWalk", false);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attack", false);
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
            }
            break;
           
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

    private void OnTriggerEnter2D(Collider2D collision) // Start throwning arrow when player entered in arrow zone i.e trigger area
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
            Debug.Log("player entred in Seleton zone");
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            MelleAttackLogic();


        }
    }
    public void TriggerCooling()
    {
        cooling = true;

    }
}

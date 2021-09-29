using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.05f;
    public LayerMask playerLayers;

    private bool inRange; // check player in range
    public float damage;
    public float attackDistance; // arrow will be possible when   distance is 7.5 b/w arrow and player
    private float distance; // stores distance btw player and arrrow
    public float rayCastLength;
    public float nextAttackTime; // after every 2 sec

    private GameObject target;
    public Transform rayCast;
    public LayerMask rayCastMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if(Input.GetKeyDown(KeyCode.M))
        {
            Attack();
        }
        if (nextAttackTime > 0)
        {
            nextAttackTime -= Time.deltaTime;
        }
        else
            nextAttackTime = 2f;
        if (inRange && nextAttackTime < 0) // if player is in arrow zone it will continue instantiating arrows after every 2 seconds.
        {

            MelleAttackLogic();
            inRange = true;
      S
        }
*/
        
    }
    void MelleAttackLogic() // melle attack 
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log("Value of distance is " + distance);
        if (attackDistance >= distance)
        {

            Attack(); 
            inRange = true;
        }
        else
            inRange = false;
    }

    void Attack()
    {
        //play an attack animation
       // animator.SetTrigger("Attack");
        animator.SetBool("Attack", true);
        //deteck enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        // demage them
        foreach(Collider2D enemy in hitEnemies)
        {
           // Destroy();
            Debug.Log("We hit player");
            enemy.GetComponent<PlayerMovement>().TakeDemage(40);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask playerLayers;
    public float attackRange = 2f;
    public float damage;
    public float attackDistance; 
    public float nextAttackTime; // after every 2 sec
    private float distance; // stores distance btw player and skeleton
    private bool inRange; // check player in range
    private bool cooling;
    private GameObject target;
    SkeletonEnemyMovement skeletonEnemyMovement;
    //public AudioSource meleeAttackSound;
    // Start is called before the first frame update
    void Start()
    {
        nextAttackTime = -1;
        skeletonEnemyMovement = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<SkeletonEnemyMovement>();
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
                 Debug.Log("nextAttackTime" + nextAttackTime);
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
        attackDistance = 6;/*
        Debug.Log("Value of distance is " + distance);
        Debug.Log("Value of attack distance is " + attackDistance);*/
        
        if (attackDistance >= distance)
        {
            Debug.Log("If called ");
            inRange = true;
            nextAttackTime = -1;
            //skeletonEnemyMovement.Flip();
            StartCoroutine(Attack());
        }
        else
            inRange = false;
        Debug.Log("Value inRange " + inRange);
    }

    IEnumerator Attack()
    {
        Debug.Log("Attack called ");
        animator.SetBool("Attack", true);
      //  animator.SetBool("CanWalk", false);
        yield return new WaitForSeconds(0.2f);
        SoundEffect.sfInstance.audioS.PlayOneShot(SoundEffect.sfInstance.meleeAttackSound);
        animator.SetBool("Attack", false);
       // animator.SetBool("CanWalk", true);
        Debug.Log("In Attack function ");
        //deteck enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        // demage them
        foreach(Collider2D player in hitEnemies)
        {
            // Destroy();
            Debug.Log("InAttack Skelton hit " + player.name);
            if (player.tag == "Player")
            {
                string difficultyLevel = PlayerPrefs.GetString("DifficultyLevel");
                Debug.Log("We hit player");
                if (difficultyLevel == "Easy")
                {
                    player.GetComponent<PlayerMovement>().TakeDamage(30);
                }
                else if (difficultyLevel == "Medium")
                {
                    player.GetComponent<PlayerMovement>().TakeDamage(40);
                }
                else if (difficultyLevel == "Hard")
                {
                    player.GetComponent<PlayerMovement>().TakeDamage(60);
                }
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
            //collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
           
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

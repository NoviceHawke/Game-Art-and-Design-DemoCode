
using UnityEngine;

public class Enemy_SwordAttack : MonoBehaviour
{/* READ ME This code is for a simple close range attack, should people show interest i will add a Ranged attack code. 
  * CREATE YOUR ENEMY MOVEMENT FIRST
   this code should be placed onto your main Enemy, you will need to create an
   empty object as a child of of your Enemy, placed where the attack part of your Enemy  animation hits 
   you will also need atleast one type of animation for your enemy's attack.  this code uses two.
    you will need to create events in your animation at the point you want the damage to be applyed
    to your player. 
    in your animator make a trigger for each attack you have 
 */


//Var related to Enemy's direct attack
    [Header("Attack Data")] 
   public bool canAttack;
    public float attackTime;
    public Transform attackPoint;
    public int damage;
  //Vars realted to Enemy looking for the player
    [Header ("Player Check Data")]
    public bool closeRange;
    public float attackRange;
    public LayerMask player;
   
    [Header("Private Data")]
    private Animator animator;
    private float cooldownTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        cooldownTimer = attackTime;
        closeRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        //cool down stops the enemy from attacking too often 
        cooldownTimer += Time.deltaTime;
       // plays if the player is within range
        if (inSights())
        {

            //randomly assigns one of two attacks. if you only have one animation then simply use the SetTrigger for it
            if (cooldownTimer >= attackTime)
            {
                int r = Random.Range(0, 10);
                if (r > 5)
                {
                    animator.SetTrigger("Attack1");
                    cooldownTimer = 0;
                }

                else
                {
                    animator.SetTrigger("Attack2");
                    cooldownTimer = 0;
                }


            }
        }
    }

    //shows us the attack range for Debuging
    /*private void OnDrawGizmos()
      {
          Gizmos.DrawWireSphere(attackPoint.position, attackRange);
      }*/


    private bool inSights()
    {//checks if the player is within range for a close attack. 
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, player);

        if (hit != null && hit.tag == "Player")
        {
            closeRange = true;
            GetComponent<EnemyMove>().wait = true;
            return true;

        }
       
        else
        {
            closeRange = false;

           if (GetComponent<EnemyMove>().wait == true)
            { closeRange = false;
                GetComponent<EnemyMove>().wait = false;
            }


            return false;
        }
    }

    public void AttackDone()
    {
        //applys damage if the player is still within the attack's range must be assigned useing an animation event
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, player);
        if (hit != null)
        {

            hit.GetComponent<PlayerHealth>().PlayerDamanged(damage);
        }
    }
}

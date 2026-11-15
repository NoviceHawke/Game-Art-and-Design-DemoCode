using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{/* READ ME
  For this code to work you will need your Main Enemy and Two Empty Objects to be the Child on a "enemy group" to allow 
    for ease with Prefabs, 
    your Main Enemy Object will need a Ridgebody2d,Animator, and some type of Colider.  this script creates a simple stright path
    that the enemy will patrol if you want your enemy to walk on stairs  or move up and down you will need to create
    new code  to allow for it. 

    you will also need to create an idle and walking animation for this code 
    in your animator use a Moving Bool to set if the Animation is moving or idle 
  
  */


    [Header("Moving")]// these points set where you enemy is moving to
    public Transform pointA;
    public Transform pointB;
    private Transform currentPoint;


    [Header("Data")]
    public Animator anim;
    public Rigidbody2D rb;
    public float speed;
    public bool wait;
    public float waitTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= rb.GetComponent<Animator>();
        //sets us to walk to our first point you will want this point to be in the direction your Enemy is faceing. 
        currentPoint = pointA;
        wait = false;

    }

    void Update()
    {//checks if the player should be Idling
        if (!wait)
        {//sets the moving animation
            if (anim.GetBool("Moving") == false)
            {
                anim.SetBool("Moving", true);
            }
        //moves the Enemy
            rb.linearVelocityX = speed;

            //checks if the Enemy as reached the last point in the patrol, optional to have them idle before moveing to the next point 
            if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == pointA)
            {
                Flip();
                speed = -1 * speed;
                currentPoint = pointB;
              //  StartCoroutine(WaitTimes());

            }
            else if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == pointB)
            {
                Flip();
                speed = -1 * speed;
                currentPoint = pointA;
                //StartCoroutine(WaitTimes());
            }
           

            }
        else
        {//sets the player to Idle if they had been moving. 
            if (anim.GetBool("Moving"))
            {
                anim.SetBool("Moving", false);
                rb.linearVelocityX = 0;
            }
        }


    }
 // Flips the Enemy sprite 
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    // Allows for Idle time if used
    private IEnumerator WaitTimes() {
        wait= true;
        yield return  new WaitForSeconds(waitTime);
        wait= false;
    }
}

using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3;
    [Header("Attacks")]
    private int attackType;
    public float waitTime;
    public int attackTime;
    public Transform[] spawnPoints;
    public GameObject bullet;
    [Header("Raycast")]
    public Vector3 tboxSize;
    public Vector2 boxSize;
    public LayerMask player;
    public float rayDistence;

    
    void Update()
    {
        //Checks for if the Enemy has 0 health/ was killed
        if (GetComponentInChildren<EnemyHealth>() == null) 
        { Destroy(gameObject); }

        waitTime += Time.deltaTime;

        //checks if the attack timer is based and the player is seen by the enemy
        if (waitTime >= attackTime&& inSights())
        {
            RollAttack();
            attackTime = Random.Range(1, 3);

            waitTime = 0;
        }
    }

    //moves the Boss ship
    private void FixedUpdate()
    { transform.Translate(Vector2.right * speed * Time.deltaTime); }



    //assigns and triggers a random attack pattern
    private void RollAttack() {
        attackType = Random.Range(1, 4);

        switch (attackType) {

            case (1):
                int attackplace = Random.Range(1, spawnPoints.Length);
                Instantiate(bullet, spawnPoints[attackplace].position, Quaternion.identity);

                break;
                case(2):
                int numattacks= Random.Range(1, spawnPoints.Length);
                for(int i=0; i< numattacks; i++)
                {
                    int c = Random.Range(1, spawnPoints.Length);
                    Instantiate(bullet, spawnPoints[c].position, Quaternion.identity);
                }
          
                break;
            case (3):
                for(int t =0; t<spawnPoints.Length; t++)
                {
                    Instantiate(bullet, spawnPoints[t].position, Quaternion.identity);
                }
            
                break;
            default:
                int attack = Random.Range(1, spawnPoints.Length);
                Instantiate(bullet, spawnPoints[attack].position, Quaternion.identity);

                break;


        }
    
    }
    //used only in engin to see the raycast range
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, tboxSize);
    }


    //checks if the player is within the attack range
    public bool inSights()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
           transform.position,//The center point of our box collider
            boxSize,//the size of the box collider
            0, //no Angle needed
            Vector2.down,//the direction under our player
           rayDistence,//distence
            player);
        return hit.collider != null;
        }
   
    //changes the ship's movement direction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bound")
        {
            speed *= -1;
        }
    }
}
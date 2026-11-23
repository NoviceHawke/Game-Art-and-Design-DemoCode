using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    

    public Transform attackSpawn;

    public GameObject bullet;

    public float waitTime;
    public float attackPause;

    [Header("Raycast")]
    public float sightLine;
    public LayerMask player;
    public float rayDistence;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackPause = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    { 

                waitTime += Time.deltaTime;
        //checks attack timer and if player is within sight range
        if (waitTime >= attackPause && inSights())
                {

                   
            Shoot();
                    waitTime = 0;
                }
            
        
    }
    //only in engin shows the line of sight
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
   

        { Gizmos.DrawLine(attackSpawn.position, new Vector3(attackSpawn.position.x, attackSpawn.position.y- sightLine,  attackSpawn.position.position.z)); }
    }

    //Checks if player is in enemy's range
    public bool inSights()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(attackSpawn.position, new Vector3(attackSpawn.position.x, attackSpawn.position.y - sightLine, attackSpawn.position.z), rayDistence, player
            );
       
        return raycastHit.collider != null;
    }

    //fires attack
    public void Shoot()
    {
        Instantiate(bullet, attackSpawn.position, Quaternion.identity);

    }
}

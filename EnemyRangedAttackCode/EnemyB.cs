using UnityEngine;

public class EnemyB : MonoBehaviour
{//This Code is for Simple Enemy Bullets. you can name yours differently then i have mine
    public int damage;
    public Rigidbody2D rb;
    public float speed = -5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocityY = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.tag == "Player")
            {

                collision.GetComponent<ShipHealth>().HurtPlayer(damage);          
                Destroy(gameObject);
            }

            else if (collision.tag == "Bound")
                Destroy(gameObject);
        

    }
}
    


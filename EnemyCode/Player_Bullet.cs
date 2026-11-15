using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    /* READ ME: This code should be used on a Bullet Prefab
     your bullet will need a rigdetbody2D and some type of collider set to Trigger 
    it should have a Tag as Bullet*/

    public Rigidbody2D rigidBody2D;

    public float speed;
    public int damage;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        rigidBody2D.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy_Health>().DoDamage(damage);
        }

        Destroy(gameObject);
    }
}

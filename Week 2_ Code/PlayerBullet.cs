using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocityY = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bound") {
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy") { 
        Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}

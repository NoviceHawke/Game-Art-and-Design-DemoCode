using UnityEngine;

public class EmemyMove : MonoBehaviour
{
    public float speed;
    public float height;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bound") { 
        transform.position= new Vector3(transform.position.x, transform.position.y-height, transform.position.z );
            speed *= -1;
        }
    }
}

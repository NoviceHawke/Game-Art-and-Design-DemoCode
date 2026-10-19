using UnityEngine;

public class AddScore : MonoBehaviour
{
	public int points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            GameManager.instance.AddScore(points);
            Destroy(gameObject);

        }
    }
}

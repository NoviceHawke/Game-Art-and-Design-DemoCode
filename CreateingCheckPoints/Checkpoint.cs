using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(GameManager.instance.currentCheckPoint != transform.position)
            {
                GameManager.instance.SetNewCheckPoint(transform.position);

            }

        }
    }
}

using UnityEngine;

public class Checkpoint : MonoBehaviour
{// to use this code you will need a game object with a 2D collider on it. this collider should be set to "Trigger" 
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

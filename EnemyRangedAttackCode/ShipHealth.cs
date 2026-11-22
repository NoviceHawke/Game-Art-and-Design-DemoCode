using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HurtPlayer(int damage)
    {
        SpaceManager.instance.playerHealth-=damage;
        if (SpaceManager.instance.playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        

        }

    }





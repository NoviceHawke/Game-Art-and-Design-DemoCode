using UnityEngine;

public class AddHealth : MonoBehaviour
{
	public HealthPickup data;
	//public float health;
	public SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
		sr.sprite = data.img;
    }
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{

			GameManager.instance.AddHealth(data.health);
			Destroy(gameObject);

		}
	}
}

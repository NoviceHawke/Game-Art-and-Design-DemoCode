using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
	public float damage;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{

			collision.GetComponent<PlayerHealth>().PlayerDamange(damage);

		}
	}
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputAction shoot;
    public InputActionAsset shipInput;

    public GameObject bulletPrefab;


	private void OnEnable()
	{
		shipInput.FindActionMap("2DShip").Enable();
	}
	private void OnDisable()
	{
		shipInput.FindActionMap("2DShip").Disable();
	}

    private void Awake()
    {
        shoot = shipInput.FindAction("Shoot");
    }
  

    // Update is called once per frame
    void Update()
    {
        if (shoot.WasPressedThisFrame()) 
        { 
        Instantiate(bulletPrefab,transform.position,Quaternion.identity);
			//Quaternion.identity = no rotation. 
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
    }
}

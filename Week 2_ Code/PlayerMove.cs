using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    //Inputs
    public InputActionAsset shipInput;
    private InputAction move;

    //Data
    public Rigidbody2D rb;
    private Vector2 _movedirection;
    public float speed;

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
        move = shipInput.FindAction("Move");
    }


    // Update is called once per frame
    void Update()
    {
        _movedirection=move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = _movedirection.x * speed; 
    }
}

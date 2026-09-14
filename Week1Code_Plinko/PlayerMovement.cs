using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    //Inputs
    private InputAction move;
    private InputAction drop;
    private InputAction restart;

    //HouseKeeping
    public Rigidbody2D rb;
    private Vector2 _moveDirection;
    private Vector2 startingPoint;
    public float speed;
    private bool setup;


    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
        drop= InputSystem.actions.FindAction("Interact");
        restart= InputSystem.actions.FindAction("Crouch");

        setup = true;
        startingPoint = transform.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.ReadValue<Vector2>();

        if (drop.WasPressedThisFrame())
        {
            if (setup)
            {
                setup = false;
                rb.gravityScale = 1;
            }
        }

        if (restart.WasPressedThisFrame()) {
            if (!setup)
            {
                rb.gravityScale = 0;
                rb.linearVelocity= new Vector2(0,0);
                transform.position = startingPoint;
                setup = true;

            }
        }
    }

    private void FixedUpdate()
    {
        if (setup) {
            rb.linearVelocityX = _moveDirection.x * speed;
        }
    }
}

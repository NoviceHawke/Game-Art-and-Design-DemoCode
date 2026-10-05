using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    [Header("Inputs")]
    private InputAction move;
    private InputAction jump;

    [Header("Componets")]
    public LayerMask groundLayer;
    private BoxCollider2D bC2D;
    private Rigidbody2D rB2D;

    [Header("Data")]
    public float speed;
    public float height;
    public bool rightDirection;
    private Vector2 moveDirection;



    private void Awake()
    {
        bC2D=GetComponent<BoxCollider2D>();
        rB2D=GetComponent<Rigidbody2D>();
        

		move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
       

        if (moveDirection.x > 0 && !rightDirection)
        {
            Flip();
        }
        else if (moveDirection.x < 0 && rightDirection) {
            Flip();
        }

        if (jump.WasPressedThisFrame() && IsGrounded()) {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        rB2D.linearVelocityX = moveDirection.x * speed;
    }

    private void Flip() {
        rightDirection = !rightDirection;
        transform.Rotate(0,180,0);
    }

    private void Jump() {
        rB2D.linearVelocityY = height;
    }
    private bool IsGrounded() {

        RaycastHit2D raycastHit = Physics2D.BoxCast
            (bC2D.bounds.center,//center of box
            bC2D.bounds.size,//size of box
            0,//rotation of box
            Vector2.down,//direction of check
            0.1f,//distace
            groundLayer//the layer we are looking for
            );

		//RaycastHit2D raycastHit = Physics2D.BoxCast(bC2D.bounds.center,bC2D.bounds.size,0,Vector2.down,0.1f,groundLayer);
		return raycastHit.collider != null ;
    }
}

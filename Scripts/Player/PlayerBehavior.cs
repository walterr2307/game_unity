using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 5,
        jumpForce = 5;
    private bool doubleJump = false;
    private InputManager inputManager;
    private Rigidbody2D rb;
    private IsGroundedChecker isGroundedChecker;

    private void Start()
    {
        inputManager = GameManager.getInstance().GetInputManager();
        rb = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<IsGroundedChecker>();

        inputManager.OnJump += HandleJump;
    }

    private void Update()
    {
        float moveDirection = inputManager.getMoveDirection() * Time.deltaTime * speed;
        transform.Translate(moveDirection, 0f, 0f);

        if (moveDirection < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveDirection > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded())
        {
            rb.velocity += Vector2.up * jumpForce;
            doubleJump = true;
        }
        else if (doubleJump)
        {
            rb.velocity += Vector2.up * jumpForce;
            doubleJump = false;
        }
    }
}

using Unity.Mathematics;
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
    }

    private void HandleJump()
    {
        if (isGroundedChecker.isGrounded())
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

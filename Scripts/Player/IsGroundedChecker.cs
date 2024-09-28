using UnityEngine;

public class IsGroundedChecker : MonoBehaviour
{
    [SerializeField]
    private Transform checkerPosition;

    [SerializeField]
    private Vector2 checkerSize;

    [SerializeField]
    private LayerMask groundLayer;

    public bool isGrounded()
    {
        return Physics2D.OverlapBox(checkerPosition.position, checkerSize, 0f, groundLayer);
    }
}

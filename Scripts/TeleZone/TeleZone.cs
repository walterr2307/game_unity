using UnityEngine;

public class TeleZone : MonoBehaviour
{
    [SerializeField]
    private Transform detectedPosition;

    [SerializeField]
    private Vector2 detectedBoxSize;

    [SerializeField]
    private LayerMask playerMask;
    InputManager inputManager;

    private void Start()
    {
        inputManager = GameManager.Instance().GetInputManager();
    }

    private void Update()
    {
        Teleport();
    }

    private Collider2D PlayerCollider()
    {
        return Physics2D.OverlapBox(detectedPosition.position, detectedBoxSize, 0f, playerMask);
    }

    private void Teleport()
    {
        if (PlayerCollider() == null)
            return;
        if (inputManager.Teleport() && PlayerCollider().TryGetComponent(out MagnusBehavior magnus))
            magnus.Teleport(transform.position.x, transform.position.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(detectedPosition.position, detectedBoxSize);
    }
}

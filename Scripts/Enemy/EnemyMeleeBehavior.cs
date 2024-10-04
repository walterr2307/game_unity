using UnityEngine;

public class EnemyMeleeBehavior : EnemyBehavior
{
    [SerializeField]
    private Transform boxPosition;

    [SerializeField]
    private Vector2 boxSize;

    [SerializeField]
    private LayerMask layerMask;

    protected override void Update() { }

    public bool isBumped()
    {
        return Physics2D.OverlapBox(boxPosition.position, boxSize, 0f, layerMask);
    }

    private void OnDrawGizmos()
    {
        /*if (!isBumped())
            return;*/
            
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxPosition.position, boxSize);
    }
}

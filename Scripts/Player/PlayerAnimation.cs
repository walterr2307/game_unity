using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isMoving = GameManager.getInstance().GetInputManager().getMoveDirection() != 0;
        animator.SetBool("isMoving", isMoving);
    }
}

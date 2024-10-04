using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected abstract void Update();
}

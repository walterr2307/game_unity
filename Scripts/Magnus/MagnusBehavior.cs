using UnityEngine;
using UnityEngine.AI;

public class MagnusBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private bool lastMovX = true;
    private InputManager inputManager;

    private void Start()
    {
        inputManager = GameManager.Instance().GetInputManager();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float accelerator = inputManager.Accelarate() ? speed * 2f : speed;

        float movX = inputManager.getMovX() * Time.deltaTime * accelerator;
        float movY = inputManager.getMovY() * Time.deltaTime * accelerator;

        if (movX != 0f && movY != 0f)
        {
            if (lastMovX)
                movY = 0f;
            else
                movX = 0f;
        }
        else if (movX != 0f)
            lastMovX = true;
        else
            lastMovX = false;

        transform.Translate(movX, movY, 0f);
    }

    public void Teleport(float x, float y)
    {
        transform.position = new Vector3(x, y, 0f);
    }
}

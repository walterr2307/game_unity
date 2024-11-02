using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private InputManager inputManager;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        inputManager = new InputManager();
    }

    public static GameManager Instance()
    {
        return instance;
    }

    public InputManager GetInputManager()
    {
        return inputManager;
    }
}

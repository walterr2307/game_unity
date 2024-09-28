using System;

public class InputManager
{
    private PlayerControls playerControls = new PlayerControls();
    public event Action OnJump;

    public InputManager()
    {
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Jump.performed += context => OnJumpPerformed();
    }

    private void OnJumpPerformed()
    {
        OnJump?.Invoke();
    }

    public float getMoveDirection()
    {
        float moveDirection = playerControls.Gameplay.Movement.ReadValue<float>();
        return moveDirection;
    }
}

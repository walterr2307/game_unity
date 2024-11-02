using System.Diagnostics;

public class InputManager
{
    private PlayerControls playerControls;

    public InputManager()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.Enable();
    }

    public float getMovX()
    {
        return playerControls.Gameplay.MovementX.ReadValue<float>();
    }

    public float getMovY()
    {
        return playerControls.Gameplay.MovementY.ReadValue<float>();
    }

    public bool Accelarate()
    {
        return playerControls.Gameplay.Accelerate.ReadValue<float>() == 1f;
    }

    public bool Teleport()
    {   
        return playerControls.Gameplay.Teleport.ReadValue<float>() == 1f;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction rotateAction;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rotateAction = playerInput.Gameplay.Rotate;
        rotateAction.Enable();
    }

    public bool RotateTriggered()
    {
        return rotateAction.WasPressedThisFrame();
    }
}

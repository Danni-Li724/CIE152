using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance { get; private set; }

    private PlayerInput playerInput;
    private InputAction rotateAction;
    private bool rotatePressed = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        playerInput = new PlayerInput();
        rotateAction = playerInput.Gameplay.Rotate;
        rotateAction.Enable();
    }
    
    private void OnDestroy()
    {
        rotateAction.Disable();
    }

    public bool RotateTriggered()
    {
        if (rotatePressed)
        {
            return rotateAction.WasPressedThisFrame();
        }
        return false;
    }
}

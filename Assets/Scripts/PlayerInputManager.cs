using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    
    public static PlayerInputManager Instance { get; private set; }

    private PlayerInput playerInput;
    private InputAction rotateAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        playerInput = new PlayerInput();
        rotateAction = playerInput.Gameplay.Rotate;
        rotateAction.Enable();
    }

    public bool RotateTriggered()
    {
        return rotateAction.WasPressedThisFrame(); 
    }

    private void OnDestroy()
    {
        rotateAction.Disable();
    }
}

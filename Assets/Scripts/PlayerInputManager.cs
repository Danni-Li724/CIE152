using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance { get; private set; }

    private InputSystem_Actions playerInput;
    private InputAction rotateAction;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Initialize the playerInput object from the generated InputSystem_Actions class
        playerInput = new InputSystem_Actions();

        // Get the Rotate action from the Gameplay map
        rotateAction = playerInput.Gameplay.Rotate;

        // Enable the action
        rotateAction.Enable();
    }
    
    private void OnDestroy()
    {
        rotateAction.Disable();
    }

    public bool IsRotating()
    {
        return rotateAction.triggered;  
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour
{
    private PolygonCollider2D pieceCollider;
    public bool isBeingDragged = false;
    private Camera mainCamera;
    private PieceUIManager pieceUIManager;
    private LightObject lightObject;

    private void Start()
    {
        pieceCollider = GetComponent<PolygonCollider2D>();
        mainCamera = Camera.main;
        pieceUIManager = FindObjectOfType<PieceUIManager>();
        lightObject = GetComponent<LightObject>(); 
    }

    private void Update()
    {
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        if (Mouse.current.leftButton.wasPressedThisFrame && IsMouseOverPiece(mouseWorldPosition))
        {
            isBeingDragged = true;
            if (pieceUIManager != null)
            {
                pieceUIManager.SetSelectedPiece(this); // Update UI when clicked
            }

            SetAsSelectedLight();
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isBeingDragged = false;
        }

        if (isBeingDragged)
        {
            DragPiece(mouseWorldPosition);
        }
    }
    
    private void SetAsSelectedLight()
    {
        if (lightObject != null)
        {
            LightUIManager.SetSelectedLight(lightObject); 
        }
    }

    private bool IsMouseOverPiece(Vector2 mouseWorldPosition)
    {
        Collider2D collider = Physics2D.OverlapPoint(mouseWorldPosition);
        return collider != null && collider.gameObject == gameObject;
    }

    private void DragPiece(Vector2 mouseWorldPosition)
    {
        transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0);
    }
    }
    // private void TrySnap()
    // {
    //     Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
    //     foreach (Collider2D collider in colliders)
    //     {
    //         TargetSnapPoint target = collider.GetComponent<TargetSnapPoint>();
    //         if (target != null && target.CorrectPiece == this)
    //         {
    //             transform.position = target.transform.position;
    //             isSnapped = true;
    //             return;
    //         }
    //     }
    // }

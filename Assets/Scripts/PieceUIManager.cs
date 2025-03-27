using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PieceUIManager : MonoBehaviour

{
  public TMP_InputField widthInput;
    public TMP_InputField heightInput;
    public TMP_InputField radiusInput;
    private DraggablePiece selectedPiece;

    private void Start()
    {
        widthInput.onEndEdit.AddListener(UpdateWidth);
        heightInput.onEndEdit.AddListener(UpdateHeight);
        radiusInput.onEndEdit.AddListener(UpdateRadius);
    }

    public void SetSelectedPiece(DraggablePiece piece)
    {
        if (piece == null) return;
        selectedPiece = piece;

        if (piece.CompareTag("Cube"))
        {
            widthInput.interactable = true;
            heightInput.interactable = true;
            radiusInput.interactable = false;

            Vector3 scale = piece.transform.localScale;
            widthInput.text = scale.x.ToString();
            heightInput.text = scale.y.ToString();
        }
        else if (piece.CompareTag("Sphere"))
        {
            widthInput.interactable = false;
            heightInput.interactable = false;
            radiusInput.interactable = true;

            radiusInput.text = piece.transform.localScale.x.ToString();
        }
    }

    private void UpdateWidth(string value)
    {
        if (selectedPiece != null && float.TryParse(value, out float width) && selectedPiece.CompareTag("Cube"))
        {
            Vector3 scale = selectedPiece.transform.localScale;
            selectedPiece.transform.localScale = new Vector3(width, scale.y, scale.z);
        }
    }

    private void UpdateHeight(string value)
    {
        if (selectedPiece != null && float.TryParse(value, out float height) && selectedPiece.CompareTag("Cube"))
        {
            Vector3 scale = selectedPiece.transform.localScale;
            selectedPiece.transform.localScale = new Vector3(scale.x, height, scale.z);
        }
    }

    private void UpdateRadius(string value)
    {
        if (selectedPiece != null && float.TryParse(value, out float radius) && selectedPiece.CompareTag("Sphere"))
        {
            selectedPiece.transform.localScale = new Vector3(radius, radius, 1);
        }
    }
}

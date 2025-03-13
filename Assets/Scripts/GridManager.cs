using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float gridSize = 1f;
    public int gridWidth = 20;
    public int gridHeight = 20;
    public GameObject gridPrefab;

    private void Start()
    {
        DrawGrid();
    }

    private void DrawGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x * gridSize, y * gridSize, 0);
                Instantiate(gridPrefab, position, Quaternion.identity, transform);
            }
        }
    }
}


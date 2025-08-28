using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawChessField : MonoBehaviour
{
    public int gridSizeX;
    public int gridSizeY;
    public float cellSize;
    public Color gridColor = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        // Draws the vertical lines
        for (int x = 0; x <= gridSizeX; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, gridSizeY * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
        
        // Draws the horizontal lines
        for (int y = 0; y <= gridSizeY; y++)
        {
            Vector3 start = new Vector3(0, y * cellSize, 0);
            Vector3 end = new Vector3(gridSizeX * cellSize, y * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour
{
    private Grid<GridObject> _grid;
    
    private void Awake()
    {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        _grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero,
            (g, x, z) => new GridObject(g, x, z));
    }

}

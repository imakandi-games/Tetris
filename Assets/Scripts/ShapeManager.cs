using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public static ShapeManager Instance;

    public TetrominoData shapeData;
    public Vector3Int shapePosition;
    public Vector3Int[] shapeCells;

    private void Awake() => Instance = this;

    public void Init(TetrominoData data, Vector3Int position)
    {
        //store data + position, locally
        this.shapeData = data;
        this.shapePosition = position;

        //check if the cells array is not null (first time calling), assign cells equal to length of data cells length
        //if (shapeCells == null)
        shapeCells = new Vector3Int[data.cells.Length];

        //Loop through those cells and populate them
        for (int i = 0; i < data.cells.Length; i++)
        {
            shapeCells[i] = (Vector3Int)data.cells[i];
            Debug.Log(shapeCells[i] + " shapeCells[i]");
        }
    }

    private void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2Int.right);
        }
    }

    private void Move(Vector2Int movePosition)
    {
        Vector3Int newPosition = this.shapePosition;
        newPosition.x += movePosition.x;
        newPosition.y += movePosition.y;
    }
}

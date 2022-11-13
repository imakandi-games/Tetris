using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(ShapeManager))]
public class Board : MonoBehaviour
{
    public static Board Instance;

    public TetrominoData[] tetrominos;
    public ShapeManager activeShape;
    public Vector3Int spawnPosition;

    private Tilemap tilemap;

    private void Awake()
    {
        Instance = this;

        if (!tilemap)
            tilemap = GetComponentInChildren<Tilemap>();

        //if (!activeShape)
        activeShape = GetComponentInChildren<ShapeManager>();

        //Initialize all the tetrominos shapes from spawn data static class
        for (int i = 0; i < tetrominos.Length; i++)
            tetrominos[i].LoadShapesData();
    }

    private void Start() => SpawnRandomShape();

    private void SpawnRandomShape()
    {
        //Spawn a random shape (Tetromino Data)
        TetrominoData tetrominoData = tetrominos[Random.Range(0, tetrominos.Length)];

        activeShape.Init(tetrominoData, spawnPosition);
        SetShapeOnTile(activeShape);
    }

    public void SetShapeOnTile(ShapeManager shapeManager)
    {
        for (int i = 0; i < shapeManager.shapeCells.Length; i++)
        {
            Vector3Int tilePosition = shapeManager.shapeCells[i] + shapeManager.shapePosition;
            tilemap.SetTile(tilePosition, shapeManager.shapeData.tile);
        }
    }

    public void UnsetShapeOnTile(ShapeManager shapeManager)
    {
        for (int i = 0; i < shapeManager.shapeCells.Length; i++)
        {
            Vector3Int tilePosition = shapeManager.shapeCells[i] + shapeManager.shapePosition;
            tilemap.SetTile(tilePosition, null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(spawnPosition, Vector3.one * 0.25f);
        Gizmos.color = Color.white;
    }
}

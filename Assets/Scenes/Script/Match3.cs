using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match3 : MonoBehaviour
{

    private Grid<GemGridPosition> grid;
    private int gridWidth;
    private int gridHeight;

    private void Awake()
    {
        gridWidth = 8;
        gridHeight = 8;
        grid = new Grid<GemGridPosition>(gridWidth, gridHeight, 1f, new Vector3(0, 0), (Grid<GemGridPosition> g, int x, int y) => new GemGridPosition(x, y));
    }

    // Start is called before the first frame update
    class GemGridPosition{
        private Grid<GemGridPosition> grid;
        public int x;
        public int y;

        public GemGridPosition(Grid<GemGridPosition> grid, int x, int y){
            this.grid = grid;
            this.x = x;
            this.y = y;
        }
    }
}

internal class Grid<T>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private T[,] gridArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, System.Func<Grid<T>, int, int, T> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridArray[x, y] = createGridObject(this, x, y);
            }
        }
    }
}
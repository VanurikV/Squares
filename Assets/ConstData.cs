using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell
{
    public GameObject Obj;
    public Color FinishColor;
    public Direction ChangeDirection;

    public Cell()
    {
        Obj = null;
        FinishColor = Color.None;
        ChangeDirection = Direction.None;
    }
}


public class UndoItem
{
    public Color SquareColor;
    public Direction SquareDirection;
    public int xPos;
    public int yPos;
}


public enum Direction
{
    None,
    Up,
    Left,
    Down,
    Right,
}

public enum Color
{
    None,
    Blue,
    Green,
    Purple,
    Red,
}


public enum GamePrefab
{
    Squares,
    Finish,
    DirChange,
}

public enum PPString
{
    MaxCompleteLevel,
    CurrentLevel,
    SoundFxVol,
    SoundPlayVol
}

public enum SoundFx
{
    ButtonClick,
    SquareMove,
    SquareMoveError,
    LevelComplete,
}

public static class Const
{
    
    public static int CellSizePx = 150;
    public static int MapSize = 7;
    public static int MaxLevel = 36;
    public static float MoveSpeed = 250;


    
    public static Vector2Int DirToVecI(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return new Vector2Int(0, -1);

            case Direction.Left:
                return new Vector2Int(-1, 0);

            case Direction.Down:
                return new Vector2Int(0, 1);

            case Direction.Right:
                return new Vector2Int(1, 0);
        }
        return new Vector2Int(0, 0);
    }

    public static Vector3 DirToVecF(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return new Vector3(0,1,0);

            case Direction.Left:
                return new Vector3(-1,0,0);

            case Direction.Down:
                return new Vector3(0,-1,0);

            case Direction.Right:
                return new Vector3(1,0,0);
        }
        return new Vector3(0,0,0);
    }

}


public class LevelCell
{
    public string Squares;
    public string Obj;

    public override string ToString()
    {
        return Squares + "_" + Obj;
    }
}

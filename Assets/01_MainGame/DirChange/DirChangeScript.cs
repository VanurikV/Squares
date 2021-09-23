using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirChangeScript : MonoBehaviour
{

    public Direction CurDirection;

    public Direction GetDirection()
    {
        return CurDirection;
    }

    public void Init(string type)
    {
        Direction dir = Direction.Up;

        switch (type[1])
        {
            case 'L':
                dir = Direction.Left;
                break;
            case 'R':
                dir = Direction.Right;
                break;
            case 'U':
                dir = Direction.Up;
                break;
            case 'D':
                dir = Direction.Down;
                break;

        }
        CurDirection = dir;
        transform.Rotate(0, 0, 90 * ((int)dir - 1));
    }
}

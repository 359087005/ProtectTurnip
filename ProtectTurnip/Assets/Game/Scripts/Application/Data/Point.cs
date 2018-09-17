using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子坐标
/// </summary>
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}

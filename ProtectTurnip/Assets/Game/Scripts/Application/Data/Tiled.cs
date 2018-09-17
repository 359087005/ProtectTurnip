using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 格子信息
/// </summary>
public class Tile
{
    /// <summary>
    /// 格子的行
    /// </summary>
    public int X;
    public int Y;

    public bool CanHold; //是否可以放塔
    public object Data;//格子所存的数据

    public Tile(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return string.Format("[X:{0},Y:{1},CanHold:{2}]",this.X,this.Y,this.CanHold);
    }
}

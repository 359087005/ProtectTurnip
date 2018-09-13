using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    //场景名字
    public string Name;
    //背景图片
    public string Background;
    //路
    public string Road;
    //初始金币
    public int InitScore;
    //炮塔可防止的位置
    public List<Point> Holders = new List<Point>();
    //怪物行走路径集合
    public List<Point> Path = new List<Point>();
    //出怪回合信息
    public List<Round> Rounds = new List<Round>();

}

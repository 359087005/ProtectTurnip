using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round
{
    public int Monster { get; set; }
    public int Count { get; set; }

    public Round(int monster, int count)
    {
        this.Monster = monster;
        this.Count = count;
    }

}

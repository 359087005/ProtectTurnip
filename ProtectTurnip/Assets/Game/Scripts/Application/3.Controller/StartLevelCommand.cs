using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelCommand : Controller
{
    public override void Execute(object data)
    {
        Game.Instance.LoadScene(3);
    }
}

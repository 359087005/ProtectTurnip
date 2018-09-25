using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : View
{
    public override string Name
    {
        get
        {
            return Constant.V_Start;
        }
    }
    public void GoToSelect()
    {
        Game.Instance.LoadScene(2);
    }


    public override void HandleEvent(string eventName, object data)
    {
        
    }
}

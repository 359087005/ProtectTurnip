using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : Controller
{
    public override void Execute(object data)
    {
        //注册模型


        //注册命令(controller)
        RegisterController(Constant.E_EnterScene, typeof(EnterSceneCommand));
        RegisterController(Constant.E_LeaveScene, typeof(LeaveSceneCommand));
        RegisterController(Constant.E_StartLevel,typeof(StartLevelCommand));
        RegisterController(Constant.E_EndLevel,typeof(EndLevelCommand));

        //进入开始界面
        Game.Instance.LoadScene(1);
    }
}

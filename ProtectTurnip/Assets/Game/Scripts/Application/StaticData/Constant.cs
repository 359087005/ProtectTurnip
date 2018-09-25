using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    //目录
    public static readonly string LevelDir = Application.dataPath + @"\Game\Resources\Res\Levels";
    public static readonly string MapDir = Application.dataPath + @"\Game\Resources\Res\Maps";

    //存档

    //Model

    //View
    public const string V_Start = "Start";
    public const string V_Select = "Select";

    public const string V_Board = "Board";//UIBoard
    public const string V_Win = "Win";//UIWin
    public const string V_Lose = "Lose";//UILose
    public const string V_CountDown = "CountDown";//UICountDown
    public const string V_System = "System";//UISystem
    public const string V_Complete = "Complete";
    //Controller

    //事件
    public const string E_StartUp = "StartUp";

    public const string E_EnterScene = "EnterScene";//SceneArgs
    public const string E_LeaveScene = "LeaveScene";//SceneArgs

    public const string E_StartLevel = "StartLevel"; //StartLevelArgs
    public const string E_EndLevel = "EndLevel";//EndLevelArgs

    public const string E_CountDownComplete = "CountDownComplete"; 
}

public enum GameSpeed
{
    One,Two
}

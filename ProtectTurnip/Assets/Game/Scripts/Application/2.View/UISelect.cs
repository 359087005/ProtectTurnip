using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : View
{
    #region 常量
    #endregion

    #region 字段
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Constant.V_Select;
        }
    }
    #endregion

    #region Unity回调
    #endregion

    #region 方法
    /// <summary>
    /// 返回按钮
    /// </summary>
    public void GoBack()
    {
        Game.Instance.LoadScene(1);
    }
    /// <summary>
    /// 选择关卡
    /// </summary>
    public void ChooseLevel()
    {
        StartLevelArgs e = new StartLevelArgs()
        {
            LevelID = 0
        };
        

        SendEvent(Constant.E_StartLevel,e);
    }

    #endregion

    #region 事件
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }

    #endregion

    #region 帮助方法
    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : View
{
    #region 常量
    #endregion

    #region 字段
    public Button btnContinue;
    public Button btnRestart;
    public Button btnChooseLevel;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Constant.V_System;
        }
    }
    #endregion

    #region Unity回调
    #endregion

    #region 方法
    public void Show() { this.gameObject.SetActive(true); }
    public void Hide() { this.gameObject.SetActive(false); }

    #endregion

    #region 事件
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }

    public void OnContinueClick()
    {

    }
    public void OnRestartClick()
    {

    }
    public void OnChooseLevelClick()
    {

    }

    #endregion

    #region 帮助方法
    #endregion
}

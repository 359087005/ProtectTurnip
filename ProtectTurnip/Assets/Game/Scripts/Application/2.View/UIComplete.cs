using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComplete : View
{

    #region 常量
    #endregion

    #region 字段
    public Button btnRestart;
    public Button btnClear;

    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Constant.V_Complete;
        }
    }
    #endregion

    #region Unity回调
    #endregion

    #region 方法
    #endregion

    #region 事件
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }

    public void OnRestratClick()
    {
        Game.Instance.LoadScene(1);
    }

    public void OnClearClick()
    {

    }

    #endregion

    #region 帮助方法
    #endregion
}

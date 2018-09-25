using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWin : View
{
    #region 常量
    #endregion

    #region 字段
    public Text txtCur;
    public Text txtTotal;
    public Button btnRestart;
    public Button btnContinue;

    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Constant.V_Win;
        }
    }
    #endregion

    #region Unity回调
    private void Awake()
    {
        UpdateRoundInfo(0,0);
    }
    #endregion

    #region 方法
    public void Show() { this.gameObject.SetActive(true); }
    public void Hide() { this.gameObject.SetActive(false); }


    public void UpdateRoundInfo(int curInfo, int totalInfo)
    {
        txtCur.text = curInfo.ToString("D2"); //始终保留2位整数
        txtTotal.text = totalInfo.ToString();
    }
    #endregion

    #region 事件
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }

    public void OnRestartClick()
    {

    }
    public void OnContinueClick()
    {

    }

    #endregion

    #region 帮助方法
    #endregion
}

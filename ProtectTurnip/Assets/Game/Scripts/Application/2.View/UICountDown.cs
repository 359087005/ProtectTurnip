using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountDown : View
{

    #region 常量
    #endregion

    #region 字段
    public Image imgCount;
    public Sprite[] Numbers;
    #endregion

    #region 属性
    public override string Name
    {
        get
        {
            return Constant.V_CountDown;
        }
    }
    #endregion

    #region Unity回调
    #endregion

    #region 方法
    public void Show()
    {
        this.gameObject.SetActive(true);

    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void StartCountDown()
    {
        Show();
        StartCoroutine(DisplayCountDown());
    }
    IEnumerator DisplayCountDown()
    {
        int count = 3;
        while (count > 0)
        {
            //显示
            imgCount.sprite =Numbers[count -1] ;
            //自减
            count--;
            //等待
            yield return new WaitForSeconds(1);
            if (count <= 0)
                break;
        }

        Hide();

        SendEvent(Constant.E_CountDownComplete);
    }

    #endregion

    #region 事件
    #endregion

    #region 事件回调

    public override void RegisterEvents()
    {
        this._attentionEventList.Add(Constant.E_EnterScene);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Constant.E_EnterScene:
                SceneArgs e = (SceneArgs)data;
                if (e.SceneIndex == 3)
                {
                    StartCountDown();
                }
                break;
            default:
                break;
        }
    }

    #endregion

    #region 帮助方法
    #endregion
}

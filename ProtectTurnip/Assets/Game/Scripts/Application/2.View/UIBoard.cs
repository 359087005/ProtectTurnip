using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoard : View
{
    #region 常量
    #endregion

    #region 字段
    public Text txtScore;
    public Image imgRoundInfo;
    public Text txtCurInfo;
    public Text txtTotalInfo;
    public Image imgPauseInfo;
    public Button btnSpeed1;
    public Button btnSpeed2;
    public Button btnResume;
    public Button btnPause;
    public Button btnSystem;

    bool isPlaying = false;
    GameSpeed gameSpeed = GameSpeed.One;
    int score = 0;

    #endregion

    #region 属性
    public override string Name
    {
        get { return Constant.V_Board; }
    }

    public bool IsPlaying
    {
        get { return isPlaying; }
        set
        {
            isPlaying = value;
            imgRoundInfo.gameObject.SetActive(value);
            imgPauseInfo.gameObject.SetActive(!value);
        }
    }

    public GameSpeed GameSpeed
    {
        get { return gameSpeed; }
        set
        {
            gameSpeed = value;
            btnSpeed1.gameObject.SetActive(gameSpeed == GameSpeed.One);
            btnSpeed1.gameObject.SetActive(gameSpeed == GameSpeed.Two);
        }
    }
    public int Gold
    {
        get { return score; }
        set
        {
            score = value;
            txtScore.text = value.ToString();
        }
    }
    #endregion

    #region Unity回调

    public UICountDown uiCountDown;
    private void Awake()
    {
        this.score = 0;
        this.isPlaying = true;
        this.gameSpeed = GameSpeed.One;


        uiCountDown.StartCountDown();
    }

    #endregion

    #region 方法
    public void UpdateRoundInfo(int curInfo, int totalInfo)
    {
        txtCurInfo.text = curInfo.ToString("D2"); //始终保留2位整数
        txtTotalInfo.text = totalInfo.ToString();
    }

    #endregion

    #region 事件
    public override void RegisterEvents()
    {
        _attentionEventList.Add(Constant.E_CountDownComplete);
    }


    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Constant.E_CountDownComplete:
                Game.Instance.LoadScene(4);
                break;
        }
    }
    #endregion

    #region 事件回调
    public void OnSpeed1Click()
    {
        gameSpeed = GameSpeed.One;
    }
    public void OnSpeed2Click()
    {
        gameSpeed = GameSpeed.Two;
    }
    public void OnResumeClick()
    {
        isPlaying = true;
    }
    public void OnPauseClick()
    {
        isPlaying = false;
    }
    public void OnSystemClick()
    {

    }

    #endregion

    #region 帮助方法
    #endregion

}

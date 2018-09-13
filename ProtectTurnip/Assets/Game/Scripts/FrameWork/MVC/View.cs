using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour {

	public abstract string Name { get; }

    //关心的事件列表
    public List<string> _attentionEventList = new List<string>();

    //事件处理函数
    public abstract void HandleEvent(string eventName, object data);

    //获取模型
    protected Model GetModel<T>() where T : Model
    {
        return MVCCenter.GetModel<T>();
    }

    //发送消息
    protected void SendEvent(string eventName, object data)
    {
        MVCCenter.SendEvent(eventName, data);
    }
}

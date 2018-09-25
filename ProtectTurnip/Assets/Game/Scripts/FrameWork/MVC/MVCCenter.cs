using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MVCCenter
{
    public static Dictionary<string, Model> _modelDict = new Dictionary<string, Model>();
    public static Dictionary<string, View> _viewlDict = new Dictionary<string, View>();
    public static Dictionary<string, Type> _commondDict = new Dictionary<string, Type>();

    //注册
    public static void RegisterModel(Model m)
    {
        _modelDict[m.Name] = m;
    }
    public static void RegisterView(View v)
    {
        //防止重复注册
        if (_viewlDict.ContainsKey(v.Name))
            _viewlDict.Remove(v.Name);
        //注册关心的事件
        v.RegisterEvents();
        _viewlDict[v.Name] = v;
    }
    public static void RegisterController(string eventName,Type t)
    {
        _commondDict[eventName] = t;
    }
    //获取
    public static Model GetModel<T>() where T : Model
    {
        foreach (var tmpModel in _modelDict.Values)
        {
            if (tmpModel is T)
                return tmpModel;
        }
        return null;
    }

    public static View GetView<T>() where T : View
    {
        foreach (var tmpView in _viewlDict.Values)
        {
            if (tmpView is T)
                return tmpView;
        }
        return null;
    }

    //public static Controller GetController<T>() where T : Controller
    //{
    //    foreach (var tmpController in _commondDict.Values)
    //    {
    //        if (tmpController is T)
    //        {
    //            Controller c = Activator.CreateInstance(tmpController) as Controller;
    //            return c;
    //        }
    //    }
    //    return null;
    //}

    //响应
    public static void SendEvent(string eventName,object data = null)
    {

        //控制器响应

        if (_commondDict.ContainsKey(eventName))
        {
            Type t = _commondDict[eventName];

            Controller c = Activator.CreateInstance(t) as Controller;

            c.Execute(data);
        }

        //视图响应事件

        foreach (View v in _viewlDict.Values)
        {
            if (v._attentionEventList.Contains(eventName))
            {
                v.HandleEvent(eventName,data);
            }
        }
    }
}

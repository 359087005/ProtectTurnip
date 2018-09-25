using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller 
{
    //获取模型
    protected Model GetModel<T>() where T:Model
    {
        return MVCCenter.GetModel<T>();
    }

    //获取视图
    protected View GetView<T>() where T : View
    {
        return MVCCenter.GetView<T>();
    }
    //注册模型
    protected void RegisterModel(Model model)
    {
        MVCCenter.RegisterModel(model);
    }

    //注册视图

    protected void RegisterView(View view)
    {
        MVCCenter.RegisterView(view);
    }
    //注册控制器
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVCCenter.RegisterController(eventName,controllerType);
    }

    public abstract void Execute(object data);
}

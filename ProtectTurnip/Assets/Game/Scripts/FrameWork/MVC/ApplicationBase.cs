using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplicationBase<T> : Singleton<T> where T : MonoBehaviour
{
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVCCenter.RegisterController(eventName,controllerType);
    }

    public void SendEvent(string eventName,object e = null)
    {
        MVCCenter.SendEvent(eventName,e);
    }
}

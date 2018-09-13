﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T _instance = null;

    protected static T Instance
    {
        get { return _instance; }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}

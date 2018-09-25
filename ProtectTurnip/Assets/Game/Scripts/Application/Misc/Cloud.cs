﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float offsetX = 1000;

    public float duration = 1f; //周期时间

    void Start()
    {
        iTween.MoveBy(
            this.gameObject,iTween.Hash
            ("x",offsetX,
            "easeType",iTween.EaseType.linear,
            "loopType",iTween.LoopType.loop,
            "time",duration)
            );
    }

}

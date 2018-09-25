using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float time = 1f; //一次循环所需事件
    public float offsetY = 2; //Y流动偏移

    void Start()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash
            ("y", offsetY,
            "easeType", iTween.EaseType.easeInOutSine,
            "loopType", iTween.LoopType.pingPong,
            "time", time)
            );
    }
}

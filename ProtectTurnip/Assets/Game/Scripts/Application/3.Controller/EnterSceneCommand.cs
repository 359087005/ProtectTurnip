using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneCommand : Controller
{
    public override void Execute(object data)
    {
        SceneArgs e = data as SceneArgs;

        switch (e.SceneIndex)
        {
            case 0:
                break;
            case 1:
                RegisterView(GameObject.Find("UIStart").GetComponent<UIStart>());
                break;
            case 2:
                RegisterView(GameObject.Find("UISelect").GetComponent<UISelect>());
                break;
            case 3:
                GameObject go = null;
                go = GameObject.Find("Canvas");
                RegisterView(GameObject.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(go.transform.Find("UICountDown").GetComponent<UICountDown>());
                RegisterView(go.transform.Find("UIWin").GetComponent<UIWin>());
                RegisterView(go.transform.Find("UILose").GetComponent<UILose>());
                RegisterView(go.transform.Find("UISystem").GetComponent<UISystem>());
                break;
            case 4:
                RegisterView(GameObject.Find("UIComplete").GetComponent<UIComplete>());
                break;
        }
    }
}

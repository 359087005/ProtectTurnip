using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(StaticData))]
public class Game : ApplicationBase<Game>
{
    //全局访问功能
    [HideInInspector]
    public ObjectPool objectPool = null;
    [HideInInspector]
    public SoundManager sound = null;
    [HideInInspector]
    public StaticData staticData = null;
    //全局方法

    public void LoadScene(int level)
    {
        SceneArgs e = new SceneArgs();
        e.SceneIndex = SceneManager.GetActiveScene().buildIndex;

        SendEvent(Constant.E_LeaveScene,e);

        SceneManager.LoadScene(level,LoadSceneMode.Single);
    }


    public void OnLevelWasLoaded(int level)
    {
        SceneArgs e = new SceneArgs();
        e.SceneIndex = level;

        SendEvent(Constant.E_EnterScene, e);
    }
    //游戏入口

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //单例赋值
        objectPool = ObjectPool.Instance;
        sound = SoundManager.Instance;
        staticData = StaticData.Instance;

        //注册控制器命令
        RegisterController(Constant.E_StartUp, typeof(StartUpCommand));
        //启动游戏
        SendEvent(Constant.E_StartUp);
    }
}

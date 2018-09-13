using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public string ResourcesDir = "";

    Dictionary<string, SubPool> poolsDict = new Dictionary<string, SubPool>();

    //去对象
    public GameObject Spawn(string name)
    {
        SubPool pool = null;
        if (!poolsDict.ContainsKey(name))
        {
            CreatNewPool(name);
        }

        pool = poolsDict[name];
        return pool.Spawn();
    }

    void CreatNewPool(string name)
    {
        //预设路径
        string path = "";
        if (string.IsNullOrEmpty(ResourcesDir))
        {
            path = name;
        }
        else
        {
            path = ResourcesDir + "/" + name;
        }
        //加载预设
        GameObject tmpPrefab = Resources.Load<GameObject>(path);

        //创建对象池
        SubPool tmpPool = new SubPool(tmpPrefab);

        poolsDict.Add(name,tmpPool);
    }

    //回收对象

    public void UnSpawn(GameObject go)
    {
        SubPool pool = null;
        //for (int i = 0; i < poolsDict.Count; i++)
        //{
        //}

        foreach (SubPool sp in poolsDict.Values)
        {
            if (sp.Contains(go))
            {
                pool = sp;
                break;
            }
        }

        pool.UnSpawn(go);
    }

    //回收所有对象

    public void UnSpawnAll()
    {
        foreach (SubPool sp in poolsDict.Values)
        {
            sp.UnSpawnAll();
        }
    }
}

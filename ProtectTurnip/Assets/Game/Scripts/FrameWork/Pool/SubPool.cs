using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool
{
    GameObject _prefab;

    List<GameObject> _objectsList = new List<GameObject>();

    public string Name
    {
        get {return _prefab.name;}
    }

    public SubPool(GameObject prefab)
    {
        this._prefab = prefab;
    }

    public GameObject Spawn()
    {
        GameObject tmp = null;

        for (int i = 0; i < _objectsList.Count; i++)
        {
            if (!_objectsList[i].activeSelf)
            {
                tmp = _objectsList[i];
                break;
            }
        }

        if (tmp == null)
        {
            tmp = GameObject.Instantiate<GameObject>(_prefab);
            _objectsList.Add(tmp);
        }

        tmp.SetActive(true);
        tmp.SendMessage("OnSpawn",SendMessageOptions.DontRequireReceiver);

        return tmp;
    }

    public void UnSpawn(GameObject go)
    {
        if (Contains(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    public void UnSpawnAll()
    {
        for (int i = 0; i < _objectsList.Count; i++)
        {
            if (_objectsList[i].activeSelf)
            {
                UnSpawn(_objectsList[i]);
            }
        }
    }
    public bool Contains(GameObject go)
    {
        return _objectsList.Contains(go);
    }
}

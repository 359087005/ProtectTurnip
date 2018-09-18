using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{
    [HideInInspector]
    public Map map = null;

    //关卡列表
    List<FileInfo> filesList = new List<FileInfo>();

    int _selectIndex = -1;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            map = target as Map;

            EditorGUILayout.BeginHorizontal();
            int currentIndex = EditorGUILayout.Popup(_selectIndex, GetNames(filesList));
            if (currentIndex != _selectIndex)
            {
                _selectIndex = currentIndex;
                LoadLevel();
            }

            if (GUILayout.Button("读取列表"))
            {
                LoadLevelFiles();
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("清除塔点"))
            {
                map.ClearHolder();
            }
            if (GUILayout.Button("清除路径"))
            {
                map.ClearRoad();
            }
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("保存关卡"))
            {
                SaveLevel();
            }
        }

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }


    /// <summary>
    /// 加载关卡
    /// </summary>
    void LoadLevel()
    {
        FileInfo file = filesList[_selectIndex];

        Level level = new Level();
        Tools.FillLevel(file.FullName, ref level);

        map.LoadLevel(level);
    }
    /// <summary>
    /// 保存关卡
    /// </summary>
    void SaveLevel()
    {
        Level level = map.Level;

        List<Point> pointList = null;
        //收集塔点
        pointList = new List<Point>();
        for (int i = 0; i < map.Grid.Count; i++)
        {
            Tile t = map.Grid[i];
            if (t.CanHold)
            {
                Point p = new Point(t.X, t.Y);
                pointList.Add(p);
            }
        }
        level.Holders = pointList;

        //收集路点
        pointList = new List<Point>();
        for (int i = 0; i < map.Road.Count; i++)
        {
            Tile t = map.Road[i];
            Point p = new Point(t.X, t.Y);
            pointList.Add(p);
        }
        level.Path = pointList;

        //保存
        string fileName = filesList[_selectIndex].FullName;

        Tools.SaveLevel(fileName,level);
        EditorUtility.DisplayDialog("保存关卡数据","保存成功","确定");
    }
    //加载关卡信息
    void LoadLevelFiles()
    {
        //清楚状态
        Clear();
        //加载列表
        filesList = Tools.GetLevelFiles();
        if (filesList.Count > 0)
        {
            _selectIndex = 0;
            LoadLevel();
        }
    }

    void Clear()
    {
        filesList.Clear();
        _selectIndex = -1;
    }

    string[] GetNames(List<FileInfo> files)
    {
        List<string> filesNameList = new List<string>();

        for (int i = 0; i < filesList.Count; i++)
        {
            filesNameList.Add(filesList[i].Name);
        }
        return filesNameList.ToArray();
    }
}

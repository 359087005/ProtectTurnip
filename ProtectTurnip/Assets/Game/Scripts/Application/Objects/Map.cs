using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于描述一个关卡地图的状态
/// </summary>
public class Map : MonoBehaviour
{

    #region  常量
    public const int RowCount = 8; //行列数
    public const int ColumnCount = 12;

    #endregion

    #region  事件
    #endregion

    #region  字段
    float MapWidth;
    float MapHeight;

    float TileWidth; //格子宽高
    float TileHeight;

    List<Tile> gridList = new List<Tile>();//格子集合
    List<Tile> roadList = new List<Tile>();//路径集合

    Level level;


    public bool DrwaGizmos = true;//是否绘制网格
    #endregion

    #region  属性

    public string BackgroundImage
    {
        set
        {
            
            SpriteRenderer render = transform.Find("Background").GetComponent <SpriteRenderer> ();
            StartCoroutine(Tools.LoadImage(value, render));
        }
    }

    public string RoadImage
    {
        set
        {
            SpriteRenderer render = transform.Find("Board").GetComponent <SpriteRenderer>();
            StartCoroutine(Tools.LoadImage(value, render));
        }
    }

    public Level Level
    {
        get { return level; }
    }

    public List<Tile> Grid { get { return gridList; } }
    public List<Tile> Road { get { return roadList; } }

    /// <summary>
    /// 怪物的寻路路径
    /// </summary>
    public Vector3[] Path
    {
        get
        {
            List<Vector3> pathList = new List<Vector3>();
            for (int i = 0; i < roadList.Count; i++)
            {
                Tile t = roadList[i];
                Vector3 point = GetPosition(t);
                pathList.Add(point);
            }
            return pathList.ToArray();
        }
    }

    #endregion

    #region  方法

    public void LoadLevel(Level level)
    {
        Clear();
        this.level = level;
        //加载图片
        this.BackgroundImage = "file://" + Constant.MapDir + level.Background;
        this.RoadImage = "file://" + Constant.MapDir + level.Road;
        //寻路路径
        for (int i = 0; i < level.Path.Count; i++)
        {
            Point p = level.Path[i];
            Tile t = GetTile(p.X, p.Y);
            roadList.Add(t);
        }
        //炮塔空地
        for (int i = 0; i < level.Holders.Count; i++)
        {
            Point p = level.Holders[i];
            Tile t = GetTile(p.X, p.Y);
            t.CanHold = true;
        }
        
    }

    /// <summary>
    /// 清除塔位信息
    /// </summary>
    public void ClearHolder()
    {
        for (int i = 0; i < gridList.Count; i++)
        {
            gridList[i].CanHold = false;
        }
    }

    public void ClearRoad()
    {
        roadList.Clear();
    }

    public void Clear()
    {
        level = null;
        ClearHolder();
        ClearRoad();
    }

    #endregion

    #region  Unity回调

    private void Awake()
    {
        CalculateSize();

        //创建所有的格子
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                gridList.Add(new Tile(i,j));
            }
        }

    }
    /// <summary>
    /// 只在编辑器起作用
    /// </summary>
    private void OnDrawGizmos()
    {
        if (!DrwaGizmos)
            return;

        CalculateSize();

        Gizmos.color = Color.green;

        //绘制行
        for (int row = 0; row <= RowCount; row++)
        {
            Vector2 from = new Vector2(-MapWidth / 2, -MapHeight / 2 + row * TileHeight);
            Vector2 to = new Vector2(-MapWidth / 2 + MapWidth, -MapHeight / 2 + row * TileHeight);
            Gizmos.DrawLine(from, to);
        }

        //绘制列
        for (int col = 0; col <= ColumnCount; col++)
        {
            Vector2 from = new Vector2(-MapWidth / 2 + col * TileWidth, -MapHeight / 2 + MapHeight);
            Vector2 to = new Vector2(-MapWidth / 2 + col * TileWidth, -MapHeight / 2 );
            Gizmos.DrawLine(from, to);
        }

        //画出塔的位置
        foreach (Tile item in gridList)
        {
            if (item.CanHold)
            {
                Vector3 pos = GetPosition(item);
                Gizmos.DrawIcon(pos,"holder.png",true);
            }
        }

        //画路线
        Gizmos.color = Color.red;
        for (int i = 0; i < roadList.Count; i++)
        {
            if (i == 0)
                Gizmos.DrawIcon(GetPosition(roadList[i]),"start.png",true);

            if (roadList.Count > 1 && i != 0)
            {
                Vector3 from = GetPosition(roadList[i-1]);
                Vector3 to = GetPosition(roadList[i]);
                Gizmos.DrawLine(from,to);
            }

            if (roadList.Count > 1 && i == roadList.Count - 1)
                Gizmos.DrawIcon(GetPosition(roadList[i]), "end.png", true);
        }
    }

    #endregion

    #region  事件回调

    #endregion

    #region  帮助方法

    /// <summary>
    /// 计算地图大小  不用screen.宽高 因为screen获得的是像素  而应该获取实际大小
    /// 
    /// 计算格子大小
    /// </summary>
    public void CalculateSize()
    {
        Vector3 p1 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        Vector3 p2 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        MapWidth = p2.x - p1.x;
        MapHeight = p2.y - p1.y;

        //求得每一个格子的宽高   屏幕宽 除以列   屏幕高 除以行
        TileWidth = MapWidth / ColumnCount;
        TileHeight = MapHeight / RowCount;
    }

    /// <summary>
    /// 获取格子中心点所在的坐标
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    Vector3 GetPosition(Tile t)
    {
        return new Vector3
            (
            -MapWidth / 2 + (t.X + 0.5f) * TileWidth,
            -MapHeight / 2 + (t.Y + 0.5f) * TileHeight,
            0
            );
    }

    /// <summary>
    /// 根据格子索引获取格子
    /// </summary>
    /// <param name="tiledX"></param>
    /// <param name="tiledY"></param>
    /// <returns></returns>
    public Tile GetTile(int tiledX, int tiledY)
    {
        int index = tiledX + tiledY * ColumnCount;

        if (index < 0 || index >= gridList.Count)
        {
            return null;
        }
        return gridList[index];
    }


    /// <summary>
    /// 获取鼠标下的格子
    /// </summary>
    /// <returns></returns>
    Tile GetTileUnderMouse()
    {
        Vector2 worldPos = GetWorldPosition();
        int col = (int)((worldPos.x + MapWidth / 2) / TileWidth);
        int row = (int)((worldPos.y + MapHeight / 2) / TileHeight);

        return GetTile(col, row);
    }


    /// <summary>
    /// 获取鼠标所在位置的世界坐标
    /// </summary>
    /// <returns></returns>
    Vector3 GetWorldPosition()
    {
        Vector3 viewPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        return worldPos;

        //return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    #endregion
}

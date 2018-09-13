using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

public class Tools
{
    //获取关卡列表信息
    public static List<FileInfo> GetLevelFiles()
    {
        string[] files = Directory.GetFiles(Constant.LevelDir, "*.xml");

        List<FileInfo> list = new List<FileInfo>();
        for (int i = 0; i < files.Length; i++)
        {
            FileInfo info = new FileInfo(files[i]);
            list.Add(info);
        }
        return list;
    }

    //填充level类数据
    public static void FillLevel(string fileName, ref Level level)
    {
        FileInfo file = new FileInfo(fileName);

        StreamReader sr = new StreamReader(file.OpenRead(), Encoding.UTF8);

        XmlDocument doc = new XmlDocument();
        doc.Load(sr);

        level.Name = doc.SelectSingleNode("/Level/Name").InnerText;
        level.Background = doc.SelectSingleNode("/Level/BackGround").InnerText;
        level.Road = doc.SelectSingleNode("/Level/Road").InnerText;
        level.InitScore = int.Parse(doc.SelectSingleNode("/Level/InitScore").InnerText);

        XmlNodeList nodes;

        nodes = doc.SelectNodes("Level/Holder/Point");
        for (int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i];
            Point p = new Point(
               int.Parse(node.Attributes["X"].Value),
               int.Parse(node.Attributes["Y"].Value));
            level.Holders.Add(p);
        }

        nodes = doc.SelectNodes("Level/Path/Point");
        for (int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i];
            Point p = new Point(
                int.Parse(node.Attributes["X"].Value),
                int.Parse(node.Attributes["Y"].Value));

            level.Path.Add(p);
        }
        nodes = doc.SelectNodes("Level/Rounds/Round");

        for (int i = 0; i < nodes.Count; i++)
        {
            XmlNode node = nodes[i];
            Round r = new Round(
                int.Parse(node.Attributes["Monster"].Value),
                int.Parse(node.Attributes["Count"].Value)
                );

            level.Rounds.Add(r);
        }

        sr.Close();
        sr.Dispose();
    }

    //保存关卡
    public static void SaveLevel(string fileName,Level level)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine("<level>");

        sb.AppendLine(string.Format("<Name>{0}</Name>",level.Name));
        sb.AppendLine(string.Format("<Bacground>{0}</Bacground>", level.Background));
        sb.AppendLine(string.Format("<Road>{0}</Road>", level.Road));
        sb.AppendLine(string.Format("<InitScore>{0}</InitScore>", level.InitScore));

        sb.AppendLine("<Holder>");
        for (int i = 0; i < level.Holders.Count; i++)
        {
            sb.AppendLine(string.Format("<Point X=\"{0}\" Y=\"{1}\"/>",level.Holders[i].X, level.Holders[i].Y));
        }
        sb.AppendLine("</Holder>");

        sb.AppendLine("<Path>");
        for (int i = 0; i < level.Path.Count; i++)
        {
            sb.AppendLine(string.Format("<Point X=\"{0}\" Y=\"{1}\"/>", level.Path[i].X, level.Path[i].Y));
        }
        sb.AppendLine("</Path>");

        sb.AppendLine("<Rounds>");
        for (int i = 0; i < level.Path.Count; i++)
        {
            sb.AppendLine(string.Format("<Round X=\"{0}\" Y=\"{1}\"/>", level.Rounds[i].Monster, level.Rounds[i].Count));
        }
        sb.AppendLine("</Rounds>");

        sb.AppendLine("</level>");

        string contnet = sb.ToString();

        //TODO
        StringWriter sw = new StringWriter();
        sw.Write(contnet);
        sw.Flush();
        sw.Dispose();
    }
}

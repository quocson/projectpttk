using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TetrisReturn
{
    class SaveLoad
    {
        XmlDocument xmlDoc;
        private string sPath = AppDomain.CurrentDomain.BaseDirectory + @"\game.stg";
        public SaveLoad()
        {
            xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(sPath))
            {
                createNew();
            }
        }
        private void createNew()
        {
            SaveDTO sld = new SaveDTO();
            save(sld);
        }
        public SaveDTO load()
        {
            SaveDTO res = new SaveDTO();
            xmlDoc.Load(sPath);
            XmlNodeList nodelist = xmlDoc.SelectNodes("Game/Info");
            XmlNode node = nodelist[0];
            res.STheme = node.Attributes[0].Value;
            res.SMap = node.Attributes[1].Value;
            res.IShapeMode = int.Parse(node.Attributes[2].Value);
            res.ILevel = int.Parse(node.Attributes[3].Value);
            res.IScore = int.Parse(node.Attributes[4].Value);
            res.ILine = int.Parse(node.Attributes[5].Value);
            res.IPiece = int.Parse(node.Attributes[6].Value);

            for (int i = 0; i < Constants.map.Row; i++)
            {
                XmlNodeList rowlist = xmlDoc.SelectNodes("Game/Row");
                XmlNode row = rowlist[i];
                for (int j = 0; j < Constants.map.Column; j++)
                {
                    res.ArrMap[i, j] = int.Parse(row.Attributes[j + 1].Value);
                }
            }
            return res;
        }
        public void save(SaveDTO save)
        {
            XmlElement Goc = xmlDoc.CreateElement("Game");
            xmlDoc.AppendChild(Goc);
            XmlElement Record = xmlDoc.CreateElement("Info");
            Record.SetAttribute("Theme", save.STheme);
            Record.SetAttribute("Map", save.SMap);
            Record.SetAttribute("ShapeMode", save.IShapeMode.ToString());
            Record.SetAttribute("Level", save.ILevel.ToString());
            Record.SetAttribute("Score", save.IScore.ToString());
            Record.SetAttribute("Line", save.ILine.ToString());
            Record.SetAttribute("Piece", save.IPiece.ToString());
            Goc.AppendChild(Record);

            for (int i = 0; i < Constants.map.Row; i++)
            {
                XmlElement Row = xmlDoc.CreateElement("Row");
                Row.SetAttribute("Num", i.ToString());
                Goc.AppendChild(Row);
                for (int j = 0; j < Constants.map.Column; j++)
                {
                    Row.SetAttribute("Col" + j, save.ArrMap[i,j].ToString());
                }
            }
            xmlDoc.Save(sPath);
        }
    }
}

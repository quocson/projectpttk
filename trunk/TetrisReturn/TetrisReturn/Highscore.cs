using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace TetrisReturn
{
    public class HighScore
    {
        XmlDocument highscore;

        public HighScore()
        {
            highscore = new XmlDocument();
            if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs"))
            {
                createNew();
            }
        }

        public SaveDTO[] readRecords()
        {
            highscore.Load(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs");
            SaveDTO[] res = new SaveDTO[10];
            XmlNodeList nodelist = highscore.SelectNodes("HighScoreBoard/Record");
            for (int i = 0; i < 10; i++)
            {
                XmlNode node = nodelist[i];
                res[i] = new SaveDTO();
                res[i].ILevel = int.Parse(node.Attributes[0].Value);
                res[i].IScore = int.Parse(node.Attributes[1].Value);
                res[i].ILine = int.Parse(node.Attributes[2].Value);
                res[i].IPiece = int.Parse(node.Attributes[3].Value);
            }
            return res;
        }
        public void createNew()
        {
            XmlElement Goc = highscore.CreateElement("HighScoreBoard");
            highscore.AppendChild(Goc);
            for (int i = 0; i < 10; i++)
            {
                XmlElement Record = highscore.CreateElement("Record");
                Record.SetAttribute("Level", "0");
                Record.SetAttribute("Score", "0");
                Record.SetAttribute("Line", "0");
                Record.SetAttribute("Piece", "0");
                Goc.AppendChild(Record);
            }
            highscore.Save(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs");
        }
        public void clear()
        {
            highscore.Load(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs");
            highscore.RemoveAll();
            XmlElement Goc = highscore.CreateElement("HighScoreBoard");
            highscore.AppendChild(Goc);
            for (int i = 0; i < 10; i++)
            {
                XmlElement Record = highscore.CreateElement("Record");
                Record.SetAttribute("Level", "0");
                Record.SetAttribute("Score", "0");
                Record.SetAttribute("Line", "0");
                Record.SetAttribute("Piece", "0");
                Goc.AppendChild(Record);
            }
            highscore.Save(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs");
        }
        public int saveRecords(SaveDTO rec)
        {
            int res = 0;
            highscore.Load(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs");
            SaveDTO[] list = new SaveDTO[10];
            
            XmlNodeList nodelist = highscore.SelectNodes("HighScoreBoard/Record");
            for (int i = 0; i < 10; i++)
            {
                XmlNode node = nodelist[i];
                list[i] = new SaveDTO();
                list[i].ILevel = int.Parse(node.Attributes[0].Value);
                list[i].IScore = int.Parse(node.Attributes[1].Value);
                list[i].ILine = int.Parse(node.Attributes[2].Value);
                list[i].IPiece = int.Parse(node.Attributes[3].Value);

            }
            for (int i = 0; i < 10; i++)
                if (i == 0 && list[i].IScore < rec.IScore)
                {
                    for (int x = 9; x > 0; x--)
                        list[x] = list[x - 1];
                    list[i] = rec;
                    res = 1;
                    i = 10;
                }
                else if (i < 9 && list[i].IScore > rec.IScore && list[i + 1].IScore <= rec.IScore)
                {
                    for (int x = 9; x > i; x--)
                        list[x] = list[x - 1];
                    list[i + 1] = rec;
                    res = i + 2;
                    i = 10;
                }
                else if (i == 9 && list[i].IScore <= rec.IScore && list[i - 1].IScore > rec.IScore)
                {
                    list[i] = rec;
                    res = 10;
                    i = 10;
                }
            if (res > 0)
            {
                highscore.RemoveAll();
                XmlElement Goc = highscore.CreateElement("HighScoreBoard");
                highscore.AppendChild(Goc);
                for (int i = 0; i < 10; i++)
                {
                    XmlElement Record = highscore.CreateElement("Record");
                    Record.SetAttribute("Level", list[i].ILevel.ToString());
                    Record.SetAttribute("Score", list[i].IScore.ToString());
                    Record.SetAttribute("Line", list[i].ILine.ToString());
                    Record.SetAttribute("Piece", list[i].IPiece.ToString());
                    Goc.AppendChild(Record);
                }
                highscore.Save(AppDomain.CurrentDomain.BaseDirectory + @"\system.ghs");
            }
            return res;


        }

    }
}
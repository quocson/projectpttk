using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TetrisReturn
{
    public class Config : IDisposable
    {
        XmlDocument xmlDoc;
        private string sPath = AppDomain.CurrentDomain.BaseDirectory + @"\setting.cfg";
        private bool bSound;
        public bool BSound
        {
            get { return bSound; }
            set { bSound = value; }
        }
        private string sTheme;
        public string STheme
        {
            get { return sTheme; }
            set { sTheme = value; }
        }
        private string sMap;
        public string SMap
        {
            get { return sMap; }
            set { sMap = value; }
        }
        private bool bGhost;
        public bool BGhost
        {
            get { return bGhost; }
            set { bGhost = value; }
        }
        private string sLanguage;
        public string SLanguage
        {
            get { return sLanguage; }
            set { sLanguage = value; }
        }
        private int modeShape;
        public int ModeShape
        {
            get { return modeShape; }
            set { modeShape = value; }
        }
        private int arrowUp;
        public int ArrowUp
        {
            get { return arrowUp; }
            set { arrowUp = value; }
        }
        public Config()
        {
            xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(sPath))
            {
                createNew();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private void createNew()
        {
            XmlElement Goc = xmlDoc.CreateElement("Game");
            xmlDoc.AppendChild(Goc);
            XmlElement Record = xmlDoc.CreateElement("Setting");
            Record.SetAttribute("Sound", "true");
            Record.SetAttribute("Theme", "Transformers");
            Record.SetAttribute("Map", "Classic");
            Record.SetAttribute("Ghost", "true");
            Record.SetAttribute("Language", "English");
            Record.SetAttribute("Mode_Shape", "1");
            Record.SetAttribute("Arrow_Up", "1");
            Goc.AppendChild(Record);
            xmlDoc.Save(sPath);
        }
        public void load()
        {
            xmlDoc.Load(sPath);
            XmlNodeList nodelist = xmlDoc.SelectNodes("Game/Setting");
            XmlNode node = nodelist[0];
            bSound = bool.Parse(node.Attributes[0].Value);
            sTheme = node.Attributes[1].Value;
            sMap = node.Attributes[2].Value;
            bGhost = bool.Parse(node.Attributes[3].Value);
            sLanguage = node.Attributes[4].Value;
            modeShape = int.Parse(node.Attributes[5].Value);
            arrowUp = int.Parse(node.Attributes[6].Value);
        }
        public void save()
        {
            XmlElement Goc = xmlDoc.CreateElement("Game");
            xmlDoc.AppendChild(Goc);
            XmlElement Record = xmlDoc.CreateElement("Setting");
            Record.SetAttribute("Sound", bSound.ToString());
            Record.SetAttribute("Theme", sTheme);
            Record.SetAttribute("Map", sMap);
            Record.SetAttribute("Ghost", bGhost.ToString());
            Record.SetAttribute("Language", sLanguage);
            Record.SetAttribute("Mode_Shape", modeShape.ToString());
            Record.SetAttribute("Arrow_Up", arrowUp.ToString());
            Goc.AppendChild(Record);
            xmlDoc.Save(sPath);
        }
    }
}

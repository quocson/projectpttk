using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TetrisReturn
{
    public class Language : IDisposable
    {
        XmlDocument xmlDoc;
        public string newgame;
        public string pause;
        public string resume;
        public string save;
        public string conti;
        public string score;
        public string help;
        public string about;
        public string exit;
        public string option;
        public string win;
        public string over;
        public string sound;
        public string ghost;
        public string loaddll;
        public string loadconfig;
        public string loadsave;

        public Language()
        {
            xmlDoc = new XmlDocument();

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void load(string filename)
        {
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"/Languages/" + filename);
            XmlNodeList nodelist = xmlDoc.SelectNodes("Language/Game");
            newgame = nodelist[0].Attributes[0].Value;
            pause = nodelist[1].Attributes[0].Value;
            resume = nodelist[2].Attributes[0].Value;
            save = nodelist[3].Attributes[0].Value;
            conti = nodelist[4].Attributes[0].Value;
            score = nodelist[5].Attributes[0].Value;
            help = nodelist[6].Attributes[0].Value;
            about = nodelist[7].Attributes[0].Value;
            exit = nodelist[8].Attributes[0].Value;
            option = nodelist[9].Attributes[0].Value;
            win = nodelist[10].Attributes[0].Value;
            over = nodelist[11].Attributes[0].Value;
            sound = nodelist[12].Attributes[0].Value;
            ghost = nodelist[13].Attributes[0].Value;
            loaddll = nodelist[14].Attributes[0].Value;
            loadconfig = nodelist[15].Attributes[0].Value;
            loadsave = nodelist[16].Attributes[0].Value;

        }

    }
}
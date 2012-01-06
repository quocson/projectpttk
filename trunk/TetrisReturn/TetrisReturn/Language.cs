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
        public string theme;
        public string map;
        public string language;
        public string shape;
        public string shape1;
        public string shape2;
        public string up;
        public string up1;
        public string up2;
        public string win;
        public string over;
        public string sound;
        public string ghost;
        public string loaddll;
        public string loadconfig;
        public string loadsave;
        public string language1;
        public string language2;
        public string captionDll;
        public string captionConfig;
        public string next;
        public string level;
        public string line;
        public string piece;
        public string exitConfirm;
        public string yes;
        public string no;
        public string winConfirm;
        public string overConfirm;
        public string newHighScore;

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
            if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"/Languages/" + filename))
                return;
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
            ghost = nodelist[12].Attributes[0].Value;
            sound = nodelist[13].Attributes[0].Value;
            loaddll = nodelist[14].Attributes[0].Value;
            loadconfig = nodelist[15].Attributes[0].Value;
            loadsave = nodelist[16].Attributes[0].Value;
            theme = nodelist[17].Attributes[0].Value;
            map = nodelist[18].Attributes[0].Value;
            language = nodelist[19].Attributes[0].Value;
            shape = nodelist[20].Attributes[0].Value;
            shape1 = nodelist[21].Attributes[0].Value;
            shape2 = nodelist[22].Attributes[0].Value;
            up = nodelist[23].Attributes[0].Value;
            up1 = nodelist[24].Attributes[0].Value;
            up2 = nodelist[25].Attributes[0].Value;
            language1 = nodelist[26].Attributes[0].Value;
            language2 = nodelist[27].Attributes[0].Value;
            captionDll = nodelist[28].Attributes[0].Value;
            captionConfig = nodelist[29].Attributes[0].Value;
            next = nodelist[30].Attributes[0].Value;
            level = nodelist[31].Attributes[0].Value;
            line = nodelist[32].Attributes[0].Value;
            piece = nodelist[33].Attributes[0].Value;
            exitConfirm = nodelist[34].Attributes[0].Value;
            yes = nodelist[35].Attributes[0].Value;
            no = nodelist[36].Attributes[0].Value;
            winConfirm = nodelist[37].Attributes[0].Value;
            overConfirm = nodelist[38].Attributes[0].Value;
            newHighScore = nodelist[39].Attributes[0].Value;

        }

    }
}
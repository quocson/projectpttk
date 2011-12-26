using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheSquareTimeMapPlugin
{
    class TheSquareTimeMapInterface : MapInterface
    {
        private Map map = new TheSquareTimeMap();
        public string VietNameseName { get { return TheSquareTimeMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheSquareTimeMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheSquareTimeMapPlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheSquareTimeMapPlugin.Properties.Resources.englishDescription; } }

        public Map Map { get { return map; } }

        public void Initialize()
        {
        }

        public void Dispose()
        {
            map.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

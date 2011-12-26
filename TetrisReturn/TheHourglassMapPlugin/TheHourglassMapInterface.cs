using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheHourglassMapPlugin
{
    class TheHourglassMapInterface : MapInterface
    {
        private Map map = new TheHourglassMap();
        public string VietNameseName { get { return TheHourglassMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheHourglassMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheHourglassMapPlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheHourglassMapPlugin.Properties.Resources.englishDescription; } }

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

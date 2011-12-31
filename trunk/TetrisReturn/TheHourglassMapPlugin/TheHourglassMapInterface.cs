using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheHourglassMapPlugin
{
    public class TheHourglassMapInterface : MapInterface
    {
        private Map map = new TheHourglassMap();
        public string VietNameseDescription { get { return TheHourglassMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheHourglassMapPlugin.Properties.Resources.name; } }
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

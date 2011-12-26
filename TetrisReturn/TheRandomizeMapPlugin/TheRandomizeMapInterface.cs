using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheRandomizeMapPlugin
{
    class TheRandomizeMapInterface : MapInterface
    {
        private Map map = new TheRandomizeMap();
        public string VietNameseName { get { return TheRandomizeMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheRandomizeMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheRandomizeMapPlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheRandomizeMapPlugin.Properties.Resources.englishDescription; } }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheRandomizeMapPlugin
{
    public class TheRandomizeMapInterface : MapInterface
    {
        private Map map = new TheRandomizeMap();
        public string VietNameseDescription { get { return TheRandomizeMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheRandomizeMapPlugin.Properties.Resources.name; } }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheClassicMapPlugin
{
    public class TheClassicMapInterface : MapInterface
    {
        private Map map = new TheClassicMap();
        public string VietNameseDescription { get { return TheClassicMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheClassicMapPlugin.Properties.Resources.name; } }
        public string EnglishDescription { get { return TheClassicMapPlugin.Properties.Resources.englishDescription; } }

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

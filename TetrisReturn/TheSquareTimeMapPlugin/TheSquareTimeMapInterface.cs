using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheSquareTimeMapPlugin
{
    public class TheSquareTimeMapInterface : MapInterface
    {
        private Map map = new TheSquareTimeMap();
        public string VietNameseDescription { get { return TheSquareTimeMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheSquareTimeMapPlugin.Properties.Resources.name; } }
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

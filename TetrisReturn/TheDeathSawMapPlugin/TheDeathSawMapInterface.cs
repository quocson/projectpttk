using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisReturn;
using MapPluginInterface;

namespace TheDeathSawMapPlugin
{
    public class TheDeathSawMapInterface : MapInterface
    {
        private Map map = new TheDeathSawMap();
        public string Name { get { return TheDeathSawMapPlugin.Properties.Resources.name; } }
        public string VietNameseDescription { get { return TheDeathSawMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishDescription { get { return TheDeathSawMapPlugin.Properties.Resources.englishDescription; } }

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

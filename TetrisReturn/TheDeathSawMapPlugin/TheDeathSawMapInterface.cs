using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisReturn;
using MapPluginInterface;

namespace TheDeathSawMapPlugin
{
    class TheDeathSawMapInterface : MapInterface
    {
        private Map map = new TheDeathSawMap();
        public string VietNameseName { get { return TheDeathSawMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheDeathSawMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheDeathSawMapPlugin.Properties.Resources.englishName; } }
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

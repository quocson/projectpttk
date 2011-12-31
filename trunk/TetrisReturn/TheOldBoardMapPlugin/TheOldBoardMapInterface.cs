using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheOldBoardMapPlugin
{
    public class TheOldBoardMapInterface : MapInterface
    {
        private Map map = new TheOldBoardMap();
        public string VietNameseDescription { get { return TheOldBoardMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheOldBoardMapPlugin.Properties.Resources.name; } }
        public string EnglishDescription { get { return TheOldBoardMapPlugin.Properties.Resources.englishDescription; } }

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

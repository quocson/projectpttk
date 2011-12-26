using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheOldBoardMapPlugin
{
    class TheOldBoardMapInterface : MapInterface
    {
        private Map map = new TheOldBoardMap();
        public string VietNameseName { get { return TheOldBoardMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheOldBoardMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheOldBoardMapPlugin.Properties.Resources.englishName; } }
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

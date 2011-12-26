using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheRazorBladeMapPlugin
{
    class TheRazorBladeMapInterface : MapInterface
    {
        private Map map = new TheRazorBladeMap();
        public string VietNameseName { get { return TheRazorBladeMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheRazorBladeMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheRazorBladeMapPlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheRazorBladeMapPlugin.Properties.Resources.englishDescription; } }

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

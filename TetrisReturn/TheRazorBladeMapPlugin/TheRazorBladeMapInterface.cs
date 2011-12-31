using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheRazorBladeMapPlugin
{
    public class TheRazorBladeMapInterface : MapInterface
    {
        private Map map = new TheRazorBladeMap();
        public string VietNameseDescription { get { return TheRazorBladeMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string Name { get { return TheRazorBladeMapPlugin.Properties.Resources.name; } }
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

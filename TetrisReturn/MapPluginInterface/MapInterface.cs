using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapPluginInterface
{
    public interface MapInterface
    {
        string VietNameseName { get; }
        string VietNameseDescription { get; }
        string EnglishName { get; }
        string EnglishDescription { get; }

        Map Map { get; }

        void Initialize();
        void Dispose();
    }
}

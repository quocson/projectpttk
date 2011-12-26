using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThemePluginInterface
{
    public interface ThemeInterface
    {
        string VietNameseName { get; }
        string VietNameseDescription { get; }
        string EnglishName { get; }
        string EnglishDescription { get; }

        Theme Theme { get; }

        void Initialize();
        void Dispose();
    }
}
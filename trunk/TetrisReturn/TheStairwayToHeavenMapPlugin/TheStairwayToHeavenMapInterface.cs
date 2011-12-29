﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapPluginInterface;

namespace TheStairwayToHeavenMapPlugin
{
    public class TheStairwayToHeavenMapInterface : MapInterface
    {
        private Map map = new TheStairwayToHeavenMap();
        public string VietNameseName { get { return TheStairwayToHeavenMapPlugin.Properties.Resources.vietNameseName; } }
        public string VietNameseDescription { get { return TheStairwayToHeavenMapPlugin.Properties.Resources.vietNameseDescription; } }
        public string EnglishName { get { return TheStairwayToHeavenMapPlugin.Properties.Resources.englishName; } }
        public string EnglishDescription { get { return TheStairwayToHeavenMapPlugin.Properties.Resources.englishDescription; } }

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

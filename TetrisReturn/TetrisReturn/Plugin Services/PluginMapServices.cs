using System;
using System.IO;
using System.Reflection;
using MapPluginInterface;

namespace TetrisReturn
{
    public class PluginMapServices
    {
        public PluginMapServices()
        {
        }
        private Types.AvailableMaps colAvailableMaps = new Types.AvailableMaps();

        public Types.AvailableMaps AvailableMaps
        {
            get { return colAvailableMaps; }
            set { colAvailableMaps = value; }
        }

        public void findMaps()
        {
            findMaps(AppDomain.CurrentDomain.BaseDirectory);
        }

        public void findMaps(string Path)
        {
            colAvailableMaps.Clear();

            foreach (string fileOn in Directory.GetFiles(Path))
            {
                FileInfo file = new FileInfo(fileOn);

                if (file.Extension.Equals(".dll"))
                {
                    this.addMap(fileOn);
                }
            }
        }

        public void closeMaps()
        {
            foreach (Types.AvailableMap mapOn in colAvailableMaps)
            {
                mapOn.Instance.Dispose();

                mapOn.Instance = null;
            }

            colAvailableMaps.Clear();
        }

        private void addMap(string FileName)
        {
            Assembly mapAssembly = Assembly.LoadFrom(FileName);

            foreach (Type mapType in mapAssembly.GetTypes())
            {
                if (mapType.IsPublic)
                {
                    if (!mapType.IsAbstract)
                    {
                        Type typeInterface = mapType.GetInterface("MapPluginInterface.MapInterface", true);

                        if (typeInterface != null)
                        {
                            Types.AvailableMap newMap = new Types.AvailableMap();

                            newMap.AssemblyPath = FileName;

                            newMap.Instance = (MapInterface)Activator.CreateInstance(mapAssembly.GetType(mapType.ToString()));

                            newMap.Instance.Initialize();

                            this.colAvailableMaps.Add(newMap);

                            newMap = null;
                        }

                        typeInterface = null;	
                    }
                }
            }

            mapAssembly = null;
        }
    }

    namespace Types
    {
        public class AvailableMaps : System.Collections.CollectionBase
        {
            public void Add(Types.AvailableMap mapToAdd)
            {
                this.List.Add(mapToAdd);
            }

            public void Remove(Types.AvailableMap mapToRemove)
            {
                this.List.Remove(mapToRemove);
            }

            public Types.AvailableMap Find(string mapNameOrPath)
            {
                Types.AvailableMap toReturn = null;

                foreach (Types.AvailableMap mapOn in this.List)
                {
                    if ((mapOn.Instance.Name.Equals(mapNameOrPath)) || mapOn.AssemblyPath.Equals(mapNameOrPath))
                    {
                        toReturn = mapOn;
                        break;
                    }
                }
                return toReturn;
            }

            public Types.AvailableMap getFirst()
            {
                Types.AvailableMap toReturn = null;

                toReturn = (AvailableMap)this.List[0];

                return toReturn;
            }
        }

        public class AvailableMap
        {
            private MapInterface myInstance = null;
            private string myAssemblyPath = "";

            public MapInterface Instance
            {
                get { return myInstance; }
                set { myInstance = value; }
            }
            public string AssemblyPath
            {
                get { return myAssemblyPath; }
                set { myAssemblyPath = value; }
            }
        }
    }
}

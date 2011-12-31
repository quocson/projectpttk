using System;
using System.IO;
using System.Reflection;
using ThemePluginInterface;

namespace TetrisReturn
{
    public class PluginThemeServices
    {
         public PluginThemeServices()
        {
        }
        private Types.AvailableThemes colAvailableThemes = new Types.AvailableThemes();

        public Types.AvailableThemes AvailableThemes
        {
            get { return colAvailableThemes; }
            set { colAvailableThemes = value; }
        }

        public void findThemes()
        {
            findThemes(AppDomain.CurrentDomain.BaseDirectory);
        }

        public void findThemes(string Path)
        {
            colAvailableThemes.Clear();

            foreach (string fileOn in Directory.GetFiles(Path))
            {
                FileInfo file = new FileInfo(fileOn);

                if (file.Extension.Equals(".dll"))
                {
                    this.addTheme(fileOn);
                }
            }
        }

        public void closeThemes()
        {
            foreach (Types.AvailableTheme themeOn in colAvailableThemes)
            {
                themeOn.Instance.Dispose();

                themeOn.Instance = null;
            }

            colAvailableThemes.Clear();
        }

        private void addTheme(string FileName)
        {
            Assembly themeAssembly = Assembly.LoadFrom(FileName);

            foreach (Type themeType in themeAssembly.GetTypes())
            {
                if (themeType.IsPublic)
                {
                    if (!themeType.IsAbstract)
                    {
                        Type typeInterface = themeType.GetInterface("ThemePluginInterface.ThemeInterface", true);

                        if (typeInterface != null)
                        {
                            Types.AvailableTheme newTheme = new Types.AvailableTheme();

                            newTheme.AssemblyPath = FileName;

                            newTheme.Instance = (ThemeInterface)Activator.CreateInstance(themeAssembly.GetType(themeType.ToString()));

                            newTheme.Instance.Initialize();

                            this.colAvailableThemes.Add(newTheme);

                            newTheme = null;
                        }

                        typeInterface = null;	
                    }
                }
            }

            themeAssembly = null;
        }
    }

    namespace Types
    {
        public class AvailableThemes : System.Collections.CollectionBase
        {
            public void Add(Types.AvailableTheme themeToAdd)
            {
                this.List.Add(themeToAdd);
            }

            public void Remove(Types.AvailableTheme themeToRemove)
            {
                this.List.Remove(themeToRemove);
            }

            public Types.AvailableTheme Find(string themeNameOrPath)
            {
                Types.AvailableTheme toReturn = null;

                foreach (Types.AvailableTheme themeOn in this.List)
                {
                    if ((themeOn.Instance.Name.Equals(themeNameOrPath)) || themeOn.AssemblyPath.Equals(themeNameOrPath))
                    {
                        toReturn = themeOn;
                        break;
                    }
                }
                return toReturn;
            }

            public Types.AvailableTheme getFirst()
            {
                Types.AvailableTheme toReturn = null;

                toReturn = (AvailableTheme)this.List[0];

                return toReturn;
            }
        }

        public class AvailableTheme
        {
            private ThemeInterface myInstance = null;
            private string myAssemblyPath = "";

            public ThemeInterface Instance
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
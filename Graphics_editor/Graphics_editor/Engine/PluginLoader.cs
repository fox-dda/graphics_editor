using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SDK;

namespace GraphicsEditor.Engine
{
    class PluginLoader
    {
        public Dictionary<string, BaseDrawer> LoadDrawers()
        {
            var drawerDictionary = new Dictionary<string, BaseDrawer>();
            DirectoryInfo drawersDirectory =
                new DirectoryInfo(Directory.GetCurrentDirectory());
            
            FileInfo[] drawersDlls = drawersDirectory.GetFiles("*Plugin.dll");
            foreach (var drawerDll in drawersDlls)
            {
                var assembly = Assembly.LoadFrom(drawerDll.FullName);
                foreach (var assemblyDefinedType in assembly.DefinedTypes)
                {
                    if (assemblyDefinedType.Name.Contains("Drawer"))
                    {
                        int cutAfter = drawerDll.Name.IndexOf
                        (
                            "Plugin.dll", 
                            StringComparison.Ordinal
                        );
                        drawerDictionary.Add(drawerDll.Name.Substring(0, cutAfter),
                            (BaseDrawer)Activator.CreateInstance(
                                assemblyDefinedType.AsType()));
                    }
                }
            }

            return drawerDictionary;
        }

        public Dictionary<string, Type> LoadModels()
        {
            var modelDictionary = new Dictionary<string, Type>();
            DirectoryInfo modelsDirectory =
                new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] modelsDlls = modelsDirectory.GetFiles("*Plugin.dll");
            foreach (var modelsDll in modelsDlls)
            {
                var assembly = Assembly.LoadFrom(modelsDll.FullName);
                foreach (var assemblyDefinedType in assembly.DefinedTypes)
                {
                    if (assemblyDefinedType.Name.Contains("Model"))
                    {
                        int cutAfter = modelsDll.Name.IndexOf
                        (
                            "Plugin.dll",
                            StringComparison.Ordinal
                        );
                        modelDictionary.Add
                        (
                            modelsDll.Name.Substring(0, cutAfter),
                            assemblyDefinedType.AsType()
                        );
                    }
                }
            }

            return modelDictionary;
        }
    }
}

using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container =  new Container(_ =>
            {
                _.Scan(o =>
                {
                    o.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    o.AddAllTypesOf<SDK.IDrawable>().NameBy(x => x.Name);
                });
            });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(container));
        }
    }
}

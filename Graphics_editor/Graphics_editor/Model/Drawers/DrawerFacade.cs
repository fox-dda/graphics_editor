using System;
using System.Collections.Generic;
using GraphicsEditor.Enums;
using System.IO;
using System.Reflection;
using System.Drawing;
using SDK;

namespace GraphicsEditor.Model.Drawers
{
    /// <summary>
    /// Фасад отрисовщиков
    /// </summary>
    public class DrawerFacade
    {
        /// <summary>
        /// Словарь отрисовщиков фигур
        /// </summary>
        private readonly Dictionary<string, BaseDrawer> _drawerDictionary = new Dictionary<string, BaseDrawer>();

        /// <summary>
        /// Отрисовщик выделения
        /// </summary>
        private readonly HighlightDrawer _highlightDrawer;

        /// <summary>
        /// Конструктор фасада отрисовщиков
        /// </summary>
        public DrawerFacade()
        {
            _drawerDictionary.Add("Selection", new HighlightRectDrawer());
            DirectoryInfo drawersDirectory =
                new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] drawersDlls = drawersDirectory.GetFiles("*Model.dll");
            foreach (var drawerDll in drawersDlls)
            {
                var assembly = Assembly.LoadFrom(drawerDll.FullName);
                foreach (var assemblyDefinedType in assembly.DefinedTypes)
                {
                    if (assemblyDefinedType.Name.Contains("Drawer"))
                    {
                        int cutAfter = drawerDll.Name.IndexOf("Model.dll", StringComparison.Ordinal);
                        _drawerDictionary.Add(drawerDll.Name.Substring(0, cutAfter),
                            (BaseDrawer)Activator.CreateInstance(assemblyDefinedType.AsType()));
                    }
                }
            }
            _highlightDrawer = new HighlightDrawer();
        }

        /// <summary>
        /// Отрисовать фигуру
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public void DrawShape(IDrawable shape, Graphics graphics)
        {
            if (shape == null)
                return;

            _drawerDictionary[(shape as INamed).GetName()]?.DrawShape(shape, graphics);
        }

        /// <summary>
        /// Отрисовать выделение
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public void DrawHighlight(IDrawable shape, Graphics graphics)
        {
            _highlightDrawer.DrawShape(shape, graphics);
        }
    }
}

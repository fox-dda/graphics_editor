using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Drawing;
using GraphicsEditor.Engine;
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
            _highlightDrawer = new HighlightDrawer();
            var pluginLoader = new PluginLoader();
            _drawerDictionary = pluginLoader.LoadDrawers();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        private readonly Dictionary<Type, BaseDrawer> _drawerDictionary = new Dictionary<Type, BaseDrawer>();
        /// <summary>
        /// Отрисовщик выделения
        /// </summary>
        private readonly HighlightDrawer _highlightDrawer;

        /// <summary>
        /// Конструктор фасад отрисовщиков
        /// </summary>
        public DrawerFacade()
        {
            _drawerDictionary.Add(typeof(Line), new LineDrawer());
            _drawerDictionary.Add(typeof(Polyline), new PolylineDrawer());
            _drawerDictionary.Add(typeof(Polygon), new PolygonDrawer());
            _drawerDictionary.Add(typeof(Circle), new CircleDrawer());
            _drawerDictionary.Add(typeof(Ellipse), new EllipseDrawer());
            _drawerDictionary.Add(typeof(HighlightRect), new HighlightRectDrawer());
            _highlightDrawer = new HighlightDrawer();
        }

        /// <summary>
        /// Отрисовать фигуру
        /// </summary>
        /// <param name="shape">Фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public void DrawShape(IDrawable shape, Graphics graphics)
        {
            _drawerDictionary[shape.GetType()]?.DrawShape(shape, graphics);
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

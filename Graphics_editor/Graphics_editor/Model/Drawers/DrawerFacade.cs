using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    public class DrawerFacade
    {
        private readonly Dictionary<Type, BaseDrawer> _drawerDictionary = new Dictionary<Type, BaseDrawer>();

        public DrawerFacade()
        {
            _drawerDictionary.Add(typeof(Line), new LineDrawer());
            _drawerDictionary.Add(typeof(Polyline), new PolylineDrawer());
            _drawerDictionary.Add(typeof(Polygon), new PolygonDrawer());
            _drawerDictionary.Add(typeof(Circle), new CircleDrawer());
            _drawerDictionary.Add(typeof(Ellipse), new EllipseDrawer());
            _drawerDictionary.Add(typeof(HighlightRect), new HighlightRectDrawer());
        }

        public void DrawShape(IDrawable shape, Graphics graphics)
        {
            _drawerDictionary[shape.GetType()]?.DrawShape(shape, graphics);
        }
    }
}

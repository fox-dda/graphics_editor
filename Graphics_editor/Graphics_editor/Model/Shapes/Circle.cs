using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Circle : Ellipse, IDrawable, IBrushable
    {
        public Circle(Point _startPoint, Point _endPoint, Pen _pen) : base(_startPoint, _endPoint, _pen)
        {
            var size = Math.Max(Math.Abs(_startPoint.X - _endPoint.X), Math.Abs(_startPoint.Y - _endPoint.Y));
            var minX = Math.Min(_startPoint.X, _endPoint.X);
            var minY = Math.Min(_startPoint.Y, _endPoint.Y);
            _startPoint = new Point(minX, minY);
            _endPoint = new Point(minX + size, minY + size);
        }
    }
}

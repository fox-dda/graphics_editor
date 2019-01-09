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
        public Circle(Point _startPoint, Point _endPoint, Pen _pen) : base(_startPoint, _endPoint, _pen){}
    }
}

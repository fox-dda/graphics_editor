using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    [Serializable]
    class Circle : Ellipse, IDrawable, IBrushable
    {
        public Circle(Point _startPoint, Point _endPoint, PenSettings _pen) : base(_startPoint, _endPoint, _pen){}
    }
}

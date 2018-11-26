using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class Circle : Ellipse, IDrawable
    {

        new public void Draw(Graphics g)
        {
            if (_brush != null)
                g.FillEllipse(_brush, (StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2,
                StartPoint.X - EndPoint.X, StartPoint.X - EndPoint.X);
            g.DrawEllipse(Pen, (StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2,
                StartPoint.X - EndPoint.X, StartPoint.X - EndPoint.X);
        }

        public Circle(Point _startPoint, Point _endPoint, Pen _pen) : base(_startPoint, _endPoint, _pen) { }
    }
}

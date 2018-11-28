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

        new public void Draw(Graphics g)
        {
            var size = Math.Abs(EndPoint.X - StartPoint.X) > Math.Abs(EndPoint.Y - StartPoint.Y) ?
                Math.Abs(EndPoint.X - StartPoint.X) : Math.Abs(EndPoint.Y - StartPoint.Y);

            //сверху вниз слево направа
            if ((StartPoint.Y < EndPoint.Y) && (StartPoint.X < EndPoint.X))
            {
                if (_brush != null)
                    g.FillEllipse(_brush, EndPoint.X, EndPoint.Y, size, size);
                g.DrawEllipse(Pen, StartPoint.X, StartPoint.Y, size, size);
            }
            //сверху вниз справа налево
            else if ((StartPoint.Y < EndPoint.Y) && (StartPoint.X > EndPoint.X))
            {
                if (_brush != null)
                    g.FillEllipse(_brush, EndPoint.X, EndPoint.Y, size, size);
                g.DrawEllipse(Pen, EndPoint.X, StartPoint.Y, size, size);
            }
            //cнизу вверх слево на права
            else if ((StartPoint.Y > EndPoint.Y) && (StartPoint.X < EndPoint.X))
            {
                if (_brush != null)
                    g.FillEllipse(_brush, EndPoint.X, EndPoint.Y, size, size);
                g.DrawEllipse(Pen, StartPoint.X, EndPoint.Y, size, size);
            }

            //cнизу вверх справа налево
            else if ((StartPoint.Y > EndPoint.Y) && (StartPoint.X > EndPoint.X))
            {
                if (_brush != null)
                    g.FillEllipse(_brush, EndPoint.X, EndPoint.Y, size, size);
                g.DrawEllipse(Pen, EndPoint.X, EndPoint.Y, size, size);
            }
        }

        public Circle(Point _startPoint, Point _endPoint, Pen _pen) : base(_startPoint, _endPoint, _pen) { }
    }
}

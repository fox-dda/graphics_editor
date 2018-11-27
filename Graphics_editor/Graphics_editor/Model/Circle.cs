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
            if (IsHighlighting)
            {
                var pen = new Pen(Color.Gray, 1);
                pen.DashPattern = new float[] { 2, 2 };
                g.DrawRectangle(pen, StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
            }
            if (_brush != null)
                g.FillEllipse(_brush, (StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2,
                StartPoint.X - EndPoint.X, StartPoint.X - EndPoint.X);
            g.DrawEllipse(Pen, (StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2,
                StartPoint.X - EndPoint.X, StartPoint.X - EndPoint.X);
        }

        public Circle(Point _startPoint, Point _endPoint, Pen _pen) : base(_startPoint, _endPoint, _pen) { }
    }
}

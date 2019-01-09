using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    class CircleDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var circle = shape as Circle;
            var startPoint = circle.StartPoint;
            var endPoint = circle.EndPoint;
            var brush = (circle as IBrushable).BrushColor;
            var pen = circle.Pen;
            var size = Math.Abs(endPoint.X - startPoint.X) > Math.Abs(endPoint.Y - startPoint.Y) ?
                Math.Abs(endPoint.X - startPoint.X) : Math.Abs(endPoint.Y - startPoint.Y);

            //сверху вниз слево направа
            if ((startPoint.Y < endPoint.Y) && (startPoint.X < endPoint.X))
            {

            }
            //сверху вниз справа налево
            else if ((startPoint.Y < endPoint.Y) && (startPoint.X > endPoint.X))
            {
                startPoint = new Point(startPoint.X - size, startPoint.Y);
            }
            //cнизу вверх слево на права
            else if ((startPoint.Y > endPoint.Y) && (startPoint.X < endPoint.X))
            {
                startPoint = new Point(startPoint.X, startPoint.Y - size);
            }
            //cнизу вверх справа налево
            else if ((startPoint.Y > endPoint.Y) && (startPoint.X > endPoint.X))
            {
                startPoint = new Point(startPoint.X - size, startPoint.Y - size);
            }
            endPoint = new Point(startPoint.X + size, startPoint.Y + size);

            if (brush != null)
                graphics.FillEllipse(new SolidBrush(brush), startPoint.X, startPoint.Y, size, size);
            graphics.DrawEllipse(pen, startPoint.X, startPoint.Y, size, size);
        }
    }
}

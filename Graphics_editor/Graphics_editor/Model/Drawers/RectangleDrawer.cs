using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Model.Drawers
{
    class RectangleDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var StartPoint = shape.StartPoint;
            var endPoint = shape.EndPoint;
            var pen = DraftFactory.CreatePen(shape.Pen);

            //сверху вниз слево направа
            if ((StartPoint.Y < endPoint.Y) && (StartPoint.X < endPoint.X))
            {
                graphics.DrawRectangle(pen, StartPoint.X, StartPoint.Y,
                    Math.Abs(endPoint.X - StartPoint.X), Math.Abs(endPoint.Y - StartPoint.Y));
            }
            //сверху вниз справа налево
            else if ((StartPoint.Y < endPoint.Y) && (StartPoint.X > endPoint.X))
            {
                graphics.DrawRectangle(pen, endPoint.X, StartPoint.Y,
                    Math.Abs(endPoint.X - StartPoint.X), Math.Abs(endPoint.Y - StartPoint.Y));
            }
            //cнизу вверх слево на права
            else if ((StartPoint.Y > endPoint.Y) && (StartPoint.X < endPoint.X))
            {
                graphics.DrawRectangle(pen, StartPoint.X, endPoint.Y,
                    Math.Abs(endPoint.X - StartPoint.X), Math.Abs(endPoint.Y - StartPoint.Y));
            }

            //cнизу вверх справа налево
            else if ((StartPoint.Y > endPoint.Y) && (StartPoint.X > endPoint.X))
            {
                graphics.DrawRectangle(pen, endPoint.X, endPoint.Y,
                    Math.Abs(endPoint.X - StartPoint.X), Math.Abs(endPoint.Y - StartPoint.Y));
            }
        }
    }
}

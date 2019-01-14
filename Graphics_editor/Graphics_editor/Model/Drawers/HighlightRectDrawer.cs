using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.Model.Drawers
{
    class HighlightRectDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var startPoint = shape.StartPoint;
            var endPoint = shape.EndPoint;
            var pen = new Pen(shape.Pen.Color, shape.Pen.Width) { DashPattern = shape.Pen.DashPattern };

            //сверху вниз слево направа
            if ((startPoint.Y < endPoint.Y) && (startPoint.X < endPoint.X))
            {
                graphics.DrawRectangle(pen, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
            //сверху вниз справа налево
            else if ((startPoint.Y < endPoint.Y) && (startPoint.X > endPoint.X))
            {
                graphics.DrawRectangle(pen, endPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
            //cнизу вверх слево на права
            else if ((startPoint.Y > endPoint.Y) && (startPoint.X < endPoint.X))
            {
                graphics.DrawRectangle(pen, startPoint.X, endPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }

            //cнизу вверх справа налево
            else if ((startPoint.Y > endPoint.Y) && (startPoint.X > endPoint.X))
            {
                graphics.DrawRectangle(pen, endPoint.X, endPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
        }

    }
}

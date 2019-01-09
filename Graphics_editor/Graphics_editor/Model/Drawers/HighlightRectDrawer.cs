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
            var _pen = new Pen(Color.Gray, 1)
            {
                DashPattern = new float[] { 2, 2 }
            };

            //сверху вниз слево направа
            if ((startPoint.Y < endPoint.Y) && (startPoint.X < endPoint.X))
            {
                graphics.DrawRectangle(_pen, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
            //сверху вниз справа налево
            else if ((startPoint.Y < endPoint.Y) && (startPoint.X > endPoint.X))
            {
                graphics.DrawRectangle(_pen, endPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
            //cнизу вверх слево на права
            else if ((startPoint.Y > endPoint.Y) && (startPoint.X < endPoint.X))
            {
                graphics.DrawRectangle(_pen, startPoint.X, endPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }

            //cнизу вверх справа налево
            else if ((startPoint.Y > endPoint.Y) && (startPoint.X > endPoint.X))
            {
                graphics.DrawRectangle(_pen, endPoint.X, endPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }

            if ((shape as HighlightRect).DotList != null)
            {
                foreach (Point dot in (shape as HighlightRect).DotList)
                {
                    graphics.DrawRectangle(new Pen(Color.Red), dot.X, dot.Y, 4, 4);
                    graphics.FillEllipse(new SolidBrush(Color.Blue), dot.X, dot.Y, 3, 3);
                }
            }
            else
            {
                graphics.FillEllipse(new SolidBrush(Color.Blue), startPoint.X, startPoint.Y, 3, 3);
                graphics.FillEllipse(new SolidBrush(Color.Blue), endPoint.X, endPoint.Y, 3, 3);
                graphics.DrawRectangle(new Pen(Color.Red), startPoint.X, startPoint.Y, 4, 4);
                graphics.DrawRectangle(new Pen(Color.Red), endPoint.X, endPoint.Y, 4, 4);
            }

            drawDragDropMarker(shape, graphics);
        }

        private void drawDragDropMarker(IDrawable shape, Graphics g)
        {
            if ((shape as HighlightRect).LightItem == null)
                return;

            var dragDropMarker = (shape as HighlightRect).DragDropMarkerPoint;
            g.DrawRectangle(new Pen(Color.Red), dragDropMarker.X + 11, dragDropMarker.Y - 11, 10, 10);
            g.DrawLine(new Pen(Color.Red), new Point(dragDropMarker.X + 11, dragDropMarker.Y - 6), new Point(dragDropMarker.X + 21, dragDropMarker.Y - 6));
            g.DrawLine(new Pen(Color.Red), new Point(dragDropMarker.X + 16, dragDropMarker.Y - 11), new Point(dragDropMarker.X + 16, dragDropMarker.Y));
        }
    }
}

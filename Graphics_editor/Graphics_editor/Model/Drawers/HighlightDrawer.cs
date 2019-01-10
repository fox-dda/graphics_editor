using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    class HighlightDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable frameItem, Graphics graphics)
        {
            var startPoint = frameItem.StartPoint;
            var endPoint = frameItem.EndPoint;
            var _pen = new Pen(Color.Gray, 1)
            {
                DashPattern = new float[] { 2, 2 }
            };

            if (frameItem is Polygon)
            {
                int minX = frameItem.StartPoint.X;
                int maxX = frameItem.StartPoint.X;
                int minY = frameItem.StartPoint.Y;
                int maxY = frameItem.StartPoint.Y;

                foreach (Point point in (frameItem as Polygon).DotList)
                {
                    if (minX > point.X)
                    {
                        minX = point.X;
                    }
                    if (maxX < point.X)
                    {
                        maxX = point.X;
                    }
                    if (minY > point.Y)
                    {
                        minY = point.Y;
                    }
                    if (maxY < point.Y)
                    {
                        maxY = point.Y;
                    }
                }
                startPoint = new Point(minX, minY);
                endPoint = new Point(maxX, maxY);
            }

            else if (frameItem is Polyline)
            {
                int minX = frameItem.StartPoint.X;
                int maxX = frameItem.StartPoint.X;
                int minY = frameItem.StartPoint.Y;
                int maxY = frameItem.StartPoint.Y;

                foreach (Point point in (frameItem as Polyline).DotList)
                {
                    if (minX > point.X)
                    {
                        minX = point.X;
                    }
                    if (maxX < point.X)
                    {
                        maxX = point.X;
                    }
                    if (minY > point.Y)
                    {
                        minY = point.Y;
                    }
                    if (maxY < point.Y)
                    {
                        maxY = point.Y;
                    }
                }
                startPoint = new Point(minX, minY);
                endPoint = new Point(maxX, maxY);
            }

            else
            {
                startPoint = frameItem.StartPoint;
                endPoint = frameItem.EndPoint;
            }

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

            if ((frameItem is Polyline) || (frameItem is Polygon))
            {
                if(frameItem is Polyline)
                    foreach (Point dot in (frameItem as Polyline).DotList)
                    {
                        graphics.DrawRectangle(new Pen(Color.Red), dot.X, dot.Y, 4, 4);
                        graphics.FillEllipse(new SolidBrush(Color.Blue), dot.X, dot.Y, 3, 3);
                    }
                else
                    foreach (Point dot in (frameItem as Polygon).DotList)
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

            drawDragDropMarker(frameItem, graphics, startPoint, endPoint);
        }

        private void drawDragDropMarker(IDrawable shape, Graphics g, Point startPoint, Point endPoint)
        {
            Point dragDropMarker = new Point();

            if ((startPoint.X < endPoint.X) && (startPoint.Y < endPoint.Y))
            {
                dragDropMarker = startPoint;
            }
            else if ((startPoint.X > endPoint.X) && (startPoint.Y < endPoint.Y))
            {
                dragDropMarker = new Point(endPoint.X, startPoint.Y);
            }
            else if ((startPoint.X < endPoint.X) && (startPoint.Y > endPoint.Y))
            {
                dragDropMarker = new Point(startPoint.X, endPoint.Y); ;
            }
            else if ((startPoint.X > endPoint.X) && (startPoint.Y > endPoint.Y))
            {
                dragDropMarker = endPoint;
            }
            g.DrawRectangle(new Pen(Color.Red), dragDropMarker.X + 11, dragDropMarker.Y - 11, 10, 10);
            g.DrawLine(new Pen(Color.Red), new Point(dragDropMarker.X + 11, dragDropMarker.Y - 6), new Point(dragDropMarker.X + 21, dragDropMarker.Y - 6));
            g.DrawLine(new Pen(Color.Red), new Point(dragDropMarker.X + 16, dragDropMarker.Y - 11), new Point(dragDropMarker.X + 16, dragDropMarker.Y));
        }
    }
}

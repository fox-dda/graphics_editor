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

            int minX = frameItem.StartPoint.X;
            int maxX = frameItem.StartPoint.X;
            int minY = frameItem.StartPoint.Y;
            int maxY = frameItem.StartPoint.Y;

            if (frameItem is Polygon)
            {
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
            else if(frameItem is Circle)
            {
                Point[] array = new Point[] { startPoint, endPoint };
                for (int i = 0; i > 1; i++)
                {
                    if (minX > array[i].X)
                    {
                        minX = array[i].X;
                    }
                    if (minY > array[i].Y)
                    {
                        minY = array[i].Y;
                    }
                }
                startPoint = new Point(minX, minY);
            }

            else
            {
                startPoint = frameItem.StartPoint;
                endPoint = frameItem.EndPoint;
            }

            /*/if(frameItem is Circle)
            {
                var size = Math.Max((endPoint.X - startPoint.X), (endPoint.Y - startPoint.Y));
                graphics.DrawRectangle(_pen, startPoint.X, startPoint.Y,
                    startPoint.X + size, startPoint.Y + size);
            }
            //сверху вниз слево направа
            else/*/ if ((startPoint.Y < endPoint.Y) && (startPoint.X < endPoint.X))
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
        }
    }
}

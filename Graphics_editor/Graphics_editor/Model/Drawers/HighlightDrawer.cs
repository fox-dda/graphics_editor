using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    /// <summary>
    /// Отрисовщик выделения
    /// </summary>
    class HighlightDrawer: BaseDrawer
    {
        /// <summary>
        /// Отрисовать выделеление
        /// </summary>
        /// <param name="frameItem">Фигура, по которой рисуется выделение</param>
        /// <param name="graphics">Ядро рисования</param>
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
            else if (frameItem is Circle)
            {
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
            }
            else
            {
                startPoint = frameItem.StartPoint;
                endPoint = frameItem.EndPoint;
            }

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
                graphics.FillEllipse(new SolidBrush(Color.Blue), frameItem.StartPoint.X, frameItem.StartPoint.Y, 3, 3);
                graphics.FillEllipse(new SolidBrush(Color.Blue), frameItem.EndPoint.X, frameItem.EndPoint.Y, 3, 3);
                graphics.DrawRectangle(new Pen(Color.Red), frameItem.StartPoint.X, frameItem.StartPoint.Y, 4, 4);
                graphics.DrawRectangle(new Pen(Color.Red), frameItem.EndPoint.X, frameItem.EndPoint.Y, 4, 4);
            }
        }
    }
}

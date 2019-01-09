using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEditor.Model;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class HighlightRect: IDrawable
    {
        private Point _startPoint;
        private Point _endPoint;
        public IDrawable LightItem = null;
        public List<Point> DotList = null;
        public Pen Pen
        {
            get
            {
                return new Pen(Color.Gray);
            }
            set{}
        }

        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                _startPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
            }
        }

        public Point DragDropMarkerPoint
        {
            get
            {
                Point dragDropMarker = new Point();

                if ((StartPoint.X < EndPoint.X) && (StartPoint.Y < EndPoint.Y))
                {
                    dragDropMarker = StartPoint;
                }
                else if ((StartPoint.X > EndPoint.X) && (StartPoint.Y < EndPoint.Y))
                {
                    dragDropMarker = new Point(EndPoint.X, StartPoint.Y);
                }
                else if ((StartPoint.X < EndPoint.X) && (StartPoint.Y > EndPoint.Y))
                {
                    dragDropMarker = new Point(StartPoint.X, EndPoint.Y); ;
                }
                else if ((StartPoint.X > EndPoint.X) && (StartPoint.Y > EndPoint.Y))
                {
                    dragDropMarker = EndPoint;
                }

                return dragDropMarker;
            }
        }

        public HighlightRect(IDrawable frameItem)
        {
            LightItem = frameItem;
            
            if (frameItem is Polygon)
            {
                DotList = (frameItem as Polygon).DotList;
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
                StartPoint = new Point(minX, minY);
                EndPoint = new Point(maxX, maxY);
            }

            else if (frameItem is Polyline)
            {
                DotList = (frameItem as Polyline).DotList;
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
                StartPoint = new Point(minX, minY);
                EndPoint = new Point(maxX, maxY);
            }

            else
            {
                StartPoint = frameItem.StartPoint;
                EndPoint = frameItem.EndPoint;
            }
        }
        public HighlightRect(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}

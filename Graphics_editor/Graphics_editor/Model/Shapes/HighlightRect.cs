using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEditor.Model.Shapes;
using System.Drawing;

namespace GraphicsEditor.Model
{
    class HighlightRect: IDrawable
    {
        private Point _startPoint;
        private Point _endPoint;
        public PenSettings Pen
        {
            get
            {
                return new PenSettings { DashPattern = new float[] { 2, 2 }, Width = 1, Color = Color.Gray };
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

        public HighlightRect(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}

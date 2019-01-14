using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{ 
    [Serializable]
    class Polyline: IDrawable
    {
        private Pen _pen;
        public List<Point> _dotList = new List<Point>();

        public Point StartPoint
        {
            get
            {
                return DotList[0];
            }
            set
            {
                DotList[0] = value;
            }
        }
        public Point EndPoint
        {
            get
            {
                return DotList.Last();
            }
            set
            {
                DotList[DotList.Count-1] = value;
            }
        }
        public Pen Pen
        {
            get
            {
                return _pen;
            }
            set
            {
                _pen = value;
            }
        }

        public List<Point> DotList
        {
            get
            {
                return _dotList; 
            }
            set
            {
                if (value.Count < 2)
                {
                    throw new Exception("Нельзя создать линию из одной точки!");
                }
                else
                {
                    _dotList = value;
                }
            }
        }

        public void AddPoint(Point point)
        {
            _dotList.Add(point);
        }

        public Polyline(List<Point> dotlist, Pen pen)
        {
            this.Pen = pen;
            DotList = dotlist;
        }
    }
}

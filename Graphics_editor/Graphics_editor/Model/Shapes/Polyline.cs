using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicsEditor.Model.Shapes;
using System.Drawing;

namespace GraphicsEditor.Model
{ 
    /// <summary>
    /// Полилиния
    /// </summary>
    [Serializable]
    class Polyline: IDrawable, IMultipoint
    {
        /// <summary>
        /// Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        /// Список точек
        /// </summary>
        public List<Point> _dotList = new List<Point>();

        /// <summary>
        /// Точка старта
        /// </summary>
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

        /// <summary>
        /// Точка конца
        /// </summary>
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

        /// <summary>
        /// Настройки пера
        /// </summary>
        public PenSettings Pen
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

        /// <summary>
        /// Список точек
        /// </summary>
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

        /// <summary>
        /// Добавить точку
        /// </summary>
        /// <param name="point">Добавляемая точка</param>
        public void AddPoint(Point point)
        {
            _dotList.Add(point);
        }

        /// <summary>
        /// Конструктор полилинии
        /// </summary>
        /// <param name="dotlist">Список точек</param>
        /// <param name="pen">Настройки пера</param>
        public Polyline(List<Point> dotlist, PenSettings pen)
        {
            Pen = pen;
            DotList = dotlist;
        }
    }
}

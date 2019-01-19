using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Полигон
    /// </summary>
    [Serializable]
    class Polygon : IDrawable, IBrushable, IMultipoint
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        private Color _brush;

        /// <summary>
        /// Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }

        /// <summary>
        /// Список точек
        /// </summary>
        private List<Point> _dotList = new List<Point>();
        
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
                DotList[DotList.Count - 1] = value;
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
        /// Добавиь точку
        /// </summary>
        /// <param name="point">Добавляемая точка</param>
        public void AddPoint(Point point)
        {
            _dotList.Add(point);
        }

        /// <summary>
        /// Конструктор полигона
        /// </summary>
        /// <param name="dotlist">Список точек</param>
        /// <param name="pen">Настройки пера</param>
        public Polygon(List<Point> dotlist, PenSettings pen)
        {
            Pen = pen;
            DotList = dotlist;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SDK;
using System.Drawing;

namespace PolygonPlugin
{
    /// <summary>
    /// Полигон
    /// </summary>
    [Serializable]
    public class PolygonModel : IDrawable, IBrushable, IMultipoint
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
            get => _brush;
            set => _brush = value;
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
            get => DotList[0];
            set => DotList[0] = value;
        }

        /// <summary>
        /// Точка конца
        /// </summary>
        public Point EndPoint
        {
            get => DotList.Last();
            set => DotList[DotList.Count - 1] = value;
        }

        /// <summary>
        /// Настройки пера
        /// </summary>
        public PenSettings Pen
        {
            get => _pen;
            set => _pen = value;
        }

        /// <summary>
        /// Список точек
        /// </summary>
        public List<Point> DotList
        {
            get => _dotList;
            set
            {
                if (value.Count > 2)
                {
                    _dotList = value;
                }
            }
        }

        /// <summary>
        /// Конструктор полигона
        /// </summary>
        /// <param name="dotlist">Список точек</param>
        /// <param name="pen">Настройки пера</param>
        public PolygonModel(List<Point> dotlist, PenSettings pen)
        {
            Pen = pen;
            DotList = dotlist;
        }
    }
}
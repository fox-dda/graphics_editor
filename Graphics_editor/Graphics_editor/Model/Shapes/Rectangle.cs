using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicsEditor.Model.Shapes;
using System.Drawing;

namespace GraphicsEditor.Model
{ 
    /// <summary>
    /// Прямоугольник
    /// </summary>
    [Serializable]
    class Rectangle : IDrawable, IBrushable
    {
        /// <summary>
        /// Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        /// Точка старта
        /// </summary>
        private Point _startPoint;

        /// <summary>
        /// Точка конца
        /// </summary>
        private Point _endPoint;

        /// <summary>
        /// Цвет заливки
        /// </summary>
        private SolidBrush _brush;
        
        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get
            {
                return _brush.Color;
            }
            set
            {
                _brush = new SolidBrush(value);
            }
        }

        /// <summary>
        /// Точка старта
        /// </summary>
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

        /// <summary>
        /// Точка конца
        /// </summary>
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
    }
}

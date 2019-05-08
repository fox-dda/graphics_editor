using System;
using SDK;
using System.Drawing;

namespace CirclePlugin
{
    /// <summary>
    /// Эллипс
    /// </summary>
    [Serializable]
    public class Circle : IDrawable, IBrushable, INamed, ICloneable
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get => _brush;
            set => _brush = value;
        }

        /// <summary>
        /// Точка старта
        /// </summary>
        private Point _startPoint;

        /// <summary>
        /// Точка конца
        /// </summary>
        private Point _endPoint;

        /// <summary>
        /// Настройки пера
        /// </summary>
        private PenSettings _pen;

        /// <summary>
        /// Цвет заливки
        /// </summary>
        protected Color _brush;

        /// <summary>
        /// Точка старта
        /// </summary>
        public Point StartPoint
        {
            get => _startPoint;
            set => _startPoint = value;
        }

        /// <summary>
        /// Точка конца
        /// </summary>
        public Point EndPoint
        {
            get => _endPoint;
            set => _endPoint = value;
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
        /// Верныть имя
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return "Circle";
        }

        /// <summary>
        /// Клонировать
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Circle(
                new Point(StartPoint.X, StartPoint.Y),
                new Point(EndPoint.X, EndPoint.Y),
                new PenSettings()
                {
                    Color = Pen.Color,
                    Width = Pen.Width,
                    DashPattern = Pen.DashPattern
                }){BrushColor = this.BrushColor };
        }

        /// <summary>
        /// Конструктор эллипса
        /// </summary>
        /// <param name="startPoint">Точка старта</param>
        /// <param name="endPoint">Точка конца</param>
        /// <param name="pen">Настройки пера</param>
        private Circle(Point startPoint, Point endPoint, PenSettings pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Pen = pen;
        }

        public Circle() { }
    }
}


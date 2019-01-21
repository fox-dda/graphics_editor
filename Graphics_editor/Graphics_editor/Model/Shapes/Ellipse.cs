using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Эллипс
    /// </summary>
    [Serializable]
    public class Ellipse : IDrawable, IBrushable
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
        protected  Color _brush;

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
        /// Конструктор эллипса
        /// </summary>
        /// <param name="startPoint">Точка старта</param>
        /// <param name="endPoint">Точка конца</param>
        /// <param name="pen">Настройки пера</param>
        public Ellipse(Point startPoint, Point endPoint, PenSettings pen)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Pen = pen;
        }
    }
}

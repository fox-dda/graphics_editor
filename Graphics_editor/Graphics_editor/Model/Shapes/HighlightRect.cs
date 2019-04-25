using System.Drawing;
using SDK;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Рамка выделения
    /// </summary>
    public class HighlightRect: IDrawable
    {
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
        public PenSettings Pen
        {
            get
            {
                return new PenSettings
                {
                    DashPattern = new float[] { 2, 2 },
                    Width = 1,
                    Color = Color.Gray
                };
            }
            set{}
        }

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
        /// Консткуктор прямоугольника выделения
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        public HighlightRect(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}

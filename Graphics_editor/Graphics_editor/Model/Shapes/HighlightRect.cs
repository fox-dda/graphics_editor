using System.Drawing;
using SDK;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Рамка выделения
    /// </summary>
    public class HighlightRect: IDrawable, INamed
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
                return new PenSettings(Color.Gray, 1)
                {
                    DashPattern = new float[] { 2, 2 }
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

        public string GetName()
        {
            return "HighlightRect";
        }

        /// <summary>
        /// Консткуктор прямоугольника выделения
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        private HighlightRect(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public HighlightRect() { }
    }
}

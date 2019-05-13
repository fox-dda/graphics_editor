using System.Drawing;
using SDK;

namespace GraphicsEditor
{
    /// <summary>
    /// Параметры рисования
    /// </summary>
    public class PaintingParameters
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        private Color _brushColor = Color.White;

        /// <summary>
        /// Штрих паттерн
        /// </summary>
        private float[] _dashPattern = new float[]{ 0, 0 };

        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get => _brushColor;
            set => _brushColor = value;
        }

        /// <summary>
        /// Паттерн штрихов
        /// </summary>
        public float[] DashPattern
        {
            get => _dashPattern[0] == 0 ? null : _dashPattern;
            set
            {
                GPen.DashPattern = value;
                _dashPattern = value;
            }
        }

        /// <summary>
        /// Настройки пера
        /// </summary>
        public PenSettings GPen
        {
            get => _gPen; 
            set => _gPen = value;
        }

        /// <summary>
        /// Настройки пера
        /// </summary>
        private PenSettings _gPen = new PenSettings { Color = Color.Black, Width = 1 };

        /// <summary>
        /// Цвет фона
        /// </summary>
        private Color _canvasColor = Color.White;
        
        /// <summary>
        /// Цвет фона
        /// </summary>
        public Color CanvasColor
        {
            get => _canvasColor;
            set => _canvasColor = value;
        }
    }
}

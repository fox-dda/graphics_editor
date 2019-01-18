using System.Drawing;
using GraphicsEditor.Model.Shapes;

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
        private float[] _dashPattern = new float[] { 0, 0 };

        /// <summary>
        /// Цвет заливки
        /// </summary>
        public Color BrushColor
        {
            get
            {
                if (_brushColor == null)
                    return Color.White;
                else
                    return _brushColor;
            }
            set
            {
                _brushColor = value;
            }
        }

        /// <summary>
        /// Паттерн штрихов
        /// </summary>
        public float[] DashPattern
        {
            get
            {
                if (_dashPattern[0] == 0)
                    return null;
                return _dashPattern;
            }
            set
            {
                GPen.DashPattern = value;
                _dashPattern = value;
            }
        }

        /// <summary>
        /// Настройки пера
        /// </summary>
        public PenSettings GPen = new PenSettings() {Color = Color.Black, Width = 1};

        /// <summary>
        /// Цвет фона
        /// </summary>
        private Color _canvasColor = Color.White;
        
        /// <summary>
        /// Цвет фона
        /// </summary>
        public Color CanvasColor
        {
            get
            {
                return _canvasColor;
            }
            set
            {
                _canvasColor = value;
            }
        }
    }
}

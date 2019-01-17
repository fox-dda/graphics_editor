using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor
{
    class PaintingParameters
    {
        private Color _brushColor = Color.White;
        private float[] _dashPattern = new float[] { 0, 0 };
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
        public PenSettings GPen = new PenSettings() {Color = Color.Black, Width = 1};
        private Color _canvasColor = Color.White;
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

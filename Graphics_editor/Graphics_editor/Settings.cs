using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor
{
    class Settings
    {
        private Color _brushColor;
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
        public Pen GPen = new Pen(Color.Black, 1);
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

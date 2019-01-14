using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Shapes
{
    [Serializable]
    public class PenSettings
    {
        public float[] DashPattern = new float[] { 1, 1 };
        public float Width;
        public Color Color;
    }
}

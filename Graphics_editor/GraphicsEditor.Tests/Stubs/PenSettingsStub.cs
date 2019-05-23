using SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Tests.Stubs
{
    public class PenSettingsStub : IPenSettings
    {
        public float[] DashPattern { get; set; }
        public float Width { get; set; }
        public Color Color { get; set; }
    }
}

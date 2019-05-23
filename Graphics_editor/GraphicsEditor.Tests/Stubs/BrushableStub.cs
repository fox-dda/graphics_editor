using SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SDK.Interfaces;

namespace GraphicsEditor.Tests.Stubs
{
    public class BrushableStub : IDrawable, IBrushable
    {
        public IPenSettings Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color BrushColor { get; set; }
    }
}

using SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Interfaces;
using System.Drawing;

namespace GraphicsEditor.Tests.Stubs
{
    public class BrushableTwoPointStub : IDrawable, IBrushable
    {
        public IPenSettings Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color BrushColor { get; set; }
    }
}

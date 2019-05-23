using SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SDK.Interfaces;
using Moq;

namespace SDKTests.Stubs
{
    internal class CloneableDraftStub : IDrawable, ICloneable
    {
        public IPenSettings Pen { get ; set ; }
        public Point StartPoint { get ; set; }
        public Point EndPoint { get; set; }

        public object Clone()
        {
            return new Mock<IDrawable>().Object;
        }
    }
}

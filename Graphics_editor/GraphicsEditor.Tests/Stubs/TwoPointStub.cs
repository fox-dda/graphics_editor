﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Tests.Stubs
{
    public class TwoPointStub : IDrawable
    {
        public IPenSettings Pen { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}

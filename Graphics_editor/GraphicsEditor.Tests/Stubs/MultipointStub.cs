using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
using SDK.Interfaces;

namespace GraphicsEditor.Tests
{
    public class MultipointStub : IMultipoint, IDrawable
    {
        public List<Point> DotList { get; set; }

        public IPenSettings Pen { get; set; }
        public Point StartPoint
        {
            get
            {
                return DotList[0];
            }
            set { }
        }
        public Point EndPoint
        {
            get
            {
                return DotList.Last();
            }
            set { }
        }
    }
}

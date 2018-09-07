using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor
{
    class Line
    {
        public float StartDotX;
        public float StartDotY;
        public float EndDotX;
        public float EndDotY;

        public void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, StartDotX, StartDotY, EndDotX, EndDotY);
        }

        public Line(float sdx, float sdy, float edx, float edy)
        {
            StartDotX = sdx;
            StartDotY = sdy;
            EndDotX = edx;
            EndDotY = edy;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor.Model
{
    class Line : IDraft
    {
        public float StartDotX;
        public float StartDotY;
        public float EndDotX;
        public float EndDotY;
        public Pen Pen;

        public void Draw(Graphics g)
        {
            g.DrawLine(Pen, StartDotX, StartDotY, EndDotX, EndDotY);
        }

        public Line(float sdx, float sdy, float edx, float edy, Pen pen)
        {
            StartDotX = sdx;
            StartDotY = sdy;
            EndDotX = edx;
            EndDotY = edy;
            this.Pen = pen;
        }
    }
}

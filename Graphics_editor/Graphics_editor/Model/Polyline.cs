using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics_editor.Model
{
    class Polyline: IDraft
    {
        public List<Line> LineList = new List<Line>();
        public Pen Pen;

        public void Draw(Graphics g)
        {
            foreach(Line line in LineList)
            {
                g.DrawLine(Pen, line.StartDotX, line.StartDotY, line.EndDotX, line.EndDotY);
            }         
        }

        public Polyline(float sdx, float sdy, float edx, float edy, Pen pen)
        {
            this.Pen = pen;
            var line = new Line(sdx, sdy, edx, edy, Pen);
            LineList.Add(line);
        }

        public void AddLine(Line line)
        {
            LineList.Add(line);
        }
    }
}

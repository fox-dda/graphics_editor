using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    class LineDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            graphics.DrawLine(new Pen(shape.Pen.Color, shape.Pen.Width) { DashPattern = shape.Pen.DashPattern }, shape.StartPoint, shape.EndPoint);
        }     
    }
}

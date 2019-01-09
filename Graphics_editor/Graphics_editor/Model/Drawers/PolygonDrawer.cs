using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    class PolygonDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var brush = (shape as IBrushable).BrushColor;
            var dorList = (shape as Polygon).DotList.ToArray();
            var pen = shape.Pen;
            if (brush != null)
                graphics.FillPolygon(new SolidBrush(brush), dorList);
            graphics.DrawPolygon(pen, dorList);
        }
    }
}

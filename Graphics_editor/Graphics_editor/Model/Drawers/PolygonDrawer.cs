using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    /// <summary>
    /// Отрисовщик полигонов
    /// </summary>
    public class PolygonDrawer: BaseDrawer
    {
        /// <summary>
        /// Отрисовать полигон
        /// </summary>
        /// <param name="shape">Полигон</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var brush = ((IBrushable) shape).BrushColor;
            var dotList = (shape as Polygon)?.DotList.ToArray();
            var pen = ConvertPen(shape.Pen);

            graphics.FillPolygon(new SolidBrush(brush), dotList);
            graphics.DrawPolygon(pen, dotList);
        }
    }
}

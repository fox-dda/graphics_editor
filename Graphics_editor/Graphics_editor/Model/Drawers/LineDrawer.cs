using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
   /// <summary>
   /// Отрисовщик линий
   /// </summary>
    public class LineDrawer: BaseDrawer
    {
        /// <summary>
        /// Отрисовать линию
        /// </summary>
        /// <param name="shape">Линия</param>
        /// <param name="graphics">Ядро рисования</param>
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var factory = new DraftFactory();
            graphics.DrawLine(ConvertPen(shape.Pen),
                shape.StartPoint,
                shape.EndPoint);
        }     
    }
}

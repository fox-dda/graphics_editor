using System;
using SDK;
using System.Drawing;

namespace LinePlugin
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
            graphics.DrawLine(ConvertPen(shape.Pen),
                shape.StartPoint,
                shape.EndPoint);
        }     
    }
}

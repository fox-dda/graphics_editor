using System;
using SDK;
using System.Drawing;

namespace EllipsePlugin
{
    /// <summary>
    /// Отрисовщик эллипсов
    /// </summary>
    public class EllipseDrawer: BaseDrawer
    {
        /// <summary>
        /// Отрисовать эллипс
        /// </summary>
        /// <param name="shape">Эллипс</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var ellipse = shape as Ellipse;
            var StartPoint = ellipse.StartPoint;
            var EndPoint = ellipse.EndPoint;
            var brush = (ellipse as IBrushable).BrushColor;
            var pen = ConvertPen(shape.Pen);

            if (brush != null)
            {
                graphics.FillEllipse(
                    new SolidBrush(brush),
                    new RectangleF(StartPoint.X, StartPoint.Y,
                    -(StartPoint.X - EndPoint.X),
                    -(StartPoint.Y - EndPoint.Y)));
            }

            graphics.DrawEllipse(pen, new RectangleF(StartPoint.X, StartPoint.Y,
                -(StartPoint.X - EndPoint.X), -(StartPoint.Y - EndPoint.Y)));
        }
    }
}

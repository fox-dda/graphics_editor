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
            var startPoint = ellipse.StartPoint;
            var endPoint = ellipse.EndPoint;
            var brush = (ellipse as IBrushable).BrushColor;
            var pen = ConvertPen(shape.Pen);

            if (brush != null)
            {
                graphics.FillEllipse(
                    new SolidBrush(brush),
                    new RectangleF(startPoint.X, startPoint.Y,
                    -(startPoint.X - endPoint.X),
                    -(startPoint.Y - endPoint.Y)));
            }

            graphics.DrawEllipse(pen, new RectangleF(startPoint.X, startPoint.Y,
                -(startPoint.X - endPoint.X), -(startPoint.Y - endPoint.Y)));
        }
    }
}

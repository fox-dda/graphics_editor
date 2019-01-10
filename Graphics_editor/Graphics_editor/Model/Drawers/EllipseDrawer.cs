﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    class EllipseDrawer: BaseDrawer
    {
        public override void DrawShape(IDrawable shape, Graphics graphics)
        {
            var ellipse = shape as Ellipse;
            var StartPoint = ellipse.StartPoint;
            var EndPoint = ellipse.EndPoint;
            var brush = (ellipse as IBrushable).BrushColor;
            var pen = ellipse.Pen;

            if (brush != null)
                graphics.FillEllipse(new SolidBrush(brush), new RectangleF(StartPoint.X, StartPoint.Y,
                -(StartPoint.X - EndPoint.X), -(StartPoint.Y - EndPoint.Y)));
            graphics.DrawEllipse(pen, new RectangleF(StartPoint.X, StartPoint.Y,
                -(StartPoint.X - EndPoint.X), -(StartPoint.Y - EndPoint.Y)));
        }
    }
}
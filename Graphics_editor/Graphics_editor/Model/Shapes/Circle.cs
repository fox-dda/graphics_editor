using System;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Circle : Ellipse, IDrawable, IBrushable
    {
        /// <summary>
        /// Конструктор круга
        /// </summary>
        /// <param name="startPoint">Точка старта</param>
        /// <param name="endPoint">Точка конца</param>
        /// <param name="pen"></param>
        public Circle(Point startPoint, Point endPoint, PenSettings pen)
            : base(startPoint, endPoint, pen){}
    }
}

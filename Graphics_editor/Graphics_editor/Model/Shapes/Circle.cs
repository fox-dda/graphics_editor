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
        /// <param name="_startPoint">Точка старта</param>
        /// <param name="_endPoint">Точка конца</param>
        /// <param name="_pen"></param>
        public Circle(Point _startPoint, Point _endPoint, PenSettings _pen)
            : base(_startPoint, _endPoint, _pen){}
    }
}

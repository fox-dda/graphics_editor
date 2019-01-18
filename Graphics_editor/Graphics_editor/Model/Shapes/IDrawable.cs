using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Интерфейс рисуемых фигур
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// 
        /// </summary>
        PenSettings Pen { get; set; }

        /// <summary>
        /// Точка старта
        /// </summary>
        Point StartPoint { get; set; }

        /// <summary>
        /// Точка конца
        /// </summary>
        Point EndPoint { get; set; }
    }
}

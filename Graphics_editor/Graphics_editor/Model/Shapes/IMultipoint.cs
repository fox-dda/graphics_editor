using System.Collections.Generic;
using System.Drawing;

namespace GraphicsEditor.Model.Shapes
{
    /// <summary>
    /// Интерфейс мультиточечных фигур
    /// </summary>
    public interface IMultipoint
    {
        /// <summary>
        /// Список точек
        /// </summary>
        List<Point> DotList { get; set; }
    }
}

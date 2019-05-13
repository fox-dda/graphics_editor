using System.Collections.Generic;
using System.Drawing;

namespace SDK
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model
{
    /// <summary>
    /// Интерфейс для закрашиваемых фигур
    /// </summary>
    public interface IBrushable
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        Color BrushColor { get; set; }
    }
}

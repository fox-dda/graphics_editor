using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Drawers
{
    /// <summary>
    /// Базовый отрисовщик фигур
    /// </summary>
    public abstract class BaseDrawer
    {
        /// <summary>
        /// Отрисовать фигуру
        /// </summary>
        /// <param name="shape">Русуемая фигура</param>
        /// <param name="graphics">Ядро отрисовки</param>
        public abstract void DrawShape(IDrawable shape, Graphics graphics);
    }
}

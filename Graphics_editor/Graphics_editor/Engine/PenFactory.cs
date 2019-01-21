using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsEditor.Model.Shapes;

namespace GraphicsEditor.Engine
{
    public class PenFactory
    {
        /// <summary>
        /// Создать перо
        /// </summary>
        /// <param name="settings">Настройки пера</param>
        /// <returns>Перо</returns>
        public Pen CreatePen(PenSettings settings)
        {
            return settings.DashPattern != null ?
                new Pen(settings.Color, settings.Width)
                {
                    DashPattern = settings.DashPattern
                } :
                new Pen(settings.Color, settings.Width);
        }
    }
}

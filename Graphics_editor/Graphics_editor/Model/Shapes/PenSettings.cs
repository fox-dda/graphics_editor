using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsEditor.Model.Shapes
{
    /// <summary>
    /// Настройки пера
    /// </summary>
    [Serializable]
    public class PenSettings
    {
        /// <summary>
        /// Паттерн штрихов
        /// </summary>
        public float[] DashPattern { get; set; }

        /// <summary>
        /// Толщина пера
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Цвет пера
        /// </summary>
        public Color Color { get; set; }
    }
}

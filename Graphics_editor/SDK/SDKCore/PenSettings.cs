using System;
using System.Drawing;

namespace SDK
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

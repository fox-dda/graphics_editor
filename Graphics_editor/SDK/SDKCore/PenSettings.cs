using System;
using System.Drawing;
using SDK.Interfaces;

namespace SDK
{
    /// <summary>
    /// Настройки пера
    /// </summary>
    [Serializable]
    public class PenSettings: IPenSettings
    {

        public PenSettings(Color color, float width)
        {
            Color = color;
            Width = width;
        }

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

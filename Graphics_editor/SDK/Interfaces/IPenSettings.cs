using System.Drawing;

namespace SDK.Interfaces
{
    public interface IPenSettings
    {
        /// <summary>
        /// Паттерн штрихов
        /// </summary>
        float[] DashPattern { get; set; }

        /// <summary>
        /// Толщина пера
        /// </summary>
        float Width { get; set; }

        /// <summary>
        /// Цвет пера
        /// </summary>
        Color Color { get; set; }
    }
}
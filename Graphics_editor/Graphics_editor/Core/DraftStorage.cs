using System.Collections.Generic;
using SDK;
using GraphicsEditor.Interfaces;

namespace GraphicsEditor
{
    /// <summary>
    /// Главное хранилище фигур
    /// </summary>
    public class DraftStorage: IDraftStorage
    {
        /// <summary>
        /// Список отрисованных фигур
        /// </summary>
        public List<IDrawable> DraftList { get; set; } = new List<IDrawable>();
        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        public List<IDrawable> HighlightDraftsList { get; set; } = new List<IDrawable>();
    }
}

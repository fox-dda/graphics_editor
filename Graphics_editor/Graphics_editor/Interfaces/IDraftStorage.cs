using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IDraftStorage
    {
        /// <summary>
        /// Список отрисованных фигур
        /// </summary>
        ICollection<IDrawable> DraftList { get; set; }

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        ICollection<IDrawable> HighlightDraftsList { get; set; }
    }
}

using System.Collections.Generic;
using SDK;

namespace GraphicsEditor.Interfaces
{
    public interface IDraftStorage
    {
        /// <summary>
        /// Список отрисованных фигур
        /// </summary>
        List<IDrawable> DraftList { get; set; }

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        List<IDrawable> HighlightDraftsList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    /// <summary>
    /// Главное хранилище фигур
    /// </summary>
    public class DraftStorage
    {
        /// <summary>
        /// Список отрисованных фигур
        /// </summary>
        public List<IDrawable> DraftList = new List<IDrawable>();
        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        public List<IDrawable> HighlightDraftsList = new List<IDrawable>();
    }
}

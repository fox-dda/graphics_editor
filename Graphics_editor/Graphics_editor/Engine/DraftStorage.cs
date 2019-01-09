using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    public class DraftStorage
    {
        public List<IDrawable> DraftList = new List<IDrawable>();
        public List<IDrawable> HighlightDraftsList = new List<IDrawable>();
    }
}

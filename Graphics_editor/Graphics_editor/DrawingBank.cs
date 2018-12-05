using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    public static class DrawingBank
    {
        private static List<IDrawable> _draftList = new List<IDrawable>();
        private static List<IDrawable> _highlightDrafts = new List<IDrawable>();
    }
}

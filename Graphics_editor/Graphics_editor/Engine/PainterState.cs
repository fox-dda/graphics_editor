using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using GraphicsEditor.Enums;
using System.Drawing;

namespace GraphicsEditor.Engine
{
    class PainterState
    {
        public Strategy DrawingStrategy
        {
            get
            {
                return DraftFactory.DefineStrategy(Figure);
            }
        }

        private Figure _figure = Figure.select;

        public Figure Figure
        {
            get
            {
                return _figure;
            }
            set
            {
                InPocessPoints.Clear();
                DragDropDraft = null;
                DragDropDot.Draft = null;
                CacheDraft = null;
                CacheLasso = null;

                _figure = value;
            }
        }

        public List<Point> InPocessPoints = new List<Point>();

        public IDrawable DragDropDraft;

        public DotInDraft DragDropDot;

        public IDrawable CacheDraft;

        public HighlightRect CacheLasso;

    }
}

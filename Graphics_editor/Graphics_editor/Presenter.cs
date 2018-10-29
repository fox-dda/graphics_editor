using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using System.Drawing;
using System.Windows.Forms;

namespace Graphics_editor
{
    class Presenter
    {
        private List<IDraft> _draftList = new List<IDraft>();
        private IDraft _cacheDraft;
        private Graphics _painter;
        private Pen _myPen = new Pen(Color.Black, 1);
        private Point _mouse;
        private bool _doDraw = false;
        strategy drawingStrategy;
        enum strategy
        {
            twoPoint,
            multipoint
        };

        //Стереть фигуру из кэша
        private void clearCache()
        {
            if (_cacheDraft != null)
            {
                _cacheDraft.Pen = new Pen(Color.White, _myPen.Width);
                _cacheDraft.Draw(_painter);
            }
        }

        public Graphics Painter
        {
            get
            {
                return _painter;
            }
            set
            {
                _painter = value;
            }
        }

        private void RefreshCanvas()
        {
            foreach (IDraft draft in _draftList)
            {
                if (draft != null)
                {
                    draft.Draw(_painter);
                }
            }
        }

        public void DefineStrategy(Type figure)
        {
            if ((figure == typeof(Line)) || (figure == typeof(Circle)) || (figure == typeof(Triangle)))
                drawingStrategy = strategy.twoPoint;
            else if (figure == typeof(Polyline))
                drawingStrategy = strategy.multipoint;
        }

        public void DynamicDrawing(MouseEventArgs e, string drawType)
        {

            if (drawingStrategy == strategy.twoPoint)
            {
                clearCache();
                switch(drawType)
                {
                    case "Line": 
                        _cacheDraft = new Line(_mouse, e.Location, _myPen);
                        break;
                    case "Circle":
                        _cacheDraft = new Circle(_mouse, e.Location, _myPen);
                        break;
                    case "Triangle":
                        _cacheDraft = new Triangle(_mouse, e.Location, _myPen);
                        break;
                }
                
            }
            else if (drawingStrategy == strategy.multipoint)
            {
                switch (drawType)
                {
                    case "Polyline":
                        
                        break;
                }
            }
        }
    }

}

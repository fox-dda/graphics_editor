using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;

namespace GraphicsEditor
{
    class Presenter
    {
        private Strategy drawingStrategy
        {
            get
            {
                return DraftFactory.DefineStrategy(Figure);
            }
        }
        private List<IDrawable> _draftList = new List<IDrawable>();
        private List<Point> inPocessPoints = new List<Point>();
        private IDrawable _cacheDraft;
        private Color canvasColor = Color.White;
        private Color _brushColor;
        private Figure _figure;
        public Color BrushColor
        {
            get
            {
                if (_brushColor == null)
                    return CanvasColor;
                else
                    return _brushColor;
            }
            set
            {
                _brushColor = value;
            }
        }
        public Graphics _painter;
        public Pen GPen = new Pen(Color.Black, 1);
        public Figure Figure
        {
            get
            {
                return _figure;
            }
            set
            {
                if (value != _figure)
                    inPocessPoints.Clear();
                _figure = value;
            }
        }
        public Color CanvasColor
        {
            get
            {
                return canvasColor;
            }
            set
            {
                canvasColor = value;
                _painter.Clear(canvasColor);
                RefreshCanvas();
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

        //Стереть фигуру из кэша
        private void ReDrawCache()
        {
            if (_cacheDraft != null)
            {
                _cacheDraft.Pen = new Pen(canvasColor, GPen.Width);
                if ((_cacheDraft is Circle) || (_cacheDraft is Ellipse) || (_cacheDraft is Triangle))
                    (_cacheDraft as IBrushable).BrushColor = CanvasColor;
                _cacheDraft.Draw(_painter);
            }
        }
  
        //Обновить канву
        public void RefreshCanvas()
        {
            foreach (IDrawable draft in _draftList)
            {
                if (draft != null)
                {
                    draft.Draw(_painter);
                }
            }
        }

        //Отрисовать и добавить в список объектов на канве объект из кэша
        private void ToDraw()
        {
            if (_cacheDraft != null && drawingStrategy == Strategy.twoPoint)
            {
                _draftList.Add(_cacheDraft);
                inPocessPoints.Clear();
                _cacheDraft = null;
            }
            if (_cacheDraft != null && drawingStrategy == Strategy.multipoint)
            {
                if (_draftList.Count != 0)
                    if (_draftList.Last() is Polyline)
                    {
                        (_draftList.Last() as Polyline).AddPoint((_cacheDraft as Polyline).StartPoint);
                    }
                _draftList.Add(_cacheDraft);
                //inPocessPoints.Clear();
                _cacheDraft = null;

            }
            RefreshCanvas();
        }

        //Обработчик мыши
        public void Process(MouseEventArgs e, MouseAction mouseAction)
        {
            switch (mouseAction)
            {
                case MouseAction.down:
                    {
                        if (drawingStrategy == Strategy.twoPoint)
                        {
                                inPocessPoints.Add(e.Location);
                        }
                        break;
                    }
                case MouseAction.move:
                    {
                        if (drawingStrategy == Strategy.twoPoint)
                        {
                            if (inPocessPoints.Count == 0)
                                return;
                            DynamicDrawing(e.Location);
                        }
                        else
                        {
                            if(inPocessPoints.Count != 0)
                            {
                                DynamicDrawing(e.Location);
                            }
                        }
                        break;
                    }
                case MouseAction.up:
                    {
                        if (drawingStrategy == Strategy.twoPoint)
                        {
                            inPocessPoints.Add(e.Location);
                            ToDraw();
                        }
                        else
                        {
                            inPocessPoints.Add(e.Location);
                            ToDraw();
                        }
                        break;
                    }
            }
            RefreshCanvas();
        }
        
        //Динамическая отрисовка
        public void DynamicDrawing(Point mousePoint)
        {
            ReDrawCache();

            if (drawingStrategy == Strategy.twoPoint)
                _cacheDraft = DraftFactory.CreateDraft(Figure, inPocessPoints[0], mousePoint, GPen, BrushColor);

            else if (drawingStrategy == Strategy.multipoint)
                _cacheDraft = DraftFactory.CreateDraft(Figure, new List<Point> { inPocessPoints.Last(), mousePoint }, GPen);
            
            _cacheDraft.Draw(_painter);       
        }

        //Очистка канвы
        public void ClearCanvas()
        {
            _draftList.Clear();
            CanvasColor = Color.White;
            _painter.Clear(CanvasColor);
        }
    }

}

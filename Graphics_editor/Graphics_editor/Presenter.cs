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
        private Strategy _drawingStrategy
        {
            get
            {
                return DraftFactory.DefineStrategy(Figure);               
            }
        }
        private List<IDrawable> _draftList = new List<IDrawable>();
        private List<Point> _inPocessPoints = new List<Point>();
        private IDrawable _cacheDraft;
        private HighlightRect _cacheLasso;
        private Color _canvasColor = Color.White;
        private Color _brushColor;
        private Figure _figure;
        private Graphics _painter;
        private float[] _dashPattern = new float[]{0, 0};
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
        public float[] DashPattern
        {
            get
            {
                if (_dashPattern[0] == 0)
                    return null;
                return _dashPattern;
            }
            set
            {
                GPen.DashPattern = value;
                _dashPattern = value;
            }
        }
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
                {
                    DisradHighlightingAll();
                    _inPocessPoints.Clear();
                }
                _figure = value;
            }
        }
        public Color CanvasColor
        {
            get
            {
                return _canvasColor;
            }
            set
            {
                _canvasColor = value;
                _painter.Clear(_canvasColor);
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

        //Выделить фигуру
        private void HighlightingDraft(IDrawable draft)
        {
            draft.IsHighlighting = true;
            var frame = new HighlightRect()
            {
                StartPoint = draft.StartPoint,
                EndPoint = draft.EndPoint
            };
            frame.AddFrame(_painter);
        }

        //Отменить выделение фигуры
        private void DisradHighlightingDraft(IDrawable draft)
        {
            draft.IsHighlighting = false;
            var frame = new HighlightRect()
            {
                StartPoint = draft.StartPoint,
                EndPoint = draft.EndPoint
            };
            frame.RemoveFrame(_painter, CanvasColor);
            RefreshCanvas();
        }

        //Отменить выеление всех фигур
        public void DisradHighlightingAll()
        {
            foreach (IDrawable draft in _draftList)
            {
                DisradHighlightingDraft(draft);
            }
        }

        //Стереть фигуру из кэша
        private void ReDrawCache()
        {
            if (_cacheDraft != null)
            {
               var a = _cacheDraft.Pen;
                _cacheDraft.Pen = new Pen(_canvasColor, GPen.Width);
                if ((_cacheDraft is Circle) || (_cacheDraft is Ellipse) || (_cacheDraft is Triangle))
                    (_cacheDraft as IBrushable).BrushColor = CanvasColor;
                if (DashPattern != null)
                    _cacheDraft.Pen.DashPattern = a.DashPattern;
                _cacheDraft.Draw(_painter);              
            }
            if (_cacheLasso != null)
            {
                _cacheLasso.RemoveFrame(_painter, CanvasColor);
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

        //Выделить объекты в ласо
        private void HighlightingDraftInLasso(List<IDrawable> list)
        {

        }

        //Отрисовать и добавить в список объектов на канве объект из кэша
        private void ToDraw()
        {
            if (_cacheDraft != null && _drawingStrategy == Strategy.twoPoint)
            {
                _draftList.Add(_cacheDraft);
                _inPocessPoints.Clear();
                _cacheDraft = null;
            }
            if (_cacheDraft != null && _drawingStrategy == Strategy.multipoint)
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
                        if (_drawingStrategy == Strategy.twoPoint)
                        {
                            _inPocessPoints.Add(e.Location);
                        }
                        if(_drawingStrategy == Strategy.selection)
                        {
                            _inPocessPoints.Add(e.Location);
                        }
                        break;
                    }
                case MouseAction.move:
                    {
                        if (_inPocessPoints.Count != 0)
                            DynamicDrawing(e.Location);
                        break;
                    }
                case MouseAction.up:
                    {
                        if (_drawingStrategy == Strategy.twoPoint)
                        {
                            _inPocessPoints.Add(e.Location);
                            ToDraw();
                        }
                        else
                        {
                            _inPocessPoints.Add(e.Location);
                            ToDraw();
                        }
                        if (_drawingStrategy == Strategy.selection)
                        {
                            var selector = new Selector();

                            var selectedDraft = selector.PointSearch(e, _draftList);
                            if (selectedDraft != null)
                            {
                                if (selectedDraft.IsHighlighting)
                                    DisradHighlightingDraft(selectedDraft);
                                else
                                    HighlightingDraft(selectedDraft);
                            }
                            _inPocessPoints.Clear();

                            
                            
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

            if (_drawingStrategy == Strategy.twoPoint)
            {
                _cacheDraft = DraftFactory.CreateDraft(Figure, _inPocessPoints[0], mousePoint, GPen, BrushColor);
                _cacheDraft.Draw(_painter);
            }
                
            else if (_drawingStrategy == Strategy.multipoint)
            {
                _cacheDraft = DraftFactory.CreateDraft(Figure, new List<Point> { _inPocessPoints.Last(), mousePoint }, GPen);
                _cacheDraft.Draw(_painter);
            }           

            else if(_drawingStrategy == Strategy.selection)
            {
                _cacheLasso = DraftFactory.CreateDraft(Figure, _inPocessPoints[0], mousePoint);
                _cacheLasso.AddFrame(_painter);
            }
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

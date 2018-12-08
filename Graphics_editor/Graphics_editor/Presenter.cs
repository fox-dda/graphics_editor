using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEditor.Model;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;

namespace GraphicsEditor
{
    class Presenter
    {
        private List<IDrawable> _draftList = new List<IDrawable>();
        private List<IDrawable> _highlightDrafts = new List<IDrawable>();
        
        private List<Point> _inPocessPoints = new List<Point>();
        private Strategy _drawingStrategy
        {
            get
            {
                return DraftFactory.DefineStrategy(Figure);               
            }
        }
        private Figure _figure = Figure.select;
        private Graphics _painter;
        private IDrawable _cacheDraft;
        private HighlightRect _cacheLasso;

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
                    _cacheDraft = null;
                }
                _figure = value;
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
        public Settings Settings = new Settings();

        //Изменить выделенный объект
        public void EditHighlightObject(IDrawable item)
        {
            _draftList.Remove(_highlightDrafts[0]);
            _highlightDrafts[0] = item;
            _draftList.Add(item);
            RefreshCanvas();
        }

        //Добавить объекты в хранилище
        public void AddObjects(List<IDrawable> addList)
        {
            foreach(IDrawable item in addList)
            {
                _draftList.Add(item);
                _highlightDrafts.Add(item);
                ReDrawCache();
            }
        }

        //Удалить выделенные объеты из хранилища
        public void RemoveHighlightObjects()
        {
            foreach (IDrawable item in _highlightDrafts)
            {
                _draftList.Remove(item);
            }
            _highlightDrafts.Clear();
        }

        //Вернуть выделенныt объекты
        public List<IDrawable> GetHighlightObjects()
        {
                return _highlightDrafts;
        }
       
        //Выделить объекты в ласо
        private void HighlightingDraftInLasso(List<IDrawable> list)
        {
            if (list.Count == 0)
                return;
            foreach (IDrawable draft in list)
                HighlightingDraft(draft);
        }
       
        //Задать цвет канвы
        public void SetCanvasColor(Color color)
        {
            Settings.CanvasColor = color;
            _painter.Clear(Settings.CanvasColor);
            RefreshCanvas();
        }

        //Выделить фигуру
        private void HighlightingDraft(IDrawable draft)
        {
            if(!(_highlightDrafts.Contains(draft)))
                _highlightDrafts.Add(draft);
        }

        //Отменить выделение фигуры
        private void DisradHighlightingDraft(IDrawable draft)
        {
            _highlightDrafts.Remove(draft);
        }

        //Отменить выделение всех фигур
        public void DisradHighlightingAll()
        {
            _highlightDrafts.Clear();
            ReDrawCache();
        }

        //Стереть фигуру из кэша
        public void ReDrawCache()
        {
            Painter.Clear(Settings.CanvasColor);
            _cacheDraft = null;
            RefreshCanvas();
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
            foreach (IDrawable draft in _highlightDrafts)
            {
                if (draft != null)
                {
                    var frame = new HighlightRect()
                    {
                        StartPoint = draft.StartPoint,
                        EndPoint = draft.EndPoint
                    };
                    frame.AddFrame(_painter);
                }
            }
        }

        //Логика двуточечного рисования
        private void DoublePointDraw()
        {
            if(_inPocessPoints.Count > 1)
            {
                _draftList.Add(_cacheDraft);
                _inPocessPoints.Clear();
                _cacheDraft = null;
                RefreshCanvas();      }
            
        }

        //логика Мультиточечного рисования
        private void MultiPointDraw()
        {
            //Устанавливаем соответствие между последним объектов в хранилище и русуемым объектом, в зависимости от этого решается
            //добавить точку к существующему объекту или создать новый объект
            if (_draftList.Count > 0)
            {
                if ((_draftList[_draftList.Count - 1] is Polygon) && (Figure == Figure.polygon))
                    (_draftList[_draftList.Count - 1] as Polygon).AddPoint(_inPocessPoints.Last());
                else if (!(_draftList[_draftList.Count - 1] is Polygon) && (Figure == Figure.polygon))
                    _draftList.Add(_cacheDraft);
                if ((_draftList[_draftList.Count - 1] is Polyline) && (Figure == Figure.polyline))
                    (_draftList[_draftList.Count - 1] as Polyline).AddPoint(_inPocessPoints.Last());
                else if (!(_draftList[_draftList.Count - 1] is Polyline) && (Figure == Figure.polyline))
                    _draftList.Add(_cacheDraft);
            }
            else
            {
                _draftList.Add(_cacheDraft);
            }
            Console.WriteLine("Список изменен. Количество элементов в списке: " + _draftList.Count().ToString()); 
            _cacheDraft = null;
        }
       
        //Добавить в список объектов на канве объект из кэша
        private void ToDraw()
        {
            if (_cacheDraft != null && _drawingStrategy == Strategy.twoPoint)
            {
                DoublePointDraw();
            }
            if (_cacheDraft != null && _drawingStrategy == Strategy.multipoint)
            {
                MultiPointDraw();
            }
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
                        if (_drawingStrategy == Strategy.selection)
                        {
                            DotSelection(e.Location);
                        }
                        break;
                    }
                case MouseAction.move:
                    {
                        ReDrawCache();
                        Console.WriteLine("Процессных точек = " + _inPocessPoints.Count.ToString());
                        if (_inPocessPoints.Count > 0)
                        {
                            Console.WriteLine("Процессных точек больше чем 0, вызывается динамическая отрисовка");
                            DynamicDrawing(e.Location);
                        }
                        break;
                    }
                case MouseAction.up:
                    {
                        if (_drawingStrategy == Strategy.twoPoint)
                        {
                            _inPocessPoints.Add(e.Location);
                            ToDraw();
                        }
                        else if (_drawingStrategy == Strategy.multipoint)
                        {
                            _inPocessPoints.Add(e.Location);
                            ToDraw();
                            RefreshCanvas();
                        }
                        else if (_drawingStrategy == Strategy.selection)
                        {
                            LassoSelection(e.Location);
                        }   
                        break;
                    }
            }
        }

        //Логика захвата в ласо
        private void LassoSelection(Point mousePoint)
        {
            if (_cacheLasso != null)
            {
                HighlightingDraftInLasso(Selector.LassoSearch(_cacheLasso, _draftList));
                ReDrawCache();
            }
            _inPocessPoints.Clear();
        }

        //Логика точесного выделения
        private void DotSelection(Point mousePoint)
        {
            var selectedDraft = Selector.PointSearch(mousePoint, _draftList);
            if (selectedDraft != null)
            {
                if (_highlightDrafts.Contains(selectedDraft))
                    _highlightDrafts.Remove(selectedDraft);
                else
                    _highlightDrafts.Add(selectedDraft);
            }
        }

        //Логика динамического рисования по двум точкам
        private void DoublePointDynamicDrawing(Point mousePoint)
        {
            _cacheDraft = DraftFactory.CreateDraft(Figure, _inPocessPoints[0], mousePoint, Settings.GPen, Settings.BrushColor);
            _cacheDraft.Draw(_painter);
        }

        //Логика мультиточечного динамического рисования
        private void MultiPointDynamicDrawing(Point mousePoint)
        {
            Console.WriteLine("Динамич мультиточечная отрисовка");
            if (_draftList.Count == 0)
            {
                _cacheDraft = DraftFactory.CreateDraft(Figure, new List<Point> { _inPocessPoints.Last(), mousePoint, mousePoint }, Settings.GPen, Settings.BrushColor);
                Console.WriteLine("создание объекта первым в списке");
            }
            else
            {
                //Устанавливаем соответствие между последним объектов в хранилище и русуемым объектом, в зависимости от этого решается
                //добавить точку к существующему объекту или создать новый объект
                if ((!(_draftList.Last() is Polygon)) && (Figure == Figure.polygon))
                {
                    _cacheDraft = DraftFactory.CreateDraft(Figure, new List<Point> { _inPocessPoints.Last(), mousePoint, mousePoint }, Settings.GPen, Settings.BrushColor);
                    Console.WriteLine("создание новой полилинии");
                }
                if ((!(_draftList.Last() is Polyline)) && (Figure == Figure.polyline))
                {
                    _cacheDraft = DraftFactory.CreateDraft(Figure, new List<Point> { _inPocessPoints.Last(), mousePoint, mousePoint }, Settings.GPen, Settings.BrushColor);
                    Console.WriteLine("создание нового полигона");
                }
                if ((_draftList.Last() is Polygon) && (Figure == Figure.polygon))
                {
                    _cacheDraft = _draftList.Last();
                    Console.WriteLine("Количество опорных точек = " + (_cacheDraft as Polygon).DotList.Count.ToString());
                    Console.WriteLine("изменение полигона из списка");
                    (_cacheDraft as Polygon).DotList[(_cacheDraft as Polygon).DotList.Count - 1] = mousePoint;
                }
                if ((_draftList.Last() is Polyline) && (Figure == Figure.polyline))
                {
                    _cacheDraft = _draftList.Last();
                    Console.WriteLine("Количество опорных точек = " + (_cacheDraft as Polyline).DotList.Count.ToString());
                    Console.WriteLine("изменение полилинии из списка");
                    (_cacheDraft as Polyline).DotList[(_cacheDraft as Polyline).DotList.Count - 1] = mousePoint;
                }
            }
            _cacheDraft.Draw(_painter);
        }

        //Логика динамичечкой отрисовки ласо, и захвата объектов в ласо
        private void LassoDynamicDrawing(Point mousePoint)
        {
            _cacheLasso = DraftFactory.CreateDraft(Figure, _inPocessPoints[0], mousePoint);
            _cacheLasso.AddFrame(_painter);
        }

        //Динамическая отрисовка
        public void DynamicDrawing(Point mousePoint)
        {
            ReDrawCache();

            if (_drawingStrategy == Strategy.twoPoint)
                DoublePointDynamicDrawing(mousePoint);

            else if (_drawingStrategy == Strategy.multipoint)
            {
                MultiPointDynamicDrawing(mousePoint);
            }           
            else if(_drawingStrategy == Strategy.selection)
            {
                LassoDynamicDrawing(mousePoint);
            }
        }

        //Очистка канвы
        public void ClearCanvas()
        {
            _draftList.Clear();
            _highlightDrafts.Clear();
            _cacheDraft = null;
            Settings.CanvasColor = Color.White;
            _painter.Clear(Settings.CanvasColor);
            _inPocessPoints.Clear();
        }

        //Обработка выхода за канву
        public void LeaveCanvas()
        {
            if (_draftList.Count > 0)
            {
                if (_draftList[_draftList.Count - 1] is Polygon)
                    (_draftList[_draftList.Count - 1] as Polygon).DotList.RemoveAt((_draftList[_draftList.Count - 1] as Polygon).DotList.Count - 1);
                if(_draftList[_draftList.Count - 1] is Polyline)
                    (_draftList[_draftList.Count - 1] as Polyline).DotList.RemoveAt((_draftList[_draftList.Count - 1] as Polyline).DotList.Count - 1);
            }
        }
    }

}

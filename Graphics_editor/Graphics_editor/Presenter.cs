using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.Model;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsEditor
{
    class Presenter
    {
        enum Strategy
        {
            twoPoint,
            multipoint
        };

        private Strategy drawingStrategy;
        private List<IDraft> _draftList = new List<IDraft>();
        private List<Point> inPocessPoints = new List<Point>();
        private IDraft _cacheDraft;
        private Color canvasColor = Color.White;
        private string _figure;

        public Graphics _painter;
        public Pen GPen = new Pen(Color.Black, 1);       
        public string Figure
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
                DefineStrategy(_figure);
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
        private void reDrawCache()
        {
            if (_cacheDraft != null)
            {
                _cacheDraft.Pen = new Pen(canvasColor, GPen.Width);
                _cacheDraft.Draw(_painter);
            }
        }
  
        //Обновить канву
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

        //Отрисовать и добавить в список объектов на канве объект из кэша
        private void toDraw()
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

        //Определение стратегии отрисовки фигуры по её классу
        public void DefineStrategy(string figure) 
        {
            if ((figure == "Line") || (figure == "Circle") || (figure == "Triangle"))
                drawingStrategy = Strategy.twoPoint;
            else if (figure == "Polyline")
                drawingStrategy = Strategy.multipoint;
        }

        //Обработчик мыши
        public void Process(MouseEventArgs e, MouseAction mouseAction)
        {
            if (Figure == null)
                return;

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
                            toDraw();
                        }
                        else
                        {
                            inPocessPoints.Add(e.Location);
                            toDraw();
                        }
                        break;
                    }
            }
            RefreshCanvas();
        }
        
        //Динамическая отрисовка
        public void DynamicDrawing(Point mousePoint)
        {
            if (drawingStrategy == Strategy.twoPoint)
            {
                reDrawCache();
                switch(Figure)
                {
                    case "Line": 
                        _cacheDraft = new Line(inPocessPoints[0], mousePoint, GPen);
                        break;
                    case "Circle":
                        _cacheDraft = new Circle(inPocessPoints[0], mousePoint, GPen);
                        break;
                    case "Triangle":
                        _cacheDraft = new Triangle(inPocessPoints[0], mousePoint, GPen);
                        break;
                }
                _cacheDraft.Draw(_painter);
            }
            else if (drawingStrategy == Strategy.multipoint)
            {
                reDrawCache();

                switch (Figure)
                {
                    case "Polyline":
                        _cacheDraft = new Polyline(new List<Point> { inPocessPoints.Last(), mousePoint }, GPen);
                        _cacheDraft.Draw(_painter);
                        break;
                }
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

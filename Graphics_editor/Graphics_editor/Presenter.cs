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
        private List<IDraft> _draftList = new List<IDraft>();
        private IDraft _cacheDraft;
        public Graphics _painter;
        private Pen _myPen = new Pen(Color.Black, 1);
        private List<Point> inPocessPoints = new List<Point>();
        string _figure;
        public string Figure
        {
            get
            {
                return _figure;
            }
            set
            {
                if(value != _figure)
                    inPocessPoints.Clear();
                _figure = value;
                DefineStrategy(_figure);
            }
        }
        Strategy drawingStrategy;
        enum Strategy
        {
            twoPoint,
            multipoint
        };

        //Стереть фигуру из кэша
        private void reDrawCache()
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

        //Определение стратегии отрисовки фигуры по её классу
        public void DefineStrategy(string figure) 
        {
            if ((figure == "Line") || (figure == "Circle") || (figure == "Triangle"))
                drawingStrategy = Strategy.twoPoint;
            else if (figure == "Polyline")
                drawingStrategy = Strategy.multipoint;
        }

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
                        _cacheDraft = new Line(inPocessPoints[0], mousePoint, _myPen);
                        break;
                    case "Circle":
                        _cacheDraft = new Circle(inPocessPoints[0], mousePoint, _myPen);
                        break;
                    case "Triangle":
                        _cacheDraft = new Triangle(inPocessPoints[0], mousePoint, _myPen);
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
                        _cacheDraft = new Polyline(new List<Point> { inPocessPoints.Last(), mousePoint }, _myPen);
                        _cacheDraft.Draw(_painter);
                        break;
                }
            }
        }
    }

}

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
        private string Figure
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

        public void Process(MouseEventArgs e, string figure, MouseAction mouseAction)
        {
            if (figure == null)
                return;

            Figure = figure;

            switch (mouseAction)
            {
                case MouseAction.down:
                    {
                        inPocessPoints.Add(e.Location);
                        break;
                    }
                case MouseAction.up:
                    {
                        inPocessPoints.Add(e.Location);
                        if (_cacheDraft != null)
                        {
                            _draftList.Add(_cacheDraft);
                            inPocessPoints.Clear();
                            _cacheDraft = null;
                        }
                        break;
                    }
                case MouseAction.move:
                    {
                        if (inPocessPoints.Count == 0)
                            return;
                        inPocessPoints.Add(e.Location);
                        DynamicDrawing(figure);
                        break;
                    }
            }
            RefreshCanvas();
        }

        public void DynamicDrawing(string figure)
        {

            if (drawingStrategy == Strategy.twoPoint)
            {
                reDrawCache();
                switch(figure)
                {
                    case "Line": 
                        _cacheDraft = new Line(inPocessPoints[0], inPocessPoints.Last(), _myPen);
                        break;
                    case "Circle":
                        _cacheDraft = new Circle(inPocessPoints[0], inPocessPoints.Last(), _myPen);
                        break;
                    case "Triangle":
                        _cacheDraft = new Triangle(inPocessPoints[0], inPocessPoints.Last(), _myPen);
                        break;
                }
                //inPocessPoints.Clear();
                _cacheDraft.Draw(_painter);
            }
            else if (drawingStrategy == Strategy.multipoint)
            {
                switch (figure)
                {
                    case "Polyline":
                        
                        break;
                }
            }
        }

       /*/ public Presenter(Graphics _gPainter)
        {
            _painter = _gPainter;
        }
        /*/
    }

}

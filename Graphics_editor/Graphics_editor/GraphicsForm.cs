using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsEditor.Model;

namespace GraphicsEditor
{

    enum MouseAction
    {
        up,
        down,
        move
    }

    public partial class MainForm : Form
    {
        private List<IDraft> _draftList = new List<IDraft>();
        private IDraft _cacheDraft;
        public Graphics _painter;
        private Pen _myPen = new Pen(Color.Black, 1);
        private Point _mouse;
        private bool _doDraw = false;
        private string figure;


        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _painter = Graphics.FromHwnd(mainPictureBox.Handle);
            GPresenter.Painter = _painter;
            lineRadioButton.Checked = true;
        }

        private Presenter GPresenter = new Presenter();

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

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            GPresenter.Process(e, MouseAction.down);
            /*/
            if (!polylineRadioButton.Checked)
            {
                _mouse = e.Location;
                _doDraw = true;
            }
            /*/
        }

        //Стереть фигуру из кэша с канвы
        private void clearCache()
        {
            if (_cacheDraft != null)
            {
                _cacheDraft.Pen = new Pen(Color.White, _myPen.Width);
                _cacheDraft.Draw(_painter);
            }
        }

        //Динамическая отрисовка фигуры вслед за курсором
        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            GPresenter.Process(e, MouseAction.move);
            /*/
            if (!_doDraw)
                return;
      
            clearCache();

            //динамическая отрисовка линии
            if (lineRadioButton.Checked)
            {
                // создаем линию вслед за курсором после нажания пкмыши   
                _cacheDraft = new Line(_mouse, e.Location, _myPen);              
            }

            // динамическая отрисовка полилинии
            if (polylineRadioButton.Checked)
            {
                _cacheDraft = new Line(_mouse, e.Location, _myPen);
            }

            // динамичская отрисовка круга
            if (circleRadioButton.Checked)
            {
                _cacheDraft = new Circle(_mouse, e.Location, _myPen);
            }

            // динамичская отрисовка треугольника
            if (triangleRadioButton.Checked)
            {
                _cacheDraft = new Triangle(_mouse, e.Location, _myPen);
            }

            _cacheDraft.Draw(_painter);
            RefreshCanvas();
            /*/
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            GPresenter.Process(e, MouseAction.up);
            /*/
                if (lineRadioButton.Checked || circleRadioButton.Checked || triangleRadioButton.Checked)
                {
                    _draftList.Add(_cacheDraft);
                    _cacheDraft = null;
                    _doDraw = false;
                }

                //отрисовка и добавление в список рисунков полилинии
                if (polylineRadioButton.Checked)
                {
                    if (_draftList.Count != 0)
                    {
                        if (_draftList.Last() is Polyline)
                        {
                            (_draftList.Last() as Polyline).AddPoint(e.Location);
                        }
                        else
                        {
                            _mouse = e.Location;
                            Polyline newPolyline = new Polyline(new List<Point> { _mouse, e.Location }, _myPen);
                            _draftList.Add(newPolyline);
                        }
                    }
                    else
                    {
                        _mouse = e.Location;
                        Polyline newPolyline = new Polyline(new List<Point> { _mouse, e.Location }, _myPen);
                        _draftList.Add(newPolyline);
                    }
                    _mouse = e.Location;
                    _doDraw = true;
                    RefreshCanvas();
                }
                /*/
        }

        private void polylineRadioButton_CheckedChanged(object sender, EventArgs e)
        {/*/
            _painter.Clear(Color.White);
            RefreshCanvas();
            _cacheDraft = null;
            if (polylineRadioButton.Checked == false)
            {
                _doDraw = false;
            }
            /*/
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        { 
        /*/
            _painter.Clear(Color.White);
            RefreshCanvas();        
            /*/
        }

        private void lineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            /*/
            RefreshCanvas();
            _cacheDraft = null;
            /*/
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = "Line";
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = "Polyline";
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = "Circle";
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = "Triangle";
        }
    }
}
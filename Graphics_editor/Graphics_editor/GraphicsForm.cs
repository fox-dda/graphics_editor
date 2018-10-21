using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphics_editor.Model;

namespace Graphics_editor
{
    public partial class MainForm : Form
    {
        private List<IDraft> _draftList = new List<IDraft>();
        private IDraft _cacheDraft;
        private Graphics _g;
        private Pen _myPen = new Pen(Color.Black, 1);
        private Point _mouse;
        private bool _doDraw = false;

        public MainForm()
        {
            InitializeComponent();
            _g = Graphics.FromHwnd(mainPictureBox.Handle);
            lineRadioButton.Checked = true;
        }

        private void RefreshCanvas()
        {
            foreach (IDraft draft in _draftList)
            {
                if (draft != null)
                {
                    draft.Draw(_g);
                }
            }
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!polylineRadioButton.Checked)
            {
                _mouse = e.Location;
                _doDraw = true;
            }           
        }

        //Стереть фигуру из кэша с канвы
        private void clearCache()
        {
            if (_cacheDraft != null)
            {
                _cacheDraft.Pen = new Pen(Color.White, _myPen.Width);
                _cacheDraft.Draw(_g);
            }
        }

        //Динамическая отрисовка фигуры вслед за курсором
        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
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

            _cacheDraft.Draw(_g);
            RefreshCanvas();
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
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
        }

        private void polylineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _g.Clear(Color.White);
            RefreshCanvas();
            _cacheDraft = null;
            if (polylineRadioButton.Checked == false)
            {
                _doDraw = false;
            }
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _g.Clear(Color.White);
            RefreshCanvas();        
        }

        private void lineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCanvas();
            _cacheDraft = null;
        }
    }
}
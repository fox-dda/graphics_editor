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
        private List<IDraft> draftList = new List<IDraft>();
        private IDraft cacheDraft;
        private Graphics g;
        private Pen myPen = new Pen(Color.Black, 1);
        private Point mouse;
        private bool doDraw = false;

        public MainForm()
        {
            InitializeComponent();
            g = Graphics.FromHwnd(mainPictureBox.Handle);
            lineRadioButton.Checked = true;
        }

        private void refreshCanvas()
        {
            foreach (IDraft draft in draftList)
            {
                if (draft != null)
                {
                    draft.Draw(g);
                }
            }
        }

        private void dynamicDraw()
        {
            cacheDraft.Draw(g);
            refreshCanvas();
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!polylineRadioButton.Checked)
            {
                mouse = e.Location;
                doDraw = true;
            }           
        }

        private void crazyMod()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            myPen.Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            myPen.Width = r.Next(12);
        }

        //Динамическая отрисовка фигуры вслед за курсором
        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!doDraw)
                return;
            crazyMod();

            // Рисуем линию цвета фона для стираниния предыдущей линии динамической отрисовки
            if (cacheDraft != null)
            {
                cacheDraft.Pen = new Pen(Color.White, myPen.Width);
                cacheDraft.Draw(g);
                refreshCanvas();
            }

            //динамическая отрисовка линии
            if (lineRadioButton.Checked)
            {
                Line newLine = new Line(mouse, e.Location, myPen); // создаем линию вслед за курсором после нажания пкмыши
                cacheDraft = newLine;
                cacheDraft.Draw(g); // чертим созданную линию
                refreshCanvas();
            }

            // динамическая отрисовка полилинии
            if (polylineRadioButton.Checked)
            {
                Line newPolyLine = new Line(mouse, e.Location, myPen);
                cacheDraft = newPolyLine;
                cacheDraft.Draw(g);
                refreshCanvas();

            }

            // динамичская отрисовка круга
            if (circleRadioButton.Checked)
            {
                Circle newCircle = new Circle(mouse, e.Location, myPen);
                cacheDraft = newCircle;
                cacheDraft.Draw(g);
                refreshCanvas();
            }

            // динамичская отрисовка треугольника
            if (triangleRadioButton.Checked)
            {
                Triangle newTriangle = new Triangle(mouse, e.Location, myPen);
                cacheDraft = newTriangle;
                cacheDraft.Draw(g);
                refreshCanvas();
            }
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (lineRadioButton.Checked || circleRadioButton.Checked || triangleRadioButton.Checked)
            {
                draftList.Add(cacheDraft);
                cacheDraft = null;
                doDraw = false;
            }

            //отрисовка и добавление в список рисунков полилинии
            if (polylineRadioButton.Checked)
            {
                if (draftList.Count != 0)
                {
                    if (draftList.Last() is Polyline)
                    {
                        (draftList.Last() as Polyline).AddPoint(e.Location);
                    }
                    else
                    {
                        mouse = e.Location;
                        Polyline newPolyline = new Polyline(new List<Point> { mouse, e.Location }, myPen);
                        draftList.Add(newPolyline);
                    }
                }
                else
                {
                    mouse = e.Location;
                    Polyline newPolyline = new Polyline(new List<Point> { mouse, e.Location }, myPen);
                    draftList.Add(newPolyline);
                }
                mouse = e.Location;
                doDraw = true;
                refreshCanvas();
            }
        }

        private void polylineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            refreshCanvas();
            cacheDraft = null;
            if (polylineRadioButton.Checked == false)
            {
                doDraw = false;
            }
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            refreshCanvas();        
        }

        private void lineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            refreshCanvas();
            cacheDraft = null;
        }
    }
}
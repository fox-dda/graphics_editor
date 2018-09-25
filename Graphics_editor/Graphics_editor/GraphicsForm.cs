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
        }

        private void RefreshCanvas()
        {
            foreach (IDraft draft in draftList)
            {
                if (draft != null)
                {
                    draft.Draw(g);
                }
            }
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!polylineRadioButton.Checked)
            {
                mouse = e.Location;
                doDraw = true;
            }           
        }

        //Динамическая отрисовка фигуры вслед за курсором
        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // if ((lineRadioButton.Checked || polylineRadioButton.Checked) && doDraw)
            if ((lineRadioButton.Checked || polylineRadioButton.Checked) && doDraw)
            {
                // Рисуем линию цвета фона для стираниния предыдущей линии динамической отрисовки
                if (cacheDraft != null) 
                {
                    cacheDraft.Pen = new Pen(Color.White, myPen.Width);
                    cacheDraft.Draw(g);
                    RefreshCanvas();
                }

                //динамическая отрисовка линии
                if (lineRadioButton.Checked)
                {
                    Line newLine = new Line(mouse, e.Location, myPen); // создаем линию вслед за курсором после нажания пкмыши
                    cacheDraft = newLine;
                    cacheDraft.Draw(g); // чертим созданную линию
                    RefreshCanvas();
                }

                // динамическая отрисовка полилинии
                if (polylineRadioButton.Checked) 
                {
                    Polyline newPolyLine = new Polyline(new List<Point> { mouse, e.Location }, myPen);
                    cacheDraft = newPolyLine;
                    cacheDraft.Draw(g);
                    RefreshCanvas();

                }
            }
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (lineRadioButton.Checked)
            {
                draftList.Add(cacheDraft);
                cacheDraft = null;
                doDraw = false;
            }

            //если в кэше находится полилиния,  в кэшовую полилинию доюавляется точка с текущими координатами курсора
            if (polylineRadioButton.Checked)
            {
                if(cacheDraft is Polyline)
                {
                    Polyline currentPolyLine = cacheDraft as Polyline;
                    currentPolyLine.AddPoint(e.Location);
                    cacheDraft = currentPolyLine;
                    draftList.Add(cacheDraft);
                }
                mouse = e.Location;
                doDraw = true;
                RefreshCanvas();
            }

            //if(polylineRadioButton.Checked == true)

            //if (polylineRadioButton.Checked && doDraw)
            //{
            //    mouse = e.Location;
            //    var locationList = new List<Point>();
            //    locationList.Add(e.Location);
            //    if (locationList.Count == 2)
            //    {
            //        var newPolyline = new Polyline(locationList, myPen);
            //        cacheDraft=newPolyline;
            //        draftList.Add(cacheDraft);
            //    }
            //    if (locationList.Count > 2)
            //    {
            //        //Polyline currentPolyline = cacheDraft as Polyline;
            //        if(draftList.Last() is Polyline)
            //        {
            //            Polyline currentPolyline = draftList.Last() as Polyline;
            //            currentPolyline.AddPoint(e.Location);
            //            cacheDraft = currentPolyline;
            //            draftList.Add(cacheDraft);
            //        }
            //    }              
            //}
        }

        private void polylineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCanvas();
            cacheDraft = null;
            if (polylineRadioButton.Checked == false)
            {
                doDraw = false;
            }
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
            RefreshCanvas();        
        }

        private void lineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RefreshCanvas();
            cacheDraft = null;
        }
    }
}
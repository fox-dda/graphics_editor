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

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
            doDraw = true;
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lineRadioButton.Checked || polylineRadioButton.Checked) && doDraw)
            {
                if (cacheDraft != null && !(cacheDraft is Polyline))
                {
                    cacheDraft.Pen = new Pen (Color.White, myPen.Width);
                    cacheDraft.Draw(g);
                }

                //  g.Clear(Color.White);
                Line newLine = new Line(mouse, e.Location, myPen); // создаем линию вслед за курсором после нажания пкмыши
                cacheDraft =  newLine;
                cacheDraft.Draw(g); // чертим созданную линию
                foreach (IDraft draft in draftList)
                {
                    if (draft != null)
                    {
                        draft.Draw(g);
                    }
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

            if (polylineRadioButton.Checked && doDraw)
            {
                var locationList = new List<Point>();
                locationList.Add(e.Location);
                if (locationList.Count == 2)
                {
                    var newPolyline = new Polyline(locationList, myPen);
                    cacheDraft=newPolyline;
                }
                if (locationList.Count > 2)
                {
                    Polyline currentPolyline = cacheDraft as Polyline;
                    currentPolyline.AddPoint(e.Location);
                    cacheDraft = currentPolyline;
                }
                draftList.Add(cacheDraft);
            }
        }

        private void polylineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (polylineRadioButton.Checked == false)
            {
                doDraw = false;
            }
        }
    }
}
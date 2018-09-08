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
        private IDraft cacheDrawft;
        private Graphics g;
        private Pen myPen = new Pen(Color.Black, 1);
        private float mouseStartX;
        private float mouseStartY;
        private bool doDraw = false;

        public MainForm()
        {
            InitializeComponent();
            g = Graphics.FromHwnd(mainPictureBox.Handle);
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStartX = e.Location.X;
            mouseStartY = e.Location.Y;
            doDraw = true;
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (lineRadioButton.Checked && doDraw)
            {
                g.Clear(Color.White);
                Line newLine = new Line(mouseStartX, mouseStartY, e.Location.X, e.Location.Y, myPen);
                cacheDrawft =  newLine;
                cacheDrawft.Draw(g);
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
            draftList.Add(cacheDrawft);
            cacheDrawft = null;
            doDraw = false;
        }
    }
}
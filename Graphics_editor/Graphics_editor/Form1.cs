using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_editor
{
    public partial class MainForm : Form
    {

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
                g.DrawLine(myPen, mouseStartX, mouseStartY, e.Location.X, e.Location.Y);
            }
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            doDraw = false;
        }

        private void mainPictureBox_MouseEnter(object sender, EventArgs e)
        {
           // mouseStartX = Cursor.Position.X - mainPictureBox.Location.X;
         //   mouseStartY = Cursor.Position.Y - mainPictureBox.Location.Y;
            //mouseStartX = Cursor.Position.X;
            //mouseStartY = Cursor.Position.Y;
        }
    }
}
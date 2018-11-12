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
        private Presenter GPresenter = new Presenter();
        private Graphics _painter;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _painter = Graphics.FromHwnd(mainPictureBox.Handle);
            GPresenter.Painter = _painter;
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            GPresenter.Process(e, MouseAction.down);
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            GPresenter.Process(e, MouseAction.move);
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            GPresenter.Process(e, MouseAction.up);
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

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                GPresenter.GPen = new Pen(colorDialog.Color);
        }

        private void selectCanvasColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                GPresenter.CanvasColor = colorDialog.Color;
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            GPresenter.ClearCanvas();
        }
    }
}
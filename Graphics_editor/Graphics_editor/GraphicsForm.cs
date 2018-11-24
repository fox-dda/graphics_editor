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

    enum Figure
    {
        circle,
        ellipse,
        line,
        polyline,
        triangle
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
            GPresenter.Figure = Figure.line;
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = Figure.polyline;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = Figure.circle;
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = Figure.triangle;
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                GPresenter.GPen = new Pen(colorDialog.Color, GPresenter.GPen.Width);
            refreshPen();
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

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            GPresenter.Figure = Figure.ellipse;
        }

        private void thicknessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            refreshPen();
        }

        private void penStrokeWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            refreshPen();
        }

        private void refreshPen()
        {          
            GPresenter.GPen = new Pen(GPresenter.GPen.Color, (float)thicknessNumericUpDown.Value);
            if(penStrokeWidthNumericUpDown.Value > 0)
                GPresenter.GPen.DashPattern = new float[] 
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
        }

    }
}
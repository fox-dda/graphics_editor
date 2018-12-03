using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using System.Reflection;


namespace GraphicsEditor
{
    public partial class MainForm : Form
    {

        private Presenter _GPresenter = new Presenter();
        private Graphics _painter;

        public MainForm()
        {
            InitializeComponent();

            _painter = Graphics.FromHwnd(mainPictureBox.Handle);
            _GPresenter.Painter = _painter;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _GPresenter.Process(e, MouseAction.down);
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _GPresenter.Process(e, MouseAction.move);
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _GPresenter.Process(e, MouseAction.up);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.line;
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.polyline;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.circle;
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.triangle;
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                _GPresenter.GPen = new Pen(colorDialog.Color, _GPresenter.GPen.Width);
            refreshPen();
        }

        private void selectCanvasColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                _GPresenter.CanvasColor = colorDialog.Color;
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            _GPresenter.ClearCanvas();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.ellipse;
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
            _GPresenter.GPen = new Pen(_GPresenter.GPen.Color, (float)thicknessNumericUpDown.Value);
            if(penStrokeWidthNumericUpDown.Value > 0)
                _GPresenter.DashPattern = new float[] 
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            _GPresenter.Painter = Graphics.FromHwnd(mainPictureBox.Handle);
            _GPresenter.RefreshCanvas();
            Invalidate();
        }

        private void selectBrushColorButton_Click(object sender, EventArgs e)
        {
            {
                ColorDialog colorDialog = new ColorDialog();

                if (colorDialog.ShowDialog() == DialogResult.OK)
                    _GPresenter.BrushColor = colorDialog.Color;
            }
        }

        private void selectMouseButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.select;
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            _GPresenter.DisradHighlightingAll();
        }

        private void lassoSelectionButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.select;
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.polygon;
        }

    }
}
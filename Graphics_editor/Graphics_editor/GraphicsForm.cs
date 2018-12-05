using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using System.Reflection;
using GraphicsEditor.Model;


namespace GraphicsEditor
{
    public partial class MainForm : Form
    {

        private Presenter _GPresenter = new Presenter();
        private Graphics _painter;

        public MainForm()
        {
            InitializeComponent();


            foreach (Control control in Controls)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
            }
            Bitmap btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _painter = Graphics.FromImage(btm);
            _GPresenter.Painter = _painter;
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            _GPresenter.Process(e, MouseAction.down);
            RefreshView();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _GPresenter.Process(e, MouseAction.move);
            RefreshView();
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _GPresenter.Process(e, MouseAction.up);
            RefreshView();

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
            {
                _GPresenter.Settings.GPen = new Pen(colorDialog.Color, _GPresenter.Settings.GPen.Width);
                penColorpanel.BackColor = colorDialog.Color;
            }
            refreshPen();
        }

        private void selectCanvasColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _GPresenter.SetCanvasColor(colorDialog.Color);
                canvasColorpanel.BackColor = colorDialog.Color;
            }
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            _GPresenter.ClearCanvas();
            canvasColorpanel.BackColor = Color.White;
            RefreshView();
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
            _GPresenter.Settings.GPen = new Pen(_GPresenter.Settings.GPen.Color, (float)thicknessNumericUpDown.Value);
            if (penStrokeWidthNumericUpDown.Value > 0)
                _GPresenter.Settings.DashPattern = new float[]
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _painter = Graphics.FromImage(btm);
            _GPresenter.Painter = _painter;
            _GPresenter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }

        private void selectBrushColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _GPresenter.Settings.BrushColor = colorDialog.Color;
                brushColorpanel.BackColor = colorDialog.Color;
            }
        }

        private void selectMouseButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.select;
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            _GPresenter.DisradHighlightingAll();
            mainPictureBox.Invalidate();
        }

        private void lassoSelectionButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.select;
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            _GPresenter.Figure = Figure.polygon;
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _GPresenter.LeaveCanvas();
        }

        private void RefreshSelectPanel()
        {
            var hightlightObject = _GPresenter.GetHighlightObject();
            if (hightlightObject != null)
            {
                //editGroupBox.Enabled = true;
                var typeStr = hightlightObject.GetType().ToString().Split('.');
                typeLabel.Text = typeStr[typeStr.Length - 1];
                sPTextBox.Text = hightlightObject.StartPoint.X.ToString() + "; " + hightlightObject.StartPoint.Y.ToString();
                ePEextBox.Text = hightlightObject.EndPoint.X.ToString() + "; " + hightlightObject.EndPoint.Y.ToString();
                selectedWidthNnumericUpDown.Value = (int)hightlightObject.Pen.Width;

                try//при не инициализованном дашпаттерне любое обращение к нему вызовет екзепшен "Недотаточно памяти"
                {
                    if (hightlightObject.Pen.DashPattern.Length > 0)
                        selectedStrokeNumericUpDown.Value = (int)hightlightObject.Pen.DashPattern[0];
                }
                catch
                {
                    selectedStrokeNumericUpDown.Value = 0;
                }

                selectedColorPanel.BackColor = hightlightObject.Pen.Color;
                if (hightlightObject is IBrushable)
                    selectedBrushPanel.BackColor = (hightlightObject as IBrushable).BrushColor;
                else
                    selectedBrushPanel.BackColor = Color.White;
            }
            else
            {
                typeLabel.Text = "";
                sPTextBox.Text = "";
                ePEextBox.Text = "";
                selectedWidthNnumericUpDown.Value = 1;
                selectedStrokeNumericUpDown.Value = 0;
                selectedColorPanel.BackColor = Color.White;
                selectedBrushPanel.BackColor = Color.White;
            }
        }

        private void RefreshView()
        {
            RefreshSelectPanel();
            mainPictureBox.Invalidate();
        }
    }
}
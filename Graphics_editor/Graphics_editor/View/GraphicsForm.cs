using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using System.Reflection;
using GraphicsEditor.Engine;


namespace GraphicsEditor
{
    public partial class MainForm : Form
    {
        private DrawManager _drawManager;
        private DraftClipboard _buffer = new DraftClipboard();
        private DraftStorage _storage = new DraftStorage();
        private Graphics _paintCore;    
        private DraftPainter _draftPainter;
        private SelectionPanel _highlightPanel;


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
            _paintCore = Graphics.FromImage(btm);
            _draftPainter = new DraftPainter(_paintCore);
            _drawManager = new DrawManager(_draftPainter, _storage);
            _highlightPanel = new SelectionPanel() { StorageManager = new DraftTools.StorageManager(_storage)};
            Controls.Add(_highlightPanel);
            rightGroupBox.Controls.Add(_highlightPanel);
            _highlightPanel.Location = new Point(3, 2);          
        }

        private void mainPictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            _drawManager.Process(e, MouseAction.move);
           // RefreshView();
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            _drawManager.Process(e, MouseAction.up);
            RefreshView();
            mainPictureBox.Invalidate();
        }
        
        private void mainPictureBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            _drawManager.Process(e, MouseAction.down);
            RefreshView();
            mainPictureBox.Invalidate();
        }
        /*/
        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _drawManager.Process(e, MouseAction.down);
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _drawManager.Process(e, MouseAction.move);
            mainPictureBox.Invalidate();
        }
        /*/
        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _drawManager.Process(e, MouseAction.up);
            RefreshView();
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.line;
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.polyline;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.circle;
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.triangle;
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.GPen = new Pen(colorDialog.Color, _drawManager.DraftPainter.Parameters.GPen.Width);
                penColorpanel.BackColor = colorDialog.Color;
            }
            refreshPen();
        }

        private void selectCanvasColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.SetCanvasColor(colorDialog.Color);
                canvasColorpanel.BackColor = colorDialog.Color;
            }
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            _drawManager.DraftPainter.ClearCanvas();
            canvasColorpanel.BackColor = Color.White;
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.ellipse;
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
            _drawManager.DraftPainter.Parameters.GPen = new Pen(_draftPainter.Parameters.GPen.Color, (float)thicknessNumericUpDown.Value);
            if (penStrokeWidthNumericUpDown.Value > 0)
                _drawManager.DraftPainter.Parameters.DashPattern = new float[]
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _paintCore = Graphics.FromImage(btm);
            _draftPainter.Painter = _paintCore;
            _drawManager.DraftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }

        private void selectBrushColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.BrushColor = colorDialog.Color;
                brushColorpanel.BackColor = colorDialog.Color;
            }
        }

        private void selectMouseButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.select;
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
           // _drawManager.DraftPainter.DisradHighlightingAll();
            mainPictureBox.Invalidate();
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.polygon;
        }

        private void mainPictureBox_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void RefreshView()
        {
            _highlightPanel.Drafts = _drawManager.Corrector.GetHighlights();
            mainPictureBox.Invalidate();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {/*/
            if (e.KeyChar == (Char)3)//c
            {
                _buffer.SetRange(_drawManager.GetHighlightObjects()); 
            }
            else if (e.KeyChar == (Char)22)//v
            {
                _drawManager.AddObjects(_buffer.GetAll());
            }
            else if (e.KeyChar == (Char)4)//d
            {
                _drawManager.RemoveHighlightObjects();
            }
            else if (e.KeyChar == (Char)24)//x
            {
                _buffer.SetRange(_drawManager.GetHighlightObjects());
                _drawManager.RemoveHighlightObjects();
            }/*/
            _draftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   DraftSerealizer.Serialize(_drawManager.GetListForSave());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  _drawManager.SetList(DraftSerealizer.DeSerialize());
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            _draftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }
    }
}
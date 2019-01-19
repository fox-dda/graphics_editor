using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using System.Reflection;
using GraphicsEditor.Engine;
using GraphicsEditor.Model.Shapes;


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

            _highlightPanel = new SelectionPanel() { StorageManager = _drawManager.DraftStorageManager };
            Controls.Add(_highlightPanel);
            rightGroupBox.Controls.Add(_highlightPanel);
            _highlightPanel.Location = new Point(3, 2);
            _highlightPanel.ModelChanged += _draftPainter.RefreshCanvas;
            _highlightPanel.ModelChanged += mainPictureBox.Invalidate;
        }

        private void mainPictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.move);
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.up);
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.down);
            RefreshView();
            mainPictureBox.Invalidate();
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

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            canvasColorpanel.BackColor = Color.White;
            _drawManager.DraftPainter.ClearCanvas();
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
            _drawManager.DraftPainter.Parameters.GPen = new PenSettings() { Color = _draftPainter.Parameters.GPen.Color, Width = (float)thicknessNumericUpDown.Value, DashPattern = _draftPainter.Parameters.GPen.DashPattern };
            if (penStrokeWidthNumericUpDown.Value > 0)
                _drawManager.DraftPainter.Parameters.DashPattern = new float[]
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if ((mainPictureBox.Width < 1) && (mainPictureBox.Height < 1))
                return;

            Bitmap btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _paintCore = Graphics.FromImage(btm);
            _draftPainter.Painter = _paintCore;
            _drawManager.DraftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }

        private void selectMouseButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.select;
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = Figure.polygon;
        }

        private void RefreshView()
        {
            _highlightPanel.Drafts = _drawManager.DraftStorageManager.HighlightDraftStorage;
            mainPictureBox.Invalidate();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            _drawManager.KeyProcess(e, _buffer);
            _draftPainter.RefreshCanvas();
            RefreshView();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void penColorpanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.GPen = new PenSettings()
                { Color = colorDialog.Color,
                    Width = _drawManager.DraftPainter.Parameters.GPen.Width,
                    DashPattern = _drawManager.DraftPainter.Parameters.GPen.DashPattern
                };
                penColorpanel.BackColor = colorDialog.Color;
            }
            refreshPen();
        }

        private void canvasColorpanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.EditCanvasColor(colorDialog.Color);
                canvasColorpanel.BackColor = colorDialog.Color;
            }
            mainPictureBox.Invalidate();
        }

        private void brushColorpanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.BrushColor = colorDialog.Color;
                brushColorpanel.BackColor = colorDialog.Color;
            }
        }

        private void exportToBmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            _drawManager.DraftStorageManager.DiscardAll();
            _draftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                mainPictureBox.Image.Save(saveDialog.FileName + ".bmp");
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Copy(_buffer);
            RefreshView();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Cut(_buffer);
            RefreshView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Remove();
            RefreshView();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Paste(_buffer);
            RefreshView();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Undo();
            RefreshView();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawManager.Redo();
            RefreshView();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Save project?",
                Text,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                SaveProject();
            }
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "You want to create a new project. Save current project?",
                Text,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                SaveProject();
                _drawManager.CreateNewProject();
            }
            if (result == DialogResult.No)
            {
                _drawManager.CreateNewProject();
            }
            mainPictureBox.Invalidate();
        }

        private void SaveProject()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GraphicsEditor Project|*.proj";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using (var stream = saveFileDialog.OpenFile())
                {
                    _drawManager.Serealize(stream);
                }
            }
        }

        private void OpenProject()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GraphicsEditor Project|*.proj";
            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using (var stream = openFileDialog.OpenFile())
                {
                    _drawManager.Deserialize(stream);
                }
            }
            mainPictureBox.Invalidate();
        }
    }
}
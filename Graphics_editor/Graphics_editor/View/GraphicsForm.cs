﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GraphicsEditor.Enums;
using System.Reflection;
using GraphicsEditor.DraftTools;
using GraphicsEditor.Engine;
using GraphicsEditor.View;
using SDK;
using GraphicsEditor.Interfaces;
using GraphicsEditor.Model.Drawers;
using GraphicsEditor.Engine.UndoRedo.Commands;
using GraphicsEditor.Engine.UndoRedo;
using StructureMap;
using System.Collections.Generic;

namespace GraphicsEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Менеджер рисования
        /// </summary>
        private IDrawManager _drawManager;

        /// <summary>
        /// Буффер обмена
        /// </summary>
        private IDraftClipboard _buffer;

        /// <summary>
        /// Ядро рисования
        /// </summary>
        private Graphics _paintCore;

        /// <summary>
        /// Панель выделенных объектов
        /// </summary>
        private SelectionPanel _highlightPanel;

        public MainForm(IContainer container)
        {
            InitializeComponent();

            foreach (Control control in Controls)
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null, control, new object[] { true });
            }

            Bitmap btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _paintCore = Graphics.FromImage(btm);

            var draftFactory = new DraftFactory(container);
            var buffer = new DraftClipboard(draftFactory, new List<IDrawable>());
            var penSettings = new PenSettings(Color.Black, 1);
            var paintingParameters = new PaintingParameters(penSettings);
            var drawerFacade = new DrawerFacade();
            var undoRedoStack = new UndoRedoStack();
            var painterState = new PainterState();
            var draftStorage = new DraftStorage();
            var commandFactory = new CommandFactory();
            var selector = new Selector();

            var storageManager = new StorageManager(
                draftStorage,
                commandFactory,
                undoRedoStack);

            var draftPainter = new DraftPainter(
                _paintCore,
                paintingParameters,
                storageManager,
                draftFactory,
                drawerFacade);

            var drawManager = new DrawManager(
                _paintCore,
                draftPainter,
                storageManager,
                painterState,
                selector,
                undoRedoStack);

            Setup(buffer, drawManager);

            _highlightPanel = new SelectionPanel(draftFactory)
            {
                StorageManager = _drawManager.DraftStorageManager 
            };

            Controls.Add(_highlightPanel);
            rightGroupBox.Controls.Add(_highlightPanel);
            _highlightPanel.Location = new Point(3, 2);
            _highlightPanel.ModelChanged += _drawManager.DraftPainter.RefreshCanvas;
            _highlightPanel.ModelChanged += mainPictureBox.Invalidate;
            var figureToolBox = new FigureToolBox(_drawManager.DraftPainter.State);
            leftGroupBox.Controls.Add(figureToolBox);
            figureToolBox.Location = new Point(6,12);
            
        }

        /// <summary>
        /// Внедрение зависимостей через метод.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="drawManager"></param>
        public void Setup(IDraftClipboard buffer, IDrawManager drawManager)
        {
            _buffer = buffer;
            _drawManager = drawManager;
        }

        private void mainPictureBox_MouseMove_1(object sender,
            MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.Move);
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.Up);
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            _drawManager.MouseProcess(e, MouseAction.Down);
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void clearCanvasButton_Click(object sender, EventArgs e)
        {
            canvasColorpanel.BackColor = Color.White;
            _drawManager.DraftPainter.ClearCanvas();
            RefreshView();
            mainPictureBox.Invalidate();
        }

        private void thicknessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshPen();
        }

        private void penStrokeWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshPen();
        }

        private void RefreshPen()
        {
            _drawManager.DraftPainter.Parameters.GPen = 
                new PenSettings(_drawManager.DraftPainter.Parameters.GPen.Color,
                (float)thicknessNumericUpDown.Value)
                {          
                    DashPattern = _drawManager.DraftPainter.Parameters.GPen.DashPattern
                };

            if (penStrokeWidthNumericUpDown.Value > 0)
                _drawManager.DraftPainter.Parameters.DashPattern = new float[]
                {
                    (float)penStrokeWidthNumericUpDown.Value,
                    (float)penStrokeWidthNumericUpDown.Value
                };
            else
            {
                _drawManager.DraftPainter.Parameters.DashPattern = null;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if ((mainPictureBox.Width < 1) && (mainPictureBox.Height < 1))
                return;

            var btm = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = btm;
            _paintCore = Graphics.FromImage(btm);
            _drawManager.DraftPainter.Painter = _paintCore;
            _drawManager.DraftPainter.RefreshCanvas();
            mainPictureBox.Invalidate();
        }

        private void selectMouseButton_Click(object sender, EventArgs e)
        {
            _drawManager.State.Figure = "HighlightRect";
        }
        
        /// <summary>
        /// Обновить настройки пера
        /// </summary>
        private void RefreshView()
        {
            _highlightPanel.Drafts =
                _drawManager.DraftStorageManager.HighlightDraftStorage;
            CommandStackView.Items.Clear();
            foreach (var command in _drawManager.CommandStack.UndoStack.ToArray().Reverse())
            {    
                CommandStackView.Items.Add(
                    command.ToString().Split('.').Last());
            }

            if (CommandStackView.Items.Count > 0)
            {
               CommandStackView.Items[CommandStackView.Items.Count - 1] =
                    "-->" + CommandStackView.Items[CommandStackView.Items.Count - 1];
               CommandStackView.TopIndex = CommandStackView.Items.Count - 1;
            }

            foreach (var command in _drawManager.CommandStack.RedoStack.ToArray())
            {
                CommandStackView.Items.Add(
                    command.ToString().Split('.').Last());
            }
            mainPictureBox.Invalidate();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            _drawManager.KeyProcess(e, _buffer);
            _drawManager.DraftPainter.RefreshCanvas();
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
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.GPen = new PenSettings(
                    colorDialog.Color,
                     _drawManager.DraftPainter.Parameters.GPen.Width)
                {
                    DashPattern = _drawManager.DraftPainter.Parameters.GPen.DashPattern
                };
                penColorpanel.BackColor = colorDialog.Color;
            }
            RefreshPen();
        }

        private void canvasColorpanel_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.EditCanvasColor(colorDialog.Color);
                canvasColorpanel.BackColor = colorDialog.Color;
            }
            mainPictureBox.Invalidate();
            RefreshView();
        }

        private void brushColorpanel_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _drawManager.DraftPainter.Parameters.BrushColor = colorDialog.Color;
                brushColorpanel.BackColor = colorDialog.Color;
            }
        }

        private void exportToBmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            _drawManager.DraftStorageManager.DiscardAll();
            _drawManager.DraftPainter.RefreshCanvas();
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
            var result = CreateCloseProjectDialog(
                "Save project?");

            switch (result)
            {
                case DialogResult.Yes:
                    SaveProject();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = CreateCloseProjectDialog(
                "You want to create a new project. Save current project ?");

            switch (result)
            {
                case DialogResult.Yes:
                    SaveProject();
                    _drawManager.CreateNewProject();
                    break;
                case DialogResult.No:
                    _drawManager.CreateNewProject();
                    break;
            }

            mainPictureBox.Invalidate();
        }

        /// <summary>
        /// Сохранение проекта
        /// </summary>
        private void SaveProject()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GraphicsEditor Project|*.proj";
            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using (var stream = saveFileDialog.OpenFile())
                {
                    _drawManager.Serealize(stream);
                }
            }
        }

        /// <summary>
        /// Открытие проекта
        /// </summary>
        private void OpenProject()
        {
            var openFileDialog = new OpenFileDialog();
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

        /// <summary>
        /// Создать диалог закрытия проекта
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Результат диалога</returns>
        private DialogResult CreateCloseProjectDialog(string message)
        {
            var result = MessageBox.Show(
                message,
                Text,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            return result;
        }
    }
}
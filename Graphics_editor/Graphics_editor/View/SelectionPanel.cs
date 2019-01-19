using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsEditor.DraftTools;
using GraphicsEditor.Model.Shapes;
using System.Windows.Forms;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    public partial class SelectionPanel : UserControl
    {
        public StorageManager StorageManager = null;

        private List<IDrawable> _draftList;

        public List<IDrawable> Drafts
        {
            get
            {
                return _draftList;
            }
            set
            {
                _draftList = value;
                RefreshView();
            }
        }

        private bool _enabledData = true;

        private bool IsShortData()
        {
            if ((Drafts.Count > 1) &&
                ((selectedBrushPanel.Enabled == true) &&
                (selectedColorPanel.Enabled == true) &&
                (selectedStrokeNumericUpDown.Enabled == true) &&
                (selectedWidthNnumericUpDown.Enabled == true)))
                return true;
            else
                return false;
        }

        private bool IsFullData()
        {
            if (Drafts.Count == 1)
            {
                if ((selectObjectSPXMaskedTextBox.Text != "") &&
                    (selectObjectSPYMaskedTextBox.Text != "") &&
                    (selectObjectEPXMaskedTextBox.Text != "") &&
                    (selectObjectEPYMaskedTextBox.Text != "") &&
                    (selectedBrushPanel.Enabled == true) &&
                    (selectedColorPanel.Enabled == true) &&
                    (selectedStrokeNumericUpDown.Enabled == true) &&
                    (selectedWidthNnumericUpDown.Enabled == true) &&
                    (selectObjectSPXMaskedTextBox.Enabled == true) &&
                    (selectObjectSPYMaskedTextBox.Enabled == true) &&
                    (selectObjectEPXMaskedTextBox.Enabled == true) &&
                    (selectObjectEPYMaskedTextBox.Enabled == true))
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }

        private void RefreshModel()
        {
            if (_enabledData == false)
                return;

            if(IsFullData() && Drafts.Count == 1)
            {
                var startPoint = new Point(Convert.ToInt32(selectObjectSPXMaskedTextBox.Text), Convert.ToInt32(selectObjectSPYMaskedTextBox.Text));
                var endPoint = new Point(Convert.ToInt32(selectObjectEPXMaskedTextBox.Text), Convert.ToInt32(selectObjectEPYMaskedTextBox.Text));
                var pen = new PenSettings() {Color =  selectedColorPanel.BackColor, Width = (float)selectedWidthNnumericUpDown.Value };

                if (selectedStrokeNumericUpDown.Value > 0)
                    pen.DashPattern = new float[]
                    {
                        (float)selectedStrokeNumericUpDown.Value,
                        (float)selectedStrokeNumericUpDown.Value
                    };

                List<Point> pointList;
                if(Drafts[0] is Polygon)
                {
                    pointList = (Drafts[0] as Polygon).DotList;
                    pointList[0] = startPoint;
                    pointList[pointList.Count - 1] = endPoint;
                }
                else if (Drafts[0] is Polyline)
                {
                    pointList = (Drafts[0] as Polyline).DotList;
                    pointList[0] = startPoint;
                    pointList[pointList.Count - 1] = endPoint;
                }
                else
                {
                    pointList = new List<Point>() { startPoint, endPoint };
                }

                if (Drafts[0] is IBrushable)
                    StorageManager.EditDraft(Drafts[0], pointList, pen, selectedBrushPanel.BackColor);
                else
                    StorageManager.EditDraft(Drafts[0], pointList, pen, Color.White);
            }
            ModelChanged();
        }

        private void RefreshView()
        {
            _enabledData = false;
            if (Drafts.Count != 0)
            {
                if (Drafts.Count == 1)
                {
                    var typeStr = Drafts[0].GetType().ToString().Split('.');
                    typeLabel.Text = typeStr[typeStr.Length - 1];
                    selectObjectSPXMaskedTextBox.Text = Drafts[0].StartPoint.X.ToString();
                    selectObjectSPYMaskedTextBox.Text = Drafts[0].StartPoint.Y.ToString();
                    selectObjectEPXMaskedTextBox.Text = Drafts[0].EndPoint.X.ToString();
                    selectObjectEPYMaskedTextBox.Text = Drafts[0].EndPoint.Y.ToString();
                    selectedWidthNnumericUpDown.Value = (int)Drafts[0].Pen.Width;
                    selectedColorPanel.BackColor = Drafts[0].Pen.Color;
                    if (Drafts[0] is IBrushable)
                        selectedBrushPanel.BackColor = (Drafts[0] as IBrushable).BrushColor;
                    else
                        selectedBrushPanel.BackColor = Color.White;

                    selectedColorPanel.Enabled = true;
                    selectedBrushPanel.Enabled = true;
                    selectedStrokeNumericUpDown.Enabled = true;
                    selectedWidthNnumericUpDown.Enabled = true;
                    selectObjectSPXMaskedTextBox.Enabled = true;
                    selectObjectSPYMaskedTextBox.Enabled = true;
                    selectObjectEPXMaskedTextBox.Enabled = true;
                    selectObjectEPYMaskedTextBox.Enabled = true;

                    //при не инициализованном дашпаттерне любое обращение к нему вызовет екзепшен "Недотаточно памяти"
                    try
                    {
                        if (Drafts[0].Pen.DashPattern.Length > 0)
                            selectedStrokeNumericUpDown.Value = (int)Drafts[0].Pen.DashPattern[0];
                    }
                    catch
                    {
                        selectedStrokeNumericUpDown.Value = 0;
                    }
                }
                else if(Drafts.Count > 1)
                {
                    selectObjectSPXMaskedTextBox.Enabled = false;
                    selectObjectSPYMaskedTextBox.Enabled = false;
                    selectObjectEPXMaskedTextBox.Enabled = false;
                    selectObjectEPYMaskedTextBox.Enabled = false;

                    selectedColorPanel.Enabled = false;
                    selectedBrushPanel.Enabled = false;
                    selectedStrokeNumericUpDown.Enabled = false;
                    selectedWidthNnumericUpDown.Enabled = false;

                    selectObjectSPXMaskedTextBox.Text = "";
                    selectObjectSPYMaskedTextBox.Text = "";
                    selectObjectEPXMaskedTextBox.Text = "";
                    selectObjectEPYMaskedTextBox.Text = "";

                    var type = DraftFactory.CheckUniformity(Drafts);

                    if (type == null)
                    {
                        typeLabel.Text = "Draft collection[" + Drafts.Count.ToString() + "]";
                    }
                    else
                    {
                        var typeStr = Drafts[0].GetType().ToString().Split('.');
                        typeLabel.Text = typeStr[typeStr.Length - 1] + " collection[" + Drafts.Count.ToString() + "]";
                    }
                }
            }
            else
            {
                typeLabel.Text = "";
                selectObjectSPXMaskedTextBox.Text = "";
                selectObjectSPYMaskedTextBox.Text = "";
                selectObjectEPXMaskedTextBox.Text = "";
                selectObjectEPYMaskedTextBox.Text = "";
                selectObjectSPXMaskedTextBox.Enabled = false;
                selectObjectSPYMaskedTextBox.Enabled = false;
                selectObjectEPXMaskedTextBox.Enabled = false;
                selectObjectEPYMaskedTextBox.Enabled = false;
                selectedWidthNnumericUpDown.Value = 1;
                selectedStrokeNumericUpDown.Value = 0;
                selectedColorPanel.Enabled = false;
                selectedBrushPanel.Enabled = false;
                selectedStrokeNumericUpDown.Enabled = false;
                selectedWidthNnumericUpDown.Enabled = false;
                selectedColorPanel.BackColor = Color.White;
                selectedBrushPanel.BackColor = Color.White;
            }
            _enabledData = true;
        }

        public SelectionPanel()
        {
            InitializeComponent();
        }

        private void selectObjectSPXMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectObjectSPYMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectObjectEPYMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectObjectEPXMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectedWidthNnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectedStrokeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectedColorPanel_BackColorChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }

        private void selectedBrushPanel_BackColorChanged(object sender, EventArgs e)
        {
            RefreshModel();
        }
        
        private void selectedColorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColorPanel.BackColor = colorDialog.Color;
            }
        }

        private void selectedBrushPanel_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedBrushPanel.BackColor = colorDialog.Color;
            }
        }

         public delegate void DataChanged();

         public event  DataChanged ModelChanged;
    }
}


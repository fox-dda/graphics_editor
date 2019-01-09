using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsEditor.DraftTools;
using System.Windows.Forms;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    public partial class SelectionPanel : UserControl
    {
        public StorageManager StorageManager = null;

        private List<IDrawable> _draftList = new List<IDrawable>();

        public List<IDrawable> Drafts
        {
            get
            {
                return _draftList;
            }
            set
            {
                _draftList.Clear();

                if (value == null)
                {
                    RefreshView();
                    return;
                }

                foreach (IDrawable draft in value)
                {
                    _draftList.Add((draft as HighlightRect).LightItem);
                }
                RefreshView();
            }
        }

        private bool IsFullData()
        {
            if (
                (selectObjectSPXMaskedTextBox.Text != "") &&
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
                (selectObjectEPYMaskedTextBox.Enabled == true)
                )
                return true;
            else
                return false;
        }

        private void RefreshModel()
        {
            if(IsFullData() && Drafts.Count == 1)
            {

                var startPoint = DraftFactory.CreatePoint(Convert.ToInt32(selectObjectSPXMaskedTextBox.Text), Convert.ToInt32(selectObjectSPYMaskedTextBox.Text));
                var endPoint = DraftFactory.CreatePoint(Convert.ToInt32(selectObjectEPXMaskedTextBox.Text), Convert.ToInt32(selectObjectEPYMaskedTextBox.Text));
                var pen = new Pen(selectedColorPanel.BackColor, (float)selectedWidthNnumericUpDown.Value);

                if (selectedStrokeNumericUpDown.Value > 0)
                    pen.DashPattern = new float[]
                    {
                        (float)selectedStrokeNumericUpDown.Value,
                        (float)selectedStrokeNumericUpDown.Value
                    };

                if (Drafts[0] is IBrushable)
                    StorageManager.EditHighlightDraft(Drafts[0], startPoint, endPoint, pen, selectedBrushPanel.BackColor);
                else
                    StorageManager.EditHighlightDraft(Drafts[0], startPoint, endPoint, pen);
            }
            else if(Drafts.Count > 0)
            {

            }
        }

        private void RefreshView()
        {

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
                    if (Drafts is IBrushable)
                        selectedBrushPanel.BackColor = (Drafts as IBrushable).BrushColor;
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

                    selectObjectSPXMaskedTextBox.Text = "";
                    selectObjectSPYMaskedTextBox.Text = "";
                    selectObjectEPXMaskedTextBox.Text = "";
                    selectObjectEPYMaskedTextBox.Text = "";

                    var type = DraftFactory.CheckUniformity(Drafts);

                    if (type == null)
                    {
                        typeLabel.Text = "Draft collection";
                        selectedColorPanel.Enabled = true;
                        selectedBrushPanel.Enabled = true;
                        selectedStrokeNumericUpDown.Enabled = true;
                        selectedWidthNnumericUpDown.Enabled = true;
                    }
                    //else if((type == typeof(Line)) && (type == typeof(Circle)) && (type == typeof(Ellipse)))
                    else
                    {
                        var typeStr = Drafts[0].GetType().ToString().Split('.');
                        typeLabel.Text = typeStr[typeStr.Length - 1] + " collection";
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

        // public delegate void _dataChanged();

        // public event _dataChanged DataChanged;
    }
}


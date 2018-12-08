using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsEditor.Model;

namespace GraphicsEditor
{
    public partial class SelectionPanel : UserControl
    {

        private IDrawable _draft = null;

        public IDrawable Draft
        {
            get
            {
                return _draft;
            }
            set
            {             
                _draft = value;
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
            if(IsFullData())
            {
                var typeStr = Draft.GetType().ToString().Split('.');

                Draft.StartPoint = new Point(Convert.ToInt32(selectObjectSPXMaskedTextBox.Text), Convert.ToInt32(selectObjectSPYMaskedTextBox.Text));
                Draft.EndPoint = new Point(Convert.ToInt32(selectObjectEPXMaskedTextBox.Text), Convert.ToInt32(selectObjectEPYMaskedTextBox.Text));

                Draft.Pen = new Pen(selectedColorPanel.BackColor, (float)selectedWidthNnumericUpDown.Value);
                if (selectedStrokeNumericUpDown.Value > 0)
                    Draft.Pen.DashPattern = new float[]
                    {
                        (float)selectedStrokeNumericUpDown.Value,
                        (float)selectedStrokeNumericUpDown.Value
                    };
                if (Draft is IBrushable)
                (Draft as IBrushable).BrushColor = selectedBrushPanel.BackColor;

            }
        }

        private void RefreshView()
        {

            if (Draft != null)
            {
                var typeStr = Draft.GetType().ToString().Split('.');
                typeLabel.Text = typeStr[typeStr.Length - 1];
                selectObjectSPXMaskedTextBox.Text = Draft.StartPoint.X.ToString();
                selectObjectSPYMaskedTextBox.Text = Draft.StartPoint.Y.ToString();
                selectObjectEPXMaskedTextBox.Text = Draft.EndPoint.X.ToString();
                selectObjectEPYMaskedTextBox.Text = Draft.EndPoint.Y.ToString();
                selectedWidthNnumericUpDown.Value = (int)Draft.Pen.Width;
                selectedColorPanel.BackColor = Draft.Pen.Color;
                if (Draft is IBrushable)
                    selectedBrushPanel.BackColor = (Draft as IBrushable).BrushColor;
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
                    if (Draft.Pen.DashPattern.Length > 0)
                        selectedStrokeNumericUpDown.Value = (int)Draft.Pen.DashPattern[0];
                }
                catch
                {
                    selectedStrokeNumericUpDown.Value = 0;
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


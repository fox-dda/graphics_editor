namespace GraphicsEditor
{
    partial class SelectionPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectedObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.designSelectedGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedBrushPanel = new System.Windows.Forms.Panel();
            this.selectedObjectBrushLabel = new System.Windows.Forms.Label();
            this.selectedColorPanel = new System.Windows.Forms.Panel();
            this.colorSelectedLabel = new System.Windows.Forms.Label();
            this.selectedStrokeLabel = new System.Windows.Forms.Label();
            this.selectedStrokeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectedWidthLabel = new System.Windows.Forms.Label();
            this.selectedWidthNnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.sEPYLabel = new System.Windows.Forms.Label();
            this.sEPXLabel = new System.Windows.Forms.Label();
            this.sSPYLabel = new System.Windows.Forms.Label();
            this.sSPXLabel = new System.Windows.Forms.Label();
            this.selectObjectEPYMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.selectObjectSPYMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.selectObjectEPXMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.selectObjectSPXMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.StartPLabel = new System.Windows.Forms.Label();
            this.EndPLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.objectLabel = new System.Windows.Forms.Label();
            this.selectedObjectGroupBox.SuspendLayout();
            this.designSelectedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedStrokeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedWidthNnumericUpDown)).BeginInit();
            this.locationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedObjectGroupBox
            // 
            this.selectedObjectGroupBox.Controls.Add(this.designSelectedGroupBox);
            this.selectedObjectGroupBox.Controls.Add(this.locationGroupBox);
            this.selectedObjectGroupBox.Controls.Add(this.typeLabel);
            this.selectedObjectGroupBox.Controls.Add(this.objectLabel);
            this.selectedObjectGroupBox.Location = new System.Drawing.Point(0, 0);
            this.selectedObjectGroupBox.Name = "selectedObjectGroupBox";
            this.selectedObjectGroupBox.Size = new System.Drawing.Size(179, 256);
            this.selectedObjectGroupBox.TabIndex = 8;
            this.selectedObjectGroupBox.TabStop = false;
            this.selectedObjectGroupBox.Text = "Selected object";
            // 
            // designSelectedGroupBox
            // 
            this.designSelectedGroupBox.Controls.Add(this.selectedBrushPanel);
            this.designSelectedGroupBox.Controls.Add(this.selectedObjectBrushLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedColorPanel);
            this.designSelectedGroupBox.Controls.Add(this.colorSelectedLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedStrokeLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedStrokeNumericUpDown);
            this.designSelectedGroupBox.Controls.Add(this.selectedWidthLabel);
            this.designSelectedGroupBox.Controls.Add(this.selectedWidthNnumericUpDown);
            this.designSelectedGroupBox.Location = new System.Drawing.Point(8, 128);
            this.designSelectedGroupBox.Name = "designSelectedGroupBox";
            this.designSelectedGroupBox.Size = new System.Drawing.Size(165, 122);
            this.designSelectedGroupBox.TabIndex = 7;
            this.designSelectedGroupBox.TabStop = false;
            this.designSelectedGroupBox.Text = "Design";
            // 
            // selectedBrushPanel
            // 
            this.selectedBrushPanel.BackColor = System.Drawing.Color.White;
            this.selectedBrushPanel.ForeColor = System.Drawing.Color.White;
            this.selectedBrushPanel.Location = new System.Drawing.Point(55, 95);
            this.selectedBrushPanel.Name = "selectedBrushPanel";
            this.selectedBrushPanel.Size = new System.Drawing.Size(23, 23);
            this.selectedBrushPanel.TabIndex = 11;
            this.selectedBrushPanel.BackColorChanged += new System.EventHandler(this.selectedBrushPanel_BackColorChanged);
            this.selectedBrushPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectedBrushPanel_MouseClick);
            // 
            // selectedObjectBrushLabel
            // 
            this.selectedObjectBrushLabel.AutoSize = true;
            this.selectedObjectBrushLabel.Location = new System.Drawing.Point(10, 100);
            this.selectedObjectBrushLabel.Name = "selectedObjectBrushLabel";
            this.selectedObjectBrushLabel.Size = new System.Drawing.Size(34, 13);
            this.selectedObjectBrushLabel.TabIndex = 10;
            this.selectedObjectBrushLabel.Text = "Brush";
            // 
            // selectedColorPanel
            // 
            this.selectedColorPanel.BackColor = System.Drawing.Color.White;
            this.selectedColorPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.selectedColorPanel.Location = new System.Drawing.Point(55, 71);
            this.selectedColorPanel.Name = "selectedColorPanel";
            this.selectedColorPanel.Size = new System.Drawing.Size(23, 23);
            this.selectedColorPanel.TabIndex = 9;
            this.selectedColorPanel.BackColorChanged += new System.EventHandler(this.selectedColorPanel_BackColorChanged);
            this.selectedColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectedColorPanel_MouseClick);
            // 
            // colorSelectedLabel
            // 
            this.colorSelectedLabel.AutoSize = true;
            this.colorSelectedLabel.Location = new System.Drawing.Point(10, 74);
            this.colorSelectedLabel.Name = "colorSelectedLabel";
            this.colorSelectedLabel.Size = new System.Drawing.Size(31, 13);
            this.colorSelectedLabel.TabIndex = 8;
            this.colorSelectedLabel.Text = "Color";
            // 
            // selectedStrokeLabel
            // 
            this.selectedStrokeLabel.AutoSize = true;
            this.selectedStrokeLabel.Location = new System.Drawing.Point(10, 47);
            this.selectedStrokeLabel.Name = "selectedStrokeLabel";
            this.selectedStrokeLabel.Size = new System.Drawing.Size(38, 13);
            this.selectedStrokeLabel.TabIndex = 6;
            this.selectedStrokeLabel.Text = "Stroke";
            // 
            // selectedStrokeNumericUpDown
            // 
            this.selectedStrokeNumericUpDown.Location = new System.Drawing.Point(55, 45);
            this.selectedStrokeNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.selectedStrokeNumericUpDown.Name = "selectedStrokeNumericUpDown";
            this.selectedStrokeNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.selectedStrokeNumericUpDown.TabIndex = 7;
            this.selectedStrokeNumericUpDown.ValueChanged += new System.EventHandler(this.selectedStrokeNumericUpDown_ValueChanged);
            // 
            // selectedWidthLabel
            // 
            this.selectedWidthLabel.AutoSize = true;
            this.selectedWidthLabel.Location = new System.Drawing.Point(10, 21);
            this.selectedWidthLabel.Name = "selectedWidthLabel";
            this.selectedWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.selectedWidthLabel.TabIndex = 7;
            this.selectedWidthLabel.Text = "Width";
            // 
            // selectedWidthNnumericUpDown
            // 
            this.selectedWidthNnumericUpDown.Location = new System.Drawing.Point(55, 19);
            this.selectedWidthNnumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.selectedWidthNnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectedWidthNnumericUpDown.Name = "selectedWidthNnumericUpDown";
            this.selectedWidthNnumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.selectedWidthNnumericUpDown.TabIndex = 6;
            this.selectedWidthNnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectedWidthNnumericUpDown.ValueChanged += new System.EventHandler(this.selectedWidthNnumericUpDown_ValueChanged);
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.Controls.Add(this.sEPYLabel);
            this.locationGroupBox.Controls.Add(this.sEPXLabel);
            this.locationGroupBox.Controls.Add(this.sSPYLabel);
            this.locationGroupBox.Controls.Add(this.sSPXLabel);
            this.locationGroupBox.Controls.Add(this.selectObjectEPYMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.selectObjectSPYMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.selectObjectEPXMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.selectObjectSPXMaskedTextBox);
            this.locationGroupBox.Controls.Add(this.StartPLabel);
            this.locationGroupBox.Controls.Add(this.EndPLabel);
            this.locationGroupBox.Location = new System.Drawing.Point(6, 48);
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.Size = new System.Drawing.Size(167, 74);
            this.locationGroupBox.TabIndex = 6;
            this.locationGroupBox.TabStop = false;
            this.locationGroupBox.Text = "Location";
            // 
            // sEPYLabel
            // 
            this.sEPYLabel.AutoSize = true;
            this.sEPYLabel.Location = new System.Drawing.Point(109, 47);
            this.sEPYLabel.Name = "sEPYLabel";
            this.sEPYLabel.Size = new System.Drawing.Size(17, 13);
            this.sEPYLabel.TabIndex = 11;
            this.sEPYLabel.Text = "Y:";
            // 
            // sEPXLabel
            // 
            this.sEPXLabel.AutoSize = true;
            this.sEPXLabel.Location = new System.Drawing.Point(59, 47);
            this.sEPXLabel.Name = "sEPXLabel";
            this.sEPXLabel.Size = new System.Drawing.Size(17, 13);
            this.sEPXLabel.TabIndex = 10;
            this.sEPXLabel.Text = "X:";
            // 
            // sSPYLabel
            // 
            this.sSPYLabel.AutoSize = true;
            this.sSPYLabel.Location = new System.Drawing.Point(109, 23);
            this.sSPYLabel.Name = "sSPYLabel";
            this.sSPYLabel.Size = new System.Drawing.Size(17, 13);
            this.sSPYLabel.TabIndex = 9;
            this.sSPYLabel.Text = "Y:";
            // 
            // sSPXLabel
            // 
            this.sSPXLabel.AutoSize = true;
            this.sSPXLabel.Location = new System.Drawing.Point(59, 23);
            this.sSPXLabel.Name = "sSPXLabel";
            this.sSPXLabel.Size = new System.Drawing.Size(17, 13);
            this.sSPXLabel.TabIndex = 8;
            this.sSPXLabel.Text = "X:";
            // 
            // selectObjectEPYMaskedTextBox
            // 
            this.selectObjectEPYMaskedTextBox.Location = new System.Drawing.Point(126, 44);
            this.selectObjectEPYMaskedTextBox.Mask = "00000";
            this.selectObjectEPYMaskedTextBox.Name = "selectObjectEPYMaskedTextBox";
            this.selectObjectEPYMaskedTextBox.PromptChar = ' ';
            this.selectObjectEPYMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectEPYMaskedTextBox.TabIndex = 7;
            this.selectObjectEPYMaskedTextBox.ValidatingType = typeof(int);
            this.selectObjectEPYMaskedTextBox.TextChanged += new System.EventHandler(this.selectObjectEPYMaskedTextBox_TextChanged);
            // 
            // selectObjectSPYMaskedTextBox
            // 
            this.selectObjectSPYMaskedTextBox.Location = new System.Drawing.Point(126, 19);
            this.selectObjectSPYMaskedTextBox.Mask = "00000";
            this.selectObjectSPYMaskedTextBox.Name = "selectObjectSPYMaskedTextBox";
            this.selectObjectSPYMaskedTextBox.PromptChar = ' ';
            this.selectObjectSPYMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectSPYMaskedTextBox.TabIndex = 5;
            this.selectObjectSPYMaskedTextBox.ValidatingType = typeof(int);
            this.selectObjectSPYMaskedTextBox.TextChanged += new System.EventHandler(this.selectObjectSPYMaskedTextBox_TextChanged);
            // 
            // selectObjectEPXMaskedTextBox
            // 
            this.selectObjectEPXMaskedTextBox.Location = new System.Drawing.Point(76, 44);
            this.selectObjectEPXMaskedTextBox.Mask = "00000";
            this.selectObjectEPXMaskedTextBox.Name = "selectObjectEPXMaskedTextBox";
            this.selectObjectEPXMaskedTextBox.PromptChar = ' ';
            this.selectObjectEPXMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectEPXMaskedTextBox.TabIndex = 6;
            this.selectObjectEPXMaskedTextBox.ValidatingType = typeof(int);
            this.selectObjectEPXMaskedTextBox.TextChanged += new System.EventHandler(this.selectObjectEPXMaskedTextBox_TextChanged);
            // 
            // selectObjectSPXMaskedTextBox
            // 
            this.selectObjectSPXMaskedTextBox.Location = new System.Drawing.Point(76, 19);
            this.selectObjectSPXMaskedTextBox.Mask = "00000";
            this.selectObjectSPXMaskedTextBox.Name = "selectObjectSPXMaskedTextBox";
            this.selectObjectSPXMaskedTextBox.PromptChar = ' ';
            this.selectObjectSPXMaskedTextBox.Size = new System.Drawing.Size(31, 20);
            this.selectObjectSPXMaskedTextBox.TabIndex = 4;
            this.selectObjectSPXMaskedTextBox.ValidatingType = typeof(int);
            this.selectObjectSPXMaskedTextBox.TextChanged += new System.EventHandler(this.selectObjectSPXMaskedTextBox_TextChanged);
            // 
            // StartPLabel
            // 
            this.StartPLabel.AutoSize = true;
            this.StartPLabel.Location = new System.Drawing.Point(6, 23);
            this.StartPLabel.Name = "StartPLabel";
            this.StartPLabel.Size = new System.Drawing.Size(58, 13);
            this.StartPLabel.TabIndex = 2;
            this.StartPLabel.Text = "Start point:";
            // 
            // EndPLabel
            // 
            this.EndPLabel.AutoSize = true;
            this.EndPLabel.Location = new System.Drawing.Point(6, 47);
            this.EndPLabel.Name = "EndPLabel";
            this.EndPLabel.Size = new System.Drawing.Size(55, 13);
            this.EndPLabel.TabIndex = 3;
            this.EndPLabel.Text = "End point:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(82, 23);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(0, 13);
            this.typeLabel.TabIndex = 1;
            // 
            // objectLabel
            // 
            this.objectLabel.AutoSize = true;
            this.objectLabel.Location = new System.Drawing.Point(12, 23);
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.Size = new System.Drawing.Size(64, 13);
            this.objectLabel.TabIndex = 0;
            this.objectLabel.Text = "Object type:";
            // 
            // SelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectedObjectGroupBox);
            this.Name = "SelectionPanel";
            this.Size = new System.Drawing.Size(179, 258);
            this.selectedObjectGroupBox.ResumeLayout(false);
            this.selectedObjectGroupBox.PerformLayout();
            this.designSelectedGroupBox.ResumeLayout(false);
            this.designSelectedGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedStrokeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedWidthNnumericUpDown)).EndInit();
            this.locationGroupBox.ResumeLayout(false);
            this.locationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox selectedObjectGroupBox;
        private System.Windows.Forms.GroupBox designSelectedGroupBox;
        private System.Windows.Forms.Panel selectedBrushPanel;
        private System.Windows.Forms.Label selectedObjectBrushLabel;
        private System.Windows.Forms.Panel selectedColorPanel;
        private System.Windows.Forms.Label colorSelectedLabel;
        private System.Windows.Forms.Label selectedStrokeLabel;
        private System.Windows.Forms.NumericUpDown selectedStrokeNumericUpDown;
        private System.Windows.Forms.Label selectedWidthLabel;
        private System.Windows.Forms.NumericUpDown selectedWidthNnumericUpDown;
        private System.Windows.Forms.GroupBox locationGroupBox;
        private System.Windows.Forms.Label sEPYLabel;
        private System.Windows.Forms.Label sEPXLabel;
        private System.Windows.Forms.Label sSPYLabel;
        private System.Windows.Forms.Label sSPXLabel;
        private System.Windows.Forms.MaskedTextBox selectObjectEPYMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox selectObjectSPYMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox selectObjectEPXMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox selectObjectSPXMaskedTextBox;
        private System.Windows.Forms.Label StartPLabel;
        private System.Windows.Forms.Label EndPLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label objectLabel;
    }
}

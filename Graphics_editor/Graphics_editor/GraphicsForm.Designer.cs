namespace GraphicsEditor
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.drawGroupBox = new System.Windows.Forms.GroupBox();
            this.selectMouseButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polylineButton = new System.Windows.Forms.Button();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.selectBrushColorButton = new System.Windows.Forms.Button();
            this.selectCanvasColorButton = new System.Windows.Forms.Button();
            this.selectPenColorButton = new System.Windows.Forms.Button();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            this.penStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.penStrokeWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.thicknessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.discardButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.drawGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.penStyleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).BeginInit();
            this.SelectionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mainPictureBox.Image")));
            this.mainPictureBox.Location = new System.Drawing.Point(120, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(920, 501);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Controls.Add(this.ellipseButton);
            this.drawGroupBox.Controls.Add(this.triangleButton);
            this.drawGroupBox.Controls.Add(this.lineButton);
            this.drawGroupBox.Controls.Add(this.circleButton);
            this.drawGroupBox.Controls.Add(this.polylineButton);
            this.drawGroupBox.Location = new System.Drawing.Point(12, 12);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(102, 163);
            this.drawGroupBox.TabIndex = 1;
            this.drawGroupBox.TabStop = false;
            this.drawGroupBox.Text = "Draw";
            // 
            // selectMouseButton
            // 
            this.selectMouseButton.Location = new System.Drawing.Point(13, 19);
            this.selectMouseButton.Name = "selectMouseButton";
            this.selectMouseButton.Size = new System.Drawing.Size(75, 23);
            this.selectMouseButton.TabIndex = 6;
            this.selectMouseButton.Text = "Select";
            this.selectMouseButton.UseVisualStyleBackColor = true;
            this.selectMouseButton.Click += new System.EventHandler(this.selectMouseButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(13, 135);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // triangleButton
            // 
            this.triangleButton.Location = new System.Drawing.Point(13, 77);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(75, 23);
            this.triangleButton.TabIndex = 5;
            this.triangleButton.Text = "Triangle";
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(13, 19);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(13, 106);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 4;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polylineButton
            // 
            this.polylineButton.Location = new System.Drawing.Point(13, 48);
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.Size = new System.Drawing.Size(75, 23);
            this.polylineButton.TabIndex = 3;
            this.polylineButton.Text = "Polyline";
            this.polylineButton.UseVisualStyleBackColor = true;
            this.polylineButton.Click += new System.EventHandler(this.polylineButton_Click);
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.selectBrushColorButton);
            this.colorGroupBox.Controls.Add(this.selectCanvasColorButton);
            this.colorGroupBox.Controls.Add(this.selectPenColorButton);
            this.colorGroupBox.Location = new System.Drawing.Point(12, 181);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(102, 106);
            this.colorGroupBox.TabIndex = 2;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // selectBrushColorButton
            // 
            this.selectBrushColorButton.Location = new System.Drawing.Point(13, 77);
            this.selectBrushColorButton.Name = "selectBrushColorButton";
            this.selectBrushColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectBrushColorButton.TabIndex = 6;
            this.selectBrushColorButton.Text = "Brush";
            this.selectBrushColorButton.UseVisualStyleBackColor = true;
            this.selectBrushColorButton.Click += new System.EventHandler(this.selectBrushColorButton_Click);
            // 
            // selectCanvasColorButton
            // 
            this.selectCanvasColorButton.Location = new System.Drawing.Point(13, 48);
            this.selectCanvasColorButton.Name = "selectCanvasColorButton";
            this.selectCanvasColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectCanvasColorButton.TabIndex = 3;
            this.selectCanvasColorButton.Text = "Canvas";
            this.selectCanvasColorButton.UseVisualStyleBackColor = true;
            this.selectCanvasColorButton.Click += new System.EventHandler(this.selectCanvasColorButton_Click);
            // 
            // selectPenColorButton
            // 
            this.selectPenColorButton.Location = new System.Drawing.Point(13, 19);
            this.selectPenColorButton.Name = "selectPenColorButton";
            this.selectPenColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectPenColorButton.TabIndex = 3;
            this.selectPenColorButton.Text = "Pen";
            this.selectPenColorButton.UseVisualStyleBackColor = true;
            this.selectPenColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // clearCanvasButton
            // 
            this.clearCanvasButton.Location = new System.Drawing.Point(25, 490);
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.Size = new System.Drawing.Size(75, 23);
            this.clearCanvasButton.TabIndex = 3;
            this.clearCanvasButton.Text = "Clear";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            this.clearCanvasButton.Click += new System.EventHandler(this.clearCanvasButton_Click);
            // 
            // penStyleGroupBox
            // 
            this.penStyleGroupBox.Controls.Add(this.label1);
            this.penStyleGroupBox.Controls.Add(this.penStrokeWidthNumericUpDown);
            this.penStyleGroupBox.Controls.Add(this.widthLabel);
            this.penStyleGroupBox.Controls.Add(this.thicknessNumericUpDown);
            this.penStyleGroupBox.Location = new System.Drawing.Point(12, 293);
            this.penStyleGroupBox.Name = "penStyleGroupBox";
            this.penStyleGroupBox.Size = new System.Drawing.Size(102, 80);
            this.penStyleGroupBox.TabIndex = 5;
            this.penStyleGroupBox.TabStop = false;
            this.penStyleGroupBox.Text = "Pen style";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stroke";
            // 
            // penStrokeWidthNumericUpDown
            // 
            this.penStrokeWidthNumericUpDown.Location = new System.Drawing.Point(55, 45);
            this.penStrokeWidthNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.penStrokeWidthNumericUpDown.Name = "penStrokeWidthNumericUpDown";
            this.penStrokeWidthNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.penStrokeWidthNumericUpDown.TabIndex = 7;
            this.penStrokeWidthNumericUpDown.ValueChanged += new System.EventHandler(this.penStrokeWidthNumericUpDown_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(10, 21);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 7;
            this.widthLabel.Text = "Width";
            // 
            // thicknessNumericUpDown
            // 
            this.thicknessNumericUpDown.Location = new System.Drawing.Point(55, 19);
            this.thicknessNumericUpDown.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Name = "thicknessNumericUpDown";
            this.thicknessNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.thicknessNumericUpDown.TabIndex = 6;
            this.thicknessNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessNumericUpDown.ValueChanged += new System.EventHandler(this.thicknessNumericUpDown_ValueChanged);
            // 
            // SelectionGroupBox
            // 
            this.SelectionGroupBox.Controls.Add(this.discardButton);
            this.SelectionGroupBox.Controls.Add(this.selectMouseButton);
            this.SelectionGroupBox.Location = new System.Drawing.Point(12, 379);
            this.SelectionGroupBox.Name = "SelectionGroupBox";
            this.SelectionGroupBox.Size = new System.Drawing.Size(102, 77);
            this.SelectionGroupBox.TabIndex = 6;
            this.SelectionGroupBox.TabStop = false;
            this.SelectionGroupBox.Text = "Selection";
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(13, 48);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 23);
            this.discardButton.TabIndex = 7;
            this.discardButton.Text = "Discard all";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 525);
            this.Controls.Add(this.SelectionGroupBox);
            this.Controls.Add(this.penStyleGroupBox);
            this.Controls.Add(this.clearCanvasButton);
            this.Controls.Add(this.colorGroupBox);
            this.Controls.Add(this.drawGroupBox);
            this.Controls.Add(this.mainPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Graphics editor [v0.2]";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.drawGroupBox.ResumeLayout(false);
            this.colorGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).EndInit();
            this.SelectionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.GroupBox drawGroupBox;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button polylineButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Button selectPenColorButton;
        private System.Windows.Forms.Button selectCanvasColorButton;
        private System.Windows.Forms.Button clearCanvasButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.GroupBox penStyleGroupBox;
        private System.Windows.Forms.NumericUpDown thicknessNumericUpDown;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown penStrokeWidthNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectBrushColorButton;
        private System.Windows.Forms.Button selectMouseButton;
        private System.Windows.Forms.GroupBox SelectionGroupBox;
        private System.Windows.Forms.Button discardButton;
    }
}


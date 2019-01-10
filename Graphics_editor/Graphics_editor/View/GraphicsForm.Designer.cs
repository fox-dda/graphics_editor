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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer refreshCanvasTimer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.drawGroupBox = new System.Windows.Forms.GroupBox();
            this.polygonButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polylineButton = new System.Windows.Forms.Button();
            this.selectMouseButton = new System.Windows.Forms.Button();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.brushColorpanel = new System.Windows.Forms.Panel();
            this.canvasColorpanel = new System.Windows.Forms.Panel();
            this.penColorpanel = new System.Windows.Forms.Panel();
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
            this.canvasGroupBox = new System.Windows.Forms.GroupBox();
            this.leftGroupBox = new System.Windows.Forms.GroupBox();
            this.rightGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centreGroupBox = new System.Windows.Forms.GroupBox();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            refreshCanvasTimer = new System.Windows.Forms.Timer(this.components);
            this.drawGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.penStyleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).BeginInit();
            this.SelectionGroupBox.SuspendLayout();
            this.canvasGroupBox.SuspendLayout();
            this.leftGroupBox.SuspendLayout();
            this.rightGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.centreGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshCanvasTimer
            // 
            refreshCanvasTimer.Enabled = true;
            refreshCanvasTimer.Interval = 500;
            refreshCanvasTimer.Tick += new System.EventHandler(this.refreshCanvasTimer_Tick);
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Controls.Add(this.polygonButton);
            this.drawGroupBox.Controls.Add(this.ellipseButton);
            this.drawGroupBox.Controls.Add(this.lineButton);
            this.drawGroupBox.Controls.Add(this.circleButton);
            this.drawGroupBox.Controls.Add(this.polylineButton);
            this.drawGroupBox.Location = new System.Drawing.Point(6, 12);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(133, 165);
            this.drawGroupBox.TabIndex = 1;
            this.drawGroupBox.TabStop = false;
            this.drawGroupBox.Text = "Draw";
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(13, 135);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(75, 23);
            this.polygonButton.TabIndex = 7;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(13, 106);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
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
            this.circleButton.Location = new System.Drawing.Point(13, 77);
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
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.brushColorpanel);
            this.colorGroupBox.Controls.Add(this.canvasColorpanel);
            this.colorGroupBox.Controls.Add(this.penColorpanel);
            this.colorGroupBox.Controls.Add(this.selectBrushColorButton);
            this.colorGroupBox.Controls.Add(this.selectCanvasColorButton);
            this.colorGroupBox.Controls.Add(this.selectPenColorButton);
            this.colorGroupBox.Location = new System.Drawing.Point(6, 269);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(133, 106);
            this.colorGroupBox.TabIndex = 2;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // brushColorpanel
            // 
            this.brushColorpanel.BackColor = System.Drawing.Color.White;
            this.brushColorpanel.Location = new System.Drawing.Point(94, 77);
            this.brushColorpanel.Name = "brushColorpanel";
            this.brushColorpanel.Size = new System.Drawing.Size(23, 23);
            this.brushColorpanel.TabIndex = 9;
            // 
            // canvasColorpanel
            // 
            this.canvasColorpanel.BackColor = System.Drawing.Color.White;
            this.canvasColorpanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.canvasColorpanel.Location = new System.Drawing.Point(94, 48);
            this.canvasColorpanel.Name = "canvasColorpanel";
            this.canvasColorpanel.Size = new System.Drawing.Size(23, 23);
            this.canvasColorpanel.TabIndex = 8;
            // 
            // penColorpanel
            // 
            this.penColorpanel.BackColor = System.Drawing.Color.Black;
            this.penColorpanel.Location = new System.Drawing.Point(94, 19);
            this.penColorpanel.Name = "penColorpanel";
            this.penColorpanel.Size = new System.Drawing.Size(23, 23);
            this.penColorpanel.TabIndex = 7;
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
            this.clearCanvasButton.Location = new System.Drawing.Point(13, 19);
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
            this.penStyleGroupBox.Location = new System.Drawing.Point(6, 183);
            this.penStyleGroupBox.Name = "penStyleGroupBox";
            this.penStyleGroupBox.Size = new System.Drawing.Size(133, 80);
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
            this.SelectionGroupBox.Location = new System.Drawing.Point(12, 281);
            this.SelectionGroupBox.Name = "SelectionGroupBox";
            this.SelectionGroupBox.Size = new System.Drawing.Size(167, 79);
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
            // canvasGroupBox
            // 
            this.canvasGroupBox.Controls.Add(this.clearCanvasButton);
            this.canvasGroupBox.Location = new System.Drawing.Point(12, 381);
            this.canvasGroupBox.Name = "canvasGroupBox";
            this.canvasGroupBox.Size = new System.Drawing.Size(127, 46);
            this.canvasGroupBox.TabIndex = 8;
            this.canvasGroupBox.TabStop = false;
            this.canvasGroupBox.Text = "Canvas";
            // 
            // leftGroupBox
            // 
            this.leftGroupBox.Controls.Add(this.drawGroupBox);
            this.leftGroupBox.Controls.Add(this.canvasGroupBox);
            this.leftGroupBox.Controls.Add(this.penStyleGroupBox);
            this.leftGroupBox.Controls.Add(this.colorGroupBox);
            this.leftGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftGroupBox.Location = new System.Drawing.Point(0, 24);
            this.leftGroupBox.Name = "leftGroupBox";
            this.leftGroupBox.Size = new System.Drawing.Size(158, 537);
            this.leftGroupBox.TabIndex = 9;
            this.leftGroupBox.TabStop = false;
            // 
            // rightGroupBox
            // 
            this.rightGroupBox.Controls.Add(this.SelectionGroupBox);
            this.rightGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightGroupBox.Location = new System.Drawing.Point(861, 24);
            this.rightGroupBox.Name = "rightGroupBox";
            this.rightGroupBox.Size = new System.Drawing.Size(191, 537);
            this.rightGroupBox.TabIndex = 10;
            this.rightGroupBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "New...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Open";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // centreGroupBox
            // 
            this.centreGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centreGroupBox.Controls.Add(this.mainPictureBox);
            this.centreGroupBox.Location = new System.Drawing.Point(158, 24);
            this.centreGroupBox.Name = "centreGroupBox";
            this.centreGroupBox.Size = new System.Drawing.Size(703, 537);
            this.centreGroupBox.TabIndex = 12;
            this.centreGroupBox.TabStop = false;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.White;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(3, 16);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(697, 518);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown_1);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove_1);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 561);
            this.Controls.Add(this.centreGroupBox);
            this.Controls.Add(this.rightGroupBox);
            this.Controls.Add(this.leftGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Graphics editor [v0.4]";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.drawGroupBox.ResumeLayout(false);
            this.colorGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).EndInit();
            this.SelectionGroupBox.ResumeLayout(false);
            this.canvasGroupBox.ResumeLayout(false);
            this.leftGroupBox.ResumeLayout(false);
            this.rightGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.centreGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox drawGroupBox;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button polylineButton;
        private System.Windows.Forms.Button circleButton;
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
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Panel brushColorpanel;
        private System.Windows.Forms.Panel canvasColorpanel;
        private System.Windows.Forms.Panel penColorpanel;
        private System.Windows.Forms.GroupBox canvasGroupBox;
        private System.Windows.Forms.GroupBox leftGroupBox;
        private System.Windows.Forms.GroupBox rightGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox centreGroupBox;
        private System.Windows.Forms.PictureBox mainPictureBox;
    }
}


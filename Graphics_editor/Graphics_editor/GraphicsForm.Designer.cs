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
            this.triangleButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.polylineButton = new System.Windows.Forms.Button();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.selectCanvasColorButton = new System.Windows.Forms.Button();
            this.selectPenColorButton = new System.Windows.Forms.Button();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.drawGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
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
            this.mainPictureBox.Size = new System.Drawing.Size(725, 337);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Controls.Add(this.triangleButton);
            this.drawGroupBox.Controls.Add(this.lineButton);
            this.drawGroupBox.Controls.Add(this.circleButton);
            this.drawGroupBox.Controls.Add(this.polylineButton);
            this.drawGroupBox.Location = new System.Drawing.Point(12, 12);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(102, 144);
            this.drawGroupBox.TabIndex = 1;
            this.drawGroupBox.TabStop = false;
            this.drawGroupBox.Text = "Draw";
            // 
            // triangleButton
            // 
            this.triangleButton.Location = new System.Drawing.Point(6, 106);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(75, 23);
            this.triangleButton.TabIndex = 5;
            this.triangleButton.Text = "Triangle";
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(6, 19);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(6, 77);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 4;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // polylineButton
            // 
            this.polylineButton.Location = new System.Drawing.Point(6, 48);
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.Size = new System.Drawing.Size(75, 23);
            this.polylineButton.TabIndex = 3;
            this.polylineButton.Text = "Polyline";
            this.polylineButton.UseVisualStyleBackColor = true;
            this.polylineButton.Click += new System.EventHandler(this.polylineButton_Click);
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.selectCanvasColorButton);
            this.colorGroupBox.Controls.Add(this.selectPenColorButton);
            this.colorGroupBox.Location = new System.Drawing.Point(12, 162);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(102, 83);
            this.colorGroupBox.TabIndex = 2;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // selectCanvasColorButton
            // 
            this.selectCanvasColorButton.Location = new System.Drawing.Point(6, 48);
            this.selectCanvasColorButton.Name = "selectCanvasColorButton";
            this.selectCanvasColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectCanvasColorButton.TabIndex = 3;
            this.selectCanvasColorButton.Text = "Canvas";
            this.selectCanvasColorButton.UseVisualStyleBackColor = true;
            this.selectCanvasColorButton.Click += new System.EventHandler(this.selectCanvasColorButton_Click);
            // 
            // selectPenColorButton
            // 
            this.selectPenColorButton.Location = new System.Drawing.Point(6, 19);
            this.selectPenColorButton.Name = "selectPenColorButton";
            this.selectPenColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectPenColorButton.TabIndex = 3;
            this.selectPenColorButton.Text = "Pen";
            this.selectPenColorButton.UseVisualStyleBackColor = true;
            this.selectPenColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // clearCanvasButton
            // 
            this.clearCanvasButton.Location = new System.Drawing.Point(18, 326);
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.Size = new System.Drawing.Size(75, 23);
            this.clearCanvasButton.TabIndex = 3;
            this.clearCanvasButton.Text = "Clear";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            this.clearCanvasButton.Click += new System.EventHandler(this.clearCanvasButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 361);
            this.Controls.Add(this.clearCanvasButton);
            this.Controls.Add(this.colorGroupBox);
            this.Controls.Add(this.drawGroupBox);
            this.Controls.Add(this.mainPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Graphics editor [v0.2]";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.drawGroupBox.ResumeLayout(false);
            this.colorGroupBox.ResumeLayout(false);
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
    }
}


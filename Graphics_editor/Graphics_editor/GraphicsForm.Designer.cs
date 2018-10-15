﻿namespace Graphics_editor
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
            this.triangleRadioButton = new System.Windows.Forms.RadioButton();
            this.circleRadioButton = new System.Windows.Forms.RadioButton();
            this.polylineRadioButton = new System.Windows.Forms.RadioButton();
            this.lineRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.drawGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mainPictureBox.Image")));
            this.mainPictureBox.Location = new System.Drawing.Point(219, 12);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(846, 459);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseLeave += new System.EventHandler(this.mainPictureBox_MouseLeave);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Controls.Add(this.triangleRadioButton);
            this.drawGroupBox.Controls.Add(this.circleRadioButton);
            this.drawGroupBox.Controls.Add(this.polylineRadioButton);
            this.drawGroupBox.Controls.Add(this.lineRadioButton);
            this.drawGroupBox.Location = new System.Drawing.Point(12, 12);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(200, 121);
            this.drawGroupBox.TabIndex = 1;
            this.drawGroupBox.TabStop = false;
            // 
            // triangleRadioButton
            // 
            this.triangleRadioButton.AutoSize = true;
            this.triangleRadioButton.Location = new System.Drawing.Point(6, 88);
            this.triangleRadioButton.Name = "triangleRadioButton";
            this.triangleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.triangleRadioButton.TabIndex = 4;
            this.triangleRadioButton.TabStop = true;
            this.triangleRadioButton.Text = "Triangle";
            this.triangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // circleRadioButton
            // 
            this.circleRadioButton.AutoSize = true;
            this.circleRadioButton.Location = new System.Drawing.Point(6, 65);
            this.circleRadioButton.Name = "circleRadioButton";
            this.circleRadioButton.Size = new System.Drawing.Size(51, 17);
            this.circleRadioButton.TabIndex = 3;
            this.circleRadioButton.TabStop = true;
            this.circleRadioButton.Text = "Circle";
            this.circleRadioButton.UseVisualStyleBackColor = true;
            // 
            // polylineRadioButton
            // 
            this.polylineRadioButton.AutoSize = true;
            this.polylineRadioButton.Location = new System.Drawing.Point(6, 42);
            this.polylineRadioButton.Name = "polylineRadioButton";
            this.polylineRadioButton.Size = new System.Drawing.Size(61, 17);
            this.polylineRadioButton.TabIndex = 2;
            this.polylineRadioButton.TabStop = true;
            this.polylineRadioButton.Text = "Polyline";
            this.polylineRadioButton.UseVisualStyleBackColor = true;
            this.polylineRadioButton.CheckedChanged += new System.EventHandler(this.polylineRadioButton_CheckedChanged);
            // 
            // lineRadioButton
            // 
            this.lineRadioButton.AutoSize = true;
            this.lineRadioButton.Location = new System.Drawing.Point(6, 19);
            this.lineRadioButton.Name = "lineRadioButton";
            this.lineRadioButton.Size = new System.Drawing.Size(45, 17);
            this.lineRadioButton.TabIndex = 2;
            this.lineRadioButton.TabStop = true;
            this.lineRadioButton.Text = "Line";
            this.lineRadioButton.UseVisualStyleBackColor = true;
            this.lineRadioButton.CheckedChanged += new System.EventHandler(this.lineRadioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 483);
            this.Controls.Add(this.drawGroupBox);
            this.Controls.Add(this.mainPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.Text = "Graphics editor";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.drawGroupBox.ResumeLayout(false);
            this.drawGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.GroupBox drawGroupBox;
        private System.Windows.Forms.RadioButton lineRadioButton;
        private System.Windows.Forms.RadioButton polylineRadioButton;
        private System.Windows.Forms.RadioButton circleRadioButton;
        private System.Windows.Forms.RadioButton triangleRadioButton;
    }
}


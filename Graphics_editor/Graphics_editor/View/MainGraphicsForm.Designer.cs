namespace Graphics_editor.View
{
    partial class MainGraphicsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGraphicsForm));
            this.GroupBoxLeft = new System.Windows.Forms.GroupBox();
            this.canvasGroupBox = new System.Windows.Forms.GroupBox();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.brushColorpanel = new System.Windows.Forms.Panel();
            this.canvasColorpanel = new System.Windows.Forms.Panel();
            this.penColorpanel = new System.Windows.Forms.Panel();
            this.selectBrushColorButton = new System.Windows.Forms.Button();
            this.selectPenColorButton = new System.Windows.Forms.Button();
            this.selectCanvasColorButton = new System.Windows.Forms.Button();
            this.penStyleGroupBox = new System.Windows.Forms.GroupBox();
            this.strokeLabel = new System.Windows.Forms.Label();
            this.penStrokeWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thicknessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.drawGroupBox = new System.Windows.Forms.GroupBox();
            this.polygonButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.polylineButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.groupBoxRight = new System.Windows.Forms.GroupBox();
            this.selectionGroupBox = new System.Windows.Forms.GroupBox();
            this.discardButton = new System.Windows.Forms.Button();
            this.selectMouseButton = new System.Windows.Forms.Button();
            this.GroupBoxLeft.SuspendLayout();
            this.canvasGroupBox.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.penStyleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).BeginInit();
            this.drawGroupBox.SuspendLayout();
            this.groupBoxRight.SuspendLayout();
            this.selectionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxLeft
            // 
            this.GroupBoxLeft.Controls.Add(this.canvasGroupBox);
            this.GroupBoxLeft.Controls.Add(this.colorGroupBox);
            this.GroupBoxLeft.Controls.Add(this.penStyleGroupBox);
            this.GroupBoxLeft.Controls.Add(this.drawGroupBox);
            this.GroupBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.GroupBoxLeft.Name = "GroupBoxLeft";
            this.GroupBoxLeft.Size = new System.Drawing.Size(140, 517);
            this.GroupBoxLeft.TabIndex = 0;
            this.GroupBoxLeft.TabStop = false;
            // 
            // canvasGroupBox
            // 
            this.canvasGroupBox.Controls.Add(this.clearCanvasButton);
            this.canvasGroupBox.Location = new System.Drawing.Point(9, 408);
            this.canvasGroupBox.Name = "canvasGroupBox";
            this.canvasGroupBox.Size = new System.Drawing.Size(126, 51);
            this.canvasGroupBox.TabIndex = 2;
            this.canvasGroupBox.TabStop = false;
            this.canvasGroupBox.Text = "Canvas";
            // 
            // clearCanvasButton
            // 
            this.clearCanvasButton.Location = new System.Drawing.Point(6, 19);
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.Size = new System.Drawing.Size(75, 23);
            this.clearCanvasButton.TabIndex = 2;
            this.clearCanvasButton.Text = "Clear";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.brushColorpanel);
            this.colorGroupBox.Controls.Add(this.canvasColorpanel);
            this.colorGroupBox.Controls.Add(this.penColorpanel);
            this.colorGroupBox.Controls.Add(this.selectBrushColorButton);
            this.colorGroupBox.Controls.Add(this.selectPenColorButton);
            this.colorGroupBox.Controls.Add(this.selectCanvasColorButton);
            this.colorGroupBox.Location = new System.Drawing.Point(6, 297);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(129, 105);
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
            this.brushColorpanel.TabIndex = 5;
            // 
            // canvasColorpanel
            // 
            this.canvasColorpanel.BackColor = System.Drawing.Color.White;
            this.canvasColorpanel.Location = new System.Drawing.Point(94, 48);
            this.canvasColorpanel.Name = "canvasColorpanel";
            this.canvasColorpanel.Size = new System.Drawing.Size(23, 23);
            this.canvasColorpanel.TabIndex = 4;
            // 
            // penColorpanel
            // 
            this.penColorpanel.BackColor = System.Drawing.Color.Black;
            this.penColorpanel.Location = new System.Drawing.Point(94, 19);
            this.penColorpanel.Name = "penColorpanel";
            this.penColorpanel.Size = new System.Drawing.Size(23, 23);
            this.penColorpanel.TabIndex = 2;
            // 
            // selectBrushColorButton
            // 
            this.selectBrushColorButton.Location = new System.Drawing.Point(9, 77);
            this.selectBrushColorButton.Name = "selectBrushColorButton";
            this.selectBrushColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectBrushColorButton.TabIndex = 3;
            this.selectBrushColorButton.Text = "Brush";
            this.selectBrushColorButton.UseVisualStyleBackColor = true;
            // 
            // selectPenColorButton
            // 
            this.selectPenColorButton.Location = new System.Drawing.Point(9, 19);
            this.selectPenColorButton.Name = "selectPenColorButton";
            this.selectPenColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectPenColorButton.TabIndex = 3;
            this.selectPenColorButton.Text = "Pen";
            this.selectPenColorButton.UseVisualStyleBackColor = true;
            // 
            // selectCanvasColorButton
            // 
            this.selectCanvasColorButton.Location = new System.Drawing.Point(9, 48);
            this.selectCanvasColorButton.Name = "selectCanvasColorButton";
            this.selectCanvasColorButton.Size = new System.Drawing.Size(75, 23);
            this.selectCanvasColorButton.TabIndex = 2;
            this.selectCanvasColorButton.Text = "Canvas";
            this.selectCanvasColorButton.UseVisualStyleBackColor = true;
            // 
            // penStyleGroupBox
            // 
            this.penStyleGroupBox.Controls.Add(this.strokeLabel);
            this.penStyleGroupBox.Controls.Add(this.penStrokeWidthNumericUpDown);
            this.penStyleGroupBox.Controls.Add(this.thicknessNumericUpDown);
            this.penStyleGroupBox.Controls.Add(this.widthLabel);
            this.penStyleGroupBox.Location = new System.Drawing.Point(6, 191);
            this.penStyleGroupBox.Name = "penStyleGroupBox";
            this.penStyleGroupBox.Size = new System.Drawing.Size(129, 100);
            this.penStyleGroupBox.TabIndex = 2;
            this.penStyleGroupBox.TabStop = false;
            this.penStyleGroupBox.Text = "Pen style";
            // 
            // strokeLabel
            // 
            this.strokeLabel.AutoSize = true;
            this.strokeLabel.Location = new System.Drawing.Point(6, 55);
            this.strokeLabel.Name = "strokeLabel";
            this.strokeLabel.Size = new System.Drawing.Size(38, 13);
            this.strokeLabel.TabIndex = 2;
            this.strokeLabel.Text = "Stroke";
            // 
            // penStrokeWidthNumericUpDown
            // 
            this.penStrokeWidthNumericUpDown.Location = new System.Drawing.Point(60, 53);
            this.penStrokeWidthNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.penStrokeWidthNumericUpDown.Name = "penStrokeWidthNumericUpDown";
            this.penStrokeWidthNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.penStrokeWidthNumericUpDown.TabIndex = 2;
            // 
            // thicknessNumericUpDown
            // 
            this.thicknessNumericUpDown.Location = new System.Drawing.Point(60, 27);
            this.thicknessNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Name = "thicknessNumericUpDown";
            this.thicknessNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.thicknessNumericUpDown.TabIndex = 1;
            this.thicknessNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(6, 29);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width";
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Controls.Add(this.polygonButton);
            this.drawGroupBox.Controls.Add(this.lineButton);
            this.drawGroupBox.Controls.Add(this.ellipseButton);
            this.drawGroupBox.Controls.Add(this.polylineButton);
            this.drawGroupBox.Controls.Add(this.circleButton);
            this.drawGroupBox.Location = new System.Drawing.Point(6, 19);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(129, 166);
            this.drawGroupBox.TabIndex = 2;
            this.drawGroupBox.TabStop = false;
            this.drawGroupBox.Text = "Draw";
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(6, 135);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(75, 23);
            this.polygonButton.TabIndex = 5;
            this.polygonButton.Text = "Polygon";
            this.polygonButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(6, 19);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = true;
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(6, 106);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(75, 23);
            this.ellipseButton.TabIndex = 4;
            this.ellipseButton.Text = "Ellipse";
            this.ellipseButton.UseVisualStyleBackColor = true;
            // 
            // polylineButton
            // 
            this.polylineButton.Location = new System.Drawing.Point(6, 48);
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.Size = new System.Drawing.Size(75, 23);
            this.polylineButton.TabIndex = 2;
            this.polylineButton.Text = "Polyline";
            this.polylineButton.UseVisualStyleBackColor = true;
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(6, 77);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 3;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            // 
            // groupBoxRight
            // 
            this.groupBoxRight.Controls.Add(this.selectionGroupBox);
            this.groupBoxRight.Location = new System.Drawing.Point(730, 0);
            this.groupBoxRight.Name = "groupBoxRight";
            this.groupBoxRight.Size = new System.Drawing.Size(200, 517);
            this.groupBoxRight.TabIndex = 1;
            this.groupBoxRight.TabStop = false;
            // 
            // selectionGroupBox
            // 
            this.selectionGroupBox.Controls.Add(this.discardButton);
            this.selectionGroupBox.Controls.Add(this.selectMouseButton);
            this.selectionGroupBox.Location = new System.Drawing.Point(6, 275);
            this.selectionGroupBox.Name = "selectionGroupBox";
            this.selectionGroupBox.Size = new System.Drawing.Size(179, 84);
            this.selectionGroupBox.TabIndex = 1;
            this.selectionGroupBox.TabStop = false;
            this.selectionGroupBox.Text = "Selection";
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(6, 48);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 23);
            this.discardButton.TabIndex = 1;
            this.discardButton.Text = "Discard al";
            this.discardButton.UseVisualStyleBackColor = true;
            // 
            // selectMouseButton
            // 
            this.selectMouseButton.Location = new System.Drawing.Point(6, 19);
            this.selectMouseButton.Name = "selectMouseButton";
            this.selectMouseButton.Size = new System.Drawing.Size(75, 23);
            this.selectMouseButton.TabIndex = 0;
            this.selectMouseButton.Text = "Select";
            this.selectMouseButton.UseVisualStyleBackColor = true;
            // 
            // MainGraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 517);
            this.Controls.Add(this.groupBoxRight);
            this.Controls.Add(this.GroupBoxLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGraphicsForm";
            this.Text = "Graphics editor [v0.4]";
            this.GroupBoxLeft.ResumeLayout(false);
            this.canvasGroupBox.ResumeLayout(false);
            this.colorGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.ResumeLayout(false);
            this.penStyleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penStrokeWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).EndInit();
            this.drawGroupBox.ResumeLayout(false);
            this.groupBoxRight.ResumeLayout(false);
            this.selectionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxLeft;
        private System.Windows.Forms.GroupBox groupBoxRight;
        private System.Windows.Forms.GroupBox drawGroupBox;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button polylineButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.GroupBox penStyleGroupBox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown thicknessNumericUpDown;
        private System.Windows.Forms.NumericUpDown penStrokeWidthNumericUpDown;
        private System.Windows.Forms.Label strokeLabel;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Button selectBrushColorButton;
        private System.Windows.Forms.Button selectPenColorButton;
        private System.Windows.Forms.Button selectCanvasColorButton;
        private System.Windows.Forms.Panel penColorpanel;
        private System.Windows.Forms.Panel canvasColorpanel;
        private System.Windows.Forms.Panel brushColorpanel;
        private System.Windows.Forms.GroupBox canvasGroupBox;
        private System.Windows.Forms.Button clearCanvasButton;
        private System.Windows.Forms.GroupBox selectionGroupBox;
        private System.Windows.Forms.Button selectMouseButton;
        private System.Windows.Forms.Button discardButton;
    }
}
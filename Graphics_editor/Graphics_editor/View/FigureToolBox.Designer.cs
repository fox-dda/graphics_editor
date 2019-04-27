namespace GraphicsEditor.View
{
    partial class FigureToolBox
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
            this.toolGroupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // toolGroupBox
            // 
            this.toolGroupBox.AutoSize = true;
            this.toolGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolGroupBox.Location = new System.Drawing.Point(0, 0);
            this.toolGroupBox.Name = "toolGroupBox";
            this.toolGroupBox.Size = new System.Drawing.Size(133, 175);
            this.toolGroupBox.TabIndex = 0;
            this.toolGroupBox.TabStop = false;
            this.toolGroupBox.Text = "Figures";
            // 
            // FigureToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.toolGroupBox);
            this.Name = "FigureToolBox";
            this.Size = new System.Drawing.Size(133, 175);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox toolGroupBox;
    }
}

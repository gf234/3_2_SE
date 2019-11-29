namespace WindowsFormsApp1
{
    partial class PathForm
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
            this.startRowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spotTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startRowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startColumnNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startRowNumericUpDown
            // 
            this.startRowNumericUpDown.Location = new System.Drawing.Point(129, 43);
            this.startRowNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.startRowNumericUpDown.Name = "startRowNumericUpDown";
            this.startRowNumericUpDown.Size = new System.Drawing.Size(120, 25);
            this.startRowNumericUpDown.TabIndex = 0;
            // 
            // startColumnNumericUpDown
            // 
            this.startColumnNumericUpDown.Location = new System.Drawing.Point(409, 45);
            this.startColumnNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.startColumnNumericUpDown.Name = "startColumnNumericUpDown";
            this.startColumnNumericUpDown.Size = new System.Drawing.Size(120, 25);
            this.startColumnNumericUpDown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "시작 행 좌표";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "시작 열 좌표";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "주요지점 좌표 (띄어 쓰기로 구분)";
            // 
            // spotTextBox
            // 
            this.spotTextBox.Location = new System.Drawing.Point(252, 93);
            this.spotTextBox.Name = "spotTextBox";
            this.spotTextBox.Size = new System.Drawing.Size(276, 25);
            this.spotTextBox.TabIndex = 5;
            this.spotTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpotTextBox_KeyPress);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(399, 144);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(89, 35);
            this.enterButton.TabIndex = 6;
            this.enterButton.Text = "입력";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // PathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 200);
            this.ControlBox = false;
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.spotTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startColumnNumericUpDown);
            this.Controls.Add(this.startRowNumericUpDown);
            this.Name = "PathForm";
            this.Text = "PathForm";
            ((System.ComponentModel.ISupportInitialize)(this.startRowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startColumnNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown startRowNumericUpDown;
        private System.Windows.Forms.NumericUpDown startColumnNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox spotTextBox;
        private System.Windows.Forms.Button enterButton;
    }
}
namespace WindowsFormsApp1
{
    partial class MapForm
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
            this.columnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.hazardPositionBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // columnNumericUpDown
            // 
            this.columnNumericUpDown.Location = new System.Drawing.Point(435, 46);
            this.columnNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.columnNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.columnNumericUpDown.Name = "columnNumericUpDown";
            this.columnNumericUpDown.Size = new System.Drawing.Size(120, 25);
            this.columnNumericUpDown.TabIndex = 0;
            this.columnNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // rowNumericUpDown
            // 
            this.rowNumericUpDown.Location = new System.Drawing.Point(122, 46);
            this.rowNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rowNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.rowNumericUpDown.Name = "rowNumericUpDown";
            this.rowNumericUpDown.Size = new System.Drawing.Size(120, 25);
            this.rowNumericUpDown.TabIndex = 1;
            this.rowNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "행 크기";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "열 크기";
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(448, 178);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(107, 35);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "입력";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "위험지역 좌표 ( 띄어쓰기로 구분 )";
            // 
            // hazardPositionBox
            // 
            this.hazardPositionBox.Location = new System.Drawing.Point(257, 120);
            this.hazardPositionBox.Name = "hazardPositionBox";
            this.hazardPositionBox.Size = new System.Drawing.Size(298, 25);
            this.hazardPositionBox.TabIndex = 6;
            this.hazardPositionBox.Text = "0 0";
            this.hazardPositionBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HazardPositionBox_KeyPress);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 233);
            this.ControlBox = false;
            this.Controls.Add(this.hazardPositionBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rowNumericUpDown);
            this.Controls.Add(this.columnNumericUpDown);
            this.Name = "MapForm";
            this.Text = "MapForm";
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown columnNumericUpDown;
        private System.Windows.Forms.NumericUpDown rowNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hazardPositionBox;
    }
}
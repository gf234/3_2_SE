namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartBtn = new System.Windows.Forms.Button();
            this.HandlingAMap = new System.Windows.Forms.Button();
            this.PlanningAPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(563, 73);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(199, 154);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // HandlingAMap
            // 
            this.HandlingAMap.Location = new System.Drawing.Point(49, 73);
            this.HandlingAMap.Name = "HandlingAMap";
            this.HandlingAMap.Size = new System.Drawing.Size(199, 154);
            this.HandlingAMap.TabIndex = 2;
            this.HandlingAMap.Text = "Map";
            this.HandlingAMap.UseVisualStyleBackColor = true;
            // 
            // PlanningAPath
            // 
            this.PlanningAPath.Location = new System.Drawing.Point(307, 73);
            this.PlanningAPath.Name = "PlanningAPath";
            this.PlanningAPath.Size = new System.Drawing.Size(199, 154);
            this.PlanningAPath.TabIndex = 3;
            this.PlanningAPath.Text = "Path";
            this.PlanningAPath.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlanningAPath);
            this.Controls.Add(this.HandlingAMap);
            this.Controls.Add(this.StartBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button HandlingAMap;
        private System.Windows.Forms.Button PlanningAPath;
    }
}


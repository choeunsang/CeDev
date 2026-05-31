namespace CeDev.DataMng
{
    partial class DataUpdate
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
            btnRealInfoUpdate = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label2 = new Label();
            btnRentInfoUpdate = new Button();
            SuspendLayout();
            // 
            // btnRealInfoUpdate
            // 
            btnRealInfoUpdate.Location = new Point(296, 49);
            btnRealInfoUpdate.Name = "btnRealInfoUpdate";
            btnRealInfoUpdate.Size = new Size(179, 38);
            btnRealInfoUpdate.TabIndex = 0;
            btnRealInfoUpdate.Text = "업데이트";
            btnRealInfoUpdate.UseVisualStyleBackColor = true;
            btnRealInfoUpdate.Click += btnRealInfoUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 61);
            label1.Name = "label1";
            label1.Size = new Size(175, 15);
            label1.TabIndex = 1;
            label1.Text = "부동산 매매 실거래가 업데이트";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(500, 61);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(254, 15);
            progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(500, 124);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(254, 15);
            progressBar2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 124);
            label2.Name = "label2";
            label2.Size = new Size(187, 15);
            label2.TabIndex = 4;
            label2.Text = "부동산 전월세 실거래가 업데이트";
            // 
            // btnRentInfoUpdate
            // 
            btnRentInfoUpdate.Location = new Point(296, 112);
            btnRentInfoUpdate.Name = "btnRentInfoUpdate";
            btnRentInfoUpdate.Size = new Size(179, 38);
            btnRentInfoUpdate.TabIndex = 3;
            btnRentInfoUpdate.Text = "업데이트";
            btnRentInfoUpdate.UseVisualStyleBackColor = true;
            btnRentInfoUpdate.Click += btnRentInfoUpdate_Click;
            // 
            // DataUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar2);
            Controls.Add(label2);
            Controls.Add(btnRentInfoUpdate);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(btnRealInfoUpdate);
            Name = "DataUpdate";
            Text = "자료 업데이트";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRealInfoUpdate;
        private Label label1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label2;
        private Button btnRentInfoUpdate;
    }
}
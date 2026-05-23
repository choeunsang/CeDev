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
            btnUpdate = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(296, 49);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(179, 38);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "업데이트";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 61);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 1;
            label1.Text = "부동산 실거래가 업데이트";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(500, 61);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(254, 15);
            progressBar1.TabIndex = 2;
            // 
            // DataUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Name = "DataUpdate";
            Text = "자료 업데이트";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private Label label1;
        private ProgressBar progressBar1;
    }
}
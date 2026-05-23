namespace CeDev.Login
{
    partial class UserInfoNew
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
            btnNew = new Button();
            txtPw = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.Location = new Point(272, 248);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(257, 56);
            btnNew.TabIndex = 13;
            btnNew.Text = "생성하기";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // txtPw
            // 
            txtPw.Location = new Point(345, 187);
            txtPw.Name = "txtPw";
            txtPw.Size = new Size(184, 23);
            txtPw.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 190);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 11;
            label2.Text = "PW";
            // 
            // txtId
            // 
            txtId.Location = new Point(345, 147);
            txtId.Name = "txtId";
            txtId.Size = new Size(184, 23);
            txtId.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(272, 150);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 9;
            label1.Text = "ID";
            // 
            // UserInfoNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNew);
            Controls.Add(txtPw);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "UserInfoNew";
            Text = "UserInfoNew";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNew;
        private TextBox txtPw;
        private Label label2;
        private TextBox txtId;
        private Label label1;
    }
}
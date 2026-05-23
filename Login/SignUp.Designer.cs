namespace CeDev.Login
{
    partial class SignUp
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
            txtPw = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            btnJoin = new Button();
            SuspendLayout();
            // 
            // txtPw
            // 
            txtPw.Location = new Point(312, 140);
            txtPw.Name = "txtPw";
            txtPw.Size = new Size(184, 23);
            txtPw.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 143);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 6;
            label2.Text = "PW";
            // 
            // txtId
            // 
            txtId.Location = new Point(312, 100);
            txtId.Name = "txtId";
            txtId.Size = new Size(184, 23);
            txtId.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 103);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 4;
            label1.Text = "ID";
            // 
            // btnJoin
            // 
            btnJoin.Location = new Point(239, 201);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(257, 56);
            btnJoin.TabIndex = 8;
            btnJoin.Text = "가입하기";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnJoin);
            Controls.Add(txtPw);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "SignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPw;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private Button btnJoin;
    }
}
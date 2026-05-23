namespace CeDev.Login
{
    partial class Login
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
            label1 = new Label();
            txtId = new TextBox();
            txtPw = new TextBox();
            label2 = new Label();
            btnLogin = new Button();
            lblJoin = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 110);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // txtId
            // 
            txtId.Location = new Point(343, 107);
            txtId.Name = "txtId";
            txtId.Size = new Size(184, 23);
            txtId.TabIndex = 1;
            // 
            // txtPw
            // 
            txtPw.Location = new Point(343, 147);
            txtPw.Name = "txtPw";
            txtPw.Size = new Size(184, 23);
            txtPw.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 150);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 2;
            label2.Text = "PW";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(270, 232);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(257, 56);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblJoin
            // 
            lblJoin.AutoSize = true;
            lblJoin.Location = new Point(466, 318);
            lblJoin.Name = "lblJoin";
            lblJoin.Size = new Size(55, 15);
            lblJoin.TabIndex = 5;
            lblJoin.TabStop = true;
            lblJoin.Text = "회원가입";
            lblJoin.LinkClicked += lblJoin_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblJoin);
            Controls.Add(btnLogin);
            Controls.Add(txtPw);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox txtPw;
        private Label label2;
        private Button btnLogin;
        private LinkLabel lblJoin;
    }
}
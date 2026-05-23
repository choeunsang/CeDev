namespace CeDev.Login
{
    partial class UserInfo
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
            gvUser = new DataGridView();
            btnSearch = new Button();
            btnNew = new Button();
            btnDetail = new Button();
            btnDel = new Button();
            ((System.ComponentModel.ISupportInitialize)gvUser).BeginInit();
            SuspendLayout();
            // 
            // gvUser
            // 
            gvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvUser.Location = new Point(23, 52);
            gvUser.Name = "gvUser";
            gvUser.Size = new Size(928, 249);
            gvUser.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(828, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 34);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "조회";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(570, 318);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(123, 34);
            btnNew.TabIndex = 2;
            btnNew.Text = "신규등록";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnDetail
            // 
            btnDetail.Location = new Point(699, 318);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(123, 34);
            btnDetail.TabIndex = 3;
            btnDetail.Text = "상세";
            btnDetail.UseVisualStyleBackColor = true;
            btnDetail.Click += btnDetail_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(828, 318);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(123, 34);
            btnDel.TabIndex = 4;
            btnDel.Text = "삭제";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // UserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 389);
            Controls.Add(btnDel);
            Controls.Add(btnDetail);
            Controls.Add(btnNew);
            Controls.Add(btnSearch);
            Controls.Add(gvUser);
            Name = "UserInfo";
            Text = "회원정보";
            ((System.ComponentModel.ISupportInitialize)gvUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gvUser;
        private Button btnSearch;
        private Button btnNew;
        private Button btnDetail;
        private Button btnDel;
    }
}
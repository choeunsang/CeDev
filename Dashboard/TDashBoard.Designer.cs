namespace CeDev.DataMng
{
    partial class TDashBoard
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
            gridPu = new DataGridView();
            btnPuSearch = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridPu).BeginInit();
            SuspendLayout();
            // 
            // gridPu
            // 
            gridPu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPu.Location = new Point(12, 39);
            gridPu.Name = "gridPu";
            gridPu.Size = new Size(829, 188);
            gridPu.TabIndex = 40;
            // 
            // btnPuSearch
            // 
            btnPuSearch.Location = new Point(758, 6);
            btnPuSearch.Name = "btnPuSearch";
            btnPuSearch.Size = new Size(83, 27);
            btnPuSearch.TabIndex = 49;
            btnPuSearch.Text = "조회";
            btnPuSearch.UseVisualStyleBackColor = true;
            btnPuSearch.Click += btnPuSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 39;
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 542);
            Controls.Add(btnPuSearch);
            Controls.Add(gridPu);
            Controls.Add(label2);
            Name = "DashBoard";
            Text = "대쉬보드";
            Load += SeriesMng_Load;
            ((System.ComponentModel.ISupportInitialize)gridPu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridPu;
        private Button btnPuSearch;
        private Label label2;
    }
}
namespace CeDev.DataMng
{
    partial class SavePop
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
            gridTarget = new DataGridView();
            txtChgReason = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)gridTarget).BeginInit();
            SuspendLayout();
            // 
            // gridTarget
            // 
            gridTarget.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTarget.Location = new Point(23, 23);
            gridTarget.Name = "gridTarget";
            gridTarget.Size = new Size(749, 252);
            gridTarget.TabIndex = 35;
            // 
            // txtChgReason
            // 
            txtChgReason.Location = new Point(23, 308);
            txtChgReason.Multiline = true;
            txtChgReason.Name = "txtChgReason";
            txtChgReason.Size = new Size(749, 90);
            txtChgReason.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 284);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 37;
            label1.Text = "변경사유";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(672, 406);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 32);
            btnSave.TabIndex = 38;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // SavePop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(txtChgReason);
            Controls.Add(gridTarget);
            Name = "SavePop";
            Text = "파장 및 PU구간 저장팝업";
            Load += SavePop_Load;
            ((System.ComponentModel.ISupportInitialize)gridTarget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridTarget;
        private TextBox txtChgReason;
        private Label label1;
        private Button btnSave;
    }
}
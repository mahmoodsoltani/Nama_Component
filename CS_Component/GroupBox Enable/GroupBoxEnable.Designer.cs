namespace CS_Component
{
    partial class GroupBoxEnable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chk_Enable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // chk_Enable
            // 
            this.chk_Enable.AutoSize = true;
            this.chk_Enable.BackColor = System.Drawing.Color.Transparent;
            this.chk_Enable.Checked = true;
            this.chk_Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Enable.Dock = System.Windows.Forms.DockStyle.Top;
            this.chk_Enable.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chk_Enable.FlatAppearance.BorderSize = 20;
            this.chk_Enable.Location = new System.Drawing.Point(0, 0);
            this.chk_Enable.Name = "chk_Enable";
            this.chk_Enable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_Enable.Size = new System.Drawing.Size(280, 17);
            this.chk_Enable.TabIndex = 0;
            this.chk_Enable.Text = "فعال سازی";
            this.chk_Enable.UseVisualStyleBackColor = false;
            this.chk_Enable.CheckedChanged += new System.EventHandler(this.chk_Enable_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // GroupBoxEnable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chk_Enable);
            this.Controls.Add(this.groupBox1);
            this.Name = "GroupBoxEnable";
            this.Size = new System.Drawing.Size(280, 178);
            this.Load += new System.EventHandler(this.GroupBoxEnable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox chk_Enable;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

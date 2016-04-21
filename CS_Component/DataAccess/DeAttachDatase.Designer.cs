namespace CS_Component 
{
    partial class DeAttachDatase
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
            this.Deta = new CS_Component.Btn();
            this.SuspendLayout();
            // 
            // Deta
            // 
            this.Deta.BackColor = System.Drawing.Color.Transparent;
            this.Deta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Deta.HeaderText = "detach db";
            this.Deta.Location = new System.Drawing.Point(68, 97);
            this.Deta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Deta.Name = "Deta";
            this.Deta.Size = new System.Drawing.Size(76, 34);
            this.Deta.TabIndex = 9;
            this.Deta.Click += new System.EventHandler(this.Deta_Click);
            // 
            // DeAttachDatase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Deta);
            this.Name = "DeAttachDatase";
            this.Text = "DeAttachDatase";
            this.ResumeLayout(false);

        }

        #endregion

        internal Btn Deta;

    }
}
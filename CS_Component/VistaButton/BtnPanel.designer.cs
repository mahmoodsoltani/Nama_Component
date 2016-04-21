namespace CS_Component
{
    partial class BtnPanel
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
            this.SuspendLayout();
            // 
            // BtnPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CS_Component.Properties.Resources.P_nor;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BtnPanel";
            this.Size = new System.Drawing.Size(213, 32);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnPanel_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

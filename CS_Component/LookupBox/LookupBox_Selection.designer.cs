namespace CS_Component
{
    partial class LookupBox_Selection
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
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_Result = new CS_Component.TextBox();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Select.Location = new System.Drawing.Point(302, 0);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(59, 23);
            this.btn_Select.TabIndex = 5;
            this.btn_Select.Text = "جستجو";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_Result
            // 
            this.txt_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Result.CheckExistValueInDb = false;
            this.txt_Result.ColorOnFocus = System.Drawing.Color.Yellow;
            this.txt_Result.CurrencyUnit = "ریال";
            this.txt_Result.DefaultValue = "";
            this.txt_Result.FillWithMaxInDb = false;
            this.txt_Result.IsRequired = false;
            this.txt_Result.Location = new System.Drawing.Point(0, 0);
            this.txt_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Result.MaxDecimalLength = 2;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ReadOnly = true;
            this.txt_Result.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Result.Size = new System.Drawing.Size(296, 23);
            this.txt_Result.SpellControl = null;
            this.txt_Result.TabIndex = 6;
            this.txt_Result.Title = null;
            this.txt_Result.TypeOfContains = CS_Component.TypeOfValues.PersianText;
            this.txt_Result.UseForData = true;
            this.txt_Result.ValidateCheckExistOnEdit = false;
            this.txt_Result.Value = "";
            // 
            // LookupBox_Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.txt_Result);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LookupBox_Selection";
            this.Size = new System.Drawing.Size(360, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Select;
        public CS_Component.TextBox txt_Result;
    }
}

namespace CS_Component
{
    partial class LookupBox
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
            this.txt_Code = new CS_Component.TextBox();
            this.txt_Result = new CS_Component.TextBox();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Select.Location = new System.Drawing.Point(244, 2);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(59, 23);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "جستجو";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_Code
            // 
            this.txt_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Code.CheckExistValueInDb = false;
            this.txt_Code.ColorOnFocus = System.Drawing.Color.Yellow;
            this.txt_Code.CurrencyUnit = "ریال";
            this.txt_Code.DefaultValue = "";
            this.txt_Code.FillWithMaxInDb = false;
            this.txt_Code.IsRequired = false;
            this.txt_Code.Location = new System.Drawing.Point(309, 2);
            this.txt_Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Code.MaxDecimalLength = 2;
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Code.Size = new System.Drawing.Size(90, 23);
            this.txt_Code.SpellControl = null;
            this.txt_Code.TabIndex = 2;
            this.txt_Code.Title = null;
            this.txt_Code.TypeOfContains = CS_Component.TypeOfValues.PersianText;
            this.txt_Code.UseForData = true;
            this.txt_Code.ValidateCheckExistOnEdit = false;
            this.txt_Code.Value = "";
            this.txt_Code.Leave += new System.EventHandler(this.txt_Code_Leave);
            this.txt_Code.TextChanged += new System.EventHandler(this.txt_Code_TextChanged);
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
            this.txt_Result.Location = new System.Drawing.Point(0, 2);
            this.txt_Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Result.MaxDecimalLength = 2;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Result.Size = new System.Drawing.Size(238, 23);
            this.txt_Result.SpellControl = null;
            this.txt_Result.TabIndex = 1;
            this.txt_Result.Title = null;
            this.txt_Result.TypeOfContains = CS_Component.TypeOfValues.PersianText;
            this.txt_Result.UseForData = true;
            this.txt_Result.ValidateCheckExistOnEdit = false;
            this.txt_Result.Value = "";
            this.txt_Result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Result_KeyDown);
            this.txt_Result.Leave += new System.EventHandler(this.txt_Result_Leave);
            this.txt_Result.TextChanged += new System.EventHandler(this.txt_Result_TextChanged);
            // 
            // LookupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.txt_Code);
            this.Controls.Add(this.txt_Result);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LookupBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(400, 26);
            this.Resize += new System.EventHandler(this.LookupBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CS_Component.TextBox txt_Result;
        public CS_Component.TextBox txt_Code;
        private System.Windows.Forms.Button btn_Select;

    }
}

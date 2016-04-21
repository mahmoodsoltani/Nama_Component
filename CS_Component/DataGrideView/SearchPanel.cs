using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CS_Component
{
    public class SearchPanel : Panel
    {
        private InputLanguage _DefaultLanguage = InputLanguage.CurrentInputLanguage;
        private Button btn_Close;
        private Label lbl_InField;
        private Label lbl_SearchCondition;
        private Label lbl_SearchFieldTitle;
        private TextBox txt_SearchKey;

        public event EventHandler SearchTextChanged;

        public bool showClose
        {
            get
            {
                return btn_Close.Visible;
            }
            set
            {
                btn_Close.Visible = value;
                if (value)
                    Show();

            }
        }

        public SearchPanel()
        {
            this.InitializeComponents();
            this.txt_SearchKey.Focus();
            base.VisibleChanged += new EventHandler(this.SearchPanel_VisibleChanged);
            base.Enter += new EventHandler(this.SearchPanel_Enter);
            this.txt_SearchKey.Enter += new EventHandler(this.txt_SearchKey_Enter);
            //foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
            //{
            //    if (language.Culture.EnglishName == "Persian (Iran)")
            //    {
            //        this._DefaultLanguage = language;
            //        break;
            //    }
            //}
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            base.Hide();
        }

        private void InitializeComponents()
        {
            this.btn_Close = new Button();
            this.txt_SearchKey = new TextBox();
            this.lbl_SearchCondition = new Label();
            this.lbl_InField = new Label();
            this.lbl_SearchFieldTitle = new Label();
            this.btn_Close.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.btn_Close.Image = CS_Component.Properties.Resources.close_16;
            this.btn_Close.Location = new Point(0x180, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new Size(0x18, 0x17);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new EventHandler(this.btn_Close_Click);
            this.txt_SearchKey.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.txt_SearchKey.Location = new Point(152, 3);
            this.txt_SearchKey.Name = "txt_SearchKey";
            this.txt_SearchKey.TextChanged += new EventHandler(this.txt_SearchKey_TextChanged);
            this.txt_SearchKey.Size = new Size(0x81, 0x17);
            this.txt_SearchKey.TabIndex = 1;
            this.lbl_SearchCondition.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.lbl_SearchCondition.AutoSize = true;
            this.lbl_SearchCondition.Location = new Point(0x11f, 6);
            this.lbl_SearchCondition.Name = "lbl_SearchCondition";
            this.lbl_SearchCondition.Size = new Size(0x5b, 0x10);
            this.lbl_SearchCondition.TabIndex = 2;
            this.lbl_SearchCondition.Text = "جستجو :";
            this.lbl_SearchCondition.BackColor = Color.Transparent;
            this.lbl_InField.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.lbl_InField.AutoSize = true;
            this.lbl_InField.Location = new Point(0x76, 6);
            this.lbl_InField.Name = "lbl_InField";
            this.lbl_InField.Size = new Size(0x1c, 0x10);
            this.lbl_InField.TabIndex = 3;
            this.lbl_InField.Text = "در :";
            this.lbl_InField.BackColor = Color.Transparent;
            this.lbl_SearchFieldTitle.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.lbl_SearchFieldTitle.Location = new Point(3, 6);
            this.lbl_SearchFieldTitle.Name = "lbl_SearchFieldTitle";
            this.lbl_SearchFieldTitle.Size = new Size(0xdd, 0x12);
            this.lbl_SearchFieldTitle.TabIndex = 4;
            this.lbl_SearchFieldTitle.BackColor = Color.Transparent;
            base.SuspendLayout();
            base.BorderStyle = BorderStyle.FixedSingle;
            base.Controls.Add(this.lbl_SearchFieldTitle);
            base.Controls.Add(this.lbl_InField);
            base.Controls.Add(this.lbl_SearchCondition);
            base.Controls.Add(this.txt_SearchKey);
            base.Controls.Add(this.btn_Close);
            this.BackColor = Color.LightSteelBlue;
            base.Location = new Point(12, 0x15);
            base.Size = new Size(0x19f, 0x1f);
            base.PerformLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush brush = new LinearGradientBrush(base.ClientRectangle, Color.SteelBlue, Color.LightSteelBlue, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, 0, base.Height / 2, base.Width, base.Height / 2);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            Application.DoEvents();
            this.btn_Close.Left = (base.Width - this.btn_Close.Width) - 6;
            this.lbl_SearchCondition.Left = (this.btn_Close.Left - 6) - this.lbl_SearchCondition.Width;
            this.txt_SearchKey.Left = (this.lbl_SearchCondition.Left - 6) - this.txt_SearchKey.Width;
            this.lbl_InField.Left = (this.txt_SearchKey.Left - 6) - this.lbl_InField.Width;
            this.lbl_SearchFieldTitle.Left = (this.lbl_InField.Left - 6) - this.lbl_SearchFieldTitle.Width;
            base.OnResize(eventargs);
        }

        private void SearchPanel_Enter(object sender, EventArgs e)
        {
            this.txt_SearchKey.Focus();
        }

        private void SearchPanel_VisibleChanged(object sender, EventArgs e)
        {
            this.txt_SearchKey.Focus();
        }

        private void txt_SearchKey_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = this._DefaultLanguage;
        }

        private void txt_SearchKey_TextChanged(object sender, EventArgs e)
        {
            if (this.SearchTextChanged != null)
                this.SearchTextChanged(sender, e);
        }

        public string SearchField
        {
            get
            {
                return this.lbl_SearchFieldTitle.Text;
            }
            set
            {
                this.lbl_SearchFieldTitle.Text = value;
            }
        }

        public string SearchText
        {
            get
            {
                return this.txt_SearchKey.Text.Replace("ی", "ي").Replace("ك", "ک");
            }
        }

        public Color SearchTextBackColor
        {
            set
            {
                this.txt_SearchKey.BackColor = value;
            }
        }
    }
}


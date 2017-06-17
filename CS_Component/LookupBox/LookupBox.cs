using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Design;

namespace CS_Component
{
    public enum LookupDataMode { UseDataTable, UseSelectCommand }

    [ComplexBindingProperties("DataSource", "ValueField")]
    public partial class LookupBox : UserControl
    {
        #region Member Fields

        private System.ComponentModel.IBindingList _DataSource;
        public CS_Component.DataGridView grd_Information;
        private DataAccess obj_DataAccess;// = new DataAccess("Data Source=.;Initial Catalog=Nama_MIS;Integrated Security=False;User ID=sa;Password=123456", false);
        private LookupDataMode _Mode;
        private string str_DataFields;
        //string[] fields;
        string[] aliases;
        private string str_ValueField;
        private string str_DisplayField;
        private string str_AliasDisplay;
        private string str_AliasCode;
        private string str_CodeField;
        private string str_TableName;
        private string str_Filter = "";
        public CS_Component.DataGridView grd_Popup;
        private DataRow _SelectedDataRow;
        public System.Windows.Forms.LinkLabel lnk_New;
        public Form frm_LookupText;
        private string str_HiddenColumnIndexes;
        private string str_Default;
        private bool bol_DisplayCodeField = true;
        private int int_CodeWidth;
        //private int int_ResultWidth = 90;
        bool _IsRequired = false;
        private string str_Title;
        #endregion

        #region Properties

        [Category("Nama")]
        [DefaultValue(false)]
        [Description("true if u want Validate value Of ComboBox after click save")]
        public bool IsRequired
        {
            get { return _IsRequired; }
            set
            {
                _IsRequired = value;
            }
        }

        [Category("Nama")]
        public string Title
        {
            get { return str_Title; }
            set
            {
                str_Title = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool DisplayCodeBox
        {
            get { return bol_DisplayCodeField; }
            set
            {

                bol_DisplayCodeField = value;
                txt_Code.Visible = bol_DisplayCodeField;
                if (!bol_DisplayCodeField)
                {
                    txt_Result.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    btn_Select.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    this.Width = btn_Select.Right + 1;
                    txt_Result.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    btn_Select.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                }
                else
                {
                    txt_Result.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    btn_Select.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    this.Width += txt_Code.Width + 4;
                    txt_Result.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    btn_Select.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                }
            }
        }

        [Category("Behavior")]
        public int CodeBoxWidth
        {
            get { return int_CodeWidth; }
            set
            {
                int_CodeWidth = value;
                txt_Code.Width = int_CodeWidth;
                txt_Result.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                btn_Select.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                txt_Code.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                this.Width = txt_Code.Right + 1;
                txt_Result.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                txt_Code.Anchor = btn_Select.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string DefaultSearchField
        {
            get { return str_Default; }
            set { str_Default = value; }
        }

        [Category("Data"), AttributeProvider("System.ComponentModel.IListSource")]
        public object DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = (System.ComponentModel.IBindingList)value;
                if (_DataSource != null)
                {
                    if (grd_Information == null)
                    {
                        grd_Information = new CS_Component.DataGridView();
                        grd_Information.DataSource = _DataSource;
                        grd_Information.DataMember = ((BindingSource)_DataSource).DataMember;
                    }
                }
            }
        }

        [Category("Data")]
        public CS_Component.DataGridView InfoDataGridView
        {
            get { return grd_Information; }
            set { grd_Information = value; }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueField
        {
            get { return str_ValueField; }
            set
            {
                str_ValueField = value;
                //((BindingSource)_DataSource).DataMember 
            }
        }

        [Category("Data")]
        public LookupDataMode DataMode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        [Category("Data")]
        [Description("Select fields like this : {ValueField,CodeField as [Code],DisplayField as [Display Field]}")]
        public string DataFields
        {
            get { return str_DataFields; }
            set
            {
                str_DataFields = value;
                if (!string.IsNullOrEmpty(str_DataFields))
                {
                    string[] Splitors = new string[1];
                    Splitors[0] = ",";
                    string[] fields = str_DataFields.ToLower().Split(Splitors, StringSplitOptions.None);
                    string[] aliases = str_DataFields.ToLower().Split(Splitors, StringSplitOptions.None);
                    for (int i = 0; i < fields.Count(); i++)
                    {
                        try
                        {
                            fields[i] = fields[i].Remove(fields[i].IndexOf(" as")).Trim();
                            aliases[i] = aliases[i].Replace(fields[i] + " as", "");
                        }
                        catch { aliases[i] = fields[i]; }
                    }
                }
            }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string DisplayField
        {
            get { return str_DisplayField; }
            set { str_DisplayField = value; }
        }

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string CodeField
        {
            get { return str_CodeField; }
            set { str_CodeField = value; }
        }

        [Category("Data")]
        [Description("Zero based index of datatable columns to make hidden after loading {Example : 6,0}")]
        public string HiddenFields
        {
            get { return str_HiddenColumnIndexes; }
            set { str_HiddenColumnIndexes = value; }
        }

        [Category("Data")]
        public string TableName
        {
            get { return str_TableName; }
            set { str_TableName = value; }
        }

        [Category("Data")]
        public string Filter
        {
            get { return str_Filter; }
            set { str_Filter = value; }
        }

        public DataRow Result
        {
            get { return _SelectedDataRow; }
            set
            {
                _SelectedDataRow = value;
                if (_SelectedDataRow == null)
                {
                    txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    txt_Result.Text = "";
                    txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                    txt_Code.TextChanged -= new EventHandler(txt_Code_TextChanged);
                    txt_Code.Text = "";
                    txt_Code.TextChanged += new EventHandler(txt_Code_TextChanged);
                }
                else
                {
                    txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    txt_Result.Text = _SelectedDataRow[str_DisplayField].ToString();
                    txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                    txt_Code.TextChanged -= new EventHandler(txt_Code_TextChanged);
                    txt_Code.Text = _SelectedDataRow[str_CodeField].ToString();
                    txt_Code.TextChanged += new EventHandler(txt_Code_TextChanged);
                }
                if (Selected != null)
                    Selected(this, _SelectedDataRow);
            }
        }

        public DataAccess DataAccess
        {
            get { return obj_DataAccess; }
            set { obj_DataAccess = value; }
        }


        #endregion

        #region Constructor

        public LookupBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Delegates and Events

        public delegate void SelectedHandler(object sender, DataRow e);

        public event SelectedHandler Selected;

        #endregion

        #region Methods

        public void SetText(string Text, string Code)
        {
            txt_Code.TextChanged -= new EventHandler(txt_Code_TextChanged);
            txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
            txt_Result.Text = Text;
            txt_Code.Text = Code;
            txt_Code.TextChanged += new EventHandler(txt_Code_TextChanged);
            txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
        }

        private void InitializeLookup()
        {
            if (frm_LookupText == null)
                frm_LookupText = new Form();
            frm_LookupText.FormBorderStyle = FormBorderStyle.None;
            frm_LookupText.TopMost = true;
            frm_LookupText.BackColor = Color.LightSteelBlue;
            frm_LookupText.Font = this.FindForm().Font;
            frm_LookupText.RightToLeft = this.RightToLeft;
            int left = this.Left;
            int top = this.Top + this.Height;
            Control p = this.Parent;
            while (p is Panel || p is GroupBox || p is TabControl)
            {
                left += p.Left;
                top += p.Top;
                p = p.Parent;
            }
            frm_LookupText.StartPosition = FormStartPosition.Manual;
            frm_LookupText.Top = top + this.FindForm().Top + this.Height + 8;
            frm_LookupText.Left = left + this.FindForm().Left + 8;
            //frm_LookupText.DesktopLocation = new Point(top, left);
            frm_LookupText.Height = 150;
            frm_LookupText.Paint += new PaintEventHandler(frm_LookupText_Paint);
            frm_LookupText.ShowInTaskbar = false;
            frm_LookupText.Width = txt_Code.Width + txt_Result.Width + btn_Select.Width + 10;
            InitLink();
        }


        void frm_LookupText_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, frm_LookupText.Width - 1, frm_LookupText.Height - 1);
        }

        private void InitializePopup(SqlDataReader Dr)
        {
            DataTable dt = new DataTable(str_TableName);
            dt.Load(Dr, LoadOption.OverwriteChanges);
            if (dt.Rows.Count == 0)
            {
                if (frm_LookupText != null)
                    frm_LookupText.Visible = false;
                txt_Code.Clear();
                return;
            }
            InitializeLookup();
            if (grd_Popup == null)
                grd_Popup = new CS_Component.DataGridView();
            frm_LookupText.Controls.Add(grd_Popup);
            frm_LookupText.Show();
            grd_Popup.Top = 25;
            grd_Popup.Left = 0;
            grd_Popup.Height = 125;
            grd_Popup.Width = frm_LookupText.Width;
            grd_Popup.DataSource = dt;
            grd_Popup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grd_Popup.Columns[str_ValueField].Visible = false;
            grd_Popup.Columns[str_AliasCode].Width = txt_Code.Width;
            grd_Popup.Columns[str_AliasDisplay].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd_Popup.AllowUserToAddRows = grd_Popup.AllowUserToDeleteRows = grd_Popup.AllowUserToOrderColumns = grd_Popup.AllowUserToResizeColumns = grd_Popup.AllowUserToResizeRows = false;
            grd_Popup.ReadOnly = true;
            grd_Popup.RowHeadersVisible = false;
            grd_Popup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd_Popup.BorderStyle = BorderStyle.FixedSingle;
            grd_Popup.CellDoubleClick += new DataGridViewCellEventHandler(grd_Popup_CellDoubleClick);
            grd_Popup.KeyDown += new KeyEventHandler(grd_Popup_KeyDown);
        }

        private void InitializePopup(BindingSource DataSource)
        {
            InitializeLookup();
            if (grd_Popup == null)
                grd_Popup = new CS_Component.DataGridView();
            frm_LookupText.Controls.Add(grd_Popup);
            VB_Component.BaseForm fm_b = new VB_Component.BaseForm();
            Control AcCon = new Control();
            AcCon = this.Parent;
            while (AcCon.GetType().BaseType != fm_b.GetType())
                AcCon = AcCon.Parent;

            frm_LookupText.Owner = (VB_Component.BaseForm)AcCon;
            Application.DoEvents();

            frm_LookupText.Show();
            grd_Popup.DataSource = DataSource;
            grd_Popup.Top = 25;
            grd_Popup.Left = 0;
            grd_Popup.Height = 125;
            grd_Popup.Width = frm_LookupText.Width;
            foreach (DataGridViewColumn dc in grd_Popup.Columns)
                dc.Visible = false;
            grd_Popup.Columns[str_CodeField].Visible = grd_Popup.Columns[str_DisplayField].Visible = true;
            grd_Popup.Columns[str_CodeField].Width = txt_Code.Width;
            grd_Popup.Columns[str_DisplayField].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grd_Popup.AllowUserToAddRows = grd_Popup.AllowUserToDeleteRows = grd_Popup.AllowUserToOrderColumns = grd_Popup.AllowUserToResizeColumns = grd_Popup.AllowUserToResizeRows = false;
            grd_Popup.ReadOnly = true;
            grd_Popup.RowHeadersVisible = false;
            grd_Popup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd_Popup.BorderStyle = BorderStyle.FixedSingle;
            grd_Popup.CellDoubleClick += new DataGridViewCellEventHandler(grd_Popup_CellDoubleClick);
            grd_Popup.KeyDown += new KeyEventHandler(grd_Popup_KeyDown);
        }

        private void InitializeAliases()
        {
            string[] Splitors = new string[1];
            Splitors[0] = ",";
            string[] fields = str_DataFields.ToLower().Split(Splitors, StringSplitOptions.None);
            string[] aliases = str_DataFields.ToLower().Split(Splitors, StringSplitOptions.None);
            for (int i = 0; i < fields.Count(); i++)
            {
                try
                {
                    fields[i] = fields[i].Remove(fields[i].IndexOf(" as")).Trim();
                    aliases[i] = aliases[i].Replace(fields[i] + " as", "");
                }
                catch { aliases[i] = fields[i]; }
                if (fields[i].ToLower().Replace('[', ' ').Replace(']', ' ').Trim() == str_CodeField.ToLower())
                    str_AliasCode = aliases[i].Replace('[', ' ').Replace(']', ' ').Trim();
                else if (fields[i].ToLower().Replace('[', (char)32).Replace(']', (char)32).Trim() == str_DisplayField.ToLower())
                    str_AliasDisplay = aliases[i].Replace('[', ' ').Replace(']', ' ').Trim();

            }
        }

        private void InitLink()
        {
            if (lnk_New == null)
                lnk_New = new LinkLabel();
            lnk_New.Text = "جدید";
            lnk_New.Left = 5;
            lnk_New.Top = 5;
            lnk_New.LinkBehavior = LinkBehavior.NeverUnderline;
            lnk_New.AutoSize = true;
            frm_LookupText.Controls.Add(lnk_New);
            lnk_New.Click += new EventHandler(lnk_New_Click);
        }

        public void LoadByValue(object value)
        {
            string str_NewFilter = str_Filter;
            if (!string.IsNullOrEmpty(str_NewFilter))
            {
                str_NewFilter += " AND ";
            }
            str_NewFilter += "[" + str_ValueField + "]=" + value.ToString();
            ((BindingSource)DataSource).Filter = str_NewFilter;
            if (((BindingSource)DataSource).List.Count != 0)
            {
                txt_Code.TextChanged -= new EventHandler(txt_Code_TextChanged);
                txt_Code.Text = ((DataRowView)((BindingSource)DataSource).Current)[str_CodeField].ToString();
                txt_Code.TextChanged += new EventHandler(txt_Code_TextChanged);

                txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                txt_Result.Text = ((DataRowView)((BindingSource)DataSource).Current)[str_DisplayField].ToString();
                txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                Result = ((DataRowView)((BindingSource)DataSource).Current).Row;
            }
        }
        #endregion

        #region Event Handlers

        private void txt_Code_Leave(object sender, EventArgs e)
        {
            if (frm_LookupText != null)
                frm_LookupText.Hide();
            if (txt_Code.Text == string.Empty)
            {
                if (_DataSource != null)
                {
                    ((BindingSource)_DataSource).Filter = str_Filter;
                }
                return;
            }
            if (_Mode == LookupDataMode.UseSelectCommand)
            {
                InitializeAliases();
                string str_Query = string.Format("SELECT {0} FROM [{1}] WHERE LTRIM(RTRIM(STR([{2}]))) = '{3}'", str_DataFields, str_TableName, str_CodeField, txt_Code.Text);
                if (!string.IsNullOrEmpty(str_Filter))
                {
                    str_Query += " AND " + str_Filter;
                }
                DataRow Dr = obj_DataAccess.GetRow(str_Query);
                if (Dr != null)
                {
                    txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    txt_Result.Text = Dr[str_AliasDisplay].ToString();
                    Result = Dr;
                    //if (Selected != null)
                    //Selected(this, _SelectedDataRow);
                    txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                }
                else
                {
                    //txt_Result.Text = "{هیچ موردی پیدا نشد}";
                    Result = null;
                    //if (Selected != null)
                    //Selected(this, _SelectedDataRow);
                    txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    txt_Result.Text = "";
                    txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                    return;
                }
            }
            else  //Use DataTable
            {
                if (DataSource == null) return;
                string str_NewFilter = str_Filter;
                if (str_NewFilter == null)
                    str_NewFilter = "";
                if (str_Filter.Trim() != string.Empty)
                {
                    str_NewFilter += " AND ";
                }
                str_NewFilter += "[" + str_CodeField + "]=" + txt_Code.Text;
                ((BindingSource)_DataSource).Filter = str_NewFilter;
                if (((BindingSource)_DataSource).List.Count != 0)
                {
                    txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    Result = ((DataRowView)((BindingSource)_DataSource).Current).Row;
                    //if (Selected != null)
                    //  Selected(this, _SelectedDataRow);
                    txt_Result.Text = ((DataRowView)((BindingSource)_DataSource).Current)[str_DisplayField].ToString();
                    txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                }
            }
        }

        private void txt_Result_TextChanged(object sender, EventArgs e)
        {
            if (txt_Result.Text == string.Empty)
            {
                if (frm_LookupText != null)
                    frm_LookupText.Visible = false;
                txt_Result.Focus();
                ResetResult();
                return;
            }

            if (_Mode == LookupDataMode.UseSelectCommand)
            {
                InitializeAliases();
                string str_Query = string.Format("SELECT {0} FROM [{1}] WHERE [{2}] LIKE '{3}%'", str_DataFields, str_TableName, str_DisplayField, txt_Result.Text);
                if (!string.IsNullOrEmpty(str_Filter))
                {
                    str_Query += " AND " + str_Filter;
                }

                str_Query += string.Format("SELECT {0} FROM [{1}] WHERE [{2}] LIKE '%{3}%'", str_DataFields, str_TableName, str_DisplayField, txt_Result.Text);
                if (!string.IsNullOrEmpty(str_Filter))
                {
                    str_Query += " AND " + str_Filter;
                }

                SqlDataReader Dr = obj_DataAccess.GetRowWithQuery(str_Query);
                if (Dr != null)
                {
                    InitializePopup(Dr);
                }
                else
                {
                    if (grd_Popup != null)
                        grd_Popup.Hide();
                    //txt_Result.Text = "{هیچ موردی پیدا نشد}";
                    txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    txt_Result.Text = "";
                    txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
                    txt_Code.Clear();
                    ResetResult();
                    return;
                }
            }
            else//Use DataTable
            {
                if (DataSource == null) return;
                string str_NewFilter = str_Filter;
                if (str_Filter == null)
                    str_Filter = "";
                if (str_Filter.Trim() != string.Empty)
                {
                    str_NewFilter += " AND ";
                }
                if (txt_Result.Text.Trim() != string.Empty)
                    str_NewFilter += "[" + str_DisplayField + "] LIKE '%" + txt_Result.Text + "%'";
                else
                    str_NewFilter = str_Filter;
                ((BindingSource)_DataSource).Filter = str_NewFilter;
                InitializePopup((BindingSource)_DataSource);
            }
            txt_Result.Focus();
            txt_Result.SelectionStart = txt_Result.Text.Length;
            txt_Result.SelectionLength = 0;
        }

        void grd_Popup_KeyDown(object sender, KeyEventArgs e)
        {
            if (grd_Popup.CurrentRow == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                grd_Popup_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, grd_Popup.CurrentRow.Index));
            }
        }

        void grd_Popup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd_Popup.CurrentRow == null)
                return;
            if (_Mode == LookupDataMode.UseSelectCommand)
            {
                txt_Code.Text = grd_Popup.CurrentRow.Cells[str_AliasCode].Value.ToString();
                txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                txt_Result.Text = grd_Popup.CurrentRow.Cells[str_AliasDisplay].Value.ToString();
                Result = (DataRow)((BindingSource)grd_Popup.DataSource).List[grd_Popup.CurrentRow.Index];
                //if (Selected != null)
                //  Selected(this, _SelectedDataRow);
                txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
            }
            else
            {
                Result = ((DataRowView)((BindingSource)_DataSource).Current).Row;
                //if (Selected != null)
                //  Selected(this, _SelectedDataRow);
                int i = grd_Popup.CurrentRow.Index;
                txt_Code.TextChanged -= new EventHandler(txt_Code_TextChanged);
                txt_Code.Text = grd_Popup.Rows[i].Cells[str_CodeField].Value.ToString();
                txt_Code.TextChanged += new EventHandler(txt_Code_TextChanged);

                txt_Result.TextChanged -= new EventHandler(txt_Result_TextChanged);
                txt_Result.Text = grd_Popup.Rows[i].Cells[str_DisplayField].Value.ToString();
                txt_Result.TextChanged += new EventHandler(txt_Result_TextChanged);
            }
            frm_LookupText.Hide();
            txt_Result.Focus();
        }

        private void txt_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (grd_Popup != null)
                grd_Popup.Focus();
        }

        private Form frm_ManagementForm;

        void lnk_New_Click(object sender, EventArgs e)
        {
            if (frm_ManagementForm != null)
            {
                frm_ManagementForm.ShowDialog();
            }
        }

        private void LookupBox_Resize(object sender, EventArgs e)
        {
            //txt_Code.Left = txt_Code.Width - this.Width;
            //txt_Result.Left = 0;
            //txt_Result.Width = txt_Result.Left - 5;
        }

        #endregion

        private void txt_Code_TextChanged(object sender, EventArgs e)
        {
            if (txt_Code.Text == string.Empty)
            {
                if (frm_LookupText != null)
                    frm_LookupText.Visible = false;
                txt_Code.Focus();
                return;
            }

            if (_Mode == LookupDataMode.UseSelectCommand)
            {
                InitializeAliases();
                string str_Query = string.Format("SELECT {0} FROM [{1}] WHERE LTRIM(RTRIM(STR([{2}]))) LIKE '{3}%'", str_DataFields, str_TableName, str_CodeField, txt_Code.Text);
                if (!string.IsNullOrEmpty(str_Filter))
                {
                    str_Query += " AND " + str_Filter;
                }

                SqlDataReader Dr = obj_DataAccess.GetRowWithQuery(str_Query);
                if (Dr != null)
                {
                    InitializePopup(Dr);
                }
                else
                {
                    if (grd_Popup != null)
                        grd_Popup.Hide();
                    //txt_Result.Text = "{هیچ موردی پیدا نشد}";
                    txt_Code.TextChanged -= new EventHandler(txt_Result_TextChanged);
                    txt_Code.Text = "";
                    txt_Code.TextChanged += new EventHandler(txt_Result_TextChanged);
                    txt_Result.Clear();
                    return;
                }
            }
            else//Use DataTable
            {
                if (DataSource == null) return;
                string str_NewFilter = str_Filter;
                if (str_Filter.Trim() != string.Empty)
                {
                    str_NewFilter += " AND ";
                }
                if (txt_Code.Text.Trim() != string.Empty)
                {
                    //if( ((BindingSource)_DataSource).
                    if (ToDataTable(DataSource).Columns[str_CodeField].DataType.Name == "String")
                        str_NewFilter += "[" + str_CodeField + "] LIKE '%" + txt_Code.Text + "%'";
                    else
                        str_NewFilter += "[" + str_CodeField + "] = " + txt_Code.Text;

                }
                ((BindingSource)_DataSource).Filter = str_NewFilter;
                InitializePopup((BindingSource)_DataSource);
            }
            txt_Code.Focus();
            txt_Code.SelectionStart = txt_Code.TextLength;
            txt_Code.SelectionLength = 0;

        }
        LookupForm frm;
        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (frm == null)
                frm = new LookupForm();
            frm = new LookupForm();
            frm.DataGridView.DataSource = this.DataSource;
            frm.Tag = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void txt_Result_Leave(object sender, EventArgs e)
        {
            if (frm_LookupText != null)
                frm_LookupText.Hide();
        }

        private DataTable ToDataTable(object DataSource)
        {
            return ((DataSet)((BindingSource)DataSource).DataSource).Tables[((BindingSource)DataSource).DataMember];
        }

        protected override void OnEnter(EventArgs e)
        {
            if (txt_Code.Visible)
                txt_Code.Focus();
            else
                txt_Result.Focus();
            base.OnEnter(e);
        }
        public void ResetResult()
        {
            Result = null;
        }

    }
}

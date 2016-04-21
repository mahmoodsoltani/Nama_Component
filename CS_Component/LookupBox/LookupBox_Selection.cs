using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS_Component;
using System.Drawing.Design;

namespace CS_Component
{
    public enum LookupSelectionMode { DataGridView, TreeView }
    public partial class LookupBox_Selection : UserControl
    {
        #region Member Fields

        private System.ComponentModel.IBindingList _DataSource;

        public CS_Component.DataGridView grd_Information;

        //private DataAccess obj_DataAccess;// = new DataAccess("Data Source=.;Initial Catalog=Nama_MIS;Integrated Security=False;User ID=sa;Password=123456", false);

        //private string str_DataFields;

        //string[] fields;

        //string[] aliases;

        private string str_ValueField;

        private string str_DisplayField;

        //private string str_AliasDisplay;

        //private string str_AliasCode;

        private string str_CodeField;

        //private string str_TableName;

        //private string str_Filter = "";

        public CS_Component.DataGridView grd_Popup;

        //private DataRow _SelectedDataRow;

        public System.Windows.Forms.LinkLabel lnk_New;

        public Form frm_LookupText;

        //private string str_HiddenColumnIndexes;

        private string str_Default;

        //private bool bol_DisplayCodeField = true;

        //private int int_CodeWidth;

        //private int int_ResultWidth = 90;

        #endregion

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

        private string str_ParentField;

        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ParentField
        {
            get { return str_ParentField; }
            set
            {
                str_ParentField = value;
                //((BindingSource)_DataSource).DataMember 
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


        public LookupBox_Selection()
        {
            InitializeComponent();
        }

        private void txt_Result_TextChanged(object sender, EventArgs e)
        {

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
            }
        }

        private CheckedListBox lbx_Popup;

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
            //frm_LookupText.Paint += new PaintEventHandler(frm_LookupText_Paint);
            frm_LookupText.ShowInTaskbar = false;
            frm_LookupText.Width =  txt_Result.Width + btn_Select.Width + 10;
            //InitLink();

        }


        private void InitializePopup(BindingSource DataSource)
        {
            InitializeLookup();
            if (lbx_Popup == null)
                lbx_Popup = new CheckedListBox();
            frm_LookupText.Controls.Add(lbx_Popup);
            frm_LookupText.Show();
            //lbx_Popup.DataSource = DataSource;            
            lbx_Popup.Top = 25;
            lbx_Popup.Left = 0;
            lbx_Popup.Height = 125;
            lbx_Popup.CheckOnClick = true;
            lbx_Popup.Width = frm_LookupText.Width;
            lbx_Popup.BorderStyle = BorderStyle.FixedSingle;
            lbx_Popup.ItemCheck += new ItemCheckEventHandler(lbx_Popup_ItemCheck);
            DataView Dt = (DataView)((BindingSource)_DataSource).List;
            if (lbx_Popup != null)
                lbx_Popup.Items.Clear();
            foreach (DataRow R in Dt.ToTable().Rows)
            {
                lbx_Popup.Items.Add(R[str_DisplayField]);
            }
        }

        private List<object> lst_SelectedItems;

        void lbx_Popup_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                lst_SelectedItems.Add(lst_SelectedItems[e.Index]);
            }
        }
        
        LookupForm_Selection frm;

        LookupForm_Selection_TreeView frm_T;

        private LookupSelectionMode _SelectionMode;

        public LookupSelectionMode SelectionMode
        {
            get { return _SelectionMode; }
            set { _SelectionMode = value; }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (_SelectionMode == LookupSelectionMode.DataGridView)
            {
                if (frm == null)
                    frm = new LookupForm_Selection();
                frm.Tag = this;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else
            {
                if (frm_T == null)
                    frm_T = new LookupForm_Selection_TreeView();
                frm_T.Tag = this;
                frm_T.StartPosition = FormStartPosition.CenterScreen;
                frm_T.ShowDialog();
            }
        }

    }
}

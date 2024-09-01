using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace CS_Component
{
    public class DataGridView : System.Windows.Forms.DataGridView
    {
        public event changed CellChange;

        public delegate void changed(object sender, KeyEventArgs e);

        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);

            //if (key == Keys.Enter)
            //{
            //    return this.ProcessRightKey(keyData);
            //}
            //else

            CellChange?.Invoke(this, new KeyEventArgs(key));
            if (keyData == Keys.Enter)
                return true;
            else
                return base.ProcessDialogKey(keyData);
        }

        //public new bool ProcessRightKey(Keys keyData)
        //{
        //    Keys key = (keyData & Keys.KeyCode);
        //    if (key == Keys.Enter)
        //    {
        //        if ((base.CurrentCell.ColumnIndex == (base.ColumnCount - 1)) && (base.CurrentCell.RowIndex == (base.RowCount - 1)))
        //        {
        //            ((BindingSource)base.DataSource).AddNew();
        //            base.CurrentCell = base.Rows[base.RowCount - 1].Cells[0];
        //            return true;
        //        }

        //        if ((base.CurrentCell.ColumnIndex == (base.ColumnCount - 1)) && (base.CurrentCell.RowIndex + 1 != base.NewRowIndex))
        //        {
        //            base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[0];
        //            return true;
        //        }
        //        return base.ProcessRightKey(keyData);
        //    }
        //    return base.ProcessRightKey(keyData);
        //}

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());

            //if (e.KeyCode == Keys.Enter)
            //{
            //    return this.ProcessRightKey(e.KeyData);
            //}
            CellChange?.Invoke(this, e);
            if (e.KeyData == Keys.Enter)
                return true;
            else
                return base.ProcessDataGridViewKey(e);
        }

        private int int_SearchColumnIndex = -1;
        //public bool Allow_Chang_SearchColumnIndex=true;
        private SearchPanel pnl;
        bool check_DataSource = false;
        DataGridViewCellStyle DataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle DataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle DataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle DataGridViewCellStyle4 = new DataGridViewCellStyle();
        DataGridViewCellStyle DataGridViewCellStyle5 = new DataGridViewCellStyle();
        private ContextMenuStrip Mnu_ShortCut;
        //bool _AlwaysShowSearchPanel = false;

        //public int SearchColumnIndex 
        //{ 
        //    get
        //    { 
        //        return int_SearchColumnIndex; 
        //    }
        //    set
        //    {
        //        int_SearchColumnIndex = value;
        //        if (value >= 0)
        //            Allow_Chang_SearchColumnIndex = false;
        //    }
        //}

        //public bool AlwaysShowSearchPanel
        //{
        //    get
        //    {
        //        return _AlwaysShowSearchPanel;
        //    }
        //    set
        //    {
        //        _AlwaysShowSearchPanel = value;

        //        if (this.pnl == null)
        //        {
        //            this.pnl = new SearchPanel();
        //            this.pnl.SearchTextChanged += new EventHandler(this.pnl_SearchTextChanged);
        //            this.pnl.Show();
        //            Application.DoEvents();
        //            this.pnl.Dock = DockStyle.Bottom;
        //            base.Controls.Add(this.pnl);
        //        }

        //        if (value)
        //            pnl.showClose = false;
        //        else
        //            pnl.showClose = true;
        //    }
        //}

        //public static void CellBorder(DataGridView dgv, int FirstColumn, int LastColumn, int Row, Color BackColor, Color BordersColor, float PenWidth, string Caption)
        //{
        //    bool _RightToLeft = false;
        //    if (dgv.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
        //        _RightToLeft = true;

        //    short VB_t_i2_L0 = (short)LastColumn;
        //    for (short j = (short)FirstColumn; j <= VB_t_i2_L0; j = (short)(j + 1))
        //    {
        //        dgv.Rows[Row].Cells[j] = new DataGridViewCellBorder();
        //        object[] VB_t_array_S1 = new object[] { Row };
        //        bool[] VB_t_array_S2 = new bool[] { true };
        //        if (VB_t_array_S2[0])
        //        {
        //            Row = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(VB_t_array_S1[0]), typeof(int));
        //        }
        //        NewLateBinding.LateSetComplex(NewLateBinding.LateGet(dgv, null, "Rows", VB_t_array_S1, null, null, VB_t_array_S2), null, "Cells", new object[] { j, new DataGridViewCellBorder() }, null, null, false, true);
        //        VB_t_array_S1 = new object[] { Row };
        //        VB_t_array_S2 = new bool[] { true };
        //        if (VB_t_array_S2[0])
        //        {
        //            Row = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(VB_t_array_S1[0]), typeof(int));
        //        }
        //        object[] VB_t_array_S4 = new object[] { j };
        //        bool[] VB_t_array_S5 = new bool[] { true };
        //        if (VB_t_array_S5[0])
        //        {
        //            j = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(VB_t_array_S4[0]), typeof(short));
        //        }
        //        DataGridViewCellBorder pCell = (DataGridViewCellBorder)NewLateBinding.LateGet(NewLateBinding.LateGet(dgv, null, "Rows", VB_t_array_S1, null, null, VB_t_array_S2), null, "Cells", VB_t_array_S4, null, null, VB_t_array_S5);
        //        pCell.LeftColumn = FirstColumn;
        //        pCell.RightColumn = LastColumn;
        //        pCell.Colors = BackColor;
        //        pCell.BordersColor = BordersColor;
        //        pCell.PenWidth = PenWidth;
        //        if (Caption != null)
        //        {
        //            pCell.ReadOnly = true;
        //        }
        //        else
        //        {
        //            pCell.ReadOnly = false;
        //        }
        //        pCell.Value = Caption;
        //        pCell.RightToLeft = _RightToLeft;
        //    }
        //}

        public DataGridView()
        {
            this.RightToLeft = RightToLeft.Inherit;
            base.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Hand;
            base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            base.RowHeadersWidth = 30;
            base.ReadOnly = false;
            this.DataGridViewCellStyle5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            base.AlternatingRowsDefaultCellStyle = this.DataGridViewCellStyle1;
            this.DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewCellStyle1.BackColor = SystemColors.Control;
            this.DataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            this.DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            this.DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            base.ColumnHeadersDefaultCellStyle = this.DataGridViewCellStyle1;
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewCellStyle2.BackColor = SystemColors.Window;
            this.DataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            this.DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            this.DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            base.DefaultCellStyle = this.DataGridViewCellStyle2;
            this.DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewCellStyle3.BackColor = SystemColors.Control;
            this.DataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            this.DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            this.DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            base.RowHeadersDefaultCellStyle = this.DataGridViewCellStyle3;
            this.DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Mnu_ShortCut = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem("جستجو", null, new EventHandler(this.OnMnuSearchClick));
            //ToolStripMenuItem item2 = new ToolStripMenuIte
            ToolStripMenuItem item2 = new ToolStripMenuItem("صدور اطلاعات به فایل", null, new EventHandler(Export_Click));
            ToolStripMenuItem item3 = new ToolStripMenuItem("ورود اطلاعات از فایل", null, new EventHandler(Import_Click));
            ToolStripMenuItem item4 = new ToolStripMenuItem("پرينت", null, new EventHandler(Print_Click));

            this.Mnu_ShortCut.Items.Add(item);
            this.Mnu_ShortCut.Items.Add(item2);
            this.Mnu_ShortCut.Items.Add(item3);
            this.Mnu_ShortCut.Items.Add(item4);
            this.ControlAdded += new ControlEventHandler(DataGridView_ControlAdded);
            //this.Mnu_ShortCut.Items.Add(item2);
            this.ContextMenuStrip = this.Mnu_ShortCut;
            this.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridView_DataBindingComplete);
        }

        void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn d in this.Columns)
            {
                if (this.DataSource is DataTable)
                {
                    if (d.DataPropertyName != "")
                    {
                        try
                        {
                            //if (((DataTable)this.DataSource).Columns[d.DataPropertyName].DataType.FullName == "System.Int64")
                            //  d.DefaultCellStyle.Format = "N0";
                        }
                        catch { }
                    }
                }
                else if (this.DataSource is BindingSource)
                    if (d.DataPropertyName != "")
                    {
                        try
                        {
                            if (((DataView)((BindingSource)this.DataSource).List).Table.Columns[d.DataPropertyName].DataType.FullName == "System.Int64")
                            {
                                //   d.DefaultCellStyle.Format = "N0";
                            }
                        }
                        catch { }
                    }
            }
        }

        void DataGridView_ControlAdded(object sender, ControlEventArgs e)
        {
            if (pnl != null)
                pnl.Focus();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Export();
        }

        public void Print_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;
            CS_Component.PrintDGV.Print_DataGridView(this);
        }

        public void Export()
        {
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\SavedGrid"))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\SavedGrid");
            saveAdress = Application.StartupPath + "\\SavedGrid\\" + this.FindForm().Name + "_" + this.Name + ".Xml";
            ((DataView)((BindingSource)this.DataSource).List).Table.WriteXml(saveAdress);
        }

        string saveAdress = "";

        private void Import_Click(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Import();
        }

        public bool Import()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Application.StartupPath + "\\SavedGrid";
            op.Filter = "Xml File|*.Xml";
            op.Multiselect = false;
            if (saveAdress != "")
                op.FileName = saveAdress;
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return false;
            saveAdress = op.FileName;
            ((DataView)((BindingSource)this.DataSource).List).Table.ReadXml(saveAdress);
            System.IO.File.Delete(op.FileName);
            saveAdress = "";
            return true;
        }

        private void InitializeSearchPanel(string ColumnIndex)
        {
            //if (Allow_Chang_SearchColumnIndex)
            //    this.int_SearchColumnIndex = ColumnIndex;

            if (ColumnIndex == "")
                return;

            if (this.pnl == null)
                this.pnl = new SearchPanel();
            this.pnl.SearchTextChanged += new EventHandler(this.pnl_SearchTextChanged);
            this.pnl.Show();
            this.pnl.SearchField = base.Columns[ColumnIndex].DataPropertyName;
            this.pnl.Dock = DockStyle.Bottom;
            base.Controls.Add(this.pnl);
            //if (typeof(DataSource) is System.Data.DataTable)
            //    DtSource = true;
            //else
            //    DtSource = false;
            if (!check_DataSource)
            {
                try
                {
                    string s = ((System.Data.DataTable)(DataSource)).DefaultView.RowFilter;
                    DtSource = true;
                }
                catch
                {
                    DtSource = false;
                }
                check_DataSource = true;
            }
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            //if (Allow_Chang_SearchColumnIndex)
            int_SearchColumnIndex = e.ColumnIndex;
            //this.InitializeSearchPanel(this.int_SearchColumnIndex);
            base.OnCellClick(e);
            //int i = 0;
            //i = 0 / i;
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //if (Allow_Chang_SearchColumnIndex)
            int_SearchColumnIndex = e.ColumnIndex;
            base.OnColumnHeaderMouseClick(e);
        }

        protected override void OnColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            if (e.Clicks != 1)
            {
                //if (Allow_Chang_SearchColumnIndex)
                int_SearchColumnIndex = e.ColumnIndex;
                this.InitializeSearchPanel(this.Columns[int_SearchColumnIndex].Name);
            }
            else
            {
                base.OnColumnHeaderMouseDoubleClick(e);
            }
        }

        private void OnMnuSearchClick(object sender, EventArgs e)
        {
            if (base.CurrentRow != null)
            {
                try
                {
                    this.InitializeSearchPanel(this.Columns[int_SearchColumnIndex].Name);
                }
                catch
                {
                    foreach (DataGridViewColumn d in this.Columns)
                    {
                        if (d.Visible)
                        {
                            this.InitializeSearchPanel(d.Name);
                            break;
                        }
                    }
                }
            }
        }

        bool DtSource = false;

        private void pnl_SearchTextChanged(object sender, EventArgs e)
        {
            //if (!check_DataSource)
            //{
            //    //if (!Allow_Chang_SearchColumnIndex)
            //        InitializeSearchPanel(int_SearchColumnIndex);
            //}   
            // int_SearchColumnIndex += invisibleIndex;
            //int i = 0;
            //i = 0 / i;
            //pnl.SearchText=pnl.SearchText.Replace("ك", "ک").Replace("ي", "ی")
            try
            {
                if (DtSource)
                {
                    if (this.pnl.SearchText.Trim() == "")
                        ((System.Data.DataTable)(DataSource)).DefaultView.RowFilter = "";
                    else if (((System.Data.DataTable)(DataSource)).DefaultView.Table.Columns[int_SearchColumnIndex].DataType.ToString().Equals("System.String"))
                        ((System.Data.DataTable)(DataSource)).DefaultView.RowFilter = "[" + ((System.Data.DataTable)(DataSource)).DefaultView.Table.Columns[int_SearchColumnIndex].ColumnName + "] like '%" + this.pnl.SearchText.Trim() + "%'";
                    else if (((System.Data.DataTable)(DataSource)).DefaultView.Table.Columns[int_SearchColumnIndex].DataType.ToString().Equals("System.Int32"))
                        ((System.Data.DataTable)(DataSource)).DefaultView.RowFilter = "[" + ((System.Data.DataTable)(DataSource)).DefaultView.Table.Columns[int_SearchColumnIndex].ColumnName + "] >= " + this.pnl.SearchText.Trim();

                }
                else
                {
                    if (this.pnl.SearchText.Trim() == "")
                        ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List).RowFilter = "";

                    else if (((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List)
                   .Table.Columns[int_SearchColumnIndex].DataType.ToString().Equals("System.String"))

                        ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List).RowFilter
                            = "[" + ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List)
                            .Table.Columns[int_SearchColumnIndex].ColumnName + "] like '%" + this.pnl.SearchText.Trim() + "%'";

                    else if (((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List)
                        .Table.Columns[int_SearchColumnIndex].DataType.ToString().Equals("System.Int32")
                        || ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List)
                        .Table.Columns[int_SearchColumnIndex].DataType.ToString().Equals("System.Double"))

                        ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List).RowFilter
                            = "[" + ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List)
                            .Table.Columns[int_SearchColumnIndex].ColumnName + "] >= " + this.pnl.SearchText.Trim();
                    else
                        ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List).RowFilter
    = "[" + ((DataView)((System.Windows.Forms.BindingSource)(DataSource)).List)
    .Table.Columns[int_SearchColumnIndex].ColumnName + "] = " + this.pnl.SearchText.Trim();

                }
            }
            catch
            {
            }
        }

        public void ShowSearchBar(int index)
        {
            InitializeSearchPanel(this.Columns[index].Name);
        }
    }
}


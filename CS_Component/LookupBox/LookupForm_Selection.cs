using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS_Component
{
    public partial class LookupForm_Selection : CS_Component.CustomUIForm 
    {
        public LookupForm_Selection()
        {
            InitializeComponent();
        }

        private void LookupForm_Selection_Load(object sender, EventArgs e)
        {
            LookupBox_Selection lkb = (LookupBox_Selection)this.Tag;
            dataGridView1.DataSource = lkb.DataSource;
            dataGridView1.Columns[lkb.ValueField].Visible = false;
            int i = 0;
            comboBox1.Items.Clear();

            foreach (DataGridViewColumn DGVC in dataGridView1.Columns)
            {
                DGVC.ReadOnly = true;
                DGVC.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                if (DGVC.Visible)
                {
                    comboBox1.Items.Add(DGVC.HeaderText);
                    if (lkb.DefaultSearchField == DGVC.HeaderText)
                    {
                        i = comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    }
                }
            }
            comboBox1.SelectedIndex = i;
            if (dataGridView1.Columns["checking"] == null)
            {
                DataGridViewColumn dc = new DataGridViewColumn(new DataGridViewCheckBoxCell());
                dc.Name = "checking";
                dc.HeaderText = "";
                dc.ValueType = typeof(Boolean);
                dc.Width = 20;
                dataGridView1.Columns.Insert(0, dc);
            }
            dataGridView1.Columns[lkb.DisplayField].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            LookupBox_Selection lkb=(LookupBox_Selection)this.Tag;
            DataTable Dt = ((DataView)((BindingSource)lkb.DataSource).List).Table;
            if (Dt.Columns[comboBox1.Text].DataType.FullName == "System.String")
            {
                ((BindingSource)dataGridView1.DataSource).Filter = "["+comboBox1.Text+"] LIKE '"+txt_Search.Text+"%'";
            }
        }

        private void LookupForm_Selection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'ی')
            {
                e.KeyChar = 'ي';
            }            
            else if (e.KeyChar == 'ك')
            {
                e.KeyChar = 'ک';
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        List<DataRow> lst_Rows;

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (lst_Rows == null)
                lst_Rows = new List<DataRow>();
            string str_Selected = ""; 
            LookupBox_Selection lkb=(LookupBox_Selection)Tag;   
            foreach (DataGridViewRow R in dataGridView1.Rows)
            {
                if (R.Cells["checking"].Value != null)
                if((bool)R.Cells["checking"].Value)
                {
                    DataRow dr = ((DataView)((BindingSource)dataGridView1.DataSource).List)[dataGridView1.Rows.IndexOf(R)].Row;
                    lst_Rows.Add(dr);
                    str_Selected += dr[lkb.DisplayField] + "، ";
                }
            }
            if (str_Selected.EndsWith("، "))
                str_Selected=str_Selected.Remove(str_Selected.Length - 2, 2);
            lkb.txt_Result.Text = str_Selected;
            Hide();
        }

        public List<DataRow> Result
        {
            get { return lst_Rows; }
        }

        private void LookupForm_Selection_Activated(object sender, EventArgs e)
        {
            LookupBox_Selection lkb = (LookupBox_Selection)Tag;
            if (lst_Rows != null)
                foreach (DataRow dr in lst_Rows)
                {
                    foreach (DataGridViewRow R in dataGridView1.Rows)
                    {
                        if (R.Cells[lkb.ValueField].Value.ToString() == dr[lkb.ValueField].ToString())
                        {
                            R.Cells["checking"].Value = true;
                        }
                    }
                }
        }
    }
}

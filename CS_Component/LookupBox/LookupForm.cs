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
    public partial class LookupForm : CS_Component.CustomUIForm
    {
        public LookupForm()
        {
            InitializeComponent();
        }

        public CS_Component.DataGridView DataGridView
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }

        private void LookupForm_Load(object sender, EventArgs e)
        {
            if (Tag == null) return;
            LookupBox lkb = (LookupBox)Tag;
            ((BindingSource)dataGridView1.DataSource).Filter = lkb.Filter;
            dataGridView1.Columns[lkb.ValueField].Visible = false;
            dataGridView1.Columns[lkb.DisplayField].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (!string.IsNullOrEmpty(lkb.HiddenFields))
            {
                foreach (string s in lkb.HiddenFields.Split(','))
                {
                    if (s != "")
                    {
                        int idx = -1;
                        if (int.TryParse(s, out idx) && idx >= 0)
                        {
                            if (dataGridView1.Columns.Count - 1 < idx)
                                return;
                            dataGridView1.Columns[idx].Visible = false;
                        }
                    }
                }
            }
            comboBox1.Items.Clear();
            int int_Index=-1;
            List<DataGridViewColumn> lst = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
                if (dc.Visible)
                    lst.Add(dc);
            foreach (DataGridViewColumn dc in lst)
            {                
                if (dc.Visible)
                {
                    comboBox1.Items.Add(dc.HeaderText);
                    if (dc.DataPropertyName == lkb.DefaultSearchField)
                        int_Index = lst.IndexOf(dc);
                }
            }            
            comboBox1.SelectedIndex = int_Index;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            LookupBox lkb = (LookupBox)this.Tag;
            string str_Filter = "";
            //((BindingSource)dataGridView1.DataSource).Filter = lkb.Filter;
            if (!string.IsNullOrEmpty(lkb.Filter))
                str_Filter += lkb.Filter+" AND ";            
            if(ToDataTable(dataGridView1.DataSource).Columns[comboBox1.Text].DataType.Name=="String")
                str_Filter+= "["+comboBox1.Text + "] LIKE '%"+textBox1.Text+"%'";
            else
                str_Filter += "[" + comboBox1.Text + "] = " + textBox1.Text;
             ((BindingSource)dataGridView1.DataSource).Filter = str_Filter;
        }

        private DataTable ToDataTable(object DataSource)
        {
            return ((DataSet)((BindingSource)dataGridView1.DataSource).DataSource).Tables[((BindingSource)dataGridView1.DataSource).DataMember];
        }

        private void LookupForm_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void LookupForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    if (dataGridView1.CurrentRow == null)
                        return;
                    ((LookupBox)Tag).Result = ((DataRowView)((BindingSource)dataGridView1.DataSource)[dataGridView1.CurrentRow.Index]).Row;
                    Hide();
                    break;
                case Keys.Escape:
                    Hide();
                    break;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            ((LookupBox)Tag).Result = ((DataRowView)((BindingSource)dataGridView1.DataSource)[dataGridView1.CurrentRow.Index]).Row;
            Hide();
        }

    }
}

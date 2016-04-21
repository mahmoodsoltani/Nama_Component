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
    public partial class LookupForm_Selection_TreeView : CS_Component.CustomUIForm 
    {
        public LookupForm_Selection_TreeView()
        {
            InitializeComponent();
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

        private void LookupForm_Selection_TreeView_Load(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0)
            {

                LookupBox_Selection Lkb = (LookupBox_Selection)Tag;
                DataTable Dt = ((DataView)((BindingSource)Lkb.DataSource).List).Table;
                foreach (DataRow Dr in Dt.Rows)
                {
                    if ((int)Dr[Lkb.ParentField] == 0)
                    {
                        TreeNode Tn = new TreeNode();
                        Tn.Text = "[" + Dr[Lkb.CodeField].ToString() + "] " + Dr[Lkb.DisplayField].ToString();
                        Tn.Tag = Dr;
                        Tn.Nodes.Add("");
                        foreach (object o in lst_Result)
                        {
                            if (o.ToString() == Dr[Lkb.ValueField].ToString())
                            {
                                Tn.Checked = true;
                            }
                        }
                        treeView1.Nodes.Add(Tn);
                    }
                }
            }
        }

        private void MakeNodes(TreeNode Tn,DataTable Dt, DataRow Dr)
        {
            foreach (DataRow Drr in Dt.Rows)
            {
                TreeNode Tnn = new TreeNode();
                Tn.Text = "[" + Dr["Code"].ToString() + "] " + Dr["Display"].ToString();
                Tn.Nodes.Add(Tnn);
                if (Drr["Parent_Field"].ToString() == Dr["ValueField"].ToString())
                { 
                    
                }
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null) return;
            e.Node.Nodes.Clear();
            DataRow Dr = (DataRow)e.Node.Tag;
            LookupBox_Selection Lkb = (LookupBox_Selection)Tag;
            DataTable Dt = ((DataView)((BindingSource)Lkb.DataSource).List).Table;
            foreach (DataRow Drr in Dt.Rows)
            {
                if (Drr[Lkb.ParentField].ToString() == Dr[Lkb.ValueField].ToString())
                {
                    e.Node.Nodes.Add("[" + Drr[Lkb.CodeField].ToString() + "] " + Drr[Lkb.DisplayField].ToString());
                    e.Node.Nodes[e.Node.Nodes.Count - 1].Tag = Drr;
                    e.Node.Nodes[e.Node.Nodes.Count - 1].Nodes.Add("");

                    foreach (object o in lst_Result)
                    {
                        if (o.ToString() == Drr[Lkb.ValueField].ToString())
                        {
                            e.Node.Nodes[e.Node.Nodes.Count-1].Checked = true;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        List<object> lst_Result = new List<object>();

        public List<object> Result
        {
            get { return lst_Result; }
            set { lst_Result = value; }
        }

        private string str_Text="";

        private void button1_Click(object sender, EventArgs e)
        {
            MakeList();            
            LookupBox_Selection lkb = (LookupBox_Selection)Tag;
            str_Text = "";
            foreach (TreeNode Tn in lst_Nodes)
            {
                if(Tn.Checked)
                if (Tn.Tag != null)
                {
                    lst_Result.Add(((DataRow)Tn.Tag)[lkb.ValueField]);
                    str_Text += ((DataRow)Tn.Tag)[lkb.DisplayField].ToString() + ", ";
                }
            }
//            foreach (TreeNode Tn in treeView1.Nodes)
            //{
                //if (Tn.Checked)
                //{
                    //lst_Result.Add(((DataRow)Tn.Tag)[lkb.ValueField]);
                    //str_Text += ((DataRow)Tn.Tag)[lkb.DisplayField].ToString()+", ";
                //}
            //}
            if (str_Text.EndsWith(", "))
                str_Text = str_Text.Remove(str_Text.Length - 2, 2);            
            lkb.txt_Result.Text = str_Text;
            Hide();
        }

        private List<TreeNode> lst_Nodes = new List<TreeNode>();

        private void MakeList()
        {
            lst_Nodes.Clear();
            foreach (TreeNode T in treeView1.Nodes)
            {
                AddNodes(T);
            }
        }

        private void AddNodes(TreeNode Tn)
        {
            lst_Nodes.Add(Tn);
            if (Tn.Nodes.Count != 0)
            {
                foreach (TreeNode T in Tn.Nodes)
                    AddNodes(T);
            }
        }
    }
}

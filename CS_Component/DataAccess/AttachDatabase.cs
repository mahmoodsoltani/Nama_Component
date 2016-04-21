using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Configuration;

namespace CS_Component
{
    public partial class AttachDatabase : Form
    {
        string ConnectionStr = "";

        public AttachDatabase(string dbName)
        {
            InitializeComponent();
            TxtDbname.Text = dbName;
        }

        public bool AttachDB(string dbname, string MdfFile, string LdfFile)
        {
            SqlConnection SqlConn = new SqlConnection(ConnectionStr);
            SqlCommand SqlComm = new SqlCommand("sp_attach_db", SqlConn);
            SqlComm.CommandType = CommandType.StoredProcedure;
            SqlComm.Parameters.AddWithValue("@dbname", dbname);
            SqlComm.Parameters.AddWithValue("@filename1", MdfFile);
            SqlComm.Parameters.AddWithValue("@filename2", LdfFile);
            try
            {
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                SqlConn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void AttachDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            SqlConnectionStringBuilder sqlcnbl = new SqlConnectionStringBuilder();
            sqlcnbl.DataSource = cmb_ServerName.Text;
            if (!chk_Trusted.Checked)
            {
                sqlcnbl.IntegratedSecurity = false;
                sqlcnbl.UserID = txtUID.Text;
                sqlcnbl.Password = txtPWD.Text;
            }
            else
                sqlcnbl.IntegratedSecurity = true;

            //ConnectionStr = "server=" + cmb_ServerName.Text + ";trusted_connection=true;database=";
            ConnectionStr = sqlcnbl.ConnectionString;
            SqlConnection sqlConn = new SqlConnection(ConnectionStr);
            try
            {
                sqlConn.Open();
            }
            catch (SqlException errSQL)
            {
                MessageBox.Show("Connection to this server was failed reason :\n" + errSQL.Message
                    + "\ncheck the spelling of server name or check username and pass is valid on this server", "Error");
            }
            btnConnect.Enabled = true;
            Gp_FileAdress.Enabled = true;
        }

        private void btn_SelectMdfFile_Click(object sender, EventArgs e)
        {
            DlgOpen.Filter = "MDF Files|*.Mdf";
            if (DlgOpen.ShowDialog() == DialogResult.OK)
            {
                TxtMdf.Text = DlgOpen.FileName;
                if (TxtMdf.Text.Contains("_Data.MDF"))
                    TxtLdf.Text = DlgOpen.FileName.Replace("_Data.MDF", "_Log.LDF");
            }
            DlgOpen.Filter = "";
        }

        private void btn_SelectLdfFile_Click(object sender, EventArgs e)
        {
            DlgOpen.Filter = "LDF Files|*.Ldf";
            if (DlgOpen.ShowDialog() == DialogResult.OK)
                TxtLdf.Text = DlgOpen.FileName;
            DlgOpen.Filter = "";
        }

        private void btn_AttachDb_Click(object sender, EventArgs e)
        {
            if (AttachDB(TxtDbname.Text, TxtMdf.Text, TxtLdf.Text))
            {
                MessageBox.Show("بانک مورد نظر با موفقیت افزوده شد");
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chk_Trusted_CheckedChanged(object sender, EventArgs e)
        {
            txtUID.Enabled = !chk_Trusted.Checked;
            txtPWD.Enabled = !chk_Trusted.Checked;
        }

        private void AttachDatabase_Load(object sender, EventArgs e)
        {
            chk_Trusted.Checked = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;;

namespace CS_Component 
{
    public partial class DeAttachDatase : Form
    {
        public DeAttachDatase()
        {
            InitializeComponent();
        }

        private void Deta_Click(object sender, EventArgs e)
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
    }
}

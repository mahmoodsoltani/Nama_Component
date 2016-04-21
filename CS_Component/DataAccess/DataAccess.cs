using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;

namespace CS_Component
{
    public class DataAccess
    {
        public DataAccess(string ConnectionString, [Optional, DefaultParameterValue(false)] bool ShowAttachWizard)
        {
            //if (VB_Component.Windows.ArrayOfString(ConnectionString))
            // return;

            this.ConnectionString = ConnectionString;
            Global_Sqlcn = new SqlConnection(ConnectionString);
            //Global_SqlcnReader = new SqlConnection(ConnectionString);
            while (true)
            {
                try
                {
                    if (Global_Sqlcn.State != ConnectionState.Open) Global_Sqlcn.Open();
                    //if (Global_SqlcnReader.State != ConnectionState.Open) Global_SqlcnReader.Open();
                    break;
                }
                catch (Exception es)
                {
                    Message_Exeption(es);
                    if (ShowAttachWizard)
                    {
                        SqlConnectionStringBuilder cninfo = new SqlConnectionStringBuilder();
                        cninfo.ConnectionString = ConnectionString;
                        if (new AttachDatabase(cninfo.InitialCatalog).ShowDialog() == DialogResult.Cancel)
                            CloseOnAttach = true;
                    }
                    break;
                }
            }
        }

        #region Fields
        string ConnectionString = "";
        SqlConnection Global_Sqlcn;
        //SqlConnection Global_SqlcnReader;
        SqlTransaction transaction = null;
        public bool CloseOnAttach = false;
        public enum LikeLocation
        {
            Start = 1,
            End = 2,
            Any = 3
        }
        #endregion

        public void CheckOpenConnection()
        {
            if (Global_Sqlcn.State != ConnectionState.Open) Global_Sqlcn.Open();
        }

        #region NewRow
        public DataRow NewRow(string TableName)
        {
            try
            {
                CheckOpenConnection();
                using (DataSet ds = new DataSet())
                using (SqlCommand cmd = new SqlCommand("select top 1 * from [" + TableName + "]", Global_Sqlcn))
                {
                    if (transaction != null)
                        cmd.Transaction = transaction;
                    using (SqlDataAdapter sqlda = new SqlDataAdapter(cmd))
                        sqlda.FillSchema(ds, SchemaType.Source, TableName);
                    return ds.Tables[0].NewRow();
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }
        #endregion

        #region Connect DisConnect ClearPool CreateCommand
        public ConnectionState ConnectionState
        {
            get { return Global_Sqlcn.State; }
        }

        public bool Connect()
        {
            try
            {
                CheckOpenConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DisConnect()
        {
            try
            {
                if (Global_Sqlcn.State != ConnectionState.Closed) Global_Sqlcn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClearPool()
        {
            SqlConnection.ClearPool(Global_Sqlcn);
        }

        public SqlCommand CreateCommand()
        {
            return Global_Sqlcn.CreateCommand();
        }

        #endregion

        #region transaction
        public bool BeginTransaction()
        {
            if (transaction != null)
                return false;

            try
            {
                transaction = Global_Sqlcn.BeginTransaction(IsolationLevel.ReadUncommitted);
                return true;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        public bool Commit()
        {
            if (transaction == null)
                return false;

            try
            {
                transaction.Commit();
                transaction = null;
                return true;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        public bool RollBack()
        {
            if (transaction == null)
                return false;

            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }
        #endregion

        #region FirstEmptyFeild
        public int FirstEmptyFeild(string TableName, string FielsName, string Condition)
        {
            try
            {
                DataTable dt = GetDataTable("select " + FielsName + " from " + TableName + " where " + Condition);

                if (dt.Rows.Count == 0)
                    return 1;
                else
                    return int.Parse(dt.Compute("max ([" + FielsName + "])", "").ToString()) + 1;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return -1;
            }
        }

        public int FirstEmptyFeild(DataTable dt, string FaFielsName, string EnFieldName)
        {

            CheckOpenConnection();
            string sqltxt = "declare @i as int \n" +
                        " set @i=1 \n" +
                        " WHILE (@i<" + dt.Compute("Count ([" + FaFielsName + "])", "").ToString() + ") \n" +
                        " BEGIN \n" +
                        " IF NOT EXISTS(SELECT CAST([" + EnFieldName + "] AS int) AS code FROM  " + dt.TableName + "  WHERE (CAST([" + EnFieldName + "] AS int) = @i)) \n" +
                        " BEGIN \n" +
                        " set @RET_VALUE=@i \n" +
                        " BREAK \n" +
                        " END \n" +
                        " ELSE \n" +
                        " set @i=@i+1 \n" +
                        " END ";

            using (SqlCommand sqlcm = new SqlCommand(sqltxt, Global_Sqlcn))
            {
                SqlParameter sqlp = new SqlParameter("@RET_VALUE", SqlDbType.Int, 4);
                sqlp.Direction = ParameterDirection.Output;
                sqlcm.Parameters.Add(sqlp);
                if (transaction != null)
                    sqlcm.Transaction = transaction;
                sqlcm.ExecuteNonQuery();

                return int.Parse(sqlcm.Parameters["@RET_VALUE"].Value.ToString());
            }
        }

        public int FirstEmptyFeild(System.Windows.Forms.DataGridView dg, int ClomnIndex, int beginNumber)
        {
            int temp = 1 + beginNumber;
            try
            {
                dg.Sort(dg.Columns[ClomnIndex], System.ComponentModel.ListSortDirection.Ascending);
                for (int i = beginNumber; i < dg.Rows.Count + beginNumber; i++)
                {
                    if (int.Parse(dg.Rows[i - beginNumber].Cells[ClomnIndex].Value.ToString()) != temp)
                        return temp;
                    temp++;
                }
                return temp;
            }
            catch
            {
                return -1;
            }
        }

        public int FirstEmptyFeild(DataTable dt, int ClomnIndex, int beginNumber)
        {
            int temp = 1 + beginNumber;
            try
            {
                dt.DefaultView.Sort = dt.Columns[ClomnIndex].ColumnName;
                dt = dt.DefaultView.ToTable();
                for (int i = beginNumber; i < dt.Rows.Count + beginNumber; i++)
                {
                    if (int.Parse(dt.Rows[i - beginNumber][ClomnIndex].ToString()) != temp)
                        return temp;
                    temp++;
                }
                return temp;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region ExecQuery
        public SqlDataReader ExecReader(string Query)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConnectionString)))
                {
                    cmd.Connection.Open();
                    return cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public bool ExecQuery(string Query)
        {
            CheckOpenConnection();

            try
            {
                using (SqlCommand cmd = new SqlCommand(Query, Global_Sqlcn))
                {
                    if (transaction != null)
                        cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        public object ExecScalar(string Query)
        {
            CheckOpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand(Query, Global_Sqlcn))
                {
                    if (transaction != null)
                        cmd.Transaction = transaction;
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public object ExecScalar(SqlCommand sqlcm)
        {
            CheckOpenConnection();
            try
            {
                sqlcm.Connection = Global_Sqlcn;
                return sqlcm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public bool ExecQuery(SqlCommand sqlcm)
        {
            CheckOpenConnection();
            try
            {
                if (transaction != null)
                    sqlcm.Transaction = transaction;
                sqlcm.Connection = Global_Sqlcn;
                sqlcm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }
        #endregion

        #region FindMax
        public int FindMax(string tableName, string FieldNameToFindMax, string Condition, bool SurroundWith)
        {
            if (SurroundWith)
            {
                try
                {
                    string sqltxt = "SELECT ISNULL(MAX(cast([" + FieldNameToFindMax + "] as int)), 0)+1 AS MaxSrl FROM " + tableName;
                    if (!string.IsNullOrEmpty(Condition)) sqltxt += " Where " + Condition;
                    return int.Parse(ExecScalar(sqltxt).ToString());
                }
                catch (System.Exception e)
                {
                    Message_Exeption(e);
                    return -1;
                }
            }
            else
            {
                try
                {
                    string sqltxt = "SELECT ISNULL(MAX(cast(" + FieldNameToFindMax + ")), 0)+1 AS MaxSrl FROM " + tableName;
                    if (!string.IsNullOrEmpty(Condition)) sqltxt += " Where " + Condition;
                    return int.Parse(ExecScalar(sqltxt).ToString());
                }
                catch (System.Exception e)
                {
                    Message_Exeption(e);
                    return -1;
                }
            }

        }

        public int FindMax(string tableName, string FieldNameToFindMax, string Condition)
        {
            try
            {
                string sqltxt = "SELECT ISNULL(MAX(cast([" + FieldNameToFindMax + "] as int)), 0)+1 AS MaxSrl FROM " + tableName;
                if (!string.IsNullOrEmpty(Condition)) sqltxt += " Where " + Condition;
                return int.Parse(ExecScalar(sqltxt).ToString());
            }
            catch (System.Exception e)
            {
                Message_Exeption(e);
                return -1;
            }
        }

        public int FindMax(string tableName)
        {
            try
            {
                return int.Parse(ExecScalar(
                    "SELECT ISNULL(MAX(cast(" + NewRow(tableName).Table.PrimaryKey[0].ColumnName + " as int)),0)+1 AS MaxSrl FROM " + tableName).ToString());
            }
            catch (System.Exception e)
            {
                Message_Exeption(e);
                return -1;
            }
        }

        public int FindMax(string tableName, string FieldNameToFindMax)
        {
            try
            {
                return int.Parse(ExecScalar("SELECT  ISNULL(MAX(cast(" + FieldNameToFindMax + " as int)), 0)+1 AS MaxSrl FROM " + tableName).ToString());
            }
            catch (System.Exception e)
            {
                Message_Exeption(e);
                return -1;
            }
        }
        #endregion

        #region Message_Exeption

        public static bool Message_Exeption(Exception ex)
        {
            try
            {
                switch (((System.Data.SqlClient.SqlException)ex).Number)
                {
                    case 17:
                    case 17142:
                    case 11:
                        MessageBox.Show("ارتباط با بانک اطلاعاتی قطع شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 547:
                        MessageBox.Show("این اطلاعات به علت به کار رفتن در قسمتی دیگر از سیستم قابل حذف نیست", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2627:
                        MessageBox.Show("اين کد قبلا ثبت شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Delete
        public bool Delete(string TableName)
        {
            try
            {
                if (ExecQuery("delete from " + TableName))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }
        public bool Delete(string TableName, int Srl)
        {
            try
            {
                if (ExecQuery("delete from " + TableName + " where srl=" + Srl.ToString()))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        public bool Delete(string TableName, string Condition)
        {
            try
            {
                if (ExecQuery("delete from " + TableName + " where " + Condition))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }
        #endregion

        #region Insert
        public bool Insert(DataRow dr, bool Promt)
        {
            //if (VB_Component.Windows.ArrayOfString("temp")) return false;

            if (dr == null) return false;

            string sqltxt = "INSERT INTO " + dr.Table.TableName + "(";
            string sqltxt1 = ") VALUES (";

            using (SqlCommand sqlcm = new SqlCommand())
            {
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    if (dr.Table.Columns[i].AutoIncrement)
                        continue;

                    if (dr.Table.PrimaryKey.Length != 0)
                    {
                        if (dr.Table.PrimaryKey[0].ColumnName == dr.Table.Columns[i].Caption.ToString())
                            sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), FindMax(dr.Table.TableName));
                    }
                    if (dr.Table.Columns[i].DataType == typeof(Int16))
                    {
                        SqlParameter param = new SqlParameter("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);
                        param.SqlDbType = SqlDbType.Image;
                        sqlcm.Parameters.Add(param);
                    }
                    else
                        sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);

                    if (i != dr.Table.Columns.Count - 1)
                    {
                        sqltxt += "[" + dr.Table.Columns[i].Caption + "] ,";
                        sqltxt1 += "@" + dr.Table.Columns[i].Caption + " ,";
                    }
                    else
                    {
                        sqltxt += "[" + dr.Table.Columns[i].Caption + "] ";
                        sqltxt1 += "@" + dr.Table.Columns[i].Caption;
                    }
                }

                sqltxt1 += ") ";
                sqltxt += sqltxt1;
                sqlcm.CommandText = sqltxt;
                try
                {
                    if (!ExecQuery(sqlcm))
                        return false;
                    if (Promt)
                        MessageBox.Show("ذخيره سازي با موفقيت انجام شد");
                    return true;
                }
                catch (Exception ex)
                {
                    Message_Exeption(ex);
                    return false;
                }
            }
        }

        public int InsertWithLastId(DataRow dr, bool Promt)
        {
            if (dr == null) return -1;

            string sqltxt = "INSERT INTO [" + dr.Table.TableName + "] (";
            string sqltxt1 = ") VALUES (";

            using (SqlCommand sqlcm = new SqlCommand())
            {
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    if (dr.Table.Columns[i].AutoIncrement) continue;

                    if (dr.Table.PrimaryKey.Length != 0)
                    {
                        if (dr.Table.PrimaryKey[0].ColumnName == dr.Table.Columns[i].Caption.ToString())
                            sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), FindMax(dr.Table.TableName));
                        else
                            if (dr.Table.Columns[i].DataType == typeof(Int16))
                            {
                                SqlParameter param = new SqlParameter("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);
                                param.SqlDbType = SqlDbType.Image;
                                sqlcm.Parameters.Add(param);
                            }
                            else
                                sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);
                    }

                    if (i != dr.Table.Columns.Count - 1)
                    {
                        sqltxt += "[" + dr.Table.Columns[i].Caption + "] ,";
                        sqltxt1 += "@" + dr.Table.Columns[i].Caption + " ,";
                    }
                    else
                    {
                        sqltxt += "[" + dr.Table.Columns[i].Caption + "] ";
                        sqltxt1 += "@" + dr.Table.Columns[i].Caption;
                    }
                }

                sqltxt1 += ") ";
                sqltxt += sqltxt1;
                sqltxt += "\r\n select @scope=CAST(SCOPE_IDENTITY() AS INT)";
                sqlcm.CommandText = sqltxt;

                SqlParameter sqlp = new SqlParameter("@scope", SqlDbType.Int, 4);
                sqlp.Direction = ParameterDirection.Output;
                sqlcm.Parameters.Add(sqlp);

                try
                {
                    if (!ExecQuery(sqlcm))
                        return -1;
                    if (Promt)
                        MessageBox.Show("ذخيره سازي با موفقيت انجام شد");
                    return int.Parse(sqlcm.Parameters["@scope"].Value.ToString());
                }
                catch (Exception ex)
                {
                    Message_Exeption(ex);
                    return -1;
                }
            }
        }
        #endregion

        #region Update
        public bool Update(DataRow dr, int ConditionFieldIndexInDataRow, [Optional, DefaultParameterValue(false)] bool Prompt)
        {
            if (dr == null) return false;

            using (SqlCommand sqlcm = new SqlCommand())
            {
                string sqltxt = "UPDATE  " + dr.Table.TableName + " set ";

                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    //if (dr[i].ToString().Trim() == "") continue;
                    if (i == ConditionFieldIndexInDataRow) continue;

                    sqltxt += "[" + dr.Table.Columns[i].Caption + "] = " + "@" + dr.Table.Columns[i].Caption + ",";
                    if (dr.Table.Columns[i].DataType == typeof(System.Byte[]))
                    {
                        SqlParameter param = new SqlParameter("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);
                        param.SqlDbType = SqlDbType.Image;
                        sqlcm.Parameters.Add(param);
                    }
                    else
                        sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);

                }

                if (sqltxt.TrimEnd()[sqltxt.Length - 1] == ',')
                {
                    sqltxt = sqltxt.TrimEnd();
                    sqltxt = sqltxt.Remove(sqltxt.Length - 1, 1);
                    sqltxt += " ";
                }

                sqltxt += " where " + "[" + dr.Table.Columns[ConditionFieldIndexInDataRow].Caption + "]='" + dr[ConditionFieldIndexInDataRow] + "'";

                sqlcm.CommandText = sqltxt;

                try
                {
                    if (!ExecQuery(sqlcm))
                        return false;
                    if (Prompt)
                        MessageBox.Show("به روز رساني با موفقيت انجام شد");
                    return true;
                }
                catch (Exception ex)
                {
                    Message_Exeption(ex);
                    return false;
                }
            }
        }

        public bool Update(DataRow dr, string Condition, [Optional, DefaultParameterValue(false)] bool Prompt, int ConditionFieldIndexInDataRow)
        {
            if (dr == null) return false;

            using (SqlCommand sqlcm = new SqlCommand())
            {
                string sqltxt = "UPDATE  " + dr.Table.TableName + " set ";

                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    //if (dr[i].ToString().Trim() == "") continue;
                    if (i == ConditionFieldIndexInDataRow) continue;

                    sqltxt += "[" + dr.Table.Columns[i].Caption + "] = " + "@" + dr.Table.Columns[i].Caption + ",";
                    if (dr.Table.Columns[i].DataType == typeof(Int16))
                    {
                        SqlParameter param = new SqlParameter("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);
                        param.SqlDbType = SqlDbType.Image;
                        sqlcm.Parameters.Add(param);
                    }
                    else

                        sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);
                }

                if (sqltxt.TrimEnd()[sqltxt.Length - 1] == ',')
                {
                    sqltxt = sqltxt.TrimEnd();
                    sqltxt = sqltxt.Remove(sqltxt.Length - 1, 1);
                    sqltxt += " ";
                }

                if (Condition.Trim() != "") sqltxt += " where " + Condition;

                sqlcm.CommandText = sqltxt;
                try
                {
                    if (!ExecQuery(sqlcm))
                        return false;
                    if (Prompt)
                        MessageBox.Show("به روز رساني با موفقيت انجام شد");
                    return true;
                }
                catch (Exception ex)
                {
                    Message_Exeption(ex);
                    return false;
                }
            }
        }
        #endregion

        #region Exist

        public DataRow Exist(DataRow dr, bool WithPrimeryKey, bool SwitchProtoType)
        {
            try
            {
                if (dr == null) return null;

                string sqltxt = "select * From " + dr.Table.TableName + " where ";

                using (SqlCommand sqlcm = new SqlCommand())
                {
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        if (dr.Table.PrimaryKey[0].Caption == dr.Table.Columns[i].Caption && !WithPrimeryKey) continue;

                        sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);

                        if (i != dr.Table.Columns.Count - 1)
                            sqltxt += "[" + dr.Table.Columns[i].Caption + "] =@" + dr.Table.Columns[i].Caption + " AND ";
                        else
                            sqltxt += "[" + dr.Table.Columns[i].Caption + "] =@" + dr.Table.Columns[i].Caption;
                    }

                    sqlcm.CommandText = sqltxt;

                    try
                    {
                        return GetRow(sqlcm);
                    }
                    catch (Exception ex)
                    {
                        Message_Exeption(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
            }
            return null;
        }

        public bool Exist(DataRow dr, bool WithPrimeryKey, ref int srl_Result)
        {
            try
            {
                if (dr == null) return false;

                string sqltxt = "select srl From " + dr.Table.TableName + " where ";

                using (SqlCommand sqlcm = new SqlCommand())
                {
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        if (dr.Table.PrimaryKey[0].Caption == dr.Table.Columns[i].Caption && !WithPrimeryKey)
                            continue;

                        sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);

                        if (i != dr.Table.Columns.Count - 1)
                            sqltxt += "[" + dr.Table.Columns[i].Caption + "] =@" + dr.Table.Columns[i].Caption + " AND ";
                        else
                            sqltxt += "[" + dr.Table.Columns[i].Caption + "] =@" + dr.Table.Columns[i].Caption;
                    }

                    sqlcm.CommandText = sqltxt;

                    try
                    {
                        object result = ExecScalar(sqlcm);

                        if (result != null)
                        {
                            srl_Result = (int)result;
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message_Exeption(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
            }
            return false;
        }

        public Boolean Exist(DataRow dr, bool WithPrimeryKey)
        {
            try
            {
                if (dr == null) return false;

                string sqltxt = "select Count(*) as NumberOfRows From " + dr.Table.TableName + " where ";

                using (SqlCommand sqlcm = new SqlCommand())
                {
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        if (dr.Table.PrimaryKey[0].Caption == dr.Table.Columns[i].Caption && !WithPrimeryKey)
                            continue;

                        sqlcm.Parameters.AddWithValue("@" + dr.Table.Columns[i].Caption.ToString(), dr[dr.Table.Columns[i].Caption.ToString()]);

                        if (i != dr.Table.Columns.Count - 1)
                            sqltxt += "[" + dr.Table.Columns[i].Caption + "] =@" + dr.Table.Columns[i].Caption + " AND ";
                        else
                            sqltxt += "[" + dr.Table.Columns[i].Caption + "] =@" + dr.Table.Columns[i].Caption;
                    }

                    sqlcm.CommandText = sqltxt;

                    try
                    {
                        if ((int)ExecScalar(sqlcm) >= 1)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        Message_Exeption(ex);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        public Boolean Exist(string strTableName, string strCondition)
        {
            try
            {
                if ((int)ExecScalar("select Count(*) as NumberOfRows From " + strTableName + " Where " + strCondition) >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        public DataRow Exist(string Query)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter sqlda = new SqlDataAdapter(new SqlCommand(Query, Global_Sqlcn)))
                    {
                        if (transaction != null)
                            sqlda.SelectCommand.Transaction = transaction;
                        sqlda.Fill(ds, 0, 1, "tb");
                        if (ds.Tables[0].Rows.Count > 0)
                            return ds.Tables[0].Rows[0];
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public Boolean Exist(string TableName, string FieldName, string FieldValue)
        {
            try
            {
                if ((int)ExecScalar("select Count(*) as NumberOfRows From " + TableName + " Where " + FieldName + "='" + FieldValue + "'") >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return false;
            }
        }

        #endregion

        #region ExistNum

        public int ExistLike(string TableName, string FieldName, string FieldValue, LikeLocation LL)
        {
            int res = 0;
            switch (LL)
            {
                case LikeLocation.Start:
                    res = (int)ExecScalar("select Count(*) as NumberOfRows From " + TableName + " Where " + FieldName + "Like %'" + FieldValue + "'");
                    break;
                case LikeLocation.End:
                    res = (int)ExecScalar("select Count(*) as NumberOfRows From " + TableName + " Where " + FieldName + "Like '" + FieldValue + "'%");
                    break;
                case LikeLocation.Any:
                    res = (int)ExecScalar("select Count(*) as NumberOfRows From " + TableName + " Where " + FieldName + "Like %'" + FieldValue + "'%");
                    break;
            }
            return res;
        }

        public int ExistNum(string TableName, string FieldName, string FieldValue)
        {
            try
            {
                return (int)ExecScalar("select Count(*) as NumberOfRows From " + TableName + " Where " + FieldName + "=N'" + FieldValue + "'");
            }
            catch { return 0; }
        }

        public int ExistNum(string TableName, string WhereCondition)
        {
            try
            {
                return (int)ExecScalar("select Count(*) as NumberOfRows From " + TableName + " Where " + WhereCondition);
            }
            catch { return 0; }
        }

        public int ExistNum(string TableName, string FieldName, string FieldValue, string WhereCondition)
        {
            try
            {
                string str_Query = "select Count(*) as NumberOfRows From [" + TableName + "] Where [" + FieldName + "]='" + FieldValue + "'";
                if (WhereCondition != "") str_Query += " AND " + WhereCondition;
                return (int)ExecScalar(str_Query);
            }
            catch { return 0; }
        }

        #endregion

        #region OptimizeRow
        public DataRow OptimizeRow(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                if (dr[i] == DBNull.Value)
                    try
                    {
                        dr[i] = "";
                    }
                    catch
                    {
                        continue;
                    }
            }
            return dr;
        }
        #endregion

        #region Populated Function

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public DataRow GetRow(SqlCommand sqlcm)
        {
            try
            {
                using (SqlDataAdapter sqlda = new SqlDataAdapter(sqlcm))
                {
                    using (DataSet ds = new DataSet())
                    {
                        sqlcm.Connection = Global_Sqlcn;
                        if (transaction != null)
                            sqlda.SelectCommand.Transaction = transaction;
                        sqlda.Fill(ds, 0, 1, "tb");
                        if (ds.Tables[0].Rows.Count > 0)
                            return OptimizeRow(ds.Tables[0].Rows[0]);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public DataRow GetRow(string Query)
        {
            try
            {
                using (SqlDataAdapter sqlda = new SqlDataAdapter(new SqlCommand(Query, Global_Sqlcn)))
                {
                    using (DataSet ds = new DataSet())
                    {
                        if (transaction != null)
                            sqlda.SelectCommand.Transaction = transaction;
                        sqlda.Fill(ds, 0, 1, "tb");
                        if (ds.Tables[0].Rows.Count > 0)
                            return OptimizeRow(ds.Tables[0].Rows[0]);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public DataRow GetRow(string TableName, int Serial)
        {
            try
            {
                using (SqlDataAdapter sqlda = new SqlDataAdapter(new SqlCommand("select * from " + TableName + " where srl=" + Serial.ToString(), Global_Sqlcn)))
                {
                    using (DataSet ds = new DataSet())
                    {
                        if (transaction != null)
                            sqlda.SelectCommand.Transaction = transaction;
                        sqlda.Fill(ds, 0, 1, TableName);
                        if (ds.Tables[0].Rows.Count > 0)
                            return OptimizeRow(ds.Tables[0].Rows[0]);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public DataRow GetRow(string TableName, string Condotion)
        {
            try
            {
                int i;
                if (int.TryParse(Condotion, out i))
                    return GetRow(TableName, i);
                else
                {
                    using (DataSet ds = new DataSet())
                    {
                        if (Condotion.Equals(""))
                            using (SqlDataAdapter sqlda = new SqlDataAdapter(new SqlCommand("select * from " + TableName, Global_Sqlcn)))
                            {
                                if (transaction != null)
                                    sqlda.SelectCommand.Transaction = transaction;
                                sqlda.Fill(ds, 0, 1, TableName);
                            }
                        else
                            using (SqlDataAdapter sqlda = new SqlDataAdapter(new SqlCommand("select * from " + TableName + " where  " + Condotion, Global_Sqlcn)))
                            {
                                if (transaction != null)
                                    sqlda.SelectCommand.Transaction = transaction;
                                sqlda.Fill(ds, 0, 1, TableName);
                            }

                        if (ds.Tables[0].Rows.Count > 0)
                            return OptimizeRow(ds.Tables[0].Rows[0]);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public SqlDataReader GetRows(string TableName)
        {
            try
            {
                return ExecReader("select * from " + TableName);
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public SqlDataReader GetRows(string TableName, string Condition)
        {
            try
            {
                if (Condition.Equals(""))
                    return ExecReader("select * from " + TableName);
                else
                    return ExecReader("select * from " + TableName + " where " + Condition);
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public SqlDataReader GetRows(SqlCommand sqlcm)
        {
            try
            {
                sqlcm.Connection = Global_Sqlcn;
                if (transaction != null)
                    sqlcm.Transaction = transaction;
                CheckOpenConnection();
                return sqlcm.ExecuteReader();
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public SqlDataReader GetRowWithQuery(string Query)
        {
            try
            {
                return ExecReader(Query);
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public DataTable GetDataTable(string Query)
        {
            try
            {
                CheckOpenConnection();
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter sqlda = new SqlDataAdapter(new SqlCommand(Query, Global_Sqlcn)))
                    {
                        if (transaction != null)
                            sqlda.SelectCommand.Transaction = transaction;
                        try
                        {
                            sqlda.Fill(ds);
                            return ds.Tables[0];
                        }
                        catch (Exception)
                        {
                            SqlDataAdapter s = new SqlDataAdapter(new SqlCommand(Query, new SqlConnection(ConnectionString)));
                            if (transaction != null)
                                s.SelectCommand.Transaction = transaction;
                            s.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public DataTable GetDataTable(string TabelName, string Condition)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    try
                    {
                        if (Condition.Trim().Equals(""))
                            new SqlDataAdapter(new SqlCommand("select * from " + TabelName, Global_Sqlcn)).Fill(ds);
                        else
                            new SqlDataAdapter(new SqlCommand("select * from " + TabelName + " where " + Condition, Global_Sqlcn)).Fill(ds);

                        return ds.Tables[0];
                    }
                    catch (Exception)
                    {
                        SqlDataAdapter s = null;
                        if (Condition.Trim().Equals(""))
                            s = new SqlDataAdapter(new SqlCommand("select * from " + TabelName, new SqlConnection(ConnectionString)));
                        else
                            s = new SqlDataAdapter(new SqlCommand("select * from " + TabelName + " where " + Condition, new SqlConnection(ConnectionString)));

                        s.Fill(ds);
                        return ds.Tables[0];

                    }
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }

        public DataSet FillDataSet(string Query)
        {
            try
            {
                using (DataSet ds = new DataSet())
                {
                    new SqlDataAdapter(new SqlCommand(Query, Global_Sqlcn)).Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                Message_Exeption(ex);
                return null;
            }
        }
        #endregion

        public void GetReferencedObjects()
        {
            System.Text.StringBuilder result = new StringBuilder();
            Type t = Global_Sqlcn.GetType();
            object innerConnection = t.GetField("_innerConnection", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(Global_Sqlcn);
            Type tin = innerConnection.GetType();
            object rc = tin.BaseType.BaseType.GetField("_referenceCollection", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(innerConnection);
            if (rc == null)
                return;
            int count = Convert.ToInt32(rc.GetType().GetField("_dataReaderCount", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rc));
            object items = rc.GetType().BaseType.GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rc);
            MethodInfo miGetValue = items.GetType().GetMethod("GetValue", new Type[] { typeof(int) });
            for (int i = 0; i < count; i++)
            {
                miGetValue.Invoke(items, new object[] { i });
                object referencedObj = miGetValue.Invoke(items, new object[] { i });
                SqlDataReader rdr = referencedObj.GetType().GetProperty("Target").GetValue(referencedObj, null) as SqlDataReader;
                rdr.Close();
            }
            //return True;
        }

        //#region Backup Restore
        //public bool Backup(string ConnectionString, string database, string FilePath)
        //{
        //    try
        //    {
        //        int startIndex = FilePath.LastIndexOf('\\');
        //        string path = FilePath.Remove(startIndex, FilePath.Length - startIndex);
        //        if (!Directory.Exists(path))
        //            Directory.CreateDirectory(path);
        //        if (File.Exists(FilePath))
        //            File.Delete(FilePath);
        //        Application.DoEvents();
        //        SqlConnection.ClearPool(Global_sqlcn);
        //        try
        //        {
        //            new SqlCommand(" BACKUP DATABASE " + database + " to disk='" + FilePath + "'", Global_sqlcn).ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Windows.Forms.MessageBox.Show(ex.Message);
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Restore(string ConnectionString, string database, string FilePath)
        //{
        //    try
        //    {
        //        string sqltxt = "use master ";
        //        sqltxt += " alter database " + database + " set single_user with rollback immediate ";
        //        sqltxt += " Restore DataBase " + database + " from disk ='" + FilePath + "' ";
        //        sqltxt += " alter database " + database + " set multi_user";
        //        new SqlCommand(sqltxt, Global_sqlcn).ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        return true;
        //    }
        //}
        //#endregion
    }
}

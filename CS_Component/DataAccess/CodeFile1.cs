
//public bool CheckFieldIdentity(string tabelName, string FieldName)
//{
//    #region Read Identiti in table
//    string temp = "SELECT   name FROM  syscolumns WHERE  (COLUMNPROPERTY(id, name, 'IsIdentity') = 1) AND (OBJECT_NAME(id) = '" + tabelName + "') AND (name = '" + FieldName + "')";
//    SqlConnection sqlCnIdentiti = new SqlConnection(ConnectionString);
//    SqlCommand CheckIdentitiNew = new SqlCommand(temp);
//    CheckIdentitiNew.Connection = sqlCnIdentiti;
//    if (sqlCnIdentiti.State == ConnectionState.Closed) sqlCnIdentiti.Open();
//    string field = (string)CheckIdentitiNew.ExecuteScalar();
//    if (sqlCnIdentiti.State == ConnectionState.Open) sqlCnIdentiti.Close();
//    sqlCnIdentiti.Dispose();
//    CheckIdentitiNew.Dispose();
//    if (FieldName == field) return true;
//    return false;
//    #endregion
//}


//public ArrayList GetTableField(string tableName)
//{
//    SqlConnection sqlcntemp = new SqlConnection(ConnectionString);
//    SqlCommand myCommand = new SqlCommand("SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "';");
//    myCommand.Connection = sqlcntemp;
//    ArrayList temp = new ArrayList();
//    SqlDataReader dr = myCommand.ExecuteReader();
//    if (sqlcntemp.State == ConnectionState.Closed) sqlcntemp.Open();
//    while (dr.Read()) temp.Add(dr[0].ToString());
//    dr.Close();
//    dr.Dispose();
//    myCommand.Dispose();
//    sqlcntemp.Dispose();
//    return temp;
//}
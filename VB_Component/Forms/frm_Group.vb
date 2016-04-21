Public Class frm_Group

    Public Overrides Function Save(ByVal DoClearForm As Boolean) As Boolean
        DataObject.DataRow("UsersBlocked") = CheckBox1.Checked
        DataObject.DataRow("JoinBlocked") = CheckBox2.Checked
        Return MyBase.Save(DoClearForm)
    End Function

    Public Overrides Function Edit() As Boolean
        Dim bol_Result = MyBase.Edit
        CheckBox1.Checked = DataObject.DataRow("UsersBlocked")
        CheckBox2.Checked = DataObject.DataRow("JoinBlocked")
        Return bol_Result
    End Function

    Public Overrides Sub LoadDataGridView()
        Me.Sec_GroupTableAdapter.Fill(Me.DataSet1.sec_Group)
        MyBase.LoadDataGridView()
    End Sub

    Public Overrides Sub ClearForm()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        MyBase.ClearForm()
    End Sub
End Class
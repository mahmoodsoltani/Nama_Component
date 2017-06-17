Public Class frm_UserList
    Public Overrides Sub LoadDataGridView()
        MyBase.LoadDataGridView()
        Sec_UserTableAdapter.Fill(DataSet1.sec_User)
    End Sub

    Private Sub frm_UserList_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        InfoForm = New frm_User()
    End Sub
End Class
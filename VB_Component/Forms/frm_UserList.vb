Public Class frm_UserList
    Public Overrides Sub LoadDataGridView()
        MyBase.LoadDataGridView()
        Me.Sec_UserTableAdapter.Fill(Me.DataSet1.sec_User)
    End Sub

    Private Sub frm_UserList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.InfoForm = New frm_User()
    End Sub
End Class
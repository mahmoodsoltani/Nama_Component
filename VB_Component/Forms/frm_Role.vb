Public Class frm_Role


    Private Sub frm_Role_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.sec_Role' table. You can move, or remove it, as needed.
    End Sub

    Public Overrides Sub LoadDataGridView()
        MyBase.LoadDataGridView()
        Me.Sec_RoleTableAdapter.Fill(Me.DataSet1.sec_Role)
    End Sub
End Class
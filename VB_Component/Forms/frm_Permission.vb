Public Class frm_Permission

    Private obj_Assembly As Reflection.Assembly

    Public Property Assembly() As Reflection.Assembly
        Get
            Return obj_Assembly
        End Get
        Set(ByVal value As Reflection.Assembly)
            obj_Assembly = value
        End Set
    End Property

    Private Sub frm_Permission_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.sec_Role' table. You can move, or remove it, as needed.

        Sec_RoleTableAdapter.Fill(DataSet1.sec_Role)

    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_Continue_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Continue.Click
        Dim frm As New frm_FormControls With {
            .Text = "تخصیص بازدارنده " + "[" + ComboBox1.Text + "]",
            .Tag = ComboBox1.SelectedValue,
            .Assembly = obj_Assembly
        }
        frm.ShowDialog()
        Close()
    End Sub
End Class
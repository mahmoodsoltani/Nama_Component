Public Class frm_Permission

    Private obj_Assembly As System.Reflection.Assembly

    Public Property Assembly() As System.Reflection.Assembly
        Get
            Return obj_Assembly
        End Get
        Set(ByVal value As System.Reflection.Assembly)
            obj_Assembly = value
        End Set
    End Property

    Private Sub frm_Permission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.sec_Role' table. You can move, or remove it, as needed.

        Me.Sec_RoleTableAdapter.Fill(Me.DataSet1.sec_Role)

    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_Continue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Continue.Click
        Dim frm As New frm_FormControls
        frm.Text = "تخصیص بازدارنده " + "[" + ComboBox1.Text + "]"        
        frm.Tag = ComboBox1.SelectedValue
        frm.Assembly = obj_Assembly
        frm.ShowDialog()
        Close()
    End Sub
End Class
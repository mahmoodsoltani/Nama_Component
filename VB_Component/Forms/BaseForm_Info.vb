Public Class BaseForm_Info

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If (Save(True)) Then Close()
    End Sub

    Public Overrides Sub LoadDataGridView()
        'If (DesignMode) Then Return
        'CType(MeOwner, BaseForm).LoadDataGridView()
    End Sub

    Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
        MyBase.OnFormClosed(e)
        CType(Me.Owner, BaseForm).LoadDataGridView()
    End Sub

End Class

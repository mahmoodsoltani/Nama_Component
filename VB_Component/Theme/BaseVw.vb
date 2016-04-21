Public Class BaseVw

    Public Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Public Overridable Sub Btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Edit.Click
        If (Btn_Edit.Tag = 0) Then
            MyBase.FormState = FormStates.Edit
            Btn_Edit.Tag = 1
            Btn_Delete.Enabled = False
            Btn_Edit.Enabled = False
        Else
            MyBase.FormState = FormStates.Submit
            Btn_Edit.Tag = 0
            Btn_Delete.Enabled = True
            Btn_Edit.Enabled = True
        End If
    End Sub

    Public Overridable Sub Btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_new.Click
        'If (Btn_Edit.Tag = 1) Then PubFun.ExitEditMode(TableName, BaseSrl)
        Btn_Delete.Enabled = True
        Btn_Edit.Enabled = True
    End Sub

    Public Overridable Sub BaseVw_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (Btn_Edit.Tag = 1) Then
            'PubFun.ExitEditMode(TableName, BaseSrl)
            Btn_Edit.Tag = 0
            Btn_Delete.Enabled = True
            Btn_Edit.Enabled = True
            VB_Component.Windows.EmptyControls(GroupBox3)
            e.Cancel = True
        End If
    End Sub
End Class

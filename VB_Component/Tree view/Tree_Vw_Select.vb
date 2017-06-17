﻿Public Class Tree_Vw_Select
    Public Result As TreeNode

    Public Sub New(ByVal dataTable As DataTable)
        InitializeComponent()
        Tree_Vw1.Fill(dataTable)
    End Sub

    Private Sub btn_Save_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Save.Click
        If Tree_Vw1.SelectedNode Is Nothing Then
            MessageBoxFa.Show("لطفا یک نود را انتخاب کنید")
            Return
        Else
            Result = Tree_Vw1.SelectedNode
        End If
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancel.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Tree_Vw_Select_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_Save_Click(Nothing, Nothing)
        End If
    End Sub
End Class
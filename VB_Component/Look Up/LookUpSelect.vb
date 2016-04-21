Public Class LookUpSelect

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal firstIndex As Integer, ByVal itemIndex As Integer)
        lstvwINFO.Items.Clear()
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim sValues As String() = New String() {dt.Rows(i).Item(itemIndex).ToString, dt.Rows(i).Item(firstIndex).ToString}
            Dim olstvwITEM As ListViewItem = New ListViewItem(sValues)
            lstvwINFO.Items.Add(olstvwITEM)
        Next
    End Sub

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal firstIndex As Integer, ByVal itemIndex As Integer, ByVal UpdtesField As Integer())
        lstvwINFO.Items.Clear()

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim sValues As String() = New String() {dt.Rows(i).Item(itemIndex).ToString, dt.Rows(i).Item(firstIndex).ToString}
            Dim olstvwITEM As ListViewItem = New ListViewItem(sValues)
            lstvwINFO.Items.Add(olstvwITEM)
        Next

        ResetChecked()

        For i As Integer = 0 To UpdtesField.Length
            If UpdtesField(i) = 1 Then
                ResultArray.Add(i)
                lstvwINFO.Items(i).Checked = True
            End If
        Next
    End Sub

    Public Sub UpdateLoockUp(ByVal UpdtesField As Integer())
        ResetChecked()
        For i As Integer = 0 To UpdtesField.Length - 1
            For index As Integer = 0 To lstvwINFO.Items.Count - 1
                If lstvwINFO.Items(index).SubItems(1).Text = UpdtesField(i) Then
                    lstvwINFO.Items(index).Checked = True
                End If
            Next
        Next
    End Sub

    Public ResultArray As New System.Collections.ArrayList
    Public changed As Boolean = False

    Public Sub ResetChecked()
        If lstvwINFO.Items.Count = 0 Then
            Return
        End If

        For i As Integer = 0 To lstvwINFO.Items.Count - 1
            lstvwINFO.Items(i).Checked = False
        Next
    End Sub

    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        For i As Integer = 0 To lstvwINFO.Items.Count - 1
            If lstvwINFO.Items(i).Checked Then
                ResultArray.Add(lstvwINFO.Items(i).SubItems(1).Text)
            End If
        Next
        Me.changed = True
        Close()
    End Sub

    Private Sub LookUpSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ResultArray = New System.Collections.ArrayList
    End Sub

    Private Sub LookUpSelect_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.changed = False
            Close()
        End If
    End Sub

    Private Sub lstvwINFO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstvwINFO.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_Ok.Focus()
        End If
    End Sub
End Class
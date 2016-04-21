Public Class Tree_Vw_Select2
    Public ReadOnly Property Koding() As String
        Get
            Return strKoding
        End Get
    End Property

    Public ReadOnly Property KodingSrl() As String
        Get
            Return _KodingSrl
        End Get
    End Property

    Dim strKoding As String = ""
    Dim _KodingSrl As String = ""

    Public Function LoadLookUp() As Boolean

    End Function

    Private Sub Btn_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Select.Click
        Try
            strKoding = ""
            _KodingSrl = ""
            If Tree_Vw1.SelectedNode.Tag.ToString = "1" Then
                MessageBoxFa.Show("در اين شاخه نميتوانيد  ثبت كنيد")
                Return
            End If
            Dim i As Integer = 0
            Dim strArr As String() = Tree_Vw1.SelectedNode.FullPath.Split("\")
            For i = 1 To strArr.Length - 1
                strKoding += " - " + strArr(i).Split("-")(1).Replace("کد", "").Trim
            Next

            strKoding = strKoding.TrimStart().Remove(0, 1).TrimStart
            _KodingSrl = Tree_Vw1.SelectedNode.Tag
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        Catch
            MessageBoxFa.Show("لطفا يك عمليات را انتخاب كنيد")
            Return
        End Try
    End Sub

    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub Tree_Vw_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Tree_Vw1.LoadTreeView(MainMenu.da, "SELECT  Srl, ParentID, Name, Code FROM SarfasleAslay", "2,-كد-,3")
    End Sub
End Class
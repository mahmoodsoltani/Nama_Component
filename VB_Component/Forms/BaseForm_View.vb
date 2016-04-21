Imports System.ComponentModel

Public Class BaseForm_View

    Private _GridView As System.Windows.Forms.DataGridView

    Private _InfoForm As BaseForm

    <Category("Nama"), Description("DataGridView"), Browsable(True)> _
    Public Property DataGridView() As System.Windows.Forms.DataGridView
        Get
            Return _GridView
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridView)
            _GridView = value
        End Set
    End Property

    <Category("Nama"), Description("InfoForm"), Browsable(True)> _
    Public Property InfoForm() As BaseForm
        Get
            Return _InfoForm
        End Get
        Set(ByVal value As BaseForm)
            _InfoForm = value
            If (Not _InfoForm Is Nothing) Then
                _InfoForm.DataObject = Me.DataObject
            End If
        End Set
    End Property

    Private Sub btn_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_New.Click
        NewRecord()
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Edit()
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If (_GridView Is Nothing) Then Return
        Dim int_Srl As Integer = FindSrl(_GridView, FindSerialPromtType.Delete, True, False)
        If (int_Srl = -1) Then Return
        If (Delete()) Then
            DataObject.Delete(int_Srl)
        End If
    End Sub

    Private Sub DataObject_Deleted(ByVal sender As Object, ByVal e As EventArgs) Handles DataObject.Deleted
        LoadDataGridView()
    End Sub

    Public Overrides Sub NewRecord(Optional ByVal ClearThisForm As Boolean = True)
        If (_InfoForm) Is Nothing Then Return
        _InfoForm.NewRecord()
        _InfoForm.Owner = Me
        _InfoForm.ShowDialog()
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub BaseForm_View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (DesignMode) Then Return
        NewRecord()
        If (Not _GridView Is Nothing) Then
            Dim I As Integer
            For I = 0 To _GridView.Columns.Count - 1
                If (_GridView.Columns(I).DataPropertyName.ToLower() = DataObject.KeyFieldName.ToLower()) Then
                    _GridView.Columns(I).Visible = False
                    Return
                End If
            Next
        End If
    End Sub

    Public Overrides Function Edit() As Boolean
        If (_InfoForm) Is Nothing Then Return False
        If (_GridView) Is Nothing Then Return False
        Dim int_Srl = FindSrl(_GridView, FindSerialPromtType.Edit, True, False)
        If (int_Srl <> -1) Then
            _InfoForm.DataObject.Load(int_Srl)
            _InfoForm.Edit()
            _InfoForm.Owner = Me
            _InfoForm.ShowDialog()
        End If
        Return MyBase.Edit()
    End Function
End Class
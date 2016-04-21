Imports System.ComponentModel

Public Class BaseForm_Layer
    Dim _ExecEditOnSelectDatagrideView As Boolean = False
    Dim ShallLoadGarideView As Boolean = True
    Private _GridView As System.Windows.Forms.DataGridView

    <Category("Nama"), Description("هنگام انتخاب يک رديف در جدول مود ويرايش فعال شود"), Browsable(True)> _
    Public Property ExecEditOnSelectDatagrideView() As Boolean
        Get
            Return _ExecEditOnSelectDatagrideView
        End Get
        Set(ByVal value As Boolean)
            _ExecEditOnSelectDatagrideView = value
            If value Then
                btn_Delete.Location = btn_Edit.Location
                btn_Delete.BringToFront()
            Else
                btn_Delete.Location = New Point(btn_Edit.Location.X - 5 - btn_Delete.Size.Width, 5)
            End If
        End Set
    End Property

    <Category("Nama"), Description("DataGridView"), Browsable(True)> _
    Public Property DataGridView() As System.Windows.Forms.DataGridView
        Get
            Return _GridView
        End Get
        Set(ByVal value As System.Windows.Forms.DataGridView)
            _GridView = value
        End Set
    End Property

    Private Sub SetFocusToFirstControl()
        'gbx_Controls.Controls(0).Focus()
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            btn_new_Click(Nothing, e)
            btn_Delete.Enabled = True
            btn_Edit.Enabled = True
        ElseIf e.KeyCode = Keys.Delete Then
            If _GridView.Focused Then
                btn_Delete_Click(Nothing, e)
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            btn_Edit_Click(Nothing, e)
        End If
        MyBase.OnKeyDown(e)
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Dim SelRow As Integer
        Dim ChangeOnEditMode As Boolean = False
        If MyBase.FormState = FormStates.Edit Then
            SelRow = GrideViewColomnAction(_GridView, GrideViewGettingState.GetCurrentRowIndex)
            ChangeOnEditMode = True
        End If
        If Not Save(True) Then
            Return
        Else
            _GridView.Enabled = True
            btn_Edit.Enabled = True
            btn_Delete.Enabled = True
            If ChangeOnEditMode Then
                If SelRow <> -1 Then
                    ShallLoadGarideView = False
                    _GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), SelRow)
                    ShallLoadGarideView = True
                End If
            Else
                If _GridView.Rows.Count > 0 Then
                    _GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), _GridView.Rows.Count - 1)
                Else
                    '_GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), 1)
                End If
            End If
            SetFocusToFirstControl()
        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Edit()
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If (_GridView Is Nothing) Then Return
        Dim int_Srl As Integer = FindSrl(_GridView, FindSerialPromtType.Delete, True, False)
        If (int_Srl = -1) Then Return
        If (Delete()) Then
            Dim SelRow As New Integer
            SelRow = GrideViewColomnAction(_GridView, GrideViewGettingState.GetCurrentRowIndex)
            If Not DataObject.Delete(int_Srl) Then
                MessageBoxFa.Show("خطا در حذف اطلاعات")
                _GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), SelRow)
            Else
                If SelRow <> -1 And SelRow > 0 Then
                    _GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), SelRow - 1)
                End If
            End If
        End If
    End Sub

    Private Sub DataObject_Deleted(ByVal sender As Object, ByVal e As EventArgs) Handles DataObject.Deleted
        LoadDataGridView()
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub BaseForm_Layer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (DesignMode) Then Return
        NewRecord(True)
        If Not _GridView Is Nothing And Not _GridView.DataSource Is Nothing Then
            GrideViewColomnAction(_GridView, GrideViewGettingState.HidePrimeryKey)
            If ExecEditOnSelectDatagrideView Then
                AddHandler _GridView.SelectionChanged, AddressOf GridView_SelectionChanged
            End If
        End If
    End Sub

    Sub GridView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not _GridView.CurrentRow Is Nothing Then
                If ShallLoadGarideView Then
                    Edit()
                End If
            End If
        Catch
        End Try
    End Sub

    Public Overrides Function Edit() As Boolean
        Dim Srl As Integer
        If ExecEditOnSelectDatagrideView Then
            Srl = FindSrl(_GridView, FindSerialPromtType.Edit, False)
        Else
            Srl = FindSrl(_GridView, FindSerialPromtType.Edit, True, False)
        End If
        If Srl = -1 Then Return False
        Dim SelRow As Integer = GrideViewColomnAction(_GridView, GrideViewGettingState.GetCurrentRowIndex)
        'If MessageBoxFa.Show("مايل به ويرايش رديف هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.No Then
        '    Return
        'End If

        If Not ExecEditOnSelectDatagrideView Then
            _GridView.Enabled = False
            btn_Edit.Enabled = False
            btn_Delete.Enabled = False
        End If

        'If (BaseDataObject.IsInEditMode(Me, TableName, Srl, "")) Then
        '    _GridView.Enabled = True
        '    Return
        'End If
        DataObject.Load(Srl)
        Dim res As Boolean = MyBase.Edit()
        If SelRow <> -1 Then
            _GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), SelRow)
        End If

        Return res
    End Function

    Public Overrides Function Edit(ByVal srl_toEdit As Integer) As Boolean
        Dim Srl As Integer = srl_toEdit
        If Srl = -1 Then Return False
        Dim SelRow As Integer = GrideViewColomnAction(_GridView, GrideViewGettingState.GetCurrentRowIndex)
        'If MessageBoxFa.Show("مايل به ويرايش رديف هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.No Then
        '    Return
        'End If
        _GridView.Enabled = False
        btn_Edit.Enabled = False
        btn_Delete.Enabled = False
        'If (BaseDataObject.IsInEditMode(Me, TableName, Srl, "")) Then
        '    _GridView.Enabled = True
        '    Return
        'End If
        DataObject.Load(Srl)
        Dim res As Boolean = MyBase.Edit()
        If SelRow <> -1 Then
            _GridView.CurrentCell = _GridView(GrideViewColomnAction(_GridView, GrideViewGettingState.GetFirstVisibleColomn), SelRow)
        End If

        Return res
    End Function

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        If (Me.FormState = FormStates.Edit) Then
            NewRecord()
            _GridView.Enabled = True
            btn_Edit.Enabled = True
            btn_Delete.Enabled = True
            e.Cancel = True
        End If
        MyBase.OnClosing(e)
    End Sub

    Public Overrides Function Save(ByVal DoClearForm As Boolean) As Boolean
        Dim res As Boolean = MyBase.Save(DoClearForm)
        If Not res Then
            Return False
        End If
        ShallLoadGarideView = False
        LoadDataGridView()
        ShallLoadGarideView = True
        Return True
    End Function
End Class

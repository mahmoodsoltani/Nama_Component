Imports System.ComponentModel
Imports CS_Component

Public Class BaseForm

    Public Shared Event F10Clicked As EventHandler

    Private _FormState As FormStates
    Private C As Control
    Private bol_IsValid As Boolean = True
    Public WithEvents DataObject As BaseDataObject
    Private bol_PromptOnExit As Boolean = False
    Private str_TableName As String
    Dim _GoOnEnter As Boolean = True
    Dim _GoOnUpDown As Boolean = True
    Dim _MaximizeToDesktopBound As Boolean = False

    Public Event FormStateChanged As EventHandler

    Public Property FormState() As FormStates
        Get
            Return _FormState
        End Get
        Set(ByVal value As FormStates)
            _FormState = value
        End Set
    End Property

    <Category("Nama"), Description("PromptOnExit"), Browsable(True)> _
    Public Property PromptOnExit() As Boolean
        Get
            Return bol_PromptOnExit
        End Get
        Set(ByVal value As Boolean)
            bol_PromptOnExit = value
        End Set
    End Property

    <Category("Nama"), Description("TableName"), Browsable(True)> _
    Public Property TableName() As String
        Get
            Return str_TableName
        End Get
        Set(ByVal value As String)
            str_TableName = value
        End Set
    End Property

    <Category("Nama"), Description("اندازه فرم را به بيشترين اندازه دسكتاپ تغيير ميدهد"), Browsable(True)> _
     Public Property MaximizeToDesktopBound() As Boolean
        Get
            Return _MaximizeToDesktopBound
        End Get
        Set(ByVal value As Boolean)
            _MaximizeToDesktopBound = value
        End Set
    End Property

    <Category("Nama"), Description("حركت روي كنترل هاي فرم با اينتر"), Browsable(True)> _
    Public Property GoOnEnter() As Boolean
        Get
            Return _GoOnEnter
        End Get
        Set(ByVal value As Boolean)
            _GoOnEnter = value
        End Set
    End Property

    <Category("Nama"), Description("حركت روي كنترل هاي فرم باآپ دون"), Browsable(True)> _
    Public Property GoOnUpDown() As Boolean
        Get
            Return _GoOnUpDown
        End Get
        Set(ByVal value As Boolean)
            _GoOnUpDown = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Try
            DataObject = New BaseDataObject() With {
                .TableName = str_TableName
            }
            'Me.DataObject.DataAccess = ApplicationPublicObjects.DataAccess
        Catch ex As Exception
        End Try
    End Sub

    'Public Function GrideViewColomnAction(ByVal _GridView As System.Windows.Forms.DataGridView, ByVal state As GrideViewGettingState) As Integer
    '    Select Case state
    '        Case GrideViewGettingState.HidePrimeryKey
    '            Dim I As Integer
    '            For I = 0 To _GridView.Columns.Count - 1
    '                If _GridView.Columns(I).DataPropertyName.ToLower() = DataObject.KeyFieldName.ToLower() Then
    '                    _GridView.Columns(I).Visible = False
    '                    Return -1
    '                End If
    '            Next
    '        Case GrideViewGettingState.GetPrimeryKey
    '            Dim I As Integer
    '            For I = 0 To _GridView.Columns.Count - 1
    '                If _GridView.Columns(I).DataPropertyName.ToLower() = DataObject.KeyFieldName.ToLower() Then
    '                    Return I
    '                End If
    '            Next
    '        Case GrideViewGettingState.GetFirstVisibleColomn
    '            Dim I As Integer
    '            For I = 0 To _GridView.Columns.Count - 1
    '                If _GridView.Columns(I).Visible = True Then
    '                    Return I
    '                End If
    '            Next
    '        Case GrideViewGettingState.GetCurrentRowIndex
    '            If _GridView.SelectedRows.Count > 0 Then
    '                Return _GridView.SelectedRows(0).Index
    '            Else
    '                Return -1
    '            End If
    '    End Select
    'End Function

    Public Function GrideViewColomnAction(ByVal _GridView As DataGridView, ByVal state As GrideViewGettingState) As Integer
        Select Case state
            Case GrideViewGettingState.HidePrimeryKey
                Dim I As Integer
                For I = 0 To _GridView.Columns.Count - 1
                    If _GridView.Columns(I).DataPropertyName.ToLower() = DataObject.KeyFieldName.ToLower() Then
                        _GridView.Columns(I).Visible = False
                        Return -1
                    End If
                Next
            Case GrideViewGettingState.GetPrimeryKey
                Dim I As Integer
                For I = 0 To _GridView.Columns.Count - 1
                    If _GridView.Columns(I).DataPropertyName.ToLower() = DataObject.KeyFieldName.ToLower() Then
                        Return I
                    End If
                Next
            Case GrideViewGettingState.GetFirstVisibleColomn
                Dim I As Integer
                For I = 0 To _GridView.Columns.Count - 1
                    If _GridView.Columns(I).Visible = True Then
                        Return I
                    End If
                Next
            Case GrideViewGettingState.GetCurrentRowIndex
                If _GridView.SelectedRows.Count > 0 Then
                    Return _GridView.SelectedRows(0).Index
                Else
                    Return -1
                End If
        End Select
    End Function

    Public Overridable Sub NewRecord(Optional ByVal ClearthisForm As Boolean = True)
        'If (DesignMode) Then Return
        'If (GetModified(Me)) Then
        '    Dim Dr As DialogResult
        '    Dr = MessageBoxFa.Show("اطلاعات فعلی ذخیره نشده است آیا مایلید قبل از خروج ذخیره شوند ؟", "خروج", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        '    Select Case Dr
        '        Case System.Windows.Forms.DialogResult.Yes
        '            If (Not Save()) Then Return
        '        Case System.Windows.Forms.DialogResult.Cancel
        '            Return
        '    End Select
        'End If

        FormState = FormStates.NewRecord
        DataObject.NewData()
        If ClearthisForm Then
            ClearForm()
        End If
    End Sub

    Public Overridable Sub ClearForm()
        bol_IsValid = True
        DataObject.NewData()
        Clear(Me)
        FocusFirst(Me)
    End Sub

    Public Sub FocusFirst(ByVal C As Control)
        Dim int_TabIndex = Integer.MaxValue
        Dim Fc As New Control
        For Each cc As Control In C.Controls
            If (cc.TabIndex < int_TabIndex) Then
                Fc = cc
                int_TabIndex = cc.TabIndex
            End If
        Next
        Fc.Focus()
        If (Fc.Controls.Count > 0) Then FocusFirst(Fc)
    End Sub

    Public Overridable Function Save(ByVal DoClearForm As Boolean) As Boolean
        bol_IsValid = True
        GetData(Me)
        If (Not bol_IsValid) Then
            Return False
        End If
        Dim Bol_Result As Boolean
        Select Case _FormState
            Case FormStates.NewRecord
                Bol_Result = DataObject.Insert()
            Case FormStates.Edit
                Bol_Result = DataObject.Update()
        End Select
        If (Bol_Result) Then
            Try
                If (DoClearForm) Then
                    ClearForm()
                    NewRecord()
                End If
            Catch ex As Exception
            End Try
        End If
        'EditMode.ExitEditMode(DataObject.DataRow)
        Return Bol_Result
    End Function

    Public Overridable Function Save() As Boolean
        bol_IsValid = True
        GetData(Me)
        If (Not bol_IsValid) Then
            Return False
        End If
        Dim Bol_Result As Boolean
        Select Case _FormState
            Case FormStates.NewRecord
                Bol_Result = DataObject.Insert()
            Case FormStates.Edit
                Bol_Result = DataObject.Update()
        End Select
        If (Bol_Result) Then
            Try
                ClearForm()
                NewRecord()
                LoadDataGridView()
            Catch ex As Exception
            End Try
        End If
        'EditMode.ExitEditMode(DataObject.DataRow)
        Return Bol_Result
    End Function

    Public Overridable Function Edit(ByVal srl_toEdit As Integer) As Boolean
        'If (EditMode.IsInEditMode(Me, DataObject.DataRow)) Then
        '    MessageBoxFa.Show("این اطلاعات توسط کاربر دیگری درحال ویرایش است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        'If (Not EditMode.StartEdit(TableName, DataObject.DataRow("Srl"))) Then Return False
        Try
            FormState = FormStates.Edit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overridable Function Edit() As Boolean
        'If (EditMode.IsInEditMode(Me, DataObject.DataRow)) Then
        '    MessageBoxFa.Show("این اطلاعات توسط کاربر دیگری درحال ویرایش است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        'If (Not EditMode.StartEdit(TableName, DataObject.DataRow("Srl"))) Then Return False
        Try
            FormState = FormStates.Edit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overridable Function Delete() As Boolean
        'If (EditMode.IsInEditMode(Me, DataObject.DataRow)) Then
        'MessageBoxFa.Show("این اطلاعات توسط کاربر دیگری درحال ویرایش است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Return False
        'End If
        Dim Dr As DialogResult = MessageBoxFa.Show("آیا مایلید اطلاعات انتخاب شده حذف شوند ؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Return (Dr = DialogResult.Yes)
    End Function

    Public Overridable Sub LoadDataGridView()

    End Sub

    Private Sub Clear(ByVal Control As Control)
        For Each C In Control.Controls
            If (TypeOf (C) Is Tbox) Then
                CType(C, Tbox).Clear()
                CType(C, Tbox).Modified = False
            ElseIf (TypeOf (C) Is TextBox) Then
                CType(C, TextBox).Clear()
                CType(C, TextBox).Modified = False
            ElseIf (TypeOf (C) Is IPAddressControl) Then
                CType(C, IPAddressControl).Text = ""
            ElseIf (TypeOf (C) Is ComboBox) Then
                If CType(C, ComboBox).Items.Count > 0 Then
                    CType(C, ComboBox).SelectedIndex = 0
                End If
            ElseIf (TypeOf (C) Is CheckBox) Then
                CType(C, CheckBox).Checked = False
            ElseIf (TypeOf (C) Is LookUpButton) Then
                CType(C, LookUpButton).ResetResult()
            ElseIf (TypeOf (C) Is LookupBox) Then
                CType(C, LookupBox).ResetResult()
            ElseIf (TypeOf (C) Is PictureGetter) Then
                CType(C, PictureGetter).Image = Nothing
            ElseIf TypeOf (C) Is Label And Not C.Tag Is Nothing Then
                CType(C, Label).Text = ""
            ElseIf TypeOf (C) Is TimeSelect And Not C.Tag Is Nothing Then
                CType(C, TimeSelect).Value = "00:00:00"
            End If
            If (CType(C, Control).Controls.Count <> 0) Then
                Clear(C)
            End If
        Next
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        Dim Dr As DialogResult
        If (PromptOnExit) Then
            Dr = MessageBoxFa.Show("آیا مایلید از فرم خارج شوید ؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If (Dr = DialogResult.No) Then
                e.Cancel = True
                Exit Sub
            End If
            If (DataObject Is Nothing) Then Return
            If (DataObject.DataRow Is Nothing) Then Return
            If (GetModified(Me)) Then
                Dr = MessageBoxFa.Show("اطلاعات فعلی ذخیره نشده است آیا مایلید قبل از خروج ذخیره شوند ؟", "خروج", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case Dr
                    Case DialogResult.Yes
                        e.Cancel = Not Save(True)
                    Case DialogResult.No
                        e.Cancel = False
                    Case DialogResult.Cancel
                        e.Cancel = True
                End Select
            End If
        End If
        MyBase.OnClosing(e)
    End Sub

    Private Function GetModified(ByVal Control As Control) As Boolean
        Dim bol_Modified As Boolean
        For Each C In Control.Controls
            If (TypeOf (C) Is TextBox And Not (TypeOf (C.Parent) Is SearchPanel)) Then
                If (CType(C, TextBox).Modified) Then
                    Return True
                End If
            End If
            If (CType(C, Control).Controls.Count <> 0) Then
                bol_Modified = GetModified(C)
                If (bol_Modified) Then Exit For
            End If
        Next
        Return bol_Modified
    End Function

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
        End If
        If e.KeyChar = Convert.ToChar(27) Then
            e.Handled = True
            Close()
        End If

        If e.KeyChar = "ك"c Then
            e.KeyChar = "ک"c
        End If

        If e.KeyChar = "ی"c Then
            e.KeyChar = "ي"c
        End If
        MyBase.OnKeyPress(e)
    End Sub

    Public Function FindSrl(ByVal Grid As System.Windows.Forms.DataGridView _
                            , ByVal PromtType As FindSerialPromtType _
                            , ByVal ShowMessageOnPromtType As Boolean _
                            , Optional ByVal ShowMessage As Boolean = False _
                            , Optional ByVal WitoutCheckPrimeryKey As Boolean = False)

        Dim Srl As Integer = -1

        If ShowMessageOnPromtType Then
            If PromtType = FindSerialPromtType.Edit Then
            ElseIf PromtType = FindSerialPromtType.Delete Then
                If MessageBoxFa.Show("مايل به حذف رديف هستيد؟", "", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Return -1
                End If
            End If
        End If

        If Grid Is Nothing OrElse Grid.CurrentRow Is Nothing Then
            Srl = -1
        Else
            If Not WitoutCheckPrimeryKey Then
                For Each Dc As DataGridViewColumn In Grid.Columns
                    If (Dc.DataPropertyName.ToLower = DataObject.KeyFieldName.ToLower) Then
                        Srl = Grid.CurrentRow.Cells(Dc.Index).Value
                    End If
                Next
            Else
                Srl = Grid.CurrentRow.Cells(0).Value
            End If
        End If

        If ShowMessageOnPromtType Then
            If Srl.Equals(-1) Then
                MessageBoxFa.Show("لطفا يک رديف را انتخاب کنيد")
            End If
        End If

        Return Srl
    End Function

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Escape And _FormState <> FormStates.Edit Then
            Close()
        End If
        Select Case e.KeyCode
            Case Keys.Enter
                If _GoOnEnter Then
                    If TypeOf ActiveControl Is DataGridView OrElse
                    TypeOf ActiveControl Is Btn Then
                        Return
                    End If
                    If TypeOf ActiveControl Is TimeSelect Then
                        If DirectCast(ActiveControl, TimeSelect).ActiveControl.Name = "txt_Hour" Then
                            DirectCast(ActiveControl, TimeSelect).txt_Min.Focus()
                        ElseIf DirectCast(ActiveControl, TimeSelect).ActiveControl.Name = "txt_Min" And DirectCast(ActiveControl, TimeSelect).ShowSecond Then
                            DirectCast(ActiveControl, TimeSelect).txt_Sec.Focus()
                        Else
                            ProcessTabKey(True)
                        End If
                    Else
                        ProcessTabKey(True)
                    End If
                End If
            Case Keys.F10
                Dim currentlang As String = InputLanguage.CurrentInputLanguage.LayoutName
                If (currentlang = "US") Then
                    Windows.ChangeLangToFarsi(True)
                Else
                    Windows.ChangeLangToFarsi(False)
                End If
            Case Keys.Up
                If _GoOnUpDown Then
                    If TypeOf ActiveControl Is ListBox _
                        OrElse TypeOf ActiveControl Is DataGridView _
                        OrElse TypeOf ActiveControl Is DataGridViewComboBoxEditingControl _
                        OrElse TypeOf ActiveControl Is ComboBox Then
                        Return
                    End If
                    ProcessTabKey(False)
                End If
            Case Keys.Down
                If _GoOnUpDown Then
                    If TypeOf ActiveControl Is ListBox _
                        OrElse TypeOf ActiveControl Is DataGridViewComboBoxEditingControl _
                        OrElse TypeOf ActiveControl Is DataGridView _
                        OrElse TypeOf ActiveControl Is LookupBox _
                        OrElse TypeOf ActiveControl Is ComboBox Then
                        Return
                    End If
                    ProcessTabKey(True)
                End If
            Case Keys.Left
                If TypeOf ActiveControl Is ComboBox Then
                    ProcessTabKey(True)
                End If
            Case Keys.Right
                If TypeOf ActiveControl Is ComboBox Then
                    ProcessTabKey(False)
                End If
        End Select
        MyBase.OnKeyDown(e)
    End Sub

    Private Sub GetData(ByVal Control As Control)
        For Each C As Control In Control.Controls
            If (C.Controls.Count <> 0 And Not (TypeOf (C) Is TextBox Or TypeOf (C) Is PictureGetter Or TypeOf (C) Is TimeSelect Or TypeOf (C) Is LookupBox Or TypeOf (C) Is LookUpButton Or TypeOf (C) Is IPAddressControl)) Then
                GetData(C)
            Else
                SetDataRowValues(DataObject.DataRow, C)
            End If
        Next
    End Sub

    Public Function ValidateAllValue(ByRef Control As Control) As Boolean
        For Each C As Control In Control.Controls
            If (TypeOf C Is LookupBox) Then
                If Not ValidateValue(C) Then
                    Return False
                End If
            ElseIf (C.Controls.Count <> 0) Then
                If Not ValidateAllValue(C) Then
                    Return False
                End If
            Else
                If Not ValidateValue(C) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function ValidateValue(ByRef Control As Control) As Boolean
        Dim titlec As Control = Control.Parent.GetChildAtPoint(New Point(Control.Left + Control.Width + 20, Control.Top + 5))
        If (TypeOf Control Is TextBox) Then
            If CType(Control, TextBox).IsRequired Then
                If (CType(Control, TextBox).TypeOfContains = TypeOfValues.Currency Or CType(Control, TextBox).TypeOfContains = TypeOfValues.Number) Then
                    If (CType(Control, TextBox).Value = 0) Then
                        If (Not titlec Is Nothing) Then
                            ControlMessage.Show(Control, titlec.Text.Replace(":", "").Trim() + " مشخص نیست.")
                            bol_IsValid = False
                            Return False
                        Else
                            ControlMessage.Show(Control, CType(Control, TextBox).Title + " مشخص نیست.")
                            bol_IsValid = False
                            Return False
                        End If
                    End If
                End If
                If (CType(Control, TextBox).TypeOfContains = TypeOfValues.Date Or CType(Control, TextBox).TypeOfContains = TypeOfValues.EnglishText) Or (CType(Control, TextBox).TypeOfContains = TypeOfValues.PersianText) Or (CType(Control, TextBox).TypeOfContains = TypeOfValues.StringNumber) Then
                    If (CType(Control, TextBox).Value = "") Then
                        If (Not titlec Is Nothing) Then
                            ControlMessage.Show(Control, titlec.Text.Replace(":", "").Trim() + " مشخص نیست.")
                            bol_IsValid = False
                            Return False
                        Else
                            ControlMessage.Show(Control, CType(Control, TextBox).Title + " مشخص نیست.")
                            bol_IsValid = False
                            Return False
                        End If
                    End If
                End If
            End If
            If CType(Control, TextBox).CheckExistValueInDb Then
                If FormState = FormStates.Edit Then
                    If CType(Control, TextBox).ValidateCheckExistOnEdit Then
                        If Not CheckExistValueInDatabase(Control) Then
                            bol_IsValid = False
                            Return False
                        End If
                    End If
                Else
                    If Not CheckExistValueInDatabase(Control) Then
                        bol_IsValid = False
                        Return False
                    End If
                End If
            End If
        ElseIf (TypeOf Control Is ComboBox) Then
            If (CType(Control, ComboBox).IsRequired And CType(Control, ComboBox).SelectedIndex = -1) Then
                If (Not titlec Is Nothing) Then
                    ControlMessage.Show(Control, titlec.Text.Replace(":", "").Trim() + " مشخص نیست.")
                    bol_IsValid = False
                    Return False
                Else
                    ControlMessage.Show(Control, CType(Control, TextBox).Title + " مشخص نیست.")
                    bol_IsValid = False
                    Return False
                End If
            End If
        ElseIf (TypeOf Control Is LookupBox) Then
            If (CType(Control, LookupBox).IsRequired And CType(Control, LookupBox).Result Is Nothing) Then
                If (Not titlec Is Nothing) Then
                    ControlMessage.Show(Control, titlec.Text.Replace(":", "").Trim() + " مشخص نیست.")
                    bol_IsValid = False
                    Return False
                Else
                    ControlMessage.Show(Control, CType(Control, LookupBox).Title + " مشخص نیست.")
                    bol_IsValid = False
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub SetDataRowValues(ByVal DataRow As DataRow, ByVal Control As Control)
        If (Control.Tag Is Nothing) Then Return
        If DataRow Is Nothing Then Return
        If (DataRow.Table.Columns.Contains(Control.Tag.ToString)) Then
            If Not ValidateValue(Control) Then
                Return
            End If
            If (TypeOf Control Is TextBox) Then
                DataRow(Control.Tag.ToString) = CType(Control, TextBox).Value
            ElseIf (TypeOf Control Is ComboBox) Then
                If Not CType(Control, ComboBox).SelectedValue Is Nothing Then
                    DataRow(Control.Tag.ToString()) = CType(Control, ComboBox).SelectedValue
                End If
            ElseIf (TypeOf Control Is System.Windows.Forms.ComboBox) Then
                If Not CType(Control, System.Windows.Forms.ComboBox).SelectedValue Is Nothing Then
                    DataRow(Control.Tag.ToString()) = CType(Control, ComboBox).SelectedValue
                End If
            ElseIf (TypeOf Control Is ComboBox) Then
                If Not CType(Control, ComboBox).SelectedValue Is Nothing Then
                    DataRow(Control.Tag.ToString()) = CType(Control, System.Windows.Forms.ComboBox).SelectedValue
                End If
            ElseIf (TypeOf Control Is CheckBox) Then
                DataRow(Control.Tag.ToString()) = CType(Control, CheckBox).Checked
            ElseIf (TypeOf Control Is RadioButton) Then
                DataRow(Control.Tag.ToString()) = CType(Control, RadioButton).Checked
            ElseIf (TypeOf Control Is LookUpButton) Then
                DataRow(Control.Tag.ToString()) = CType(Control, LookUpButton).Result(CType(Control, LookUpButton).Tag)
            ElseIf TypeOf Control Is LookupBox Then
                DataRow(Control.Tag.ToString) = CType(Control, LookupBox).Result(CType(Control, LookupBox).ValueField)
            ElseIf TypeOf Control Is Label Then
                DataRow(Control.Tag.ToString) = CType(Control, Label).Text
            ElseIf TypeOf Control Is PictureGetter Then
                DataRow(Control.Tag.ToString) = CType(Control, PictureGetter).Image
            ElseIf TypeOf Control Is TimeSelect Then
                DataRow(Control.Tag.ToString) = CType(Control, TimeSelect).Value
            ElseIf TypeOf Control Is IPAddressControl Then
                DataRow(Control.Tag.ToString) = CType(Control, IPAddressControl).Text
            End If
        End If
    End Sub

    Public Function CheckExistValueInDatabase(ByVal Control As Control) As Boolean
        Dim titlec As Control = Control.Parent.GetChildAtPoint(New Point(Control.Left + Control.Width + 20, Control.Top + 5))

        If (TypeOf (Me) Is BaseForm_Layer) Then
            Dim Bs_Inf As BaseForm_Layer = CType(Me, BaseForm_Layer)
            If (ExistInDataGridView(Bs_Inf.DataGridView, titlec.Text.Replace(":", "").Trim(), Control.Text)) Then
                Control.Focus()
                Application.DoEvents()
                ControlMessage.Show(Control, "مقدار " + titlec.Text.Replace(":", "").Trim() + " تکراري است.")
                Return False
            End If
        ElseIf (TypeOf (Me) Is BaseForm_Info) Then
            Dim Bs_Inf As BaseForm_View = CType(Owner, BaseForm_View)
            If (ExistInDataGridView(Bs_Inf.DataGridView, titlec.Text.Replace(":", "").Trim(), Control.Text)) Then
                Control.Focus()
                Application.DoEvents()
                ControlMessage.Show(Control, "مقدار " + titlec.Text.Replace(":", "").Trim() + " تکراري است.")
                Return False
            End If
        ElseIf BaseDataObject.DataAccess.ExistNum(TableName, Control.Tag.ToString, CType(Control, TextBox).Value) > 0 Then
            Control.Focus()
            Application.DoEvents()
            ControlMessage.Show(Control, "مقدار " + titlec.Text.Replace(":", "").Trim() + " تکراري است.")
            Return False
        End If
        Return True
    End Function

    Public Shared Function ExistInDataGridView(ByVal dg As DataGridView, ByVal ClomnHeader As String, ByVal TextToSearch As String) As Boolean
        Dim i As Integer
        For Each C As DataGridViewColumn In dg.Columns
            If (C.HeaderText = ClomnHeader) Then
                i = dg.Columns.IndexOf(C)
                Exit For
            End If
        Next
        For Each Row As DataGridViewRow In dg.Rows
            If (Row.Cells(i).Value.ToString = TextToSearch) Then Return True
        Next
        Return False
    End Function

    Protected Overridable Sub SetData(ByVal Control As Control)
        If (TypeOf Control Is TextBox) Then
            GetDataRowValues(DataObject.DataRow, Control)
            Return
        End If
        Dim C As Control
        For Each C In Control.Controls
            If (C.Controls.Count <> 0) Then
                If Not (TypeOf (C) Is IPAddressControl Or TypeOf (C) Is TextBox Or TypeOf (C) Is TimeSelect Or TypeOf (C) Is LookUpButton Or TypeOf (C) Is PictureGetter Or TypeOf (C) Is LookupBox) Then
                    SetData(C)
                Else
                    GetDataRowValues(DataObject.DataRow, C)
                End If
            Else
                GetDataRowValues(DataObject.DataRow, C)
            End If
        Next
    End Sub

    Private Sub GetDataRowValues(ByVal DataRow As DataRow, ByVal Control As Control)
        If (DataRow Is Nothing) Then Return
        If (Control.Tag Is Nothing) Then Return
        If (DataRow.Table.Columns.Contains(Control.Tag.ToString)) Then
            If (TypeOf Control Is TextBox) Then
                CType(Control, TextBox).Value = DataRow(Control.Tag.ToString)
            ElseIf (TypeOf Control Is ComboBox) Then
                CType(Control, ComboBox).SelectedValue = DataRow(Control.Tag.ToString())
            ElseIf (TypeOf Control Is CheckBox) Then
                CType(Control, CheckBox).Checked = DataRow(Control.Tag.ToString())
            ElseIf (TypeOf Control Is RadioButton) Then
                CType(Control, RadioButton).Checked = DataRow(Control.Tag.ToString())
            ElseIf (TypeOf Control Is LookUpButton) Then
                CType(Control, LookUpButton).LoadBySerial(DataRow(Control.Tag.ToString()))
            ElseIf TypeOf Control Is LookupBox Then
                CType(Control, LookupBox).LoadByValue(DataRow(Control.Tag.ToString()))
            ElseIf TypeOf (Control) Is Label Then
                CType(Control, Label).Text = DataRow(Control.Tag.ToString())
            ElseIf TypeOf (Control) Is PictureGetter And Not (DataRow(Control.Tag.ToString()) Is DBNull.Value) Then
                CType(Control, PictureGetter).Image = DirectCast(DataRow(Control.Tag.ToString()), Byte())
            ElseIf TypeOf (Control) Is TimeSelect And Not (DataRow(Control.Tag.ToString()) Is DBNull.Value) Then
                CType(Control, TimeSelect).Value = DirectCast(DataRow(Control.Tag.ToString()), String)
            ElseIf TypeOf (Control) Is IPAddressControl And Not (DataRow(Control.Tag.ToString()) Is DBNull.Value) Then
                CType(Control, IPAddressControl).Text = DirectCast(DataRow(Control.Tag.ToString()), String)
            End If
        End If
    End Sub

    Protected Overridable Sub OnDataRowChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataObject.DataRowChanged
        SetData(Me)
    End Sub

    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        DataObject.TableName = str_TableName
        LoadDataGridView()
        ToolStripManager.Renderer = New CS_Component.Office2007Renderer()
        Security.ApplyPermission(Me)
        MenuStrip1.Visible = False
        FocusFirst(Me)
    End Sub

    Private Sub mnu_F10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnu_F10.Click
        RaiseEvent F10Clicked(Me, e)
    End Sub
End Class
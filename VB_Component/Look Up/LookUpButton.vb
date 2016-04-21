Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Reflection

<DefaultEvent("Finalize_Result")> _
Public Class LookUpButton

    Public Event Finalize_Result As EventHandler
    Public Event Finalize_baseForm As EventHandler
    Public Event CodeTextChang As EventHandler
    Dim _ShowSrl As Integer
    Dim dt As DataTable
    Dim _SearchColomnIndex As Integer
    Dim LK As LookUpForm
    Dim ResultFieldIndex As Integer
    Dim CodeFieldIndex As Integer
    Dim HidenField As Integer()
    Dim ShowField As Boolean
    Dim assembly As System.Reflection.Assembly
    Dim FormName As String
    Dim _LoadBySerial As Boolean = False
    Dim FormCaption As String = ""
    Dim LastResult As DataRowView = Nothing
    Dim _ShowCodeTextBox As Boolean = True
    Dim _ValidateValue As Boolean = False
    Dim _RiseCodeChange As Boolean = True

    <Category("Nama"), Browsable(True)> _
    Public Property RiseCodeChange() As Boolean
        Get
            Return _RiseCodeChange
        End Get
        Set(ByVal value As Boolean)
            _RiseCodeChange = value
        End Set
    End Property

    <Category("Nama"), Description("true if u want Validate value Of Look up after click save"), Browsable(True)> _
    Public Property ValidateValue() As Boolean
        Get
            Return _ValidateValue
        End Get
        Set(ByVal value As Boolean)
            _ValidateValue = value
        End Set
    End Property

    <Category("Nama"), Description("show code text box to user?"), Browsable(True)> <System.ComponentModel.DefaultValue(44)> _
    Public Property ShowCodeTextBox() As Boolean
        Get
            Return _ShowCodeTextBox
        End Get
        Set(ByVal value As Boolean)
            _ShowCodeTextBox = value
            tbox_Code.Enabled = Not value
            If value Then
                btn_LoadLookUp.Size = New Size(Me.Size.Width - tbox_Result.Size.Width, btn_LoadLookUp.Size.Height)
            Else
                btn_LoadLookUp.Size = New Size(53, btn_LoadLookUp.Size.Height)
            End If
        End Set
    End Property

    Public ReadOnly Property Result() As DataRowView
        Get
            Try
                Dim dr As DataRowView = LK.Result
            Catch ex As Exception
                Return Nothing
            End Try
            Return LK.Result
        End Get
    End Property

    <Category("Nama"), Description("Size of code text box"), Browsable(True)> <System.ComponentModel.DefaultValue(44)> _
    Public Property CodeSize() As Integer
        Get
            Return tbox_Code.Size.Width
        End Get
        Set(ByVal value As Integer)
            If tbox_Code.Size.Width > value Then
                Dim sizechange As Integer = (tbox_Code.Size.Width - value)
                tbox_Result.Size = New Drawing.Point(tbox_Result.Size.Width + sizechange, tbox_Result.Size.Height)
                tbox_Result.Location = New Drawing.Point(0, 0)
                btn_LoadLookUp.Location = New Drawing.Point(btn_LoadLookUp.Location.X + sizechange, btn_LoadLookUp.Location.Y)
                tbox_Code.Location = New Drawing.Point(tbox_Code.Location.X + sizechange, tbox_Code.Location.Y)
                tbox_Code.Size = New Drawing.Size(value, tbox_Code.Size.Height)
            ElseIf tbox_Code.Size.Width < value Then
                Dim sizechange As Integer = (value - tbox_Code.Size.Width)
                tbox_Result.Size = New Drawing.Point(tbox_Result.Size.Width - sizechange, tbox_Result.Size.Height)
                tbox_Result.Location = New Drawing.Point(0, 0)
                btn_LoadLookUp.Location = New Drawing.Point(btn_LoadLookUp.Location.X - sizechange, btn_LoadLookUp.Location.Y)
                tbox_Code.Location = New Drawing.Point(tbox_Code.Location.X - sizechange, tbox_Code.Location.Y)
                tbox_Code.Size = New Drawing.Size(value, tbox_Code.Size.Height)
            ElseIf tbox_Code.Size.Width = value Then
                Return
            End If
        End Set
    End Property

    <Category("Nama"), Description("Activate Load By Serial"), Browsable(True)> <System.ComponentModel.DefaultValue(False)> _
    Public Property LoadingBySerial() As Boolean
        Get
            Return _LoadBySerial
        End Get
        Set(ByVal value As Boolean)
            _LoadBySerial = value
        End Set
    End Property

    <Description("Load By Serial"), Browsable(True), Category("Nama"), DefaultValue(0)> _
    Public Property GetSerial() As Integer
        Get
            Return GetSerial
        End Get
        Set(ByVal value As Integer)
            If Me._LoadBySerial Then
                Me.LoadBySerial(value)
            Else
                Me.tbox_Code.Text = value
            End If
        End Set
    End Property

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.Size = New Drawing.Size(MyBase.Size.Width, 22)
        MyBase.OnResize(e)
    End Sub

    Private Sub LookUpButton_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        'If tbox_Code.Focus() Then
        '    If (Not (e.KeyChar >= Convert.ToChar("0") And e.KeyChar <= Convert.ToChar("9"))) Then
        '        e.Handled = True
        '    End If
        '    If e.KeyChar = Convert.ToChar(Keys.Back) AndAlso DirectCast(sender, TextBox).Text.Trim <> "" Then
        '        Dim i As Integer = DirectCast(sender, TextBox).SelectionStart
        '        If DirectCast(sender, TextBox).SelectionStart <> 0 Then
        '            DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text.Remove(DirectCast(sender, TextBox).SelectionStart - 1, 1)
        '            DirectCast(sender, TextBox).SelectionStart = i - 1
        '        End If
        '    End If
        'End If
    End Sub

    Public Sub ShowLookUPForm()
        btn_LoadLookUp_Click(Me, Nothing)
    End Sub

    Public Sub ShowLookUPForm(ByVal SearchIndex As Integer, ByVal SearchStr As String)
        LK = New LookUpForm(SearchIndex, SearchStr)
        LK.HidenField = HidenField
        LK.ShowField = ShowField
        If LastResult Is Nothing Then
            LK.LoadLookUp(dt, FormCaption, _ShowSrl, SearchIndex, SearchStr)
        Else
            LK.LoadLookUp(dt, FormCaption, _ShowSrl, SearchIndex, SearchStr, LastResult)
        End If

        'Dim P As Point = Me.PointToScreen(btn_LoadLookUp.Location)
        LK.ShowDialog()
        'LK.SetDesktopLocation(P.X, P.Y + btn_LoadLookUp.Height)

        If Not LK.Result Is Nothing Then
            RemoveHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
            If LK.Result(CodeFieldIndex) Is DBNull.Value Then
                tbox_Code.Text = ""
            Else
                tbox_Code.Text = LK.Result(CodeFieldIndex)
            End If
            AddHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
            If LK.Result(ResultFieldIndex) Is DBNull.Value Then
                tbox_Result.Text = ""
            Else
                tbox_Result.Text = LK.Result(ResultFieldIndex)
            End If
            LastResult = LK.Result
            RaiseEvent Finalize_Result(Me, New EventArgs)
        End If
    End Sub

    Public Sub ResetResult()
        LastResult = Nothing
        If Not LK Is Nothing Then
            tbox_Code.Text = ""
            tbox_Result.Text = ""
            LK.Result = Nothing
        End If
    End Sub

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal CodeFieldIndex As Integer, ByVal ResultFieldIndex As Integer _
    , ByVal _FormCaption As String, ByVal ShowSerial As Boolean)
        _ShowSrl = ShowSerial
        Me.ResultFieldIndex = ResultFieldIndex
        Me.CodeFieldIndex = CodeFieldIndex
        Me.dt = dt
        FormCaption = _FormCaption
    End Sub

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal CodeFieldIndex As Integer, ByVal ResultFieldIndex As Integer _
    , ByVal _FormCaption As String, ByVal ShowSerial As Boolean, ByVal ShowOrHidenField As Integer(), ByVal _ShowField As Boolean)
        _ShowSrl = ShowSerial
        Me.ResultFieldIndex = ResultFieldIndex
        Me.CodeFieldIndex = CodeFieldIndex
        Me.dt = dt
        Me.HidenField = ShowOrHidenField
        Me.ShowField = _ShowField
        FormCaption = _FormCaption
    End Sub

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal CodeFieldIndex As Integer, ByVal ResultFieldIndex As Integer _
    , ByVal _FormCaption As String, ByVal ShowSerial As Boolean, ByVal ShowOrHidenField As Integer(), ByVal _ShowField As Boolean, ByVal assembly As System.Reflection.Assembly _
    , ByVal FormName As String)
        _ShowSrl = ShowSerial
        Me.ResultFieldIndex = ResultFieldIndex
        Me.CodeFieldIndex = CodeFieldIndex
        Me.dt = dt
        Me.HidenField = ShowOrHidenField
        Me.ShowField = _ShowField
        Me.assembly = assembly
        Me.FormName = FormName
        FormCaption = _FormCaption
    End Sub

    Public Sub LoadBySerial(ByVal serial As Integer)
        LK = New LookUpForm
        LK.HidenField = HidenField
        LK.ShowField = ShowField
        LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex)
        LK.LoadBySerial(Me, serial, CodeFieldIndex)
    End Sub

    Public Sub LoadByCodeField()
        RemoveHandler Me.tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
        If tbox_Code.Text.Length > 0 Then

            LK = New LookUpForm()
            LK.LoadLookUp(dt, FormCaption, _ShowSrl, CodeFieldIndex, tbox_Code.Text.Trim)
            LK.SetDigitalRef(Me)
            If LK.Result Is Nothing Then
                tbox_Result.Text = "موردي يافت نشد"
            Else
                If LK.Result(ResultFieldIndex) Is DBNull.Value Then
                    tbox_Result.Text = ""
                Else
                    tbox_Result.Text = LK.Result(ResultFieldIndex)
                End If

                RaiseEvent Finalize_Result(Nothing, Nothing)
            End If

        Else
            If Not LK Is Nothing Then
                LK.Result = Nothing
                LastResult = Nothing
                tbox_Result.Text = ""
            End If
            RaiseEvent Finalize_Result(Nothing, Nothing)
        End If
        AddHandler Me.tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
    End Sub

    Private Sub btn_LoadLookUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LoadLookUp.Click
        RemoveHandler tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
        RemoveHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
        LK = New LookUpForm
        LK.HidenField = HidenField
        LK.ShowField = ShowField

        If tbox_Code.Focused Then
            If LastResult Is Nothing Then
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Code.Text.Trim)
            Else
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Code.Text.Trim, LastResult)
            End If
        Else
            If LastResult Is Nothing Then
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Result.Text.Trim)
            Else
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Result.Text.Trim, LastResult)
            End If
        End If
       
        'Dim P As Point = Me.PointToScreen(btn_LoadLookUp.Location)
        LK.ShowDialog()
        'LK.SetDesktopLocation(P.X, P.Y + btn_LoadLookUp.Height)

        If Not LK.Result Is Nothing Then
            RemoveHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
            If LK.Result(CodeFieldIndex) Is DBNull.Value Then
                tbox_Code.Text = ""
            Else
                tbox_Code.Text = LK.Result(CodeFieldIndex)
            End If
            AddHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
            If LK.Result(ResultFieldIndex) Is DBNull.Value Then
                tbox_Result.Text = ""
            Else
                tbox_Result.Text = LK.Result(ResultFieldIndex)
            End If
            LastResult = LK.Result
            RaiseEvent Finalize_Result(sender, e)
        End If

        tbox_Code.Focus()
        AddHandler tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
        AddHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
    End Sub

    Private Sub tbox_Result_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbox_Result.KeyPress
        If e.KeyChar = ChrW(Keys.Space) Then
            e.Handled = True

            RemoveHandler tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
            RemoveHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
            LK = New LookUpForm
            LK.HidenField = HidenField
            LK.ShowField = ShowField

            If LastResult Is Nothing Then
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Result.Text.Trim)
            Else
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Result.Text.Trim, LastResult)
            End If

            'Dim P As Point = Me.PointToScreen(btn_LoadLookUp.Location)
            LK.ShowDialog()
            'LK.SetDesktopLocation(P.X, P.Y + btn_LoadLookUp.Height)

            If Not LK.Result Is Nothing Then
                RemoveHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
                If LK.Result(CodeFieldIndex) Is DBNull.Value Then
                    tbox_Code.Text = ""
                Else
                    tbox_Code.Text = LK.Result(CodeFieldIndex)
                End If
                AddHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
                If LK.Result(ResultFieldIndex) Is DBNull.Value Then
                    tbox_Result.Text = ""
                Else
                    tbox_Result.Text = LK.Result(ResultFieldIndex)
                End If
                LastResult = LK.Result
                RaiseEvent Finalize_Result(sender, e)
            End If
            tbox_Code.Focus()
            AddHandler tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
            AddHandler tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)

            Return
        End If
        If Not dt Is Nothing Then
            If Not dt.Columns(CodeFieldIndex).DataType.ToString().Equals("System.String") Then
                If (Not (e.KeyChar >= Convert.ToChar("0") And e.KeyChar <= Convert.ToChar("9"))) Then
                    e.Handled = True
                End If
                If e.KeyChar = Convert.ToChar(Keys.Back) AndAlso DirectCast(sender, TextBox).Text.Trim <> "" Then
                    Dim i As Integer = tbox_Code.SelectionStart
                    If tbox_Code.SelectionStart <> 0 Then
                        'RemoveHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
                        DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text.Remove(tbox_Code.SelectionStart - 1, 1)
                        'AddHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
                        tbox_Code.SelectionStart = i - 1
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub LookUpButton_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        If tbox_Code.Enabled Then
            tbox_Code.Focus()
        Else
            tbox_Result.Focus()
        End If
    End Sub

    Private Sub tbox_Code_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Code.Enter
        tbox_Code.BackColor = Drawing.Color.FromArgb(&HFF, &HFF, &H88)
    End Sub

    Private Sub tbox_Code_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Code.Leave
        tbox_Code.BackColor = Drawing.Color.White
    End Sub

    Private Sub tbox_Code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Code.TextChanged
        RaiseEvent CodeTextChang(sender, e)
        If RiseCodeChange Then
            RemoveHandler Me.tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
            If tbox_Code.Text.Length > 0 Then

                LK = New LookUpForm()
                LK.LoadLookUp(dt, FormCaption, _ShowSrl, CodeFieldIndex, tbox_Code.Text.Trim)
                LK.SetDigitalRef(Me)
                If LK.Result Is Nothing Then
                    tbox_Result.Text = "موردي يافت نشد"
                Else
                    If LK.Result(ResultFieldIndex) Is DBNull.Value Then
                        tbox_Result.Text = ""
                    Else
                        tbox_Result.Text = LK.Result(ResultFieldIndex)
                    End If

                    RaiseEvent Finalize_Result(sender, e)
                End If

            Else
                If Not LK Is Nothing Then
                    LK.Result = Nothing
                    LastResult = Nothing
                    tbox_Result.Text = ""
                End If
                RaiseEvent Finalize_Result(sender, e)
            End If
            AddHandler Me.tbox_Result.TextChanged, New EventHandler(AddressOf tbox_Result_TextChanged)
        End If
    End Sub

    Private Sub tbox_Code_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbox_Code.KeyDown
        If e.KeyCode = Keys.PageUp Then
            e.Handled = True
            btn_LoadLookUp_Click(sender, e)
        End If
    End Sub

    Private Sub tbox_Code_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbox_Code.KeyPress

        'If e.KeyChar = ChrW(Keys.Space) Then
        '    e.Handled = True
        '    btn_LoadLookUp_Click(sender, e)
        '    Return
        'End If
        If Not dt Is Nothing Then
            If Not dt.Columns(CodeFieldIndex).DataType.ToString().Equals("System.String") Then
                If (Not (e.KeyChar >= Convert.ToChar("0") And e.KeyChar <= Convert.ToChar("9"))) Then
                    e.Handled = True
                End If
                If e.KeyChar = Convert.ToChar(Keys.Back) AndAlso DirectCast(sender, TextBox).Text.Trim <> "" Then
                    Dim i As Integer = tbox_Code.SelectionStart
                    If tbox_Code.SelectionStart <> 0 Then
                        'RemoveHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
                        DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text.Remove(tbox_Code.SelectionStart - 1, 1)
                        'AddHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
                        tbox_Code.SelectionStart = i - 1
                    End If
                End If
            End If
            tbox_Code_TextChanged(sender, e)
        End If

    End Sub

    Private Sub btn_LoadForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LoadForm.Click
        Try

            TryCast(assembly.CreateInstance(FormName), Form).ShowDialog()
        Catch exNull As NullReferenceException
            MessageBoxFa.Show("نام فرم مقداردهي نشده", "Form not found")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        RaiseEvent Finalize_baseForm(sender, e)
    End Sub

    Private Sub tbox_Result_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Result.TextChanged
        RemoveHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
        RemoveHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
        If tbox_Result.Text.Length > 0 Then
            LK = New LookUpForm()
            LK.LoadLookUp(dt, FormCaption, _ShowSrl, ResultFieldIndex, tbox_Result.Text.Trim)
            LK.SetDigitalRefByIndex(Me)
            If Not LK.Result Is Nothing Then
                If LK.Result(CodeFieldIndex) Is DBNull.Value Then
                    tbox_Code.Text = ""
                Else
                    tbox_Code.Text = LK.Result(CodeFieldIndex)
                End If
                RaiseEvent Finalize_Result(sender, e)
            Else
                tbox_Code.Text = ""
                'tbox_Result.Text = LK.Result(ResultFieldIndex)
                RaiseEvent Finalize_Result(sender, e)
            End If
        Else
            tbox_Result.Text = ""
        End If
        AddHandler Me.tbox_Code.TextChanged, New EventHandler(AddressOf tbox_Code_TextChanged)
    End Sub
End Class

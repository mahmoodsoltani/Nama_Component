Imports System.ComponentModel

<DefaultEvent("Finalize_Result")> _
Public Class TimeSelect
    Dim _Minutes As String = ""
    Dim _Hour As String = ""
    Dim _Second As String = ""
    Dim _Value As String
    Dim _ShowSecond As Boolean = False
    Private _time As New TimeSpan(0, 0, 0)
    Public Event Finalize_Result As EventHandler

    <Category("Nama"), Browsable(True)> _
    Public Property time() As TimeSpan
        Get
            setTime()
            Return _time
        End Get
        Set(ByVal value As TimeSpan)
            Minutes = value.Minutes.ToString()
            Hour = value.Hours.ToString()
            Second = value.Seconds.ToString()
            setTime()
        End Set
    End Property

    <Category("Nama"), Browsable(True)> _
    Public Property HourMaxLen() As Integer
        Get
            Return txt_Hour.MaxLength
        End Get
        Set(ByVal value As Integer)
            txt_Hour.MaxLength = value
        End Set
    End Property

    <Category("Nama"), Browsable(True), DefaultValue(False)> _
    Public Property ShowSecond() As Boolean
        Get
            Return _ShowSecond
        End Get
        Set(ByVal value As Boolean)
            _ShowSecond = value
            InitialSecond()
        End Set
    End Property

    <Category("Nama"), Browsable(True)> _
    Public Property Minutes() As String
        Get
            Return _Minutes
        End Get
        Set(ByVal value As String)
            Try
                If CInt(value) > -1 And CInt(value) < 61 Then
                    _Minutes = value
                    txt_Min.Value = _Minutes
                Else
                    txt_Min.Value = "59"
                    txt_Min.SelectionStart = 2
                    _Minutes = "59"
                End If
                setTime()
            Catch
                txt_Min.Value = "00"
                _Minutes = "00"
                setTime()
            End Try
        End Set
    End Property

    <Category("Nama"), Browsable(True)> _
    Public Property Second() As String
        Get
            Return _Second
        End Get
        Set(ByVal value As String)
            Try
                If CInt(value) > -1 And CInt(value) < 61 Then
                    _Second = value
                    txt_Sec.Value = _Second
                Else
                    _Second = "59"
                    txt_Sec.Value = "59"
                    txt_Sec.SelectionStart = 2
                End If
                setTime()
            Catch
                _Second = "00"
                txt_Sec.Value = "00"
                setTime()
            End Try
        End Set
    End Property

    <Category("Nama"), Browsable(True)> _
    Public Property Hour() As String
        Get
            Return _Hour
        End Get
        Set(ByVal value As String)
            Try
                If CInt(value) > -1 Then
                    _Hour = value
                    txt_Hour.Value = _Hour
                Else
                    _Hour = "0"
                    txt_Hour.Value = "0"
                End If
                setTime()
            Catch
                _Hour = "0"
                txt_Hour.Value = "0"
                setTime()
            End Try
        End Set
    End Property

    Public Property Value() As String
        Get
            Return _time.ToString()
        End Get
        Set(ByVal value As String)
            Dim H As String
            Dim M As String
            Dim S As String
            If value.IndexOf(":") < 0 Or value.Split(":").Length > 3 Then
                txt_Hour.Value = "0"
                txt_Min.Value = "00"
                txt_Sec.Value = "00"
                Hour = "0"
                Minutes = "00"
                Second = "00"
                _time = New TimeSpan(0, 0, 0)
            Else
                Try
                    If value.Split(":").Length = 3 Then
                        H = value.Substring(0, value.IndexOf(":"))
                        M = value.Substring(value.IndexOf(":") + 1, value.LastIndexOf(":") - (value.IndexOf(":") + 1))
                        S = value.Substring(value.LastIndexOf(":") + 1)
                    Else
                        H = value.Substring(0, value.IndexOf(":"))
                        M = value.Substring(value.IndexOf(":") + 1)
                        S = "00"
                    End If
                    Hour = H
                    Minutes = M
                    Second = S
                    setTime()
                Catch
                    txt_Hour.Value = "0"
                    txt_Min.Value = "00"
                    txt_Sec.Value = "00"
                    Hour = "0"
                    Minutes = "00"
                    Second = "00"
                    _time = New TimeSpan(0, 0, 0)
                End Try
            End If
        End Set
    End Property

    '<Category("Nama"), Browsable(True)> _
    ''Public Property ColorOnFocus() As Color
    ''    Get
    ''        Return _ColorOnFocus
    ''    End Get
    ''    Set(ByVal value As Color)
    ''        _ColorOnFocus = value
    ''    End Set
    ''End Property

    'Sub SelectAllText(ByVal nudControl As NumericUpDown)
    '    Dim udb As UpDownBase = DirectCast(nudControl, UpDownBase)
    '    udb.Select(0, udb.Text.Length)
    'End Sub

    'Private Sub NDU_Min_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DirectCast(sender, NumericUpDown).BackColor = _ColorOnFocus
    '    SelectAllText(DirectCast(sender, NumericUpDown))
    'End Sub

    'Private Sub NDU_Min_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DirectCast(sender, NumericUpDown).BackColor = SystemColors.Window
    'End Sub

    'Private Sub NDU_Min_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Not (Char.IsDigit(e.KeyChar)) And e.KeyChar <> ControlChars.Back Then
    '        e.KeyChar = "\0"
    '    End If
    'End Sub

    Public Overridable Sub NDU_Min_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Min.ValueChanged, txt_Min.TextChanged
        If txt_Min.Text.Length > 0 Then
            Minutes = txt_Min.Value
            RaiseEvent Finalize_Result(Nothing, Nothing)
        End If
        If txt_Hour.Text.Length = 2 Then
            Try
                If Integer.Parse(txt_Hour.Value) > 59 Then
                    txt_Hour.Value = "59"
                End If
            Catch ex As Exception
                txt_Hour.Value = "59"
            End Try
        End If
    End Sub

    Public Overridable Sub NDU_Hour_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Hour.ValueChanged, txt_Hour.TextChanged
        If txt_Hour.Text.Length > 0 Then
            Hour = txt_Hour.Value
            RaiseEvent Finalize_Result(Nothing, Nothing)
        End If
        If txt_Hour.Text.Length = 2 Then
            Try
                If Integer.Parse(txt_Hour.Value) > 23 Then
                    txt_Hour.Value = "23"
                Else
                    txt_Min.Focus()
                End If
            Catch ex As Exception
                txt_Hour.Value = "23"
            End Try
        End If
    End Sub

    Public Overridable Sub NDU_Second_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Sec.ValueChanged, txt_Sec.TextChanged
        If txt_Sec.Text.Length > 0 Then
            Second = txt_Sec.Value
            RaiseEvent Finalize_Result(Nothing, Nothing)
        End If
    End Sub

    Public Sub ResetResult()
        Hour = "0"
        Minutes = "00"
        Second = "00"
    End Sub

    Private Sub TimeSelect_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        InitialSecond()
    End Sub

    Sub InitialSecond()
        txt_Sec.Anchor = AnchorStyles.None
        txt_Min.Anchor = AnchorStyles.None
        txt_Hour.Anchor = AnchorStyles.None
        Min_Hour_Spliter.Anchor = AnchorStyles.None
        Min_Sec_spliter.Anchor = AnchorStyles.None
        If _ShowSecond Then
            If Width < 110 Then
                Width = 110
            End If

            Min_Sec_spliter.Visible = True
            txt_Sec.Visible = True
            txt_Sec.TabStop = True

            txt_Sec.Location = New Point(Width - 30, 0)
            Min_Sec_spliter.Location = New Point(Width - 40, 0)
            txt_Min.Location = New Point(Width - 70, 0)
            Min_Hour_Spliter.Location = New Point(Width - 80, 0)
            txt_Hour.Width = Width - 80
        Else
            txt_Hour.Width = Width - 40
            If Width < 70 Then
                Width = 70
            End If

            txt_Sec.Visible = False
            Min_Sec_spliter.Visible = False
            txt_Sec.TabStop = False

            txt_Min.Location = New Point(Width - 30, 0)
            Min_Hour_Spliter.Location = New Point(Width - 40, 0)
        End If
        txt_Hour.Location = New Point(0, 0)
        txt_Sec.Anchor = AnchorStyles.Right
        txt_Min.Anchor = AnchorStyles.Right
        txt_Hour.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Min_Sec_spliter.Anchor = AnchorStyles.Right
        txt_Hour.Focus()
    End Sub

    Public Function TimePercent(ByVal inputTime As TimeSpan, ByVal Percent As Double) As TimeSpan
        Dim result As TimeSpan = inputTime
        Dim tmp_min As Double = (inputTime.Minutes * Percent) / 100
        result = inputTime.Add(New TimeSpan(0, tmp_min, 0))

        Dim tmp_hor As Double = (inputTime.Hours * Percent) / 100
        Return result.Add(New TimeSpan(tmp_hor, 0, 0))
    End Function

    Sub setTime()
        Try
            If _ShowSecond Then
                _time = New TimeSpan(CInt(_Hour), CInt(_Minutes), CInt(_Second))
            Else
                _time = New TimeSpan(CInt(_Hour), CInt(_Minutes), 0)
            End If
        Catch
            _time = New TimeSpan(0, 0, 0)
        End Try
    End Sub

    Private Sub txt_Min_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_Min.KeyUp, txt_Hour.KeyUp
        Try
            If txt_Min.Value.ToString().Length = 2 And _ShowSecond And CInt(txt_Min.Value) <> 0 And Not e.KeyCode = Keys.Tab And Not e.KeyCode = Keys.ShiftKey And Not e.KeyCode = Keys.Enter Then
                txt_Sec.Focus()
            ElseIf txt_Min.Value.ToString().Length >= 2 Then
            End If
        Catch
        End Try
    End Sub

    Private Sub txt_Hour_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_Hour.KeyUp
        Try
            If txt_Hour.Value.ToString().Length = txt_Hour.MaxLength And CInt(txt_Hour.Value) <> 0 And Not e.KeyCode = Keys.Tab And Not e.KeyCode = Keys.ShiftKey And Not e.KeyCode = Keys.Enter Then
                txt_Min.Focus()
            End If
        Catch
        End Try
    End Sub

    Private Sub TimeSelect_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Enter
        txt_Hour.Focus()
    End Sub

    Private Sub txt_Hour_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Hour.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txt_Min.Focus()
        End If
    End Sub

    Private Sub txt_Min_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_Min.MouseDown
        DirectCast(sender, CS_Component.TextBox).Focus()
    End Sub

    Private Sub txt_Sec_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_Sec.MouseDown
        DirectCast(sender, CS_Component.TextBox).Focus()
    End Sub

    Private Sub TimeSelect_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_Hour.Focused Then
                txt_Min.Focus()
            ElseIf txt_Min.Focus And _ShowSecond Then
                txt_Sec.Focus()
            Else
                ProcessTabKey(True)
            End If
        End If
    End Sub
End Class

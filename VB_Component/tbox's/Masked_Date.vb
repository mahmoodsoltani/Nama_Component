Imports System.ComponentModel

Public Class Masked_Date

    Dim _ValidateValue As Boolean = False
    Dim _Read_Only As Boolean = False
    Public Event TarikhChange As EventHandler
    Private _EnterStop As Boolean = True
    Private DayChanged As Boolean = False

    <Category("Nama"), Description("If true go on to the  next control by enter"), Browsable(True)> _
   Public Property EnterStop() As Boolean
        Get
            Return _EnterStop
        End Get
        Set(ByVal value As Boolean)
            _EnterStop = value
        End Set
    End Property

    <Category("Nama"), Description("true if u want Validate value Of date box after click save"), Browsable(True)> _
    Public Property ValidateValue() As Boolean
        Get
            Return _ValidateValue
        End Get
        Set(ByVal value As Boolean)
            _ValidateValue = value
        End Set
    End Property

    <Category("Nama"), Description(""), Browsable(True), DefaultValueAttribute("13  /  /  ")> _
    Public Property Tarikh() As String
        Get
            ValidateRozMah()
            Return "13" + tbox_Sal.Text + "/" + tbox_Mah.Text + "/" + tbox_roz.Text
        End Get
        Set(ByVal value As String)
            Try
                tbox_Sal.Text = value.Substring(2, 2)
                tbox_Mah.Text = value.Substring(5, 2)
                'RemoveHandler tbox_roz.TextChanged, New EventHandler(AddressOf tbox_roz_TextChanged)
                tbox_roz.Text = value.Substring(8, 2)
                'AddHandler tbox_roz.TextChanged, New EventHandler(AddressOf tbox_roz_TextChanged)
            Catch
            End Try
        End Set
    End Property

    <Category("Nama"), Description(""), Browsable(True)> _
    Public Property Read_Only() As Boolean
        Get
            Return _Read_Only
        End Get
        Set(ByVal value As Boolean)
            _Read_Only = value
            If _Read_Only Then
                Me.BackColor = Drawing.SystemColors.Info
                tbox_Mah.BackColor = Drawing.SystemColors.Info
                tbox_roz.BackColor = Drawing.SystemColors.Info
                tbox_Sal.BackColor = Drawing.SystemColors.Info
                Label1.BackColor = Drawing.SystemColors.Info
                Label2.BackColor = Drawing.SystemColors.Info
                Label3.BackColor = Drawing.SystemColors.Info

                tbox_Mah.ReadOnly = True
                tbox_roz.ReadOnly = True
                tbox_Sal.ReadOnly = True

                tbox_Mah.Enabled = False
                tbox_roz.Enabled = False
                tbox_Sal.Enabled = False
                Label1.Enabled = False
                Label2.Enabled = False
                Label3.Enabled = False
            Else
                Me.BackColor = Drawing.SystemColors.Window
                tbox_Mah.BackColor = Drawing.SystemColors.Window
                tbox_roz.BackColor = Drawing.SystemColors.Window
                tbox_Sal.BackColor = Drawing.SystemColors.Window
                Label1.BackColor = Drawing.SystemColors.Window
                Label2.BackColor = Drawing.SystemColors.Window
                Label3.BackColor = Drawing.SystemColors.Window

                tbox_Mah.ReadOnly = False
                tbox_roz.ReadOnly = False
                tbox_Sal.ReadOnly = False

                tbox_Mah.Enabled = True
                tbox_roz.Enabled = True
                tbox_Sal.Enabled = True
                Label1.Enabled = True
                Label2.Enabled = True
                Label3.Enabled = True
            End If
        End Set
    End Property

    Public ReadOnly Property TextOrEmpty()
        Get
            If tbox_Sal.Text.Trim = "" And tbox_Mah.Text.Trim = "" And tbox_roz.Text.Trim = "" Then
                Return Nothing
            End If
            Return Tarikh
        End Get
    End Property

    Public Overloads Property Text()
        Get
            Return Tarikh
        End Get
        Set(ByVal value)
            RemoveHandler tbox_roz.TextChanged, New EventHandler(AddressOf tbox_roz_TextChanged)
            RemoveHandler tbox_Mah.TextChanged, New EventHandler(AddressOf tbox_Mah_TextChanged)
            RemoveHandler tbox_Sal.TextChanged, New EventHandler(AddressOf tbox_Sal_TextChanged)
            Tarikh = value
            AddHandler tbox_roz.TextChanged, New EventHandler(AddressOf tbox_roz_TextChanged)
            AddHandler tbox_Mah.TextChanged, New EventHandler(AddressOf tbox_Mah_TextChanged)
            AddHandler tbox_Sal.TextChanged, New EventHandler(AddressOf tbox_Sal_TextChanged)
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Text = "13  /  /  "
    End Sub

    Private Sub GoFocus(ByVal GoForward As Boolean)
        If GoForward Then
            Try
                If DirectCast(Me.ActiveControl, System.Windows.Forms.TextBox).Name = tbox_roz.Name Then
                    Exit Sub
                ElseIf DirectCast(Me.ActiveControl, System.Windows.Forms.TextBox).Name = tbox_Mah.Name Then
                    tbox_roz.Focus()
                ElseIf DirectCast(Me.ActiveControl, System.Windows.Forms.TextBox).Name = tbox_Sal.Name Then
                    tbox_Mah.Focus()
                End If
            Catch
            End Try
        Else
            Try
                If DirectCast(Me.ActiveControl, System.Windows.Forms.TextBox).Name = tbox_roz.Name Then
                    tbox_Mah.Focus()
                ElseIf DirectCast(Me.ActiveControl, System.Windows.Forms.TextBox).Name = tbox_Mah.Name Then
                    tbox_Sal.Focus()
                ElseIf DirectCast(Me.ActiveControl, System.Windows.Forms.TextBox).Name = tbox_Sal.Name Then
                    Exit Sub
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub tbox_roz_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbox_roz.KeyDown, tbox_Sal.KeyDown, tbox_Mah.KeyDown
        If e.KeyCode = Keys.Left Then
            GoFocus(False)
        ElseIf e.KeyCode = Keys.Right Then
            GoFocus(True)
        ElseIf e.KeyValue = 191 Then
            GoFocus(True)
        ElseIf e.KeyValue = Keys.Enter Then
            If TabStop Then
                Exit Sub
            End If
        Else
            Application.DoEvents()
            If Not DirectCast(sender, System.Windows.Forms.TextBox).Text.Trim.Equals("") Then
                If DirectCast(sender, System.Windows.Forms.TextBox).Name = tbox_roz.Name Then
                    If Double.Parse(DirectCast(sender, System.Windows.Forms.TextBox).Text) > 31 Then
                        Return
                    End If
                ElseIf DirectCast(sender, System.Windows.Forms.TextBox).Name = tbox_Mah.Name Then
                    If Double.Parse(DirectCast(sender, System.Windows.Forms.TextBox).Text) > 12 Then
                        Return
                    End If
                End If
            End If

            If DirectCast(sender, System.Windows.Forms.TextBox).MaxLength _
            = DirectCast(sender, System.Windows.Forms.TextBox).Text.Trim().Length Then
                GoFocus(False)
            End If
        End If
    End Sub

    Private Sub tbox_roz_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbox_roz.KeyPress, tbox_Sal.KeyPress, tbox_Mah.KeyPress
        If (Not (e.KeyChar >= Convert.ToChar("0") And e.KeyChar <= Convert.ToChar("9"))) Then
            e.Handled = True
        End If
        If e.KeyChar = Convert.ToChar(Keys.Back) _
        AndAlso DirectCast(sender, System.Windows.Forms.TextBox).Text.Trim <> "" Then
            DirectCast(sender, System.Windows.Forms.TextBox).Text = _
            DirectCast(sender, System.Windows.Forms.TextBox).Text.Remove(DirectCast(sender, System.Windows.Forms.TextBox).Text.Length - 1, 1)
            System.Windows.Forms.SendKeys.Send("{END}")
        End If
        If e.KeyChar = Convert.ToChar(191) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbox_roz_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_roz.Enter, tbox_Sal.Enter, tbox_Mah.Enter
        If DirectCast(sender, System.Windows.Forms.TextBox).Text.Replace(" ", "") = "" Then
            DirectCast(sender, System.Windows.Forms.TextBox).Text = ""
        Else
            DirectCast(sender, System.Windows.Forms.TextBox).SelectAll()
        End If
    End Sub

    Public Function Validate_FDate(Optional ByVal ChekEmpty As Boolean = False _
    , Optional ByVal Promt As Boolean = True) As Boolean
        If ChekEmpty Then
            If tbox_Sal.Text.Trim = "" And tbox_Mah.Text = "" And tbox_roz.Text = "" Then
                Return True
            End If
        End If
        Dim i_yy, i_mm, i_dd As Integer
        Dim dt As String
        Dim fmt As String = " مثال :" & " 1362/04/13 "

        dt = Trim(Me.Text)

        i_yy = Val(Mid(dt, 1, 4))
        If i_yy < 1300 Or i_yy > 2500 Then
            If Promt Then
                MessageBoxFa.Show(" سال در تاريخ به طور صحيح وارد نشده " & fmt, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return False
        End If

        i_mm = Val(Mid(dt, 6, 2))
        If i_mm < 0 Or i_mm > 12 Then
            If Promt Then
                MessageBoxFa.Show(" ماه در تاريخ به طور صحيح وارد نشده " & fmt, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return False
        End If

        i_dd = Val(Mid(dt, 9, 2))
        If i_dd < 0 Or i_dd > 31 Then
            If Promt Then
                MessageBoxFa.Show(" روز در تاريخ به طور صحيح وارد نشده " & fmt, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return False
        End If

        'i_dd = Len(Trim(dt))
        'If i_dd <> 0 And i_dd < Len(fmt) Then
        '    MessageBoxFa.Show("فرمت تاريخ درست نيست " & fmt, "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        'End If

        Return True
    End Function

    Private Sub Masked_Date_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        ValidateRozMah()
    End Sub

    Dim temp_Txt_roz As String = ""

    Private Sub tbox_roz_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_roz.Leave
        If Val(tbox_roz.Text) > 31 Or Val(tbox_roz.Text) <= 0 Then
            ' ErrorProvider1.SetError(Me, "روز در تاريخ به طور صحيح وارد نشده")
        Else
            ErrorProvider1.SetError(Me, "")
        End If
        ValidateRozMah()
    End Sub

    Private Sub tbox_Mah_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Mah.Leave
        If Val(tbox_Mah.Text) > 12 Or Val(tbox_Mah.Text) <= 0 Then
            'ErrorProvider1.SetError(Me, "ماه در تاريخ به طور صحيح وارد نشده")
        Else
            ErrorProvider1.SetError(Me, "")
        End If
        If Val(tbox_Mah.Text) >= 7 And Val(tbox_Mah.Text) <= 12 Then
            If Val(tbox_roz.Text) >= 31 Or Val(tbox_roz.Text) <= 0 Then
                ' ErrorProvider1.SetError(Me, "روز در تاريخ به طور صحيح وارد نشده")
            Else
                ErrorProvider1.SetError(Me, "")
            End If
        End If
        ValidateRozMah()
    End Sub

    Private Sub ValidateRozMah()
        If tbox_Mah.Text.Length = 1 Then
            tbox_Mah.Text = "0" + tbox_Mah.Text
        End If
        If tbox_roz.Text.Length = 1 Then
            tbox_roz.Text = "0" + tbox_roz.Text
        End If
        If tbox_Sal.Text.Length = 1 Then
            tbox_Sal.Text = "0" + tbox_Sal.Text
        End If
    End Sub

    Private Sub tbox_roz_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_roz.TextChanged
        If DirectCast(sender, System.Windows.Forms.TextBox).Text.Trim.Length = 2 Then
            RaiseEvent TarikhChange(Me, New EventArgs)
            tbox_Mah.TabStop = True
        End If
    End Sub

    Public Sub ResetTarikh()
        tbox_Mah.Text = ""
        tbox_Sal.Text = ""
        tbox_roz.Text = ""
    End Sub

    Private Sub tbox_Mah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Mah.TextChanged
        Select Case DirectCast(sender, System.Windows.Forms.TextBox).Text.Trim.Length
            Case 1
                If Integer.Parse(DirectCast(sender, System.Windows.Forms.TextBox).Text) > 1 Then
                    DirectCast(sender, System.Windows.Forms.TextBox).Text = "0" + DirectCast(sender, System.Windows.Forms.TextBox).Text
                    RaiseEvent TarikhChange(Me, New EventArgs)
                End If
            Case 2
                If Integer.Parse(DirectCast(sender, System.Windows.Forms.TextBox).Text) <= 12 Then
                    RaiseEvent TarikhChange(Me, New EventArgs)
                End If
                tbox_Sal.TabStop = True
        End Select
    End Sub

    Private Sub tbox_Sal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_Sal.TextChanged
        If DirectCast(sender, System.Windows.Forms.TextBox).Text.Trim.Length = 2 Then
            RaiseEvent TarikhChange(Me, New EventArgs)
        End If
    End Sub
End Class

Imports System.Windows.Forms
Imports System.ComponentModel
Public Class Tbox

    Dim _ValidateValue As Boolean = False
    Dim _CheckLength As Boolean = False
    Dim _TextPading As Boolean = False
    Dim _cololOnFocus As System.Drawing.Color = Drawing.Color.FromArgb(&HFF, &HFF, &H88)
    Dim _ErrorMessage As String
    Private _Type As TypeOfValues
    Private _EnterStop As Boolean = True

    Public Enum TypeOfValues
        All = 0
        Digit = 1
        DigitDot = 2
        Currency = 3
    End Enum

    <Category("Nama"), Description("If true go on to the  next control by enter"), Browsable(True)> _
   Public Property EnterStop() As Boolean
        Get
            Return _EnterStop
        End Get
        Set(ByVal value As Boolean)
            _EnterStop = value
        End Set
    End Property

    <Category("Nama"), Description("Set the message to displays in error messages"), Browsable(True)> _
    Public Property ErrorMessage() As String
        Get
            Return Me._ErrorMessage
        End Get
        Set(ByVal value As String)
            Me._ErrorMessage = value
        End Set
    End Property

    <Category("Nama"), Description(""), Browsable(True)> _
    Public Property TypeOfContains() As TypeOfValues
        Get
            Return Me._Type
        End Get
        Set(ByVal value As TypeOfValues)
            Me._Type = value
        End Set
    End Property

    <Category("Nama"), Description("Check the length in Validation function"), Browsable(True)> _
    Public Property CheckLength() As Boolean
        Get
            Return Me._CheckLength
        End Get
        Set(ByVal value As Boolean)
            Me._CheckLength = value
        End Set
    End Property

    <Category("Nama"), Description("adding the padding to the text"), Browsable(True)> _
    Public Property TextPading() As Boolean
        Get
            Return Me._TextPading
        End Get
        Set(ByVal value As Boolean)
            Me._TextPading = value
        End Set
    End Property

    <Category("Nama"), Description("true if u want Validate value Of textbox after click save"), Browsable(True)> _
    Public Property ValidateValue() As Boolean
        Get
            Return _ValidateValue
        End Get
        Set(ByVal value As Boolean)
            _ValidateValue = value
        End Set
    End Property

    <Category("Nama"), Description("Color Of textbox when Got Focus"), Browsable(True)> _
    Public Property ColorOnFoucus() As System.Drawing.Color
        Get
            Return _cololOnFocus
        End Get
        Set(ByVal value As System.Drawing.Color)
            _cololOnFocus = value
        End Set
    End Property

    Private Sub Tbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        If _Type = TypeOfValues.Digit Or _Type = TypeOfValues.DigitDot Then
            Me.TextAlign = HorizontalAlignment.Center
        Else
            If InputLanguage.CurrentInputLanguage.Culture.ToString() = "fa-IR" Then
                MyBase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Else
                MyBase.RightToLeft = System.Windows.Forms.RightToLeft.No
            End If
        End If

        Me.BackColor = _cololOnFocus
        If TextPading Then
            ApplyPading()
        End If
    End Sub

    Private Sub Tbox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "ك"c Then
            e.KeyChar = "ک"c
        End If

        If e.KeyChar = "ی"c Then
            e.KeyChar = "ي"c
        End If

        If _Type = TypeOfValues.DigitDot Then

            If (((e.KeyChar < "0"c) OrElse (e.KeyChar > "9"c)) AndAlso (e.KeyChar <> Convert.ToChar("."))) Then
                e.Handled = True
            End If
            If e.KeyChar = Convert.ToChar(".") Then
                If DirectCast(sender, TextBox).Text.IndexOf(Convert.ToChar(".")) <> -1 Then
                    e.Handled = True
                End If
            End If
        ElseIf _Type = TypeOfValues.Digit Then
            If (Not (e.KeyChar >= Convert.ToChar("0") And e.KeyChar <= Convert.ToChar("9"))) Then
                e.Handled = True
            End If
        End If

        If _Type = TypeOfValues.DigitDot Or _Type = TypeOfValues.Digit Then
            If e.KeyChar = Convert.ToChar(Keys.Back) AndAlso DirectCast(sender, TextBox).Text.Trim <> "" Then
                Dim i As Integer = Me.SelectionStart
                If SelectionStart <> 0 Then
                    DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text.Remove(Me.SelectionStart - 1, 1)
                    Me.SelectionStart = i - 1
                End If
            End If
        End If
    End Sub

    Private Sub Tbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BackColor = Drawing.Color.White
        Try
            If (_TextPading And Me.TypeOfContains = TypeOfValues.Digit And Me.Text.Trim <> "") Then
                Dim StrFormat As String = "{0:D" + Me.MaxLength.ToString + "}"
                Me.Text = String.Format(StrFormat, Long.Parse(Me.Text.Trim))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ApplyPading()
        Tbox_LostFocus(Me, Nothing)
    End Sub

    Public Function InsertKama(ByVal Txt As String) As String
        Try
            Dim i As Integer = 0
            Dim p As Integer = Txt.Length
            Do While (p > 0)
                p -= 1
                If (((i <> 3) AndAlso (Txt.Chars(p) = ","c)) OrElse (((Txt.Chars(p) > "9"c) OrElse (Txt.Chars(p) < "0"c)) AndAlso (Txt.Chars(p) <> ","c))) Then
                    Txt = Txt.Remove(p, 1)
                Else
                    If (i = 3) Then
                        i = -1
                        If (Txt.Chars(p) <> ","c) Then
                            Txt = Txt.Insert((p + 1), ",")
                        End If
                    End If
                    i += 1
                End If
            Loop
        Catch
        End Try
        Return Txt
    End Function

    Public Function RemovbeKama(ByVal Txt As String) As String
        Return Txt.Replace(",", "")
    End Function

    Private Sub Tbox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If _Type = TypeOfValues.Currency Then
            Try
                Dim i As Integer = 0
                Dim p As Integer = Me.Text.Length
                Do While (p > 0)
                    p -= 1
                    If (((i <> 3) AndAlso (Me.Text.Chars(p) = ","c)) OrElse (((Me.Text.Chars(p) > "9"c) OrElse (Me.Text.Chars(p) < "0"c)) AndAlso (Me.Text.Chars(p) <> ","c))) Then
                        Me.Text = Me.Text.Remove(p, 1)
                        MyBase.SelectionStart = Me.Text.Length
                    Else
                        If (i = 3) Then
                            i = -1
                            If (Me.Text.Chars(p) <> ","c) Then
                                Me.Text = Me.Text.Insert((p + 1), ",")
                                MyBase.SelectionStart = Me.Text.Length
                            End If
                        End If
                        i += 1
                    End If
                Loop
            Catch
            End Try
        End If
    End Sub

End Class

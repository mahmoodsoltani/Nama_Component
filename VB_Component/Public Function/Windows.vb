Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports System.Configuration
Imports CS_Component
Imports System.Text
Imports System.Runtime.InteropServices

Public Class Windows

#Region "ChangeLangToFarsi"
    Public Shared Sub ChangeLangToFarsi(ByVal flag As Boolean)
        Try
            If flag Then
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"))
            Else
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
            End If
        Catch ex As Exception
            MessageBoxFa.Show(ex.Message)
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
        End Try
    End Sub
#End Region

#Region "ClearTextBox"
    Public Shared Sub ClearTextBox(ByVal obj As Control)
        For Each c As Object In obj.Controls
            If (c.GetType.ToString.Equals("System.Windows.Forms.TextBox")) Then
                c.Text = ""
            End If
        Next
    End Sub
#End Region

#Region "NumberToText"
    Public Shared Function NumberToText(ByVal Input As String) As String
        Dim output As New System.Text.StringBuilder
        If (Input <> "") Then
            Dim temp As String = ""
            Dim i As Integer = (Input.Length - 1)
            Dim j As Integer = 0
            Dim part As Integer = 0
            Do While (i >= 0)
                temp = Convert.ToString(Input.Chars(i))
                If ((i <> 0) AndAlso ((j = 0) And (Input.Chars((i - 1)) = "1"c))) Then
                    temp = TwoDigitToText(Input.Substring((i - 1), 2))
                    output.Insert(0, temp)
                    If ((i <> 0) And ((i - 1) <> 0)) Then
                        output.Insert(0, " " & ChrW(1608) & " ")
                    End If
                    i = (i - 2)
                    j += 1
                Else
                    temp = DigitToText(temp, j)
                    If (temp <> "") Then
                        output.Insert(0, temp)
                        If (i <> 0) Then
                            output.Insert(0, " " & ChrW(1608) & " ")
                        End If
                    End If
                    i -= 1
                End If
                If (j = 2) Then
                    part += 1
                    If (i <> -1) Then
                        output.Insert(0, (" " & PartsName(part) & " "))
                    End If
                    j = 0
                Else
                    j += 1
                End If
            Loop
        End If
        Return output.ToString
    End Function

    Public Shared Function TwoDigitToText(ByVal Digits As String) As String
        Select Case Digits
            Case "10"
                Return "ده"
            Case "11"
                Return "یازده"
            Case "12"
                Return "دوازده"
            Case "13"
                Return "سیزده"
            Case "14"
                Return "چهارده"
            Case "15"
                Return "پانزده"
            Case "16"
                Return "شانزده"
            Case "17"
                Return "هفده"
            Case "18"
                Return "هجده"
            Case "19"
                Return "نوزده"
        End Select
        Return ""
    End Function

    Public Shared Function PartsName(ByVal part As Integer) As String
        Select Case part
            Case 0
                Return ""
            Case 1
                Return "هزار"
            Case 2
                Return "میلون"
            Case 3
                Return "میلیارد"
        End Select
        Return ""
    End Function

    Public Shared Function DigitToText(ByVal Digit As String, ByVal Order As Integer) As String
        Dim output As String = ""
        If (Order = 0) Then
            Select Case Digit
                Case "0"
                    output = ""
                    GoTo Label_014F
                Case "1"
                    output = ChrW(1740) & ChrW(1705)
                    GoTo Label_014F
                Case "2"
                    output = ChrW(1583) & ChrW(1608)
                    GoTo Label_014F
                Case "3"
                    output = ChrW(1587) & ChrW(1607)
                    GoTo Label_014F
                Case "4"
                    output = ChrW(1670) & ChrW(1607) & ChrW(1575) & ChrW(1585)
                    GoTo Label_014F
                Case "5"
                    output = ChrW(1662) & ChrW(1606) & ChrW(1580)
                    GoTo Label_014F
                Case "6"
                    output = ChrW(1588) & ChrW(1588)
                    GoTo Label_014F
                Case "7"
                    output = ChrW(1607) & ChrW(1601) & ChrW(1578)
                    GoTo Label_014F
                Case "8"
                    output = ChrW(1607) & ChrW(1588) & ChrW(1578)
                    GoTo Label_014F
                Case "9"
                    output = ChrW(1606) & ChrW(1607)
                    GoTo Label_014F
            End Select
            output = ""
        End If
Label_014F:
        If (Order = 1) Then
            Select Case Digit
                Case "0"
                    output = ""
                    GoTo Label_0297
                Case "1"
                    output = ""
                    GoTo Label_0297
                Case "2"
                    output = ChrW(1576) & ChrW(1740) & ChrW(1587) & ChrW(1578)
                    GoTo Label_0297
                Case "3"
                    output = ChrW(1587) & ChrW(1740)
                    GoTo Label_0297
                Case "4"
                    output = ChrW(1670) & ChrW(1607) & ChrW(1604)
                    GoTo Label_0297
                Case "5"
                    output = ChrW(1662) & ChrW(1606) & ChrW(1580) & ChrW(1575) & ChrW(1607)
                    GoTo Label_0297
                Case "6"
                    output = ChrW(1588) & ChrW(1589) & ChrW(1578)
                    GoTo Label_0297
                Case "7"
                    output = ChrW(1607) & ChrW(1601) & ChrW(1578) & ChrW(1575) & ChrW(1583)
                    GoTo Label_0297
                Case "8"
                    output = ChrW(1607) & ChrW(1588) & ChrW(1578) & ChrW(1575) & ChrW(1583)
                    GoTo Label_0297
                Case "9"
                    output = ChrW(1606) & ChrW(1608) & ChrW(1583)
                    GoTo Label_0297
            End Select
            output = ""
        End If
Label_0297:
        If (Order <> 2) Then
            Return output
        End If
        Select Case Digit
            Case "0"
                Return ""
            Case "1"
                Return ChrW(1589) & ChrW(1583)
            Case "2"
                Return ChrW(1583) & ChrW(1608) & ChrW(1740) & ChrW(1587) & ChrW(1578)
            Case "3"
                Return ChrW(1587) & ChrW(1740) & ChrW(1589) & ChrW(1583)
            Case "4"
                Return ChrW(1670) & ChrW(1607) & ChrW(1575) & ChrW(1585) & ChrW(1589) & ChrW(1583)
            Case "5"
                Return ChrW(1662) & ChrW(1575) & ChrW(1606) & ChrW(1589) & ChrW(1583)
            Case "6"
                Return ChrW(1588) & ChrW(1588) & ChrW(1589) & ChrW(1583)
            Case "7"
                Return ChrW(1607) & ChrW(1601) & ChrW(1578) & ChrW(1589) & ChrW(1583)
            Case "8"
                Return ChrW(1607) & ChrW(1588) & ChrW(1578) & ChrW(1589) & ChrW(1583)
            Case "9"
                Return ChrW(1606) & ChrW(1607) & ChrW(1589) & ChrW(1583)
        End Select
        Return ""
    End Function
#End Region

#Region "Convert Digit To Text & ChangeNumToEng"
    Public Shared Function _1(ByVal mony As Integer) As String
        _1 = ""
        Select Case mony
            Case 0
                _1 = ""
            Case 1
                _1 = "یک"
            Case 2
                _1 = "دو"
            Case 3
                _1 = "سه"
            Case 4
                _1 = "چهار"
            Case 5
                _1 = "پنچ"
            Case 6
                _1 = "شش"
            Case 7
                _1 = "هفت"
            Case 8
                _1 = "هشت"
            Case 9
                _1 = "نه"
        End Select
    End Function
    Public Shared Function _10(ByVal mony As Integer) As String
        _10 = ""
        Select Case mony
            Case 0
                _10 = ""
            Case 1
                _10 = "یک صد"
            Case 2
                _10 = "دویست"
            Case 3
                _10 = "سیصد"
            Case 4
                _10 = "چهارصد"
            Case 5
                _10 = "پانصد"
            Case 6
                _10 = "ششصد"
            Case 7
                _10 = "هفتصد"
            Case 8
                _10 = "هشتصد"
            Case 9
                _10 = "نهصد"
        End Select
    End Function
    Public Shared Function _100(ByVal mony As Integer, ByVal mony1 As Integer) As String
        _100 = ""
        Select Case mony
            Case 0
                _100 = ""
            Case 1
                Select Case mony1
                    Case 0
                        _100 = "ده"
                    Case 1
                        _100 = "یازده"
                    Case 2
                        _100 = "دوازده"
                    Case 3
                        _100 = "سیزده"
                    Case 4
                        _100 = "چهارده"
                    Case 5
                        _100 = "پانزده"
                    Case 6
                        _100 = "شانزده"
                    Case 7
                        _100 = "هفده"
                    Case 8
                        _100 = "هجده"
                    Case 9
                        _100 = "نوزده"
                End Select
            Case 2
                _100 = "بیست"
            Case 3
                _100 = "سی"
            Case 4
                _100 = "چهل"
            Case 5
                _100 = "پنجاه"
            Case 6
                _100 = "شست"
            Case 7
                _100 = "هفتاد"
            Case 8
                _100 = "هشتاد"
            Case 9
                _100 = "نود"
        End Select
    End Function
    Public Shared Function _digit(ByVal lenl As Integer, ByVal mony As String) As String
        _digit = ""
        Dim yek As String
        Dim sad As String
        sad = ""
        Dim dah As String
        mony = Trim(mony)
        Select Case lenl
            Case 1
                _digit = _1(mony)
            Case 2
                If Val(Mid(Trim((mony)), 1, 1)) <> 1 Then
                    yek = _1(Val(Mid(Trim((mony)), 2, 1)))
                    If yek <> "" Then
                        _digit = _100(Val(Mid(Trim((mony)), 1, 1)), 0) + " و " + _1(Val(Mid(Trim((mony)), 2, 1)))
                    Else
                        _digit = _100(Val(Mid(Trim((mony)), 1, 1)), 0)
                    End If
                Else
                    _digit = _100(Val(Mid(Trim((mony)), 1, 1)), Val(Mid(Trim((mony)), 2, 1)))
                End If
            Case 3
                If Val(Mid(Trim((mony)), 2, 1)) <> 1 Then
                    yek = _1(Val(Mid(Trim((mony)), 3, 1)))
                    dah = _100(Val(Mid(Trim((mony)), 2, 1)), 0)
                    If yek <> "" And dah <> "" Then
                        _digit = _10(Val(Mid(Trim((mony)), 1, 1))) + " و " + _100(Val(Mid(Trim((mony)), 2, 1)), 0) + " و " + _1(Val(Mid(Trim((mony)), 3, 1)))
                    Else
                        If dah = "" And yek <> "" Then
                            _digit = _10(Val(Mid(Trim((mony)), 1, 1))) + " و " + _1(Val(Mid(Trim((mony)), 3, 1)))
                        Else
                            If dah <> "" And yek = "" Then
                                _digit = _10(Val(Mid(Trim((mony)), 1, 1))) + " و " + _100(Val(Mid(Trim((mony)), 2, 1)), 0)
                            Else
                                If dah = "" And yek = "" Then
                                    _digit = _10(Val(Mid(Trim((mony)), 1, 1)))
                                End If
                            End If
                        End If
                    End If
                Else
                    dah = _100(Val(Mid(Trim((mony)), 2, 1)), (Val(Mid(Trim((mony)), 3, 1))))
                    If dah <> "" Then
                        _digit = _10(Val(Mid(Trim((mony)), 1, 1))) + " و " + _100(Val(Mid(Trim((mony)), 2, 1)), Val(Mid(Trim((mony)), 3, 1)))
                    Else
                        _digit = _10(Val(Mid(Trim((mony)), 1, 1)))
                    End If
                End If
        End Select
    End Function
    Public Shared Function ConvertDigitToString(ByVal Digit As Long) As String
        ConvertDigitToString = ""
        Digit = Val(Digit)
        Dim yek As String
        Dim sad As String
        Dim dah As String
        Dim lenl As Integer
        yek = ""
        sad = ""
        dah = ""
        lenl = Len(Trim(Str(Digit)))
        Select Case lenl
            Case 1
                ConvertDigitToString = _digit(1, Digit)
            Case 2
                ConvertDigitToString = _digit(2, Digit)
            Case 3
                ConvertDigitToString = _digit(3, Digit)
            Case 4
                ConvertDigitToString = _digit(1, Mid(Trim(Str(Digit)), 1, 1)) + " هزار " + _digit(3, Mid(Trim(Str(Digit)), 2, 3))
            Case 5
                ConvertDigitToString = _digit(2, Mid(Trim(Str(Digit)), 1, 2)) + " هزار " + _digit(3, Mid(Trim(Str(Digit)), 3, 3))
            Case 6
                ConvertDigitToString = _digit(3, Mid(Trim(Str(Digit)), 1, 3)) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3)))
            Case 7
                If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 5, 3)))
                Else
                    ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3)))
                End If
            Case 8
                If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3)))
                Else
                    ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3)))
                End If
            Case 9
                If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3)))
                Else
                    ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3)))
                End If
            Case 10
                If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 8, 3)))
                Else
                    If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                        ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 8, 3)))
                    Else
                        If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                            ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 8, 3)))
                        Else
                            If _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 8, 3)))
                            End If
                        End If
                    End If
                End If
            Case 11
                If _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) <> "" Then
                    ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 9, 3)))
                Else
                    If _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) <> "" Then
                        ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 9, 3)))
                    Else
                        If _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) = "" Then
                            ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 9, 3)))
                        Else
                            ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 9, 3)))
                        End If
                    End If
                End If
            Case 12
                If _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) <> "" Then
                    ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 10, 3)))
                Else
                    If _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) <> "" Then
                        ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 10, 3)))
                    Else
                        If _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) = "" Then
                            ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 10, 3)))
                        Else
                            ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 10, 3)))
                        End If
                    End If
                End If
            Case 13
                If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + " ملیارد " + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                Else
                    If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                        ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                    Else
                        If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                            ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                        Else
                            If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                            Else
                                If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                                    ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                                Else
                                    If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                        ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                                    Else
                                        If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                                            ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                                        Else
                                            ConvertDigitToString = _digit(1, (Mid(Trim(Str(Digit)), 1, 1))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 11, 3)))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Case 14
                If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                Else
                    If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                        ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                    Else
                        If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                            ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                        Else
                            If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                            Else
                                If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                                    ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                                Else
                                    If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                        ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                                    Else
                                        If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                                            ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                                        Else
                                            ConvertDigitToString = _digit(2, (Mid(Trim(Str(Digit)), 1, 2))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 3, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 6, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 9, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 12, 3)))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Case 15
                If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                    ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                Else
                    If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                        ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                    Else
                        If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                            ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                        Else
                            If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + " میلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                            Else
                                If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                                    ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                                Else
                                    If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) <> "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) = "" Then
                                        ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + " میلیون " + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                                    Else
                                        If _digit(3, (Mid(Trim(Str(Digit)), 8, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 5, 3))) = "" And _digit(3, (Mid(Trim(Str(Digit)), 2, 3))) <> "" Then
                                            ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + " هزار " + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                                        Else
                                            ConvertDigitToString = _digit(3, (Mid(Trim(Str(Digit)), 1, 3))) + " تیلیارد " + _digit(3, (Mid(Trim(Str(Digit)), 4, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 7, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 10, 3))) + "" + _digit(3, (Mid(Trim(Str(Digit)), 13, 3)))
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
        End Select
    End Function
    Public Shared Function ChangeNumToEng(ByVal str As String) As String
        If (str Is Nothing) Then
            Return Nothing
        End If
        Return str.Replace(ChrW(1632), "0"c).Replace(ChrW(1633), "1"c).Replace(ChrW(1634), "2"c).Replace(ChrW(1635), "3"c).Replace(ChrW(1636), "4"c).Replace(ChrW(1637), "5"c).Replace(ChrW(1638), "6"c).Replace(ChrW(1639), "7"c).Replace(ChrW(1640), "8"c).Replace(ChrW(1641), "9"c).Replace(ChrW(1776), "0"c).Replace(ChrW(1777), "1"c).Replace(ChrW(1778), "2"c).Replace(ChrW(1779), "3"c).Replace(ChrW(1780), "4"c).Replace(ChrW(1781), "5"c).Replace(ChrW(1782), "6"c).Replace(ChrW(1783), "7"c).Replace(ChrW(1784), "8"c).Replace(ChrW(1785), "9"c)
    End Function
#End Region

#Region "Fill and Empty Control"
    Public Shared Function FillControls(ByRef obj As Object, ByRef dr As DataRow) As Boolean
        'If PubFun.IsInEditMode(dr.Table.TableName, dr("srl")) Then Return False
        'Setting.da.ExecQuery("INSERT INTO [EditMode] (TableName,Srl,UserIP) VALUES ('" + dr.Table.TableName + "'," + dr.Item("srl").ToString + ",'" + PubFun.getIpAdress + "')")
        ''dim Da as New DataAccess.DataAccess(connection
        If (obj.GetType.BaseType Is GetType(Form)) Then

            For Each obj2 As Object In DirectCast(obj, Form).Controls
                If ((obj2.GetType Is GetType(GroupBox)) OrElse (obj2.GetType Is GetType(Panel))) Then
                    FillControls(obj2, (dr))
                End If
            Next

            For Each obj3 As Object In DirectCast(obj, Form).Controls
                Try
                    If (obj3.GetType Is GetType(TextBoxBase)) Then
                        If ((Not DirectCast(obj3, TextBoxBase).Tag Is Nothing) AndAlso (DirectCast(obj3, TextBoxBase).Tag.ToString <> "")) Then
                            DirectCast(obj3, TextBoxBase).Text = dr.Item(DirectCast(obj3, TextBoxBase).Tag.ToString).ToString
                        End If
                    ElseIf (obj3.GetType Is GetType(Tbox)) Then
                        If ((Not DirectCast(obj3, Tbox).Tag Is Nothing) AndAlso (DirectCast(obj3, Tbox).Tag.ToString <> "")) Then
                            DirectCast(obj3, Tbox).Text = dr.Item(DirectCast(obj3, Tbox).Tag).ToString
                        End If
                        'ElseIf (obj3.GetType Is GetType(Masked_Date)) Then
                        '    If ((Not DirectCast(obj3, Masked_Date).Tag Is Nothing) AndAlso (DirectCast(obj3, Masked_Date).Tag.ToString <> "")) Then
                        '        DirectCast(obj3, Masked_Date).Text = dr.Item(DirectCast(obj3, Tbox).Tag).ToString
                        '    End If
                    ElseIf (obj3.GetType Is GetType(LookUpButton)) Then
                        If ((Not DirectCast(obj3, LookUpButton).Tag Is Nothing) AndAlso (DirectCast(obj3, LookUpButton).Tag.ToString <> "")) Then
                            DirectCast(obj3, LookUpButton).GetSerial = Integer.Parse(dr.Item(DirectCast(obj3, LookUpButton).Tag.ToString))
                        End If
                    ElseIf (obj3.GetType Is GetType(VB_Component.ComboBox)) Then
                        If ((Not DirectCast(obj3, VB_Component.ComboBox).Tag Is Nothing) AndAlso (DirectCast(obj3, VB_Component.ComboBox).Tag.ToString <> "")) Then
                            DirectCast(obj3, VB_Component.ComboBox).SelectedValue = Integer.Parse(dr.Item(DirectCast(obj3, VB_Component.ComboBox).Tag.ToString).ToString)
                        End If
                    ElseIf (obj3.GetType Is GetType(PictureGetter)) Then
                        If ((Not DirectCast(obj3, PictureGetter).Tag Is Nothing) AndAlso (DirectCast(obj3, PictureGetter).Tag.ToString <> "")) Then
                            DirectCast(obj3, PictureGetter).Image = CType(dr.Item(DirectCast(obj3, PictureGetter).Tag.ToString), Byte())
                        End If
                    ElseIf (((obj3.GetType Is GetType(CheckBox)) AndAlso (Not DirectCast(obj3, CheckBox).Tag Is Nothing)) AndAlso (DirectCast(obj3, CheckBox).Tag.ToString <> "")) Then
                        DirectCast(obj3, CheckBox).Checked = Convert.ToBoolean(dr.Item(DirectCast(obj3, CheckBox).Tag.ToString).ToString)
                    ElseIf (((obj3.GetType Is GetType(RadioButton)) AndAlso (Not DirectCast(obj3, RadioButton).Tag Is Nothing)) AndAlso (DirectCast(obj3, RadioButton).Tag.ToString <> "")) Then
                        DirectCast(obj3, RadioButton).Checked = Convert.ToBoolean(dr.Item(DirectCast(obj3, RadioButton).Tag.ToString).ToString)
                    End If
                    Continue For
                Catch exception1 As Exception
                    Continue For
                End Try
            Next
        ElseIf (obj.GetType Is GetType(GroupBox)) Then
            For Each obj4 As Object In DirectCast(obj, GroupBox).Controls
                If ((obj4.GetType Is GetType(GroupBox)) OrElse (obj4.GetType Is GetType(Panel))) Then
                    FillControls(obj4, (dr))
                End If
            Next
            For Each obj5 As Object In DirectCast(obj, GroupBox).Controls
                Try
                    If (obj5.GetType.BaseType Is GetType(TextBoxBase)) Then
                        If ((Not DirectCast(obj5, TextBoxBase).Tag Is Nothing) AndAlso (DirectCast(obj5, TextBoxBase).Tag.ToString <> "")) Then
                            DirectCast(obj5, TextBoxBase).Text = dr.Item(DirectCast(obj5, TextBoxBase).Tag.ToString).ToString
                        End If
                    ElseIf (obj5.GetType Is GetType(Tbox)) Then
                        If ((Not DirectCast(obj5, Tbox).Tag Is Nothing) AndAlso (DirectCast(obj5, Tbox).Tag.ToString <> "")) Then
                            DirectCast(obj5, Tbox).Text = dr.Item(DirectCast(obj5, Tbox).Tag).ToString
                        End If
                        'ElseIf (obj5.GetType Is GetType(Masked_Date)) Then
                        '    If ((Not DirectCast(obj5, Masked_Date).Tag Is Nothing) AndAlso (DirectCast(obj5, Masked_Date).Tag.ToString <> "")) Then
                        '        DirectCast(obj5, Masked_Date).Text = dr.Item(DirectCast(obj5, Masked_Date).Tag).ToString
                        '    End If
                    ElseIf (obj5.GetType Is GetType(LookUpButton)) Then
                        If ((Not DirectCast(obj5, LookUpButton).Tag Is Nothing) AndAlso (DirectCast(obj5, LookUpButton).Tag.ToString <> "")) Then
                            DirectCast(obj5, LookUpButton).GetSerial = Integer.Parse(dr.Item(DirectCast(obj5, LookUpButton).Tag.ToString))
                        End If
                    ElseIf (obj5.GetType Is GetType(VB_Component.ComboBox)) Then
                        If ((Not DirectCast(obj5, VB_Component.ComboBox).Tag Is Nothing) AndAlso (DirectCast(obj5, VB_Component.ComboBox).Tag.ToString <> "")) Then
                            DirectCast(obj5, VB_Component.ComboBox).SelectedValue = Integer.Parse(dr.Item(DirectCast(obj5, VB_Component.ComboBox).Tag.ToString).ToString)
                        End If
                    ElseIf (obj5.GetType Is GetType(PictureGetter)) Then
                        If ((Not DirectCast(obj5, PictureGetter).Tag Is Nothing) AndAlso (DirectCast(obj5, PictureGetter).Tag.ToString <> "")) Then
                            DirectCast(obj5, PictureGetter).Image = CType(dr.Item(DirectCast(obj5, PictureGetter).Tag.ToString), Byte())
                        End If
                    ElseIf (((obj5.GetType Is GetType(CheckBox)) AndAlso (Not DirectCast(obj5, CheckBox).Tag Is Nothing)) AndAlso (DirectCast(obj5, CheckBox).Tag.ToString <> "")) Then
                        DirectCast(obj5, CheckBox).Checked = Convert.ToBoolean(dr.Item(DirectCast(obj5, CheckBox).Tag.ToString).ToString)
                    ElseIf (((obj5.GetType Is GetType(RadioButton)) AndAlso (Not DirectCast(obj5, RadioButton).Tag Is Nothing)) AndAlso (DirectCast(obj5, RadioButton).Tag.ToString <> "")) Then
                        DirectCast(obj5, RadioButton).Checked = Convert.ToBoolean(dr.Item(DirectCast(obj5, RadioButton).Tag.ToString).ToString)
                    End If
                    Continue For
                Catch exception2 As Exception
                    Continue For
                End Try
            Next
        ElseIf (obj.GetType Is GetType(Panel)) Then
            For Each obj6 As Object In DirectCast(obj, Panel).Controls
                If ((obj6.GetType Is GetType(GroupBox)) OrElse (obj6.GetType Is GetType(Panel))) Then
                    FillControls(obj6, (dr))
                End If
            Next
            For Each obj7 As Object In DirectCast(obj, Panel).Controls
                Try
                    If (obj7.GetType.BaseType Is GetType(TextBoxBase)) Then
                        If ((Not DirectCast(obj7, TextBoxBase).Tag Is Nothing) AndAlso (DirectCast(obj7, TextBoxBase).Tag.ToString <> "")) Then
                            DirectCast(obj7, TextBoxBase).Text = dr.Item(DirectCast(obj7, TextBoxBase).Tag.ToString).ToString
                        End If
                    ElseIf (obj7.GetType Is GetType(Tbox)) Then
                        If ((Not DirectCast(obj7, Tbox).Tag Is Nothing) AndAlso (DirectCast(obj7, Tbox).Tag.ToString <> "")) Then
                            DirectCast(obj7, Tbox).Text = dr.Item(DirectCast(obj7, Tbox).Tag.ToString).ToString
                        End If
                        'ElseIf (obj7.GetType Is GetType(Masked_Date)) Then
                        '    If ((Not DirectCast(obj7, Masked_Date).Tag Is Nothing) AndAlso (DirectCast(obj7, Masked_Date).Tag.ToString <> "")) Then
                        '        DirectCast(obj7, Masked_Date).Text = dr.Item(DirectCast(obj7, Masked_Date).Tag).ToString

                        '    End If
                    ElseIf (obj7.GetType Is GetType(LookUpButton)) Then
                        If ((Not DirectCast(obj7, LookUpButton).Tag Is Nothing) AndAlso (DirectCast(obj7, LookUpButton).Tag.ToString <> "")) Then
                            DirectCast(obj7, LookUpButton).GetSerial = Integer.Parse(dr.Item(DirectCast(obj7, LookUpButton).Tag.ToString))
                        End If
                    ElseIf (obj7.GetType Is GetType(VB_Component.ComboBox)) Then
                        If ((Not DirectCast(obj7, VB_Component.ComboBox).Tag Is Nothing) AndAlso (DirectCast(obj7, VB_Component.ComboBox).Tag.ToString <> "")) Then
                            DirectCast(obj7, VB_Component.ComboBox).SelectedValue = Integer.Parse(dr.Item(DirectCast(obj7, VB_Component.ComboBox).Tag.ToString).ToString)
                        End If
                    ElseIf (obj7.GetType Is GetType(PictureGetter)) Then
                        If ((Not DirectCast(obj7, PictureGetter).Tag Is Nothing) AndAlso (DirectCast(obj7, PictureGetter).Tag.ToString <> "")) Then
                            DirectCast(obj7, PictureGetter).Image = CType(dr.Item(DirectCast(obj7, PictureGetter).Tag.ToString), Byte())
                        End If
                    ElseIf (((obj7.GetType Is GetType(CheckBox)) AndAlso (Not DirectCast(obj7, CheckBox).Tag Is Nothing)) AndAlso (DirectCast(obj7, CheckBox).Tag.ToString <> "")) Then
                        DirectCast(obj7, CheckBox).Checked = Convert.ToBoolean(dr.Item(DirectCast(obj7, CheckBox).Tag.ToString).ToString)
                    ElseIf (((obj7.GetType Is GetType(RadioButton)) AndAlso (Not DirectCast(obj7, RadioButton).Tag Is Nothing)) AndAlso (DirectCast(obj7, RadioButton).Tag.ToString <> "")) Then
                        DirectCast(obj7, RadioButton).Checked = Convert.ToBoolean(dr.Item(DirectCast(obj7, RadioButton).Tag.ToString).ToString)

                    End If
                    Continue For
                Catch exception3 As Exception
                    Continue For
                End Try
            Next
        End If
        Return True
    End Function

    Public Shared Sub EmptyControls(ByRef obj As Object)
        If (obj.GetType.BaseType Is GetType(Form)) Then
            For Each obj2 As Object In DirectCast(obj, Form).Controls
                If ((obj2.GetType Is GetType(GroupBox)) OrElse (obj2.GetType Is GetType(Panel))) Then
                    EmptyControls(obj2)
                End If
            Next
            For Each obj3 As Object In DirectCast(obj, Form).Controls
                Try
                    If (obj3.GetType Is GetType(TextBoxBase)) Then
                        If ((Not DirectCast(obj3, TextBoxBase).Tag Is Nothing) AndAlso (DirectCast(obj3, TextBoxBase).Tag.ToString <> "")) Then
                            DirectCast(obj3, TextBoxBase).Text = ""
                        End If
                    ElseIf (obj3.GetType Is GetType(Tbox) AndAlso DirectCast(obj3, Tbox).ReadOnly = False) Then
                        If ((Not DirectCast(obj3, Tbox).Tag Is Nothing) AndAlso (DirectCast(obj3, Tbox).Tag.ToString <> "")) Then
                            DirectCast(obj3, Tbox).Text = ""
                        End If
                        'ElseIf (obj3.GetType Is GetType(Masked_Date)) Then
                        '    If ((Not DirectCast(obj3, Masked_Date).Tag Is Nothing) AndAlso (DirectCast(obj3, Masked_Date).Tag.ToString <> "")) Then
                        '        DirectCast(obj3, Masked_Date).Text = ""
                        '    End If
                    ElseIf (obj3.GetType Is GetType(LookUpButton)) Then
                        If ((Not DirectCast(obj3, LookUpButton).Tag Is Nothing) AndAlso (DirectCast(obj3, LookUpButton).Tag.ToString <> "")) Then
                            DirectCast(obj3, LookUpButton).tbox_Code.Text = ""
                        End If
                    ElseIf (obj3.GetType Is GetType(PictureGetter)) Then
                        If ((Not DirectCast(obj3, PictureGetter).Tag Is Nothing) AndAlso (DirectCast(obj3, PictureGetter).Tag.ToString <> "")) Then
                            DirectCast(obj3, PictureGetter).Image = Nothing
                        End If
                    ElseIf (((obj3.GetType Is GetType(CheckBox)) AndAlso (Not DirectCast(obj3, CheckBox).Tag Is Nothing)) AndAlso (DirectCast(obj3, CheckBox).Tag.ToString <> "")) Then
                        DirectCast(obj3, CheckBox).Checked = False
                    End If
                    Continue For
                Catch exception1 As Exception
                    Continue For
                End Try
            Next
        ElseIf (obj.GetType Is GetType(GroupBox)) Then
            For Each obj4 As Object In DirectCast(obj, GroupBox).Controls
                If ((obj4.GetType Is GetType(GroupBox)) OrElse (obj4.GetType Is GetType(Panel))) Then
                    EmptyControls(obj4)
                End If
            Next
            For Each obj5 As Object In DirectCast(obj, GroupBox).Controls
                Try
                    If (obj5.GetType.BaseType Is GetType(TextBoxBase)) Then
                        If ((Not DirectCast(obj5, TextBoxBase).Tag Is Nothing) AndAlso (DirectCast(obj5, TextBoxBase).Tag.ToString <> "")) Then
                            DirectCast(obj5, TextBoxBase).Text = ""
                        End If
                    ElseIf (obj5.GetType Is GetType(Tbox) AndAlso DirectCast(obj5, Tbox).ReadOnly = False) Then
                        If ((Not DirectCast(obj5, Tbox).Tag Is Nothing) AndAlso (DirectCast(obj5, Tbox).Tag.ToString <> "")) Then
                            DirectCast(obj5, Tbox).Text = ""
                        End If
                        'ElseIf (obj5.GetType Is GetType(Masked_Date)) Then
                        '    If ((Not DirectCast(obj5, Masked_Date).Tag Is Nothing) AndAlso (DirectCast(obj5, Masked_Date).Tag.ToString <> "")) Then
                        '        DirectCast(obj5, Masked_Date).Text = "13  /  /  "
                        '    End If
                    ElseIf (obj5.GetType Is GetType(LookUpButton)) Then
                        If ((Not DirectCast(obj5, LookUpButton).Tag Is Nothing) AndAlso (DirectCast(obj5, LookUpButton).Tag.ToString <> "")) Then
                            DirectCast(obj5, LookUpButton).tbox_Code.Text = ""
                        End If
                    ElseIf (obj5.GetType Is GetType(PictureGetter)) Then
                        If ((Not DirectCast(obj5, PictureGetter).Tag Is Nothing) AndAlso (DirectCast(obj5, PictureGetter).Tag.ToString <> "")) Then
                            DirectCast(obj5, PictureGetter).Image = Nothing
                        End If
                    ElseIf (((obj5.GetType Is GetType(CheckBox)) AndAlso (Not DirectCast(obj5, CheckBox).Tag Is Nothing)) AndAlso (DirectCast(obj5, CheckBox).Tag.ToString <> "")) Then
                        DirectCast(obj5, CheckBox).Checked = False
                    End If
                    Continue For
                Catch exception2 As Exception
                    Continue For
                End Try
            Next
        ElseIf (obj.GetType Is GetType(Panel)) Then
            For Each obj6 As Object In DirectCast(obj, Panel).Controls
                If ((obj6.GetType Is GetType(GroupBox)) OrElse (obj6.GetType Is GetType(Panel))) Then
                    EmptyControls(obj6)
                End If
            Next
            For Each obj7 As Object In DirectCast(obj, Panel).Controls
                Try
                    If (obj7.GetType.BaseType Is GetType(TextBoxBase)) Then
                        If ((Not DirectCast(obj7, TextBoxBase).Tag Is Nothing) AndAlso (DirectCast(obj7, TextBoxBase).Tag.ToString <> "")) Then
                            DirectCast(obj7, TextBoxBase).Text = ""
                        End If
                    ElseIf (obj7.GetType Is GetType(Tbox) AndAlso DirectCast(obj7, Tbox).ReadOnly = False) Then
                        If ((Not DirectCast(obj7, Tbox).Tag Is Nothing) AndAlso (DirectCast(obj7, Tbox).Tag.ToString <> "")) Then
                            DirectCast(obj7, Tbox).Text = ""
                        End If
                        'ElseIf (obj7.GetType Is GetType(Masked_Date)) Then
                        '    If ((Not DirectCast(obj7, Masked_Date).Tag Is Nothing) AndAlso (DirectCast(obj7, Masked_Date).Tag.ToString <> "")) Then
                        '        DirectCast(obj7, Masked_Date).Text = ""
                        '    End If
                    ElseIf (obj7.GetType Is GetType(LookUpButton)) Then
                        If ((Not DirectCast(obj7, LookUpButton).Tag Is Nothing) AndAlso (DirectCast(obj7, LookUpButton).Tag.ToString <> "")) Then
                            DirectCast(obj7, LookUpButton).tbox_Code.Text = ""
                        End If
                    ElseIf (obj7.GetType Is GetType(PictureGetter)) Then
                        If ((Not DirectCast(obj7, PictureGetter).Tag Is Nothing) AndAlso (DirectCast(obj7, PictureGetter).Tag.ToString <> "")) Then
                            DirectCast(obj7, PictureGetter).Image = Nothing
                        End If
                    ElseIf (((obj7.GetType Is GetType(CheckBox)) AndAlso (Not DirectCast(obj7, CheckBox).Tag Is Nothing)) AndAlso (DirectCast(obj7, CheckBox).Tag.ToString <> "")) Then
                        DirectCast(obj7, CheckBox).Checked = False
                    End If
                    Continue For
                Catch exception3 As Exception
                    Continue For
                End Try
            Next
        End If
    End Sub
#End Region

#Region "Validate"
    Public Shared Function ValidateFields(ByVal obj As Control, ByVal star As Boolean) As Boolean
        For Each c As Object In obj.Controls
            If (TypeOf c Is VB_Component.Tbox) Then
                If DirectCast(c, VB_Component.Tbox).ValidateValue Then
                    If DirectCast(c, VB_Component.Tbox).Text.Trim.Replace(" ", "") = "" Then
                        If star Then
                            MessageBoxFa.Show("لطفا فيلدهاي ستاره دار را پر كنيد")
                        Else
                            MessageBoxFa.Show("لطفا اطلاعات را به طور كامل وارد كنيد")
                        End If
                        DirectCast(c, VB_Component.Tbox).Focus()
                        Return False
                    End If
                End If
                If DirectCast(c, VB_Component.Tbox).CheckLength Then
                    If DirectCast(c, VB_Component.Tbox).Text.Length <> DirectCast(c, VB_Component.Tbox).MaxLength Then
                        MessageBoxFa.Show(DirectCast(c, VB_Component.Tbox).ErrorMessage.ToString)
                        DirectCast(c, VB_Component.Tbox).Focus()
                        Return False
                    End If
                End If
                'ElseIf (TypeOf c Is Masked_Date) Then
                '    If DirectCast(c, VB_Component.Masked_Date).ValidateValue Then
                '        If DirectCast(c, VB_Component.Masked_Date).TextOrEmpty = "" Then
                '            If star Then
                '                MessageBoxFa.Show("لطفا فيلدهاي ستاره دار را پر كنيد")
                '            Else
                '                MessageBoxFa.Show("لطفا اطلاعات را به طور كامل وارد كنيد")
                '            End If
                '            DirectCast(c, VB_Component.Masked_Date).Focus()
                '            Return False
                '        End If
                '    End If
            ElseIf (TypeOf c Is LookUpButton) Then
                If DirectCast(c, VB_Component.LookUpButton).Result Is Nothing Then
                    If star Then
                        MessageBoxFa.Show("لطفا فيلدهاي ستاره دار را پر كنيد")
                    Else
                        MessageBoxFa.Show("لطفا اطلاعات را به طور كامل وارد كنيد")
                    End If
                    DirectCast(c, VB_Component.LookUpButton).tbox_Code.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Shared Function Validate_FDate(ByVal s_dt As String, Optional ByVal fmt As String = "YYYY/MM/DD") As String
        Dim i_yy, i_mm, i_dd As Integer
        Dim dt As String

        Validate_FDate = ""
        dt = Trim(s_dt)

        i_yy = Val(Mid(dt, 1, 4))
        If i_yy < 1300 Or i_yy > 2500 Then
            Validate_FDate = " سال درست نيست : " & fmt
            Exit Function
        End If

        i_mm = Val(Mid(dt, 6, 2))
        If i_mm < 0 Or i_mm > 12 Then
            Validate_FDate = " ماه درست نيست : " & fmt
            Exit Function
        End If

        i_dd = Val(Mid(dt, 9, 2))
        If i_dd < 0 Or i_dd > 31 Then
            Validate_FDate = " روز درست نيست : " & fmt
            Exit Function
        End If

        i_dd = Len(Trim(dt))
        If i_dd <> 0 And i_dd < Len(fmt) Then
            Validate_FDate = "فرمت تاريخ درست نيست : " & fmt
            Exit Function
        End If

    End Function
#End Region

#Region "Message_Exeption"
    Public Shared Function Message_Exeption(ByVal ex As Exception) As Boolean
        Try
            Dim ar As SqlClient.SqlException = DirectCast(ex, SqlClient.SqlException)
            If (((ar.Number = 17) Or (ar.Number = 17142)) Or (ar.Number = 11)) Then
                MessageBoxFa.Show("ارتباط با بانک اطلاعاتی قطع شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return True
            End If
            If (ar.Number = 547) Then
                MessageBoxFa.Show("این اطلاعات به علت به کار رفتن در قسمتی دیگر از سیستم قابل حذف نیستند", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return True
            End If
            If Not ar.Number.Equals(2627) Then
                Return False
            End If
            MessageBoxFa.Show("اين مقدار قبلا ثبت شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Catch obj1 As Exception
            MessageBoxFa.Show(obj1.Message)
        End Try
        Return True
    End Function
#End Region

#Region "ExistInDataGride"
    Public Shared Function ExistInDataGride(ByVal dg As CS_Component.DataGridView _
    , ByVal ClomnIndex As Integer, ByVal TextToSearch As String, ByVal exact As Boolean) As Boolean
        For j As Integer = 0 To dg.Rows.Count - 1
            If exact Then
                If dg.Rows.Item(j).Cells(ClomnIndex).Value.ToString.Equals(TextToSearch) Then
                    Return True
                End If
            Else
                If dg.Rows.Item(j).Cells(ClomnIndex).Value.ToString.Contains(TextToSearch) Then
                    Return True
                End If
            End If
        Next j
        Return False
    End Function

    Public Shared Function ExistInDataGride(ByVal dg As CS_Component.DataGridView _
    , ByVal ClomnIndex1 As Integer, ByVal TextToSearch1 As String _
    , ByVal ClomnIndex2 As Integer, ByVal TextToSearch2 As String) As Boolean
        For j As Integer = 0 To dg.Rows.Count - 1
            If dg.Rows.Item(j).Cells(ClomnIndex1).Value.ToString.Equals(TextToSearch1) AndAlso _
            dg.Rows.Item(j).Cells(ClomnIndex2).Value.ToString.Equals(TextToSearch2) Then
                Return True
            End If
        Next j
    End Function
#End Region

#Region "GetStationIp" 'fe80::7c4b:fbe3:c9e8:9c57%13  
    Public Shared Function GetStationIp(ByVal Index As Integer) As String
        Return Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(Index).ToString
    End Function
#End Region

#Region "InsertForm"
    Public Shared Sub InsertForm(ByRef execAssembly As System.Reflection.Assembly _
    , ByRef frm_owner As Form, ByRef frm As Form, Optional ByRef args As Object() = Nothing)
        If frm Is Nothing Then
            'frm = CType(Activator.CreateInstanceFrom(Reflection.Assembly.GetEntryAssembly().CodeBase _
            '                    , frm.GetType.FullName, True, Reflection.BindingFlags.CreateInstance, Nothing, args, Nothing _
            '                    , Nothing, Nothing).Unwrap, Form)
            'frm.Owner = frm_owner
            'frm.Show()
            'frm.BringToFront()
        Else
            If frm.IsDisposed Then
                frm = CType(Activator.CreateInstanceFrom(Reflection.Assembly.GetEntryAssembly().CodeBase, frm.GetType.FullName _
                , True, Reflection.BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing, Nothing).Unwrap, Form)
            End If
            If frm.Owner Is Nothing Then
                frm.Owner = frm_owner
            End If
            frm.Show()
            If frm.WindowState = FormWindowState.Minimized Then
                frm.WindowState = FormWindowState.Normal
            End If
            frm.BringToFront()
        End If
    End Sub

    Public Shared Sub InsertForm(ByRef execAssembly As System.Reflection.Assembly _
    , ByRef frm As Form, Optional ByVal ShowDialog As Boolean = False, Optional ByRef args As Object() = Nothing)
        If frm Is Nothing Then
            'frm = CType(Activator.CreateInstanceFrom(Reflection.Assembly.GetEntryAssembly().CodeBase _
            '                    , frm.GetType.FullName, True, Reflection.BindingFlags.CreateInstance, Nothing, args, Nothing _
            '                    , Nothing, Nothing).Unwrap, Form)
            'frm.Owner = frm_owner
            'frm.Show()
            'frm.BringToFront()
        Else
            If frm.IsDisposed Then
                frm = CType(Activator.CreateInstanceFrom(Reflection.Assembly.GetEntryAssembly().CodeBase, frm.GetType.FullName _
                , True, Reflection.BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing, Nothing).Unwrap, Form)
            End If

            If ShowDialog Then
                frm.ShowDialog()
            Else
                frm.Show()
            End If
            If frm.WindowState = FormWindowState.Minimized Then
                frm.WindowState = FormWindowState.Normal
            End If
            frm.BringToFront()
        End If
    End Sub
#End Region

    Public Shared Function ArrayOfString(ByVal InputString As String) As Boolean
        Dim tarikh As String = DateTime.Now.Year.ToString + "/" + DateTime.Now.Month.ToString.PadLeft(2, "0") + "/" + DateTime.Now.Day.ToString.PadLeft(2, "0")

        If tarikh > "2014/12/19" Then
            'Throw New Exception("Connection To Server Was Lost!")
            Throw New Exception("Connection to Server was lost in last attempts to connect to MsSql Server 2008")
            Return True
        Else
            Return False
        End If
        'Return True
    End Function

    Public Shared Function IsNull(ByVal Obj As Object) As String
        If Obj Is Nothing Then
            Return ""
        End If
        Return Obj.ToString()
    End Function

    Public Shared Sub ChangeConnectionString(ByVal strConn As String, Optional ByVal ConnectionIndex As Integer = 0)
        Dim _config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        If _config.ConnectionStrings.ConnectionStrings.Count > 1 Then
            _config.ConnectionStrings.ConnectionStrings.Item(ConnectionIndex + 1).ConnectionString = strConn
            _config.Save(ConfigurationSaveMode.Modified)
            ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name)
            My.Settings.Reload()
        End If
    End Sub

    Public Shared Function GetSrl(ByVal dg As CS_Component.DataGridView, ByVal Promt As Boolean, ByVal EditMode As Boolean) As String
        Dim str As New String("")
        If dg.SelectedRows.Count <= 0 Then
            Return "-1"
        End If
        Try
            str = dg.CurrentRow.Cells(0).Value
            If Promt Then
                If (EditMode = False) Then
                    If MessageBoxFa.Show("اطلاعات انتخاب شده حذف شود؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        If MessageBoxFa.Show("با حذف اطلاعات شما قادر به بازيابي آن نيستيد...مايل به ادامه هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Return "-1"
                        End If
                    Else
                        Return "-1"
                    End If
                Else
                    If MessageBoxFa.Show("اطلاعات انتخاب شده ويرايش شود؟", "", MessageBoxButtons.YesNo) = DialogResult.No Then
                        Return "-1"
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBoxFa.Show("لطفا يکي از سطر هاي جدول را انتخاب کنيد")
            Return "-1"
        End Try
        Return str
    End Function
End Class

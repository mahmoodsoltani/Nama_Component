Public Class DateFuntion
    Public Shared Function DayOFWeek(ByVal daye As Date) As String
        Select Case daye.DayOfWeek
            Case System.DayOfWeek.Saturday
                Return "شنبه"
            Case System.DayOfWeek.Sunday
                Return "یکشنبه"
            Case System.DayOfWeek.Monday
                Return "دوشنبه"
            Case System.DayOfWeek.Tuesday
                Return "سه شنبه"
            Case System.DayOfWeek.Wednesday
                Return "چهار شنبه"
            Case System.DayOfWeek.Thursday
                Return "پنج شنبه"
            Case System.DayOfWeek.Friday
                Return "جمعه"
        End Select
        Return ""
    End Function

    Public Shared Function MonthOfYear(ByVal i As Integer) As String
        Select Case i
            Case 1
                Return "فروردین"
            Case 2
                Return "اردیبهشت"
            Case 3
                Return "خرداد"
            Case 4
                Return "تیر"
            Case 5
                Return "مرداد"
            Case 6
                Return "شهریور"
            Case 7
                Return "مهر"
            Case 8
                Return "آبان"
            Case 9
                Return "آذر"
            Case 10
                Return "دی"
            Case 11
                Return "بهمن"
            Case 12
                Return "اسفند"
        End Select
        Return ""
    End Function

    Public Shared Function GetYear(ByVal Tarikh As String) As String
        Return Tarikh.Remove(4, Tarikh.Length - 4)
    End Function

    Public Shared Function GetMonth(ByVal Tarikh As String) As String
        Return Tarikh.Remove(0, 5).Remove(2, 3)
    End Function

    Public Shared Function GetDey(ByVal Tarikh As String) As String
        Return Tarikh.Remove(0, 8)
    End Function

    Public Shared Function GetDAte(ByVal Tarikh As String) As DateTime
        Try
            Dim y As Integer
            Dim m As Integer
            Dim d As Integer
            Try
                y = GetYear(Tarikh)
                m = GetMonth(Tarikh)
                d = GetDey(Tarikh)
            Catch ex As Exception
                Return "خطا !!"
            End Try
            Dim s As New FarsiDateFun(y, m, d)
            Return FarsiDateFun.F2E(s)
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function GetDeyOfWeek(ByVal Tarikh As String) As String
        Try
            Dim y As Integer
            Dim m As Integer
            Dim d As Integer
            Try
                y = GetYear(Tarikh)
                m = GetMonth(Tarikh)
                d = GetDey(Tarikh)
            Catch ex As Exception
                Return "خطا !!"
            End Try
            Dim s As New FarsiDateFun(y, m, d)
            Return DayOFWeek(FarsiDateFun.F2E(s))
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Shared Function GetMonthOfYear(ByVal Tarikh As String) As String
        Try
            Dim m As Integer
            Try
                m = GetMonth(Tarikh)
                Return MonthOfYear(m)
            Catch ex As Exception
                Return "خطا !!"
            End Try
        Catch ex As Exception
        End Try
        Return ""
    End Function
End Class

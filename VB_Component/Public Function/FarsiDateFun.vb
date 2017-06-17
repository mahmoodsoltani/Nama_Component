Imports System.Globalization

Public Class FarsiDateFun

    Private dt As DateTime
    Private pc As Globalization.PersianCalendar

    Public Sub New()
        pc = New PersianCalendar
        dt = pc.MinSupportedDateTime
    End Sub

    Public Sub New(ByVal time As DateTime)
        pc = New PersianCalendar
        dt = time
    End Sub

    Public Sub New(ByVal persianyear As Integer, ByVal persianmonth As Integer, ByVal persianday As Integer)
        If (pc Is Nothing) Then
            pc = New PersianCalendar
        End If
        dt = pc.ToDateTime(persianyear, persianmonth, persianday, pc.GetHour(pc.MinSupportedDateTime), pc.GetMinute(pc.MinSupportedDateTime), pc.GetSecond(pc.MinSupportedDateTime), CInt(pc.GetMilliseconds(pc.MinSupportedDateTime)), PersianCalendar.PersianEra)
    End Sub

    Public Sub New(ByVal persianyear As Integer, ByVal persianmonth As Integer, ByVal persianday As Integer, ByVal hour As Integer, ByVal minute As Integer, ByVal second As Integer, ByVal millisecond As Integer)
        If (pc Is Nothing) Then
            pc = New PersianCalendar
        End If
        dt = pc.ToDateTime(persianyear, persianmonth, persianday, hour, minute, second, millisecond, PersianCalendar.PersianEra)
    End Sub

    Public Function AddDays(ByVal days As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddDays(dt, days))
    End Function

    Public Function AddHours(ByVal hours As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddHours(dt, hours))
    End Function

    Public Function AddMilliseconds(ByVal milliseconds As Double) As FarsiDateFun
        Return New FarsiDateFun(pc.AddMilliseconds(dt, milliseconds))
    End Function

    Public Function AddMinuts(ByVal minutes As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddMinutes(dt, minutes))
    End Function

    Public Function AddMonths(ByVal months As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddMonths(dt, months))
    End Function

    Public Function AddSeconds(ByVal seconds As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddSeconds(dt, seconds))
    End Function

    Public Function AddWeeks(ByVal weeks As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddWeeks(dt, weeks))
    End Function

    Public Function AddYears(ByVal years As Integer) As FarsiDateFun
        Return New FarsiDateFun(pc.AddYears(dt, years))
    End Function

    Private Shared Function Convert2ASCII(ByVal s As String) As String
        s = s.Replace(ChrW(1776), "0"c)
        s = s.Replace(ChrW(1777), "1"c)
        s = s.Replace(ChrW(1778), "2"c)
        s = s.Replace(ChrW(1779), "3"c)
        s = s.Replace(ChrW(1780), "4"c)
        s = s.Replace(ChrW(1781), "5"c)
        s = s.Replace(ChrW(1782), "6"c)
        s = s.Replace(ChrW(1783), "7"c)
        s = s.Replace(ChrW(1784), "8"c)
        s = s.Replace(ChrW(1785), "9"c)
        s = s.Replace(ChrW(1632), "0"c)
        s = s.Replace(ChrW(1633), "1"c)
        s = s.Replace(ChrW(1634), "2"c)
        s = s.Replace(ChrW(1635), "3"c)
        s = s.Replace(ChrW(1636), "4"c)
        s = s.Replace(ChrW(1637), "5"c)
        s = s.Replace(ChrW(1638), "6"c)
        s = s.Replace(ChrW(1639), "7"c)
        s = s.Replace(ChrW(1640), "8"c)
        Return s.Replace(ChrW(1641), "9"c)
    End Function

    Public Shared Function E2F(ByVal Dac As CS_Component.DataAccess) As String
        Dim datetime As DateTime = Dac.ExecScalar("SELECT  GETDATE()")
        Dim pc As New PersianCalendar
        Return String.Concat(New String() {pc.GetYear(DateTime).ToString.PadLeft(4, "0"c), "/", pc.GetMonth(DateTime).ToString.PadLeft(2, "0"c), "/", pc.GetDayOfMonth(DateTime).ToString.PadLeft(2, "0"c)})
    End Function

    Public Shared Function E2F(ByVal datetime As DateTime) As String
        Dim pc As New PersianCalendar
        Return String.Concat(New String() {pc.GetYear(datetime).ToString.PadLeft(4, "0"c), "/", pc.GetMonth(datetime).ToString.PadLeft(2, "0"c), "/", pc.GetDayOfMonth(datetime).ToString.PadLeft(2, "0"c)})
    End Function

    Public Shared Function F2E(ByVal pd As FarsiDateFun) As DateTime
        Dim pc As New PersianCalendar
        Return pc.ToDateTime(pd.Year, pd.Month, pd.Day, pd.Hour, pd.Minute, pd.Second, CInt(pd.Milliseconds), PersianCalendar.PersianEra)
    End Function

    Public Overrides Function ToString() As String
        Return FarsiDateFun.E2F(dt)
    End Function

    Public ReadOnly Property [Date]() As String
        Get
            Return FarsiDateFun.E2F(dt)
        End Get
    End Property

    Public ReadOnly Property Day() As Integer
        Get
            Return pc.GetDayOfMonth(dt)
        End Get
    End Property

    Public ReadOnly Property Hour() As Integer
        Get
            Return pc.GetHour(dt)
        End Get
    End Property

    Public Shared ReadOnly Property MaxValue() As FarsiDateFun
        Get
            Dim pc As New PersianCalendar
            Return New FarsiDateFun(pc.MaxSupportedDateTime)
        End Get
    End Property

    Public ReadOnly Property Milliseconds() As Double
        Get
            Return pc.GetMilliseconds(dt)
        End Get
    End Property

    Public ReadOnly Property Minute() As Integer
        Get
            Return pc.GetMinute(dt)
        End Get
    End Property

    Public Shared ReadOnly Property MinValue() As FarsiDateFun
        Get
            Dim pc As New PersianCalendar
            Return New FarsiDateFun(pc.MinSupportedDateTime)
        End Get
    End Property

    Public ReadOnly Property Month() As Integer
        Get
            Return pc.GetMonth(dt)
        End Get
    End Property

    Public ReadOnly Property NowFromNew() As String
        Get
            Return (FarsiDateFun.E2F(dt))
        End Get
    End Property

    Public Shared ReadOnly Property Now() As String
        Get
            Return (FarsiDateFun.E2F(DateTime.UtcNow))
        End Get
    End Property

    Public Shared ReadOnly Property Now(ByVal CurrentTime As Date) As String
        Get
            Return (FarsiDateFun.E2F(CurrentTime))
        End Get
    End Property

    Public ReadOnly Property Second() As Integer
        Get
            Return pc.GetSecond(dt)
        End Get
    End Property

    Public ReadOnly Property TimeOfDay() As TimeSpan
        Get
            Return New TimeSpan(dt.Hour, dt.Minute, dt.Second)
        End Get
    End Property

    Public ReadOnly Property Year() As Integer
        Get
            Return pc.GetYear(dt)
        End Get
    End Property
End Class

Public Class Report
#Region "SetReportServer"
    Public Shared Sub SetReportServer(ByRef rp As Object, ByVal ServerName As String, ByVal UserName As String, ByVal Pass As String)
        Dim crtableLogoninfos As New CrystalDecisions.Shared.TableLogOnInfos
        Dim crtableLogoninfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim crConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo
        crConnectionInfo.ServerName = ServerName
        crConnectionInfo.UserID = UserName
        crConnectionInfo.Password = Pass
        Dim CrTable As CrystalDecisions.CrystalReports.Engine.Table
        For Each CrTable In rp.Database.Tables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
    End Sub

    Public Shared Sub SetReportServer(ByRef rp As Object, ByVal ServerName As String, ByVal IntegratedSecurity As Boolean)
        Dim crtableLogoninfos As New CrystalDecisions.Shared.TableLogOnInfos
        Dim crtableLogoninfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim crConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo
        crConnectionInfo.ServerName = ServerName
        crConnectionInfo.IntegratedSecurity = IntegratedSecurity
        Dim CrTable As CrystalDecisions.CrystalReports.Engine.Table
        For Each CrTable In rp.Database.Tables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
    End Sub
#End Region
End Class

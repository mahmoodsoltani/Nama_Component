Public Class Management

    Public Shared Sub CreateTables(ByVal ConnectionString As String)
        Dim SqlConnection As New SqlClient.SqlConnection(ConnectionString)
        Dim SqlCommand As New SqlClient.SqlCommand("", SqlConnection)
        For i As Integer = 0 To My.Resources.Commands.Split("/").Length - 1
            Try
                If (SqlConnection.State = ConnectionState.Closed) Then
                    SqlConnection.Open()
                End If
                SqlCommand.CommandText = My.Resources.Commands.Split("/")(i)
                If (SqlCommand.CommandText = "") Then Continue For
                SqlCommand.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Shared Str_ConnectionString As String

    Public Shared Property ConnectionString() As String
        Get
            Return Str_ConnectionString
        End Get
        Set(ByVal value As String)
            Str_ConnectionString = value
        End Set
    End Property

    Private Shared obj_DataAccess As CS_Component.DataAccess

    Public Shared ReadOnly Property DataAccess() As CS_Component.DataAccess
        Get
            If (obj_DataAccess Is Nothing) Then
                obj_DataAccess = New CS_Component.DataAccess(Str_ConnectionString, False)
            End If
            Return obj_DataAccess
        End Get
    End Property

End Class

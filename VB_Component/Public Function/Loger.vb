Imports System.IO

Public Class Loger
    Public Enum DatabaseAction
        Insert = 1
        Update = 2
        Delete = 3
    End Enum

    Public Shared Sub WriteLog(ByVal TableName As String _
                               , ByVal UserName As String _
                               , ByVal Srl As String _
                               , ByVal Action As DatabaseAction _
                               , ByVal SubmitedDate As String)

    End Sub
End Class

Public Class ExceptionLogger
    Shared obj() As Object

    Public Shared Sub WriteLog(ByVal ParamArray Data() As Object)
        If (Data Is Nothing) Then Return
        If (Not Directory.Exists(Application.StartupPath + "\Log")) Then Directory.CreateDirectory(Application.StartupPath + "\Log")
        Using Tr As TextWriter = New StreamWriter(Application.StartupPath + "\Log\Error.log", True)
            Tr.WriteLine("---------[Date:" + FarsiDateFun.E2F(Date.Now) + "]----------[Time:" + Date.Now.ToShortTimeString + "]---------")
            For Each obj As Object In Data
                If (obj Is Nothing) Then
                    Tr.WriteLine("NULL")
                ElseIf TypeOf obj Is DataRow Then
                    For Each dtc As DataColumn In CType(obj, DataRow).Table.Columns
                        Tr.WriteLine("[" + dtc.ColumnName + "] = " + CType(obj, DataRow)(dtc.ColumnName).ToString + " ** ")
                    Next
                ElseIf TypeOf obj Is Array Then
                    For Each o As Object In obj
                        WriteLog(o)
                    Next
                Else
                    Tr.WriteLine(obj.ToString)
                End If
            Next
            Tr.Close()
        End Using
    End Sub

    Public Shared Sub WriteExceptionLog(ByVal Ex As Exception)
        WriteLog(Ex.Message, Ex.StackTrace, Ex.Source)
    End Sub

    Public Shared Sub WriteExceptionLog(ByVal Ex As Exception, ByVal ParamArray Comments() As Object)
        WriteLog(Ex.Message, Ex.StackTrace, Comments)
    End Sub

    Public Shared Sub WriteExceptionLog(ByVal Form As BaseForm, ByVal Ex As Exception, ByVal ParamArray Comments() As Object)
        If Form.DataObject.DataRow Is Nothing Then
            WriteLog("Form : " + Form.Name, "Table : " + Form.TableName, "State : " _
                     + Form.FormState.ToString, "Active Control : " + Form.ActiveControl.Name _
                     , "===[Data Row Is NULL]===", Ex.Message, Ex.StackTrace, Comments)
        Else
            WriteLog("Form : " + Form.Name, "Table : " + Form.TableName, "State : " _
                     + Form.FormState.ToString, "Active Control : " + Form.ActiveControl.Name _
                     , "===[Data Row]===", Form.DataObject.DataRow.ItemArray, "----------" _
                     , Ex.Message, Ex.StackTrace, Comments)
        End If
    End Sub

End Class

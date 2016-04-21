Public Class EditMode

    Private Shared ClientIP As New Net.IPAddress(Net.Dns.GetHostByName(Net.Dns.GetHostName()).AddressList(0).Address)

    Public Shared Function IsInEditMode(ByRef frm As BaseForm, ByRef dr As DataRow) As Boolean
        If (dr Is Nothing) Then
            Return False
        End If
        If StartEdit(dr.Table.TableName, dr("srl")) Then Return True
        BaseDataObject.DataAccess.ExecQuery("INSERT INTO [EditMode] (TableName,Srl,UserIP) VALUES ('" + dr.Table.TableName + "'," + dr.Item("srl").ToString + ",'" + ClientIP.ToString() + "')")
        frm.TableName = dr.Table.TableName
        Return False
    End Function

    Public Shared Function IsInEditMode(ByRef frm As BaseForm, ByVal TableName As String, ByVal Srl As Integer) As Boolean
        If (TableName = "") Then
            Return False
        End If
        If StartEdit(TableName, Srl) Then Return True
        BaseDataObject.DataAccess.ExecQuery("INSERT INTO [EditMode] (TableName,Srl,UserIP) VALUES ('" + TableName + "'," + Srl.ToString + ",'" + ClientIP.ToString + "')")
        frm.TableName = TableName
        Return False
    End Function

    Public Shared Sub ExitEditMode(ByRef dr As DataRow)
        If (dr Is Nothing) Then
            Return
        End If
        BaseDataObject.DataAccess.Delete("EditMode", "srl = " + dr("srl").ToString + " AND TableName = '" + dr.Table.TableName + "' AND UserIP = '" + ClientIP.ToString + "'")
    End Sub

    Public Shared Sub ExitEditMode(ByVal TableName As String)
        If (TableName = Nothing) Then
            Return
        End If
        BaseDataObject.DataAccess.Delete("EditMode", "TableName = '" + TableName + "' AND UserIP = '" + ClientIP.ToString + "'")
    End Sub

    Public Shared Sub ExitEditMode(ByRef frm As BaseForm)
        If (frm.TableName = "") Then
            Return
        End If
        BaseDataObject.DataAccess.Delete("EditMode", "TableName = '" + frm.TableName + "' AND UserIP = '" + ClientIP.ToString + "'")
    End Sub

    Public Shared Function StartEdit(ByVal TableName As String, ByVal Srl As Integer)
        If BaseDataObject.DataAccess.Exist("EditMode", "srl = " + Srl.ToString + " AND TableName = '" + TableName + "'") Then
            MessageBoxFa.Show("این ردیف توسط کاربر دیگری درحال ویرایش است.")
            Return True
        Else : Return False
        End If
    End Function
End Class

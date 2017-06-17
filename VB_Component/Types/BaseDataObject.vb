Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class BaseDataObject

    Private str_TableName As String
    Private WithEvents dr_DataRow As DataRow
    Private str_KeyFieldName As String = "Srl"
    Private Shared obj_DataAccess As CS_Component.DataAccess

    Public Delegate Sub CancelEventHandler(ByVal sender As Object, ByVal e As CancelEventArgs)
    Public Event Deleting As CancelEventHandler
    Public Event Deleted As EventHandler
    Public Event Inserting As CancelEventHandler
    Public Event Inserted As EventHandler
    Public Event Updateing As CancelEventHandler
    Public Event UpDated As EventHandler

    Public Event TableNameChanged As EventHandler
    Public Event DataRowChanged As EventHandler

    Public Property TableName() As String
        Get
            Return str_TableName
        End Get
        Set(ByVal value As String)
            str_TableName = value
            RaiseEvent TableNameChanged(Me, New EventArgs())
        End Set
    End Property

    Public Property DataRow() As DataRow
        Get
            Return dr_DataRow
        End Get
        Set(ByVal value As DataRow)
            dr_DataRow = value
            RaiseEvent DataRowChanged(Me, New EventArgs())
        End Set
    End Property

    Public Shared Property DataAccess() As CS_Component.DataAccess
        Get
            Return obj_DataAccess
        End Get
        Set(ByVal value As CS_Component.DataAccess)
            obj_DataAccess = value
        End Set
    End Property

    Public Property KeyFieldName() As String
        Get
            Return str_KeyFieldName
        End Get
        Set(ByVal value As String)
            str_KeyFieldName = value
        End Set
    End Property

    Public Overridable Overloads Sub Load(ByVal PrimaryKey As Object)
        DataRow = obj_DataAccess.GetRow(str_TableName, Convert.ToInt32(PrimaryKey))
    End Sub

    Public Overridable Overloads Sub Load(ByVal Condition As String)
        obj_DataAccess.GetRow(str_TableName, Condition)
    End Sub

    Public Overridable Overloads Sub Load(ByVal SqlCommand As SqlCommand)
        obj_DataAccess.GetRow(SqlCommand)
    End Sub

    Public Overridable Sub NewData()
        dr_DataRow = obj_DataAccess.NewRow(str_TableName)
        dr_DataRow.Table.TableName = str_TableName
    End Sub

    Public Overridable Function Insert() As Boolean
        Dim CancelResult As New CancelEventArgs
        RaiseEvent Inserting(Me, CancelResult)
        If (CancelResult.Cancel) Then
            Return False
        End If
        DataRow(KeyFieldName) = obj_DataAccess.InsertWithLastId(dr_DataRow, False)
        Dim bol_Result As Boolean = DataRow(KeyFieldName) <> -1
        If (bol_Result) Then RaiseEvent Inserted(Me, New EventArgs())
        Return bol_Result
    End Function

    Public Overridable Function Update() As Boolean
        Dim CancelResult As New CancelEventArgs
        RaiseEvent Updateing(Me, CancelResult)
        If (CancelResult.Cancel) Then Return False
        Dim bol_Result As Boolean = obj_DataAccess.Update(dr_DataRow, dr_DataRow.Table.Columns.IndexOf(dr_DataRow.Table.Columns(str_KeyFieldName)), False)
        If (bol_Result) Then RaiseEvent UpDated(Me, New EventArgs())
        Return bol_Result
    End Function

    Public Overridable Function Delete(ByVal Srl As Integer) As Boolean
        Dim CancelResult As New CancelEventArgs
        RaiseEvent Deleting(Me, CancelResult)
        If (CancelResult.Cancel) Then
            Return False
        End If
        Dim bol_Result As Boolean = obj_DataAccess.Delete(str_TableName, Srl)
        If (bol_Result) Then
            RaiseEvent Deleted(Me, New EventArgs())
        End If
        Return bol_Result
    End Function

    Public Shared Function IsInEditMode(ByRef frm As BaseForm, ByRef dr As DataRow, ByVal ClientIpAddress As String) As Boolean
        If (dr Is Nothing) Then
            Return False
        End If
        If StartEdit(dr.Table.TableName, dr("srl")) Then Return True
        DataAccess.ExecQuery("INSERT INTO [EditMode] (TableName,Srl,UserIP) VALUES ('" + dr.Table.TableName + "'," + dr.Item("srl").ToString + ",'" + ClientIpAddress + "')")
        frm.TableName = dr.Table.TableName
        Return False
    End Function

    Public Shared Function IsInEditMode(ByRef frm As BaseForm, ByVal TableName As String, ByVal Srl As Integer, ByVal ClientIpAddress As String) As Boolean
        If (TableName = "") Then
            Return False
        End If
        If StartEdit(TableName, Srl) Then Return True
        DataAccess.ExecQuery("INSERT INTO [EditMode] (TableName,Srl,UserIP) VALUES ('" + TableName + "'," + Srl.ToString + ",'" + ClientIpAddress + "')")
        frm.TableName = TableName
        Return False
    End Function

    Public Shared Sub ExitEditMode(ByRef dr As DataRow, ByVal ClientIpAddress As String)
        If (dr Is Nothing) Then
            Return
        End If
        DataAccess.Delete("EditMode", "srl = " + dr("srl").ToString + " AND TableName = '" + dr.Table.TableName + "' AND UserIP = '" + ClientIpAddress + "'")
    End Sub

    Public Shared Sub ExitEditMode(ByVal TableName As String, ByVal ClientIpAddress As String)
        If (TableName = Nothing) Then
            Return
        End If
        DataAccess.Delete("EditMode", "TableName = '" + TableName + "' AND UserIP = '" + ClientIpAddress + "'")
    End Sub

    Public Shared Sub ExitEditMode(ByRef frm As BaseForm, ByVal ClientIpAddress As String)
        If (frm.TableName = Nothing) Then
            Return
        End If
        DataAccess.Delete("EditMode", "TableName = '" + frm.TableName + "' AND UserIP = '" + ClientIpAddress + "'")
    End Sub

    Public Shared Function StartEdit(ByVal TableName As String, ByVal Srl As Integer)
        If DataAccess.Exist("EditMode", "srl = " + Srl.ToString + " AND TableName = '" + TableName + "'") Then
            MessageBoxFa.Show("این ردیف توسط کاربر دیگری درحال ویرایش است.")
            Return True
        Else : Return False
        End If
    End Function
End Class

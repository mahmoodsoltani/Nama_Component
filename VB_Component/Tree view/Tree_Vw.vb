Imports System.Data.SqlClient

Public Class Tree_Vw
    Delegate Sub ExpandDelegate(ByVal tn As TreeNode)
    Public Event SelectedChange As EventHandler
    Dim da As CS_Component.DataAccess
    Private _SelectedNode As TreeNode
    Private TableName As String = ""
    Dim dt As DataTable
    Public Event ExpandNode As ExpandDelegate

    Public Function LevelOfNode(ByVal node As TreeNode) As Integer
        Dim level As Integer = 0
        While Not node Is Nothing
            node = node.Parent
            Level = Level + 1
        End While
        Return level
    End Function

    Public Sub LoadTreeView(ByVal da As CS_Component.DataAccess, ByVal dt As DataTable, ByVal TableName As String)
        Me.da = da
        Me.TableName = TableName
        Me.dt = dt
        Fill(dt)
    End Sub

    Public Sub Clear()
        TreeView1.Nodes.Clear()
    End Sub
    Public Sub Fill(ByVal node As TreeNode, ByVal dt As DataTable)
        Dim dv As New DataView
        dv.Table = dt

        Dim tn As TreeNode
        Dim tn1 As TreeNode
        If node Is Nothing Then
            dv.RowFilter = "Srl_Parent = 0"
            tn = New TreeNode(dv.Item(0)("Name").ToString)
            tn.Srl = dv.Item(0)("Srl").ToString
            tn.Srl_Parent = dv.Item(0)("Srl_Parent").ToString
            tn.IsRootNode = True
            tn.IsLoad = False

            TreeView1.Nodes.Add(tn)
            node = tn

        End If
        dv.RowFilter = "srl_parent=" + node.Srl.ToString()
        If Not node.IsLoad Then
            For i As Integer = 0 To dv.Count - 1

                tn = New TreeNode(dv.Item(i)("Name").ToString())
                tn.Srl = dv.Item(i)("Srl").ToString()
                tn.Srl_Parent = dv.Item(i)("srl_Parent").ToString()
                tn.IsRootNode = False
                tn.IsLoad = False
                If IsExist(node, tn) Is Nothing Then
                    node.Nodes.Add(tn)
                Else
                    tn = IsExist(node, tn)
                End If
               

                dv.RowFilter = "srl_parent=" + tn.Srl.ToString()
                For j As Integer = 0 To dv.Count - 1
                    tn1 = New TreeNode(dv.Item(j)("Name").ToString())
                    tn1.Srl = dv.Item(j)("Srl").ToString()
                    tn1.Srl_Parent = dv.Item(j)("srl_Parent").ToString()
                    tn1.IsRootNode = False
                    tn1.IsLoad = False
                    If IsExist(tn, tn1) Is Nothing Then
                        tn.Nodes.Add(tn1)
                    End If
                Next
                dv.RowFilter = "srl_parent=" + node.Srl.ToString()
            Next
        End If
        node.IsLoad = True
        node.Expand()
    End Sub
    Public Function IsExist(ByVal tn As TreeNode, ByVal Searchtn As TreeNode) As TreeNode
        For Each tn1 As TreeNode In tn.Nodes
            If tn1.Srl = Searchtn.Srl Then
                Return tn1
            End If
        Next
        Return Nothing
    End Function
    Public Sub Fill(ByVal dt As DataTable)
        If dt.Rows.Count = 0 Then
            Return
        End If
        Dim tn As TreeNode
        TreeView1.Nodes.Clear()
        Dim dv As New DataView
        dv.Table = dt

        dv.RowFilter = "Srl_Parent = 0"
        tn = New TreeNode(dv.Item(0)("Name").ToString)
        tn.Srl = dv.Item(0)("Srl").ToString
        tn.Srl_Parent = dv.Item(0)("Srl_Parent").ToString
        tn.IsRootNode = True

        TreeView1.Nodes.Add(tn)
        findAndAdd(tn, dv)
    End Sub

    Private Sub findAndAdd(ByVal tn As TreeNode, ByVal dv1 As DataView)
        dv1.RowFilter = ""
        dv1.RowFilter = "Srl_Parent = " & tn.Srl.ToString
        Application.DoEvents()
        For i As Integer = 0 To dv1.Count - 1
            Dim tn1 As TreeNode
            Try
                tn1 = New TreeNode(dv1.Item(i)("Name").ToString + " - " + dv1.Item(i)("Code").ToString)
            Catch ex As Exception
                tn1 = New TreeNode(dv1.Item(i)("Name").ToString)
            End Try
            tn1.Srl = dv1.Item(i)("Srl").ToString
            tn1.Srl_Parent = dv1.Item(i)("Srl_Parent").ToString
            tn1.IsRootNode = False
            tn.Nodes.Add(tn1)
            findAndAdd(tn1, dv1)
            dv1.RowFilter = "Srl_Parent = " & tn.Srl.ToString
        Next
    End Sub

    Public Sub DeleteSelectedNode()
        Try
            If CType(TreeView1.SelectedNode, VB_Component.TreeNode).IsRootNode = True Then
                MessageBoxFa.Show("این شاخه قابل حذف نمودن نیست")
                Return
            End If
            If MessageBoxFa.Show("اطلاعات انتخاب شده حذف شود؟", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If MessageBoxFa.Show("با حذف اطلاعات شما قادر به بازيابي آن نيستيد...مايل به ادامه هستيد؟", "", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Return
                Else
                    DeleteTreeNode(Integer.Parse(CType(TreeView1.SelectedNode, VB_Component.TreeNode).Srl))
                End If
            End If
        Catch
            MessageBoxFa.Show("لطفا يك عمليات را انتخاب كنيد")
            Return
        End Try
        'Fill(dt)
    End Sub

    Private Sub DeleteTreeNode(ByVal nodeId As Integer)
        If da.Exist(TableName, ("(Srl_Parent = " & nodeId & ")")) Then
            Dim dr As SqlDataReader = da.GetRowWithQuery("SELECT * From " + TableName + "  Where (Srl_Parent = " & nodeId & ")")
            Do While dr.Read
                DeleteTreeNode(Integer.Parse(dr.Item("Srl").ToString))
            Loop
        End If
        da.Delete(TableName, Integer.Parse(nodeId))
    End Sub

    Private Sub btn_Expand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Expand.Click
        TreeView1.ExpandAll()
    End Sub

    Private Sub btn_Colaps_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Colaps.Click
        TreeView1.CollapseAll()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        FindNodeInHierarchy(TreeView1.Nodes, tbox_search.Text, False)
        Cursor = Cursors.Default
    End Sub

    Public Sub FindNodeInHierarchy(ByVal nodes As TreeNodeCollection, ByVal strSearchValue As String, ByRef Find As Boolean)
        Dim iCount As Integer
        Dim i As Integer = 0
        i = i / i
        For iCount = 0 To nodes.Count - 1
            If Not Find Then
                If nodes.Item(iCount).Text.ToUpper.Contains(strSearchValue.ToUpper) Then
                    TreeView1.SelectedNode = nodes.Item(iCount)
                    TreeView1.Focus()
                    Find = True
                    Return
                End If
                nodes.Item(iCount).Expand()
                FindNodeInHierarchy(nodes.Item(iCount).Nodes, strSearchValue, False)
            End If
        Next iCount
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        _SelectedNode = TreeView1.SelectedNode
        RaiseEvent SelectedChange(sender, e)

    End Sub

    Public ReadOnly Property SelectedNode() As TreeNode
        Get
            Return _SelectedNode
        End Get
    End Property

    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TreeView1.DoubleClick
        If Not TreeView1.SelectedNode Is Nothing Then
            RaiseEvent ExpandNode(TreeView1.SelectedNode)
        End If
    End Sub

    'Private Delegate Sub FillGridDelegate()

    'Private Sub HandleCallback(ByVal result As IAsyncResult)
    '    Try
    '        Try
    '            Dim reader As SqlDataReader = DirectCast(result.AsyncState, SqlCommand).EndExecuteReader(result)
    '            Dim del As FillGridDelegate = New FillGridDelegate(AddressOf Me.Fill)
    '            MyBase.Invoke(del, New Object() {reader})
    '        Catch ex As Exception
    '        End Try
    '    Finally
    '    End Try
    'End Sub

    'Public Sub Fill(ByVal result As IAsyncResult)
    '    Dim tn As TreeNode
    '    Me.TreeView1.Nodes.Clear()
    '    Dim dv As New DataView
    '    dv.Table = dt
    '    dv.RowFilter = "Srl_Parent = 0"
    '    tn = New TreeNode(FindStringToShow(dv.Item(0)))
    '    tn.Srl = dv.Item(0)(0).ToString
    '    tn.Srl_Parent = dv.Item(0)(1).ToString
    '    tn.IsRootNode = True
    '    Me.TreeView1.Nodes.Add(tn)
    '    Me.findAndAdd(tn, dv)
    'End Sub

    'Private Function FindStringToShow(ByVal dr As DataRowView) As String
    '    Dim stringToShow As String = ""
    '    For i As Integer = 0 To CodeToshow.Length - 1
    '        If Microsoft.VisualBasic.IsNumeric(CodeToshow(i)) Then
    '            stringToShow += dr(Integer.Parse(CodeToshow(i))).ToString
    '        Else
    '            stringToShow += " " + CodeToshow(i) + " "
    '        End If
    '    Next
    '    Return stringToShow
    'End Function

    Private Sub TreeView1_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub TreeView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseClick

    End Sub

    Private Sub TreeView1_AfterExpand_1(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand

        RaiseEvent ExpandNode(DirectCast(e.Node, TreeNode))

    End Sub
End Class

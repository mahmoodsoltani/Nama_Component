Imports System.Data.SqlClient

Public Class frm_FormControls
    Inherits BaseForm

    Private lst_SecControls As SecurityControls


    Private obj_Assembly As System.Reflection.Assembly

    Public Property Assembly() As System.Reflection.Assembly
        Get
            Return obj_Assembly
        End Get
        Set(ByVal value As System.Reflection.Assembly)
            obj_Assembly = value
        End Set
    End Property

    Private Sub frm_FormControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFormsName()
        lst_SecControls = New SecurityControls
        Dim Dr As SqlDataReader = VB_Component.BaseDataObject.DataAccess.ExecReader("SELECT * FROM [sec_windowscontrol] WHERE Srl_Role=" + Me.Tag.ToString())
        While Dr.Read
            Dim Sc As New SecurityControl
            Sc.ControlName = Dr("ControlName")
            Sc.Disabled = Dr("Disable")
            Sc.FormName = Dr("FormName")
            Sc.Invisible = Dr("Invisible")
            Sc.Srl = Dr("Srl")
            Sc.Type = Dr("Type")
            lst_SecControls.Add(Sc)
        End While
    End Sub

    Sub GetFormsName()
        DataGridView1.Rows.Clear()
        Dim a As Reflection.Assembly = obj_Assembly
        Dim i As Integer = a.GetTypes().Length
        For i = 0 To a.GetTypes().Length - 1
            Dim str As String = a.GetTypes()(i).Name
            If (a.GetTypes()(i).IsSubclassOf(GetType(Form))) Then
                'cmb_Form.Items.Add(a.GetTypes()(i).Name)
                Try
                    Dim frm As Form = a.CreateInstance(a.GetTypes()(i).FullName)
                    DataGridView1.Rows.Add(a.GetTypes()(i).Name, a.GetTypes()(i).FullName, frm.Text)
                    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Tag = frm
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If (DataGridView1.CurrentRow Is Nothing) Then Return
        If (DataGridView1.CurrentRow.Tag Is Nothing) Then Return
        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add(CType(DataGridView1.CurrentRow.Tag, Form).Text)
        ScanControls(DataGridView1.CurrentRow.Tag, TreeView1.Nodes(0))
        Panel1.Visible = False
        'ScanMenus(DataGridView1.CurrentRow.Tag, TreeView1.Nodes(0))
    End Sub

    Dim Tn As System.Windows.Forms.TreeNode

    Public Sub ScanControls(ByVal C As Control, ByVal TreeNode As System.Windows.Forms.TreeNode)
        For Each Ct As Object In C.Controls
            Tn = New System.Windows.Forms.TreeNode()
            If (Ct.Controls.Count = 0) Then
                Tn.Text = Ct.Name + "(" + Ct.GetType().Name + ")" + "[" + Ct.Text + "]"
                Tn.Tag = Ct
                TreeNode.Nodes.Add(Tn)
                If (Ct.GetType().Name = "MenuStrip") Then ScanSubMenus(CType(Ct, MenuStrip), Tn)
            Else
                Tn.Text = Ct.Name + "(" + Ct.GetType().Name + ")" + "[" + Ct.Text + "]"
                Tn.Tag = Ct
                TreeNode.Nodes.Add(Tn)
                ScanControls(Ct, Tn)
            End If
        Next
    End Sub

    Sub ScanSubMenus(ByVal Ms As MenuStrip, ByVal TreeNode As System.Windows.Forms.TreeNode)
        For Each Ts As ToolStripMenuItem In Ms.Items
            Dim Tn As New System.Windows.Forms.TreeNode
            Tn.Text = Ts.Name + "[" + Ts.Text + "]"
            Tn.Tag = Ts
            TreeNode.Nodes.Add(Tn)
            ScanMenus(Ts, Tn)
        Next
    End Sub

    Sub ScanMenus(ByVal Menu As ToolStripMenuItem, ByVal TreeNode As System.Windows.Forms.TreeNode)
        For Each Mn As ToolStripItem In Menu.DropDownItems
            If (TypeOf (Mn) Is ToolStripMenuItem) Then
                Tn = New System.Windows.Forms.TreeNode()
                If (CType(Mn, ToolStripMenuItem).DropDownItems.Count = 0) Then
                    Tn.Text = Mn.Name + "[" + Mn.Text + "]"
                    Tn.Tag = Mn
                    TreeNode.Nodes.Add(Tn)
                Else
                    Tn.Text = Mn.Name + "[" + Mn.Text + "]"
                    Tn.Tag = Mn
                    TreeNode.Nodes.Add(Tn)
                    ScanMenus(Mn, Tn)
                End If
            End If
        Next
    End Sub


    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If (e.Node Is Nothing) Then Panel1.Visible = False
        'TreeView1.Controls.Add(Panel1)
        RemoveHandler chk_Disabled.CheckedChanged, AddressOf chk_Disabled_CheckedChanged
        RemoveHandler chk_Invisible.CheckedChanged, AddressOf chk_Disabled_CheckedChanged
        Panel1.Visible = True
        Panel1.Top = e.Node.Bounds.Bottom + TreeView1.Top + 2
        Panel1.Left = Panel1.Width - e.Node.Bounds.Left
        chk_Disabled.Checked = False
        chk_Invisible.Checked = False
        Dim sc As SecurityControl = Nothing
        If (TypeOf (TreeView1.SelectedNode.Tag) Is Control) Then
            sc = lst_SecControls.GetItem(CType(TreeView1.SelectedNode.Tag, Control).Name, CType(DataGridView1.CurrentRow.Tag, Form).Name)
        ElseIf (TypeOf (TreeView1.SelectedNode.Tag) Is ToolStripMenuItem) Then
            sc = lst_SecControls.GetItem(CType(TreeView1.SelectedNode.Tag, ToolStripMenuItem).Name, CType(DataGridView1.CurrentRow.Tag, Form).Name)
        End If
        If (Not sc Is Nothing) Then
            chk_Disabled.Checked = sc.Disabled
            chk_Invisible.Checked = sc.Invisible
        End If
        AddHandler chk_Disabled.CheckedChanged, AddressOf chk_Disabled_CheckedChanged
        AddHandler chk_Invisible.CheckedChanged, AddressOf chk_Disabled_CheckedChanged
    End Sub

    Private Sub chk_Disabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Disabled.CheckedChanged, chk_Invisible.CheckedChanged
        Dim sc As SecurityControl = Nothing
        If (TypeOf (TreeView1.SelectedNode.Tag) Is Control) Then
            sc = lst_SecControls.GetItem(CType(TreeView1.SelectedNode.Tag, Control).Name, CType(DataGridView1.CurrentRow.Tag, Form).Name)
        ElseIf (TypeOf (TreeView1.SelectedNode.Tag) Is ToolStripMenuItem) Then
            sc = lst_SecControls.GetItem(CType(TreeView1.SelectedNode.Tag, ToolStripMenuItem).Name, CType(DataGridView1.CurrentRow.Tag, Form).Name)
        End If
        If (sc Is Nothing) Then
            sc = New SecurityControl
            lst_SecControls.Add(sc)
        End If
        If (TypeOf (TreeView1.SelectedNode.Tag) Is Control) Then
            sc.ControlName = CType(TreeView1.SelectedNode.Tag, Control).Name
        Else
            sc.ControlName = CType(TreeView1.SelectedNode.Tag, ToolStripMenuItem).Name
        End If
        sc.Disabled = chk_Disabled.Checked
        sc.Invisible = chk_Invisible.Checked
        sc.FormName = CType(DataGridView1.CurrentRow.Tag, Form).Name
        sc.Type = TreeView1.SelectedNode.Tag.GetType().Name
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_Continue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Continue.Click
        'VB_Component.BaseDataObject.DataAccess.Delete("sec_WindowsControl", "Srl_Role=" + Me.Tag.ToString())
        Dim dr As DataRow
        For Each sc As SecurityControl In lst_SecControls
            If (sc.Srl = 0) Then
                dr = VB_Component.BaseDataObject.DataAccess.NewRow("sec_WindowsControl")
                dr("Srl_Role") = CType(Me.Tag, Integer)
                dr("ControlName") = sc.ControlName
                dr("Disable") = sc.Disabled
                dr("Invisible") = sc.Invisible
                dr("Type") = sc.Type
                dr("FormName") = sc.FormName
                VB_Component.BaseDataObject.DataAccess.Insert(dr, False)
            Else
                dr = VB_Component.BaseDataObject.DataAccess.GetRow("sec_WindowsControl", sc.Srl)
                dr("Srl_Role") = CType(Me.Tag, Integer)
                dr("ControlName") = sc.ControlName
                dr("Disable") = sc.Disabled
                dr("Invisible") = sc.Invisible
                dr("Type") = sc.Type
                dr("FormName") = sc.FormName
                VB_Component.BaseDataObject.DataAccess.Update(dr, 0, False)
            End If

        Next
        MessageBoxFa.Show("تغییرات مورد نظر انجام شد.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
End Class
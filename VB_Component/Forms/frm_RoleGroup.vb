Public Class frm_RoleGroup

    Private Sub frm_RoleGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Sec_RoleTableAdapter.Fill(Me.DataSet1.sec_Role)
        Me.Sec_GroupTableAdapter.Fill(Me.DataSet1.sec_Group)
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub btn_AddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddGroup.Click
        If (DataGridView1.CurrentRow Is Nothing) Then Return
        For Each R As DataGridViewRow In DataGridView2.Rows
            If (R.Cells(1).Value = DataGridView1.CurrentRow.Cells(0).Value) Then Return
        Next
        Dim dr As DataRow = VB_Component.BaseDataObject.DataAccess.NewRow("sec_RoleGroup")
        dr("Srl_Role") = DataGridView1.CurrentRow.Cells(0).Value
        dr("Srl_Group") = ComboBox1.SelectedValue
        VB_Component.BaseDataObject.DataAccess.Insert(dr, False)
        Me.Sec_RoleGroupTableAdapter.Fill(DataSet1.sec_RoleGroup, ComboBox1.SelectedValue)
    End Sub

    Private Sub btn_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Remove.Click
        If (DataGridView2.CurrentRow Is Nothing) Then Return
        Dim dr As DialogResult = MessageBoxFa.Show("آیا مایلید این بازدارنده را برای گروه حذف کنید ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (dr = System.Windows.Forms.DialogResult.No) Then Return
        VB_Component.BaseDataObject.DataAccess.Delete("sec_RoleGroup", DataGridView2.CurrentRow.Cells(0).Value)
        Me.Sec_RoleGroupTableAdapter.Fill(DataSet1.sec_RoleGroup, ComboBox1.SelectedValue)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Sec_RoleGroupTableAdapter.Fill(DataSet1.sec_RoleGroup, CType(ComboBox1.SelectedValue, Integer))
    End Sub
End Class
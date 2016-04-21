Public Class frm_User
    Inherits VB_Component.BaseForm_Info

    Dim dt As DataTable

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Private Sub frm_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        txt_Password.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        txt_DupPassword.UseSystemPasswordChar = Not CheckBox2.Checked
    End Sub

    Dim dr As DataRow
    Public Overrides Function Save(ByVal DoClearForm As Boolean) As Boolean
        If (txt_DupPassword.Value <> txt_Password.Value) Then
            VB_Component.MessageBoxFa.Show("کلمه عبور و تکرار آن برابر نیست.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        If clb_Groups.CheckedItems.Count = 0 Then
            MessageBoxFa.Show("plz select som groups")
            Return False
        End If
        DataObject.DataRow("Enabled") = chk_Enabled.Checked
        DataObject.DataRow("Password") = Security.Encrypt(txt_Password.Value, "tuhgshcd", "lvjqdlahmvc", "SHA512", 4, "@1B2c3D4e5F6g7H8", 256)
        Dim bol_Result As Boolean = MyBase.Save(False)
        VB_Component.BaseDataObject.DataAccess.Delete("sec_UserGroup", "Srl_User=" + DataObject.DataRow("Srl").ToString())
        dr = VB_Component.BaseDataObject.DataAccess.NewRow("sec_UserGroup")
        For i As Integer = 0 To clb_Groups.Items.Count - 1
            If (clb_Groups.GetItemChecked(i)) Then
                dr("Srl_User") = DataObject.DataRow("Srl")
                dr("Srl_Group") = dt.Rows(i)("Srl")
                VB_Component.BaseDataObject.DataAccess.Insert(dr, False)
            End If
        Next
        ClearForm()
        Return bol_Result
    End Function

    Public Overrides Function Edit() As Boolean
        Dim bol_Result As Boolean = MyBase.Edit()
        chk_Enabled.Checked = DataObject.DataRow("Enabled")
        txt_Password.Value = Security.Decrypt(DataObject.DataRow("Password"), "tuhgshcd", "lvjqdlahmvc", "SHA512", 4, "@1B2c3D4e5F6g7H8", 256)
        txt_DupPassword.Value = txt_Password.Value
        Dim dtr As SqlClient.SqlDataReader = VB_Component.BaseDataObject.DataAccess.GetRows("sec_UserGroup", "Srl_User=" + DataObject.DataRow("Srl").ToString())
        If dtr Is Nothing Then
            Return bol_Result
        End If
        While dtr.Read()
            For i As Integer = 0 To clb_Groups.Items.Count - 1
                If (dt.Rows(i)("Srl") = dtr("Srl_Group")) Then clb_Groups.SetItemChecked(i, True)
            Next
        End While
        Return bol_Result
    End Function

    Public Overrides Sub ClearForm()
        MyBase.ClearForm()
        chk_Enabled.Checked = False
    End Sub

    Private Sub frm_User_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim dr As DataRow
        dt = VB_Component.BaseDataObject.DataAccess.GetDataTable("sec_Group", "")
        clb_Groups.Items.Clear()
        For Each dr In dt.Rows
            clb_Groups.Items.Add(dr("GroupName"))
            If (CType(VB_Component.BaseDataObject.DataAccess.ExecScalar("SELECT ISNULL(Count(*),0) FROM sec_UserGroup WHERE Srl_User=" + DataObject.DataRow("Srl").ToString() + " AND Srl_Group=" + dr("Srl").ToString()), Double) <> 0) Then
                clb_Groups.SetItemChecked(dt.Rows.IndexOf(dr), True)
            End If
        Next
    End Sub
End Class
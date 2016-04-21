Public Class Frm_Login

    Dim da As CS_Component.DataAccess

    Private _UserDAtarow As DataRow = Nothing

    Public ReadOnly Property UserDataRow() As DataRow
        Get
            Return _UserDAtarow
        End Get
    End Property

    Private Sub Frm_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        statusStrip1.Visible = False
        If VB_Component.Windows.ArrayOfString("temp") Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click
        If txt_UserNAme.Text.Trim.Equals("") Then
            MessageBoxFa.Show("لطفا شناسه کاربري را وارد کنيد")
            txt_UserNAme.Focus()
            Return
        End If

        If txt_Pass.Text.Trim.Equals("") Then
            MessageBoxFa.Show("لطفا کلمه عبور را وارد کنيد")
            txt_Pass.Focus()
            Return
        End If

        Dim dr As DataRow = da.NewRow("Sec_Users")
        'dr.Table.Columns.Remove("srl")
        dr.Table.Columns.Remove("Name")
        dr.Table.Columns.Remove("active")
        dr("UserName") = txt_UserNAme.Text
        dr("Pass") = System.Text.Encoding.Unicode.GetBytes(txt_Pass.Text)
        Dim dr_user As DataRow = da.Exist(dr, False, True)

        If Not dr_user Is Nothing Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            _UserDAtarow = dr_user
            Close()
        Else
            MessageBoxFa.Show("نام کاربري يا کلمه عبور اشتباه است")
            txt_UserNAme.Focus()
            Return
        End If
    End Sub

    Private Sub Frm_Login_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Public Sub New(ByRef da As CS_Component.DataAccess)
        InitializeComponent()
        Me.da = da
    End Sub
End Class

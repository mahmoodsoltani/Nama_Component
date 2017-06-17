Public Class frm_ResetPassword

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_OK.Click
        Dim dr As DataRow = Management.DataAccess.GetRow("sec_User", "[Username]=N'" + txt_Username.Text + "' AND [Password]=N'" + Security.Encrypt(txt_Password.Text, "tuhgshcd", "lvjqdlahmvc", "SHA512", 4, "@1B2c3D4e5F6g7H8", 256) + "'")
        If dr Is Nothing Then
            MessageBoxFa.Show("نام کاربری یا کلمه عبور صحیح نیست.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        If (txt_DupNewPassword.Text <> txt_NewPassword.Text) Then
            MessageBoxFa.Show("کلمه عبور جدید با تکرار آن برابر نیست.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If
        dr("Password") = Security.Encrypt(txt_NewPassword.Text, "tuhgshcd", "lvjqdlahmvc", "SHA512", 4, "@1B2c3D4e5F6g7H8", 256)
        Management.DataAccess.Update(dr, 0)
        MessageBoxFa.Show("کلمه عبور تغییر یافت.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
End Class
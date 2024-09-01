Imports System.Security.Cryptography
Public Enum LoginStatus
    Abort
    UsernameOrPasswordIsInvalid
    UserIsDisabled
    GroupIsBlocked
    Succeed
End Enum

Public Class Security

    Private Shared dr_LoggedInUser As DataRow

    Public Shared ReadOnly Property LoggedInUser() As DataRow
        Get
            Return dr_LoggedInUser
        End Get
    End Property

    Public Shared Function Authenticate(ByVal UserName As String, ByVal Password As String) As LoginStatus        
        Dim Dr As DataRow = VB_Component.BaseDataObject.DataAccess.GetRow("sec_User", "Username = '" + UserName + "' AND Password='" + Security.Encrypt(Password, "tuhgshcd", "lvjqdlahmvc", "SHA512", 4, "@1B2c3D4e5F6g7H8", 256) + "'")
        If (Dr Is Nothing) Then Return LoginStatus.UsernameOrPasswordIsInvalid
        If (Not Dr("Enabled")) Then Return LoginStatus.UserIsDisabled
        Dim dr_Grp As DataRow = VB_Component.BaseDataObject.DataAccess.GetRow("SELECT * FROM [sec_Group] where Srl IN (Select Srl_Group FROM sec_UserGroup WHERE Srl_User=" + Dr("Srl").ToString() + ")")        
        If (Not dr_Grp Is Nothing) Then
            If (dr_Grp("UsersBlocked")) Then Return LoginStatus.GroupIsBlocked
        End If
        dr_LoggedInUser = Dr
        Return LoginStatus.Succeed
    End Function

    Public Shared Function Login() As LoginStatus
        Dim frm As New frm_Login

        frm.ShowDialog()
        If (frm.DialogResult = DialogResult.Abort) Then Return LoginStatus.Abort
        Dim ls As LoginStatus = Authenticate(frm.UserName, frm.Password)
        Return ls
    End Function

    Public Shared Function Login(ByVal temp As String) As LoginStatus
        Dim frm As New frm_Login(temp)
        If frm.IsDisposed Then
            Return LoginStatus.Abort
        End If
        frm.ShowDialog()
        If (frm.DialogResult = DialogResult.Abort) Then Return LoginStatus.Abort
        Dim ls As LoginStatus = Authenticate(frm.UserName, frm.Password)
        Return ls
    End Function

    Public Shared Sub Users(ByVal Owner As Form)
        Dim frm As New frm_UserList With {
            .Owner = Owner
        }
        frm.ShowDialog()
    End Sub

    Public Shared Sub Groups(ByVal Owner As Form)
        Dim frm As New frm_Group With {
            .Owner = Owner
        }
        frm.ShowDialog()
    End Sub

    Public Shared Sub Roles(ByVal Owner As Form)
        Dim frm As New frm_Role With {
            .Owner = Owner
        }
        frm.ShowDialog()
    End Sub

    Public Shared Sub RoleGroups(ByVal Owner As Form)
        Dim frm As New frm_RoleGroup With {
            .Owner = Owner
        }
        frm.ShowDialog()
    End Sub

    Public Shared Sub ResetPassword(ByVal Owner As Form)
        Dim frm As New frm_ResetPassword With {
            .Owner = Owner
        }
        frm.ShowDialog()    
    End Sub

    Public Shared Sub Permission(ByVal Owner As Form, ByVal Assembly As Reflection.Assembly)
        Dim frm As New frm_Permission With {
            .Owner = Owner,
            .Assembly = Assembly
        }
        frm.ShowDialog()
    End Sub

    Public Shared Function Encrypt(ByVal plainText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal hashAlgorithm As String, ByVal passwordIterations As Integer, ByVal initVector As String, ByVal keySize As Integer) As String
        Dim initVectorBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(saltValue)
        Dim plainTextBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(plainText)
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged() With {
            .Mode = CipherMode.CBC
        }
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
        Dim memoryStream As IO.MemoryStream = New IO.MemoryStream()
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, System.Security.Cryptography.CryptoStreamMode.Write)
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText
    End Function

    Public Shared Function Decrypt(ByVal cipherText As String, ByVal passPhrase As String, ByVal saltValue As String, ByVal hashAlgorithm As String, ByVal passwordIterations As Integer, ByVal initVector As String, ByVal keySize As Integer) As String
        Dim initVectorBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(saltValue)
        Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)
        Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
        Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged() With {
            .Mode = CipherMode.CBC
        }
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
        Dim memoryStream As IO.MemoryStream = New IO.MemoryStream(cipherTextBytes)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes As Byte()
        ReDim plainTextBytes(cipherTextBytes.Length)
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Dim plainText As String = System.Text.Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
        Return plainText

    End Function

    Public Shared Sub ApplyPermission(ByVal Form As Form)
        If (Security.LoggedInUser Is Nothing) Then Return
        Dim dr As SqlClient.SqlDataReader = VB_Component.BaseDataObject.DataAccess.ExecReader("exec Load_Controls @Srl_User= " + Security.LoggedInUser("Srl").ToString() + ", @FormName='" + Form.Name + "'")
        'Dim dr As SqlClient.SqlDataReader = VB_Component.BaseDataObject.DataAccess.ExecReader("exec Load_Controls @Srl_User= 1, @FormName='" + Form.Name + "'")
        While dr.Read
            If (dr.Item("Type") = "ToolStripMenuItem") Then
                For Each T As Object In Form.Controls
                    Try
                        If (TypeOf (T) Is MenuStrip) Then
                            Dim C As ToolStripMenuItem = T.Items.Find(dr("ControlName"), True)(0)
                            If (Not C Is Nothing) Then
                                C.Enabled = Not dr("Disable")
                                C.Visible = Not dr("Invisible")
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                Next
            Else
                Dim C As Control = Form.Controls.Find(dr("ControlName"), True)(0)
                If Not C Is Nothing Then
                    C.Enabled = Not dr("Disable")
                    C.Visible = Not dr("Invisible")
                End If
            End If
        End While
    End Sub

    Public Shared Function IsUserInRole(ByVal Srl_User As Integer, ByVal Srl_Group As Integer) As Boolean
        Dim Dr As DataRow = BaseDataObject.DataAccess.GetRow("sec_UserGroup", "Srl_User=" + Srl_User.ToString + " AND Srl_Group=" + Srl_Group.ToString)
        Return Not Dr Is Nothing
    End Function

End Class

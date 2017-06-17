Public Class frm_Login
    Public Sub New(ByVal temp As String)
        'If VB_Component.Windows.ArrayOfString(temp) Then
        '    Me.Dispose()
        'End If
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public ReadOnly Property UserName() As String
        Get
            Return TextBox1.Value
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return TextBox2.Value
        End Get
    End Property

    Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_OK.Click
        Try
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Software\Nama\MIS", "UserName", TextBox1.Value)
        Catch ex As Exception

        End Try
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancel.Click
        DialogResult = DialogResult.Abort
    End Sub

    Private Sub frm_Login_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (DialogResult <> DialogResult.OK) Then DialogResult = DialogResult.Abort
    End Sub

    Private Sub frm_Login_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            TextBox1.Value = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\Software\Nama\MIS", "UserName", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Security.ResetPassword(Me)
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ResetPassword
    Inherits VB_Component.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ResetPassword))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_Username = New CS_Component.TextBox
        Me.txt_Password = New CS_Component.TextBox
        Me.txt_NewPassword = New CS_Component.TextBox
        Me.txt_DupNewPassword = New CS_Component.TextBox
        Me.btn_OK = New CS_Component.Btn
        Me.btn_Cancel = New CS_Component.Btn
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(278, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "نام کاربری :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "کلمه عبور فعلی :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "کلمه عبور جدید :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "تکرار کلمه عبور جدید :"
        '
        'txt_Username
        '
        Me.txt_Username.CheckExistValueInDb = False
        Me.txt_Username.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Username.CurrencyUnit = "ریال"
        Me.txt_Username.DefaultValue = ""
        Me.txt_Username.FillWithMaxInDb = False
        Me.txt_Username.IsRequired = False
        Me.txt_Username.Location = New System.Drawing.Point(19, 45)
        Me.txt_Username.MaxDecimalLength = 2
        Me.txt_Username.Name = "txt_Username"
        Me.txt_Username.Size = New System.Drawing.Size(154, 23)
        Me.txt_Username.SpellControl = Nothing
        Me.txt_Username.TabIndex = 9
        Me.txt_Username.Title = Nothing
        Me.txt_Username.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_Username.UseForData = True
        Me.txt_Username.ValidateCheckExistOnEdit = False
        Me.txt_Username.Value = ""
        '
        'txt_Password
        '
        Me.txt_Password.CheckExistValueInDb = False
        Me.txt_Password.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Password.CurrencyUnit = "ریال"
        Me.txt_Password.DefaultValue = ""
        Me.txt_Password.FillWithMaxInDb = False
        Me.txt_Password.IsRequired = False
        Me.txt_Password.Location = New System.Drawing.Point(19, 74)
        Me.txt_Password.MaxDecimalLength = 2
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.Size = New System.Drawing.Size(154, 23)
        Me.txt_Password.SpellControl = Nothing
        Me.txt_Password.TabIndex = 10
        Me.txt_Password.Title = Nothing
        Me.txt_Password.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_Password.UseForData = True
        Me.txt_Password.UseSystemPasswordChar = True
        Me.txt_Password.ValidateCheckExistOnEdit = False
        Me.txt_Password.Value = ""
        '
        'txt_NewPassword
        '
        Me.txt_NewPassword.CheckExistValueInDb = False
        Me.txt_NewPassword.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_NewPassword.CurrencyUnit = "ریال"
        Me.txt_NewPassword.DefaultValue = ""
        Me.txt_NewPassword.FillWithMaxInDb = False
        Me.txt_NewPassword.IsRequired = False
        Me.txt_NewPassword.Location = New System.Drawing.Point(19, 103)
        Me.txt_NewPassword.MaxDecimalLength = 2
        Me.txt_NewPassword.Name = "txt_NewPassword"
        Me.txt_NewPassword.Size = New System.Drawing.Size(154, 23)
        Me.txt_NewPassword.SpellControl = Nothing
        Me.txt_NewPassword.TabIndex = 11
        Me.txt_NewPassword.Title = Nothing
        Me.txt_NewPassword.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_NewPassword.UseForData = True
        Me.txt_NewPassword.UseSystemPasswordChar = True
        Me.txt_NewPassword.ValidateCheckExistOnEdit = False
        Me.txt_NewPassword.Value = ""
        '
        'txt_DupNewPassword
        '
        Me.txt_DupNewPassword.CheckExistValueInDb = False
        Me.txt_DupNewPassword.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_DupNewPassword.CurrencyUnit = "ریال"
        Me.txt_DupNewPassword.DefaultValue = ""
        Me.txt_DupNewPassword.FillWithMaxInDb = False
        Me.txt_DupNewPassword.IsRequired = False
        Me.txt_DupNewPassword.Location = New System.Drawing.Point(19, 132)
        Me.txt_DupNewPassword.MaxDecimalLength = 2
        Me.txt_DupNewPassword.Name = "txt_DupNewPassword"
        Me.txt_DupNewPassword.Size = New System.Drawing.Size(154, 23)
        Me.txt_DupNewPassword.SpellControl = Nothing
        Me.txt_DupNewPassword.TabIndex = 12
        Me.txt_DupNewPassword.Title = Nothing
        Me.txt_DupNewPassword.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_DupNewPassword.UseForData = True
        Me.txt_DupNewPassword.UseSystemPasswordChar = True
        Me.txt_DupNewPassword.ValidateCheckExistOnEdit = False
        Me.txt_DupNewPassword.Value = ""
        '
        'btn_OK
        '
        Me.btn_OK.BackColor = System.Drawing.Color.Transparent
        Me.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_OK.HeaderText = "تایید"
        Me.btn_OK.Image = CType(resources.GetObject("btn_OK.Image"), System.Drawing.Bitmap)
        Me.btn_OK.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.btn_OK.Location = New System.Drawing.Point(205, 168)
        Me.btn_OK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(67, 26)
        Me.btn_OK.TabIndex = 13
        '
        'btn_Cancel
        '
        Me.btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.HeaderText = "انصراف"
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.btn_Cancel.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.btn_Cancel.Location = New System.Drawing.Point(19, 168)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(78, 26)
        Me.btn_Cancel.TabIndex = 14
        '
        'frm_ResetPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 236)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.txt_DupNewPassword)
        Me.Controls.Add(Me.txt_NewPassword)
        Me.Controls.Add(Me.txt_Password)
        Me.Controls.Add(Me.txt_Username)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_ResetPassword"
        Me.Text = "تغییر کلمه عبور"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_Username, 0)
        Me.Controls.SetChildIndex(Me.txt_Password, 0)
        Me.Controls.SetChildIndex(Me.txt_NewPassword, 0)
        Me.Controls.SetChildIndex(Me.txt_DupNewPassword, 0)
        Me.Controls.SetChildIndex(Me.btn_OK, 0)
        Me.Controls.SetChildIndex(Me.btn_Cancel, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Username As CS_Component.TextBox
    Friend WithEvents txt_Password As CS_Component.TextBox
    Friend WithEvents txt_NewPassword As CS_Component.TextBox
    Friend WithEvents txt_DupNewPassword As CS_Component.TextBox
    Friend WithEvents btn_OK As CS_Component.Btn
    Friend WithEvents btn_Cancel As CS_Component.Btn
End Class

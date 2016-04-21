<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Login
    Inherits VB_Component.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Login))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btn_Ok = New CS_Component.Btn
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txt_Pass = New VB_Component.Tbox
        Me.txt_UserNAme = New VB_Component.Tbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Btn_Ok)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.txt_Pass)
        Me.GroupBox1.Controls.Add(Me.txt_UserNAme)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(451, 156)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Btn_Ok
        '
        Me.Btn_Ok.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Ok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Ok.HeaderText = "ورود به سیستم"
        Me.Btn_Ok.Location = New System.Drawing.Point(235, 118)
        Me.Btn_Ok.Name = "Btn_Ok"
        Me.Btn_Ok.Size = New System.Drawing.Size(114, 26)
        Me.Btn_Ok.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 141)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'txt_Pass
        '
        Me.txt_Pass.CheckLength = False
        Me.txt_Pass.ColorOnFoucus = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.txt_Pass.ErrorMessage = Nothing
        Me.txt_Pass.Location = New System.Drawing.Point(179, 80)
        Me.txt_Pass.Name = "txt_Pass"
        Me.txt_Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Pass.Size = New System.Drawing.Size(170, 22)
        Me.txt_Pass.TabIndex = 1
        Me.txt_Pass.TextPading = False
        Me.txt_Pass.TypeOfContains = VB_Component.Tbox.TypeOfValues.All
        Me.txt_Pass.ValidateValue = False
        '
        'txt_UserNAme
        '
        Me.txt_UserNAme.CheckLength = False
        Me.txt_UserNAme.ColorOnFoucus = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.txt_UserNAme.ErrorMessage = Nothing
        Me.txt_UserNAme.Location = New System.Drawing.Point(179, 30)
        Me.txt_UserNAme.Name = "txt_UserNAme"
        Me.txt_UserNAme.Size = New System.Drawing.Size(170, 22)
        Me.txt_UserNAme.TabIndex = 0
        Me.txt_UserNAme.TextPading = False
        Me.txt_UserNAme.TypeOfContains = VB_Component.Tbox.TypeOfValues.All
        Me.txt_UserNAme.ValidateValue = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(365, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "کلمه عبور"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(365, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "نام کاربری"
        '
        'Frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(468, 191)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_Login"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_UserNAme As VB_Component.Tbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_Pass As VB_Component.Tbox
    Friend WithEvents Btn_Ok As CS_Component.Btn

End Class

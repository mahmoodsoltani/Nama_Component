<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_User
    Inherits VB_Component.BaseForm_Info

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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.chk_Enabled = New System.Windows.Forms.CheckBox
        Me.txt_Name = New CS_Component.TextBox
        Me.txt_Family = New CS_Component.TextBox
        Me.txt_Username = New CS_Component.TextBox
        Me.txt_Password = New CS_Component.TextBox
        Me.txt_DupPassword = New CS_Component.TextBox
        Me.clb_Groups = New System.Windows.Forms.CheckedListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.gbx_Buttons.SuspendLayout()
        Me.gbx_Fields.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx_Buttons
        '
        Me.gbx_Buttons.Location = New System.Drawing.Point(12, 229)
        Me.gbx_Buttons.Size = New System.Drawing.Size(482, 50)
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(391, 17)
        '
        'gbx_Fields
        '
        Me.gbx_Fields.Controls.Add(Me.CheckBox2)
        Me.gbx_Fields.Controls.Add(Me.CheckBox1)
        Me.gbx_Fields.Controls.Add(Me.Label4)
        Me.gbx_Fields.Controls.Add(Me.clb_Groups)
        Me.gbx_Fields.Controls.Add(Me.txt_DupPassword)
        Me.gbx_Fields.Controls.Add(Me.txt_Password)
        Me.gbx_Fields.Controls.Add(Me.txt_Username)
        Me.gbx_Fields.Controls.Add(Me.txt_Family)
        Me.gbx_Fields.Controls.Add(Me.txt_Name)
        Me.gbx_Fields.Controls.Add(Me.chk_Enabled)
        Me.gbx_Fields.Controls.Add(Me.Label6)
        Me.gbx_Fields.Controls.Add(Me.Label5)
        Me.gbx_Fields.Controls.Add(Me.Label3)
        Me.gbx_Fields.Controls.Add(Me.Label2)
        Me.gbx_Fields.Controls.Add(Me.Label1)
        Me.gbx_Fields.Size = New System.Drawing.Size(482, 191)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(381, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "نام :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(381, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نام خانوادگی :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(381, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "نام کاربری :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(381, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "رمز عبور :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(381, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "تکرار رمز عبور :"
        '
        'chk_Enabled
        '
        Me.chk_Enabled.AutoSize = True
        Me.chk_Enabled.Checked = True
        Me.chk_Enabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Enabled.Location = New System.Drawing.Point(260, 161)
        Me.chk_Enabled.Name = "chk_Enabled"
        Me.chk_Enabled.Size = New System.Drawing.Size(114, 20)
        Me.chk_Enabled.TabIndex = 6
        Me.chk_Enabled.Tag = "Enabled"
        Me.chk_Enabled.Text = "کاربر فعال است."
        Me.chk_Enabled.UseVisualStyleBackColor = True
        '
        'txt_Name
        '
        Me.txt_Name.CheckExistValueInDb = False
        Me.txt_Name.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Name.CurrencyUnit = "ریال"
        Me.txt_Name.DefaultValue = ""
        Me.txt_Name.FillWithMaxInDb = False
        Me.txt_Name.IsRequired = False
        Me.txt_Name.Location = New System.Drawing.Point(229, 16)
        Me.txt_Name.MaxDecimalLength = 2
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Name.Size = New System.Drawing.Size(145, 23)
        Me.txt_Name.SpellControl = Nothing
        Me.txt_Name.TabIndex = 7
        Me.txt_Name.Tag = "FirstName"
        Me.txt_Name.Title = Nothing
        Me.txt_Name.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_Name.UseForData = True
        Me.txt_Name.ValidateCheckExistOnEdit = False
        Me.txt_Name.Value = ""
        '
        'txt_Family
        '
        Me.txt_Family.CheckExistValueInDb = False
        Me.txt_Family.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Family.CurrencyUnit = "ریال"
        Me.txt_Family.DefaultValue = ""
        Me.txt_Family.FillWithMaxInDb = False
        Me.txt_Family.IsRequired = False
        Me.txt_Family.Location = New System.Drawing.Point(229, 45)
        Me.txt_Family.MaxDecimalLength = 2
        Me.txt_Family.Name = "txt_Family"
        Me.txt_Family.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Family.Size = New System.Drawing.Size(145, 23)
        Me.txt_Family.SpellControl = Nothing
        Me.txt_Family.TabIndex = 8
        Me.txt_Family.Tag = "LastName"
        Me.txt_Family.Title = Nothing
        Me.txt_Family.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_Family.UseForData = True
        Me.txt_Family.ValidateCheckExistOnEdit = False
        Me.txt_Family.Value = ""
        '
        'txt_Username
        '
        Me.txt_Username.CheckExistValueInDb = False
        Me.txt_Username.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Username.CurrencyUnit = "ریال"
        Me.txt_Username.DefaultValue = ""
        Me.txt_Username.FillWithMaxInDb = False
        Me.txt_Username.IsRequired = False
        Me.txt_Username.Location = New System.Drawing.Point(229, 74)
        Me.txt_Username.MaxDecimalLength = 2
        Me.txt_Username.Name = "txt_Username"
        Me.txt_Username.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Username.Size = New System.Drawing.Size(145, 23)
        Me.txt_Username.SpellControl = Nothing
        Me.txt_Username.TabIndex = 9
        Me.txt_Username.Tag = "Username"
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
        Me.txt_Password.Location = New System.Drawing.Point(251, 103)
        Me.txt_Password.MaxDecimalLength = 2
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Password.Size = New System.Drawing.Size(123, 23)
        Me.txt_Password.SpellControl = Nothing
        Me.txt_Password.TabIndex = 10
        Me.txt_Password.Tag = ""
        Me.txt_Password.Title = Nothing
        Me.txt_Password.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_Password.UseForData = True
        Me.txt_Password.UseSystemPasswordChar = True
        Me.txt_Password.ValidateCheckExistOnEdit = False
        Me.txt_Password.Value = ""
        '
        'txt_DupPassword
        '
        Me.txt_DupPassword.CheckExistValueInDb = False
        Me.txt_DupPassword.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_DupPassword.CurrencyUnit = "ریال"
        Me.txt_DupPassword.DefaultValue = ""
        Me.txt_DupPassword.FillWithMaxInDb = False
        Me.txt_DupPassword.IsRequired = False
        Me.txt_DupPassword.Location = New System.Drawing.Point(251, 132)
        Me.txt_DupPassword.MaxDecimalLength = 2
        Me.txt_DupPassword.Name = "txt_DupPassword"
        Me.txt_DupPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_DupPassword.Size = New System.Drawing.Size(123, 23)
        Me.txt_DupPassword.SpellControl = Nothing
        Me.txt_DupPassword.TabIndex = 11
        Me.txt_DupPassword.Title = Nothing
        Me.txt_DupPassword.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.txt_DupPassword.UseForData = True
        Me.txt_DupPassword.UseSystemPasswordChar = True
        Me.txt_DupPassword.ValidateCheckExistOnEdit = False
        Me.txt_DupPassword.Value = ""
        '
        'clb_Groups
        '
        Me.clb_Groups.FormattingEnabled = True
        Me.clb_Groups.Location = New System.Drawing.Point(10, 34)
        Me.clb_Groups.Name = "clb_Groups"
        Me.clb_Groups.Size = New System.Drawing.Size(213, 148)
        Me.clb_Groups.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(213, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "گروه هایی که کاربر عضو آن میباشد"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(230, 108)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(230, 137)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 15
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'frm_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 315)
        Me.Name = "frm_User"
        Me.TableName = "sec_User"
        Me.Text = "تعریف کاربر"
        Me.gbx_Buttons.ResumeLayout(False)
        Me.gbx_Fields.ResumeLayout(False)
        Me.gbx_Fields.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chk_Enabled As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents clb_Groups As System.Windows.Forms.CheckedListBox
    Friend WithEvents txt_DupPassword As CS_Component.TextBox
    Friend WithEvents txt_Password As CS_Component.TextBox
    Friend WithEvents txt_Username As CS_Component.TextBox
    Friend WithEvents txt_Family As CS_Component.TextBox
    Friend WithEvents txt_Name As CS_Component.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class

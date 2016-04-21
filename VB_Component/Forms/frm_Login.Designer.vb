<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Login))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New CS_Component.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New CS_Component.TextBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(279, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(201, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "نام کاربری :"
        '
        'TextBox1
        '
        Me.TextBox1.CheckExistValueInDb = False
        Me.TextBox1.ColorOnFocus = System.Drawing.Color.Yellow
        Me.TextBox1.CurrencyUnit = "ریال"
        Me.TextBox1.DefaultValue = ""
        Me.TextBox1.FillWithMaxInDb = False
        Me.TextBox1.IsRequired = False
        Me.TextBox1.Location = New System.Drawing.Point(20, 49)
        Me.TextBox1.MaxDecimalLength = 2
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(175, 23)
        Me.TextBox1.SpellControl = Nothing
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Title = Nothing
        Me.TextBox1.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.TextBox1.UseForData = True
        Me.TextBox1.ValidateCheckExistOnEdit = False
        Me.TextBox1.Value = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "کلمه عبور :"
        '
        'TextBox2
        '
        Me.TextBox2.CheckExistValueInDb = False
        Me.TextBox2.ColorOnFocus = System.Drawing.Color.Yellow
        Me.TextBox2.CurrencyUnit = "ریال"
        Me.TextBox2.DefaultValue = ""
        Me.TextBox2.FillWithMaxInDb = False
        Me.TextBox2.IsRequired = False
        Me.TextBox2.Location = New System.Drawing.Point(20, 87)
        Me.TextBox2.MaxDecimalLength = 2
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox2.Size = New System.Drawing.Size(175, 23)
        Me.TextBox2.SpellControl = Nothing
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Title = Nothing
        Me.TextBox2.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.TextBox2.UseForData = True
        Me.TextBox2.UseSystemPasswordChar = True
        Me.TextBox2.ValidateCheckExistOnEdit = False
        Me.TextBox2.Value = ""
        '
        'btn_OK
        '
        Me.btn_OK.Image = CType(resources.GetObject("btn_OK.Image"), System.Drawing.Image)
        Me.btn_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_OK.Location = New System.Drawing.Point(194, 125)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 36)
        Me.btn_OK.TabIndex = 9
        Me.btn_OK.Text = "    تایید"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Image)
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel.Location = New System.Drawing.Point(20, 125)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 36)
        Me.btn_Cancel.TabIndex = 10
        Me.btn_Cancel.Text = "    انصراف"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(316, 177)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(91, 16)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "تغییر کلمه عبور"
        '
        'frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BorderColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(417, 205)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "frm_Login"
        Me.ShowInTaskbar = True
        Me.Text = "ورود به نرم افزار"
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TextBox2, 0)
        Me.Controls.SetChildIndex(Me.btn_OK, 0)
        Me.Controls.SetChildIndex(Me.btn_Cancel, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As CS_Component.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As CS_Component.TextBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class

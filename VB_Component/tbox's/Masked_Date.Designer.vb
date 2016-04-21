<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Masked_Date
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbox_Sal = New VB_Component.Tbox
        Me.tbox_roz = New VB_Component.Tbox
        Me.tbox_Mah = New VB_Component.Tbox
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(-1, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(22, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "13"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(64, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "/"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkRate = 200
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(35, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 1004
        Me.Label3.Text = "/"
        '
        'tbox_Sal
        '
        Me.tbox_Sal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbox_Sal.CheckLength = False
        Me.tbox_Sal.ColorOnFoucus = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.tbox_Sal.EnterStop = True
        Me.tbox_Sal.ErrorMessage = Nothing
        Me.tbox_Sal.Location = New System.Drawing.Point(19, 2)
        Me.tbox_Sal.MaxLength = 2
        Me.tbox_Sal.Name = "tbox_Sal"
        Me.tbox_Sal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbox_Sal.Size = New System.Drawing.Size(18, 15)
        Me.tbox_Sal.TabIndex = 1003
        Me.tbox_Sal.TabStop = False
        Me.tbox_Sal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbox_Sal.TextPading = False
        Me.tbox_Sal.TypeOfContains = VB_Component.Tbox.TypeOfValues.Digit
        Me.tbox_Sal.ValidateValue = False
        '
        'tbox_roz
        '
        Me.tbox_roz.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbox_roz.CheckLength = False
        Me.tbox_roz.ColorOnFoucus = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.tbox_roz.EnterStop = True
        Me.tbox_roz.ErrorMessage = Nothing
        Me.tbox_roz.Location = New System.Drawing.Point(76, 1)
        Me.tbox_roz.MaxLength = 2
        Me.tbox_roz.Name = "tbox_roz"
        Me.tbox_roz.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbox_roz.Size = New System.Drawing.Size(20, 15)
        Me.tbox_roz.TabIndex = 1001
        Me.tbox_roz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_roz.TextPading = False
        Me.tbox_roz.TypeOfContains = VB_Component.Tbox.TypeOfValues.Digit
        Me.tbox_roz.ValidateValue = False
        '
        'tbox_Mah
        '
        Me.tbox_Mah.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbox_Mah.CheckLength = False
        Me.tbox_Mah.ColorOnFoucus = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.tbox_Mah.EnterStop = True
        Me.tbox_Mah.ErrorMessage = Nothing
        Me.tbox_Mah.Location = New System.Drawing.Point(47, 2)
        Me.tbox_Mah.MaxLength = 2
        Me.tbox_Mah.Name = "tbox_Mah"
        Me.tbox_Mah.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbox_Mah.Size = New System.Drawing.Size(18, 15)
        Me.tbox_Mah.TabIndex = 1002
        Me.tbox_Mah.TabStop = False
        Me.tbox_Mah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_Mah.TextPading = False
        Me.tbox_Mah.TypeOfContains = VB_Component.Tbox.TypeOfValues.Digit
        Me.tbox_Mah.ValidateValue = False
        '
        'Masked_Date
        '
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.tbox_Sal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbox_roz)
        Me.Controls.Add(Me.tbox_Mah)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "Masked_Date"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Size = New System.Drawing.Size(99, 20)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tbox_Sal As Tbox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents tbox_Mah As Tbox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents tbox_roz As Tbox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class

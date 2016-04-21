<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSelect
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Min_Hour_Spliter = New System.Windows.Forms.Label
        Me.Min_Sec_spliter = New System.Windows.Forms.Label
        Me.txt_Hour = New CS_Component.TextBox
        Me.txt_Min = New CS_Component.TextBox
        Me.txt_Sec = New CS_Component.TextBox
        Me.SuspendLayout()
        '
        'Min_Hour_Spliter
        '
        Me.Min_Hour_Spliter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Min_Hour_Spliter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Min_Hour_Spliter.Location = New System.Drawing.Point(31, 1)
        Me.Min_Hour_Spliter.Name = "Min_Hour_Spliter"
        Me.Min_Hour_Spliter.Size = New System.Drawing.Size(13, 17)
        Me.Min_Hour_Spliter.TabIndex = 3
        Me.Min_Hour_Spliter.Text = ":"
        Me.Min_Hour_Spliter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Min_Sec_spliter
        '
        Me.Min_Sec_spliter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Min_Sec_spliter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Min_Sec_spliter.Location = New System.Drawing.Point(69, 1)
        Me.Min_Sec_spliter.Name = "Min_Sec_spliter"
        Me.Min_Sec_spliter.Size = New System.Drawing.Size(11, 17)
        Me.Min_Sec_spliter.TabIndex = 4
        Me.Min_Sec_spliter.Text = ":"
        Me.Min_Sec_spliter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Hour
        '
        Me.txt_Hour.CheckExistValueInDb = False
        Me.txt_Hour.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Hour.CurrencyUnit = "ریال"
        Me.txt_Hour.DefaultValue = ""
        Me.txt_Hour.FillWithMaxInDb = False
        Me.txt_Hour.IsRequired = False
        Me.txt_Hour.Location = New System.Drawing.Point(0, 0)
        Me.txt_Hour.MaxDecimalLength = 2
        Me.txt_Hour.MaxLength = 4
        Me.txt_Hour.Name = "txt_Hour"
        Me.txt_Hour.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Hour.Size = New System.Drawing.Size(33, 20)
        Me.txt_Hour.SpellControl = Nothing
        Me.txt_Hour.TabIndex = 2
        Me.txt_Hour.Text = "00"
        Me.txt_Hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_Hour.Title = Nothing
        Me.txt_Hour.TypeOfContains = CS_Component.TypeOfValues.StringNumber
        Me.txt_Hour.UseForData = True
        Me.txt_Hour.ValidateCheckExistOnEdit = False
        Me.txt_Hour.Value = "00"
        '
        'txt_Min
        '
        Me.txt_Min.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Min.CheckExistValueInDb = False
        Me.txt_Min.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Min.CurrencyUnit = "ریال"
        Me.txt_Min.DefaultValue = ""
        Me.txt_Min.FillWithMaxInDb = False
        Me.txt_Min.IsRequired = False
        Me.txt_Min.Location = New System.Drawing.Point(40, 0)
        Me.txt_Min.MaxDecimalLength = 2
        Me.txt_Min.MaxLength = 2
        Me.txt_Min.Name = "txt_Min"
        Me.txt_Min.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Min.Size = New System.Drawing.Size(30, 20)
        Me.txt_Min.SpellControl = Nothing
        Me.txt_Min.TabIndex = 2
        Me.txt_Min.Text = "00"
        Me.txt_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_Min.Title = Nothing
        Me.txt_Min.TypeOfContains = CS_Component.TypeOfValues.StringNumber
        Me.txt_Min.UseForData = True
        Me.txt_Min.ValidateCheckExistOnEdit = False
        Me.txt_Min.Value = "00"
        '
        'txt_Sec
        '
        Me.txt_Sec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Sec.CheckExistValueInDb = False
        Me.txt_Sec.ColorOnFocus = System.Drawing.Color.Yellow
        Me.txt_Sec.CurrencyUnit = "ریال"
        Me.txt_Sec.DefaultValue = ""
        Me.txt_Sec.FillWithMaxInDb = False
        Me.txt_Sec.IsRequired = False
        Me.txt_Sec.Location = New System.Drawing.Point(77, 0)
        Me.txt_Sec.MaxDecimalLength = 2
        Me.txt_Sec.MaxLength = 2
        Me.txt_Sec.Name = "txt_Sec"
        Me.txt_Sec.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Sec.Size = New System.Drawing.Size(30, 20)
        Me.txt_Sec.SpellControl = Nothing
        Me.txt_Sec.TabIndex = 3
        Me.txt_Sec.Text = "00"
        Me.txt_Sec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txt_Sec.Title = Nothing
        Me.txt_Sec.TypeOfContains = CS_Component.TypeOfValues.StringNumber
        Me.txt_Sec.UseForData = True
        Me.txt_Sec.ValidateCheckExistOnEdit = False
        Me.txt_Sec.Value = "00"
        '
        'TimeSelect
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txt_Hour)
        Me.Controls.Add(Me.txt_Min)
        Me.Controls.Add(Me.txt_Sec)
        Me.Controls.Add(Me.Min_Hour_Spliter)
        Me.Controls.Add(Me.Min_Sec_spliter)
        Me.Name = "TimeSelect"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(108, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Min_Hour_Spliter As System.Windows.Forms.Label
    Friend WithEvents Min_Sec_spliter As System.Windows.Forms.Label
    Friend WithEvents txt_Sec As CS_Component.TextBox
    Friend WithEvents txt_Min As CS_Component.TextBox
    Friend WithEvents txt_Hour As CS_Component.TextBox

End Class

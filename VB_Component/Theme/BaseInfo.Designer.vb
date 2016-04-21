<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseInfo
    Inherits BaseForm


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseInfo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Btn_Cancel = New CS_Component.Btn
        Me.Btn_Save = New CS_Component.Btn
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(479, 231)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Btn_Cancel)
        Me.GroupBox2.Controls.Add(Me.Btn_Save)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 235)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(479, 50)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Cancel.HeaderText = "انصراف"
        Me.Btn_Cancel.Image = CType(resources.GetObject("Btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.Btn_Cancel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Btn_Cancel.Location = New System.Drawing.Point(10, 17)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(80, 26)
        Me.Btn_Cancel.TabIndex = 44
        '
        'Btn_Save
        '
        Me.Btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Save.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Save.HeaderText = "ذخيره"
        Me.Btn_Save.Image = CType(resources.GetObject("Btn_Save.Image"), System.Drawing.Bitmap)
        Me.Btn_Save.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Btn_Save.Location = New System.Drawing.Point(388, 17)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(80, 26)
        Me.Btn_Save.TabIndex = 43
        '
        'BaseInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 311)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "BaseInfo"
        Me.Text = "BaseInfo"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Btn_Cancel As CS_Component.Btn
    Public WithEvents Btn_Save As CS_Component.Btn
End Class

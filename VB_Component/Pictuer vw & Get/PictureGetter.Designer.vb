<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PictureGetter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PictureGetter))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lnk_SelectPic = New System.Windows.Forms.LinkLabel
        Me.lnk_clear = New System.Windows.Forms.LinkLabel
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(121, 129)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lnk_SelectPic
        '
        Me.lnk_SelectPic.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lnk_SelectPic.AutoSize = True
        Me.lnk_SelectPic.Location = New System.Drawing.Point(68, 129)
        Me.lnk_SelectPic.Name = "lnk_SelectPic"
        Me.lnk_SelectPic.Size = New System.Drawing.Size(36, 13)
        Me.lnk_SelectPic.TabIndex = 1
        Me.lnk_SelectPic.TabStop = True
        Me.lnk_SelectPic.Text = "انتخاب"
        '
        'lnk_clear
        '
        Me.lnk_clear.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lnk_clear.AutoSize = True
        Me.lnk_clear.Location = New System.Drawing.Point(7, 129)
        Me.lnk_clear.Name = "lnk_clear"
        Me.lnk_clear.Size = New System.Drawing.Size(46, 13)
        Me.lnk_clear.TabIndex = 2
        Me.lnk_clear.TabStop = True
        Me.lnk_clear.Text = "پاك كردن"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.png|*.png|all File|*.*"
        '
        'PictureGetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lnk_clear)
        Me.Controls.Add(Me.lnk_SelectPic)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "PictureGetter"
        Me.Size = New System.Drawing.Size(133, 144)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lnk_SelectPic As System.Windows.Forms.LinkLabel
    Friend WithEvents lnk_clear As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class

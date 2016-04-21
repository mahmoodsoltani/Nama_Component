<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PictureViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PictureViewer))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_ZoomIn = New System.Windows.Forms.ToolStripButton
        Me.btn_ZoomOut = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_RotatRight = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Stresh = New System.Windows.Forms.ToolStripButton
        Me.btn_NormalSize = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_GrayScale = New System.Windows.Forms.ToolStripButton
        Me.ImageControl1 = New VB_Component.PictuerViewer.ImageControl
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ZoomIn, Me.btn_ZoomOut, Me.ToolStripSeparator1, Me.btn_RotatRight, Me.ToolStripSeparator2, Me.btn_Stresh, Me.btn_NormalSize, Me.ToolStripSeparator3, Me.btn_GrayScale})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(663, 38)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_ZoomIn
        '
        Me.btn_ZoomIn.AutoSize = False
        Me.btn_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ZoomIn.Image = CType(resources.GetObject("btn_ZoomIn.Image"), System.Drawing.Image)
        Me.btn_ZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ZoomIn.Name = "btn_ZoomIn"
        Me.btn_ZoomIn.Size = New System.Drawing.Size(35, 35)
        Me.btn_ZoomIn.Text = "بزرگ نمايي"
        Me.btn_ZoomIn.ToolTipText = "بزرگ نمايي"
        '
        'btn_ZoomOut
        '
        Me.btn_ZoomOut.AutoSize = False
        Me.btn_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ZoomOut.Image = CType(resources.GetObject("btn_ZoomOut.Image"), System.Drawing.Image)
        Me.btn_ZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ZoomOut.Name = "btn_ZoomOut"
        Me.btn_ZoomOut.Size = New System.Drawing.Size(35, 35)
        Me.btn_ZoomOut.Text = "كوچك نمايي"
        Me.btn_ZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_ZoomOut.ToolTipText = "كوچك نمايي"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'btn_RotatRight
        '
        Me.btn_RotatRight.AutoSize = False
        Me.btn_RotatRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_RotatRight.Image = CType(resources.GetObject("btn_RotatRight.Image"), System.Drawing.Image)
        Me.btn_RotatRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_RotatRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_RotatRight.Name = "btn_RotatRight"
        Me.btn_RotatRight.Size = New System.Drawing.Size(35, 35)
        Me.btn_RotatRight.Text = "چرخاندن عكس"
        Me.btn_RotatRight.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_RotatRight.ToolTipText = "چرخاندن عكس"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'btn_Stresh
        '
        Me.btn_Stresh.AutoSize = False
        Me.btn_Stresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Stresh.Image = CType(resources.GetObject("btn_Stresh.Image"), System.Drawing.Image)
        Me.btn_Stresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_Stresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Stresh.Name = "btn_Stresh"
        Me.btn_Stresh.Size = New System.Drawing.Size(35, 35)
        Me.btn_Stresh.Text = "بزرگنمايي عكس به انداره صفحه"
        Me.btn_Stresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Stresh.ToolTipText = "بزرگنمايي عكس به انداره صفحه"
        '
        'btn_NormalSize
        '
        Me.btn_NormalSize.AutoSize = False
        Me.btn_NormalSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_NormalSize.Image = CType(resources.GetObject("btn_NormalSize.Image"), System.Drawing.Image)
        Me.btn_NormalSize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_NormalSize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_NormalSize.Name = "btn_NormalSize"
        Me.btn_NormalSize.Size = New System.Drawing.Size(35, 35)
        Me.btn_NormalSize.Text = "بزرگنمايي عكس به انداره استاندارد"
        Me.btn_NormalSize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_NormalSize.ToolTipText = "بزرگنمايي عكس به انداره استاندارد"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'btn_GrayScale
        '
        Me.btn_GrayScale.AutoSize = False
        Me.btn_GrayScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_GrayScale.Image = CType(resources.GetObject("btn_GrayScale.Image"), System.Drawing.Image)
        Me.btn_GrayScale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_GrayScale.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_GrayScale.Name = "btn_GrayScale"
        Me.btn_GrayScale.Size = New System.Drawing.Size(35, 35)
        Me.btn_GrayScale.Text = "سياه و سفيد كردن عكس"
        Me.btn_GrayScale.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_GrayScale.ToolTipText = "سياه و سفيد كردن عكس"
        '
        'ImageControl1
        '
        Me.ImageControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageControl1.Image = Nothing
        Me.ImageControl1.initialimage = Nothing
        Me.ImageControl1.Location = New System.Drawing.Point(1, 41)
        Me.ImageControl1.Name = "ImageControl1"
        Me.ImageControl1.Origin = New System.Drawing.Point(0, 0)
        Me.ImageControl1.PanButton = System.Windows.Forms.MouseButtons.Left
        Me.ImageControl1.PanMode = True
        Me.ImageControl1.ScrollbarsVisible = True
        Me.ImageControl1.Size = New System.Drawing.Size(660, 461)
        Me.ImageControl1.StretchImageToFit = False
        Me.ImageControl1.TabIndex = 4
        Me.ImageControl1.ZoomFactor = 1
        Me.ImageControl1.ZoomOnMouseWheel = True
        '
        'PictureViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.ImageControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "PictureViewer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(663, 505)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_ZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_RotatRight As System.Windows.Forms.ToolStripButton
    Public WithEvents ImageControl1 As PictuerViewer.ImageControl
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_Stresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_NormalSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_GrayScale As System.Windows.Forms.ToolStripButton

End Class

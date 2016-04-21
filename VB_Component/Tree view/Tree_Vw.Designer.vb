<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tree_Vw
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tree_Vw))
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_Expand = New System.Windows.Forms.ToolStripButton
        Me.btn_Colaps = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tbox_search = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HideSelection = False
        Me.TreeView1.HotTracking = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 38)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(438, 391)
        Me.TreeView1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Expand, Me.btn_Colaps, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.tbox_search, Me.ToolStripButton1, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(438, 38)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Expand
        '
        Me.btn_Expand.AutoSize = False
        Me.btn_Expand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Expand.Image = CType(resources.GetObject("btn_Expand.Image"), System.Drawing.Image)
        Me.btn_Expand.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_Expand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Expand.Name = "btn_Expand"
        Me.btn_Expand.Size = New System.Drawing.Size(35, 35)
        Me.btn_Expand.Text = "باز نمودن كل شاخه ها"
        Me.btn_Expand.ToolTipText = "باز نمودن كل شاخه ها"
        '
        'btn_Colaps
        '
        Me.btn_Colaps.AutoSize = False
        Me.btn_Colaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Colaps.Image = CType(resources.GetObject("btn_Colaps.Image"), System.Drawing.Image)
        Me.btn_Colaps.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_Colaps.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Colaps.Name = "btn_Colaps"
        Me.btn_Colaps.Size = New System.Drawing.Size(35, 35)
        Me.btn_Colaps.Text = "بستن كل شاخه ها"
        Me.btn_Colaps.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Colaps.ToolTipText = "بستن كل شاخه ها"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(49, 35)
        Me.ToolStripLabel1.Text = "جستجو :"
        '
        'tbox_search
        '
        Me.tbox_search.Name = "tbox_search"
        Me.tbox_search.Size = New System.Drawing.Size(100, 38)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 35)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "available_white1[1].GIF")
        '
        'Tree_Vw
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "Tree_Vw"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(438, 429)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents TreeView1 As System.Windows.Forms.TreeView
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btn_Expand As System.Windows.Forms.ToolStripButton
    Public WithEvents btn_Colaps As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Public WithEvents tbox_search As System.Windows.Forms.ToolStripTextBox
    Public WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator

End Class

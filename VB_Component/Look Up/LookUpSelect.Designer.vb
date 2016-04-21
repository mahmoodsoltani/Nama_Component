<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LookUpSelect
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LookUpSelect))
        Me.lstvwINFO = New System.Windows.Forms.ListView
        Me.Item = New System.Windows.Forms.ColumnHeader
        Me.code = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Ok = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstvwINFO
        '
        Me.lstvwINFO.AllowColumnReorder = True
        Me.lstvwINFO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvwINFO.CausesValidation = False
        Me.lstvwINFO.CheckBoxes = True
        Me.lstvwINFO.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Item, Me.code})
        Me.lstvwINFO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstvwINFO.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstvwINFO.HideSelection = False
        Me.lstvwINFO.LabelWrap = False
        Me.lstvwINFO.Location = New System.Drawing.Point(0, 0)
        Me.lstvwINFO.MultiSelect = False
        Me.lstvwINFO.Name = "lstvwINFO"
        Me.lstvwINFO.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lstvwINFO.RightToLeftLayout = True
        Me.lstvwINFO.Size = New System.Drawing.Size(321, 312)
        Me.lstvwINFO.TabIndex = 0
        Me.lstvwINFO.UseCompatibleStateImageBehavior = False
        Me.lstvwINFO.View = System.Windows.Forms.View.Details
        '
        'Item
        '
        Me.Item.Text = "آيتم"
        Me.Item.Width = 350
        '
        'code
        '
        Me.code.Width = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Ok)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 274)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(321, 38)
        Me.Panel1.TabIndex = 1
        '
        'btn_Ok
        '
        Me.btn_Ok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Ok.Image = CType(resources.GetObject("btn_Ok.Image"), System.Drawing.Image)
        Me.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_Ok.Location = New System.Drawing.Point(123, 7)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(75, 25)
        Me.btn_Ok.TabIndex = 0
        Me.btn_Ok.Text = "تاييد"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'LookUpSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 312)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstvwINFO)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LookUpSelect"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lstvwINFO As System.Windows.Forms.ListView
    Private WithEvents Item As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents code As System.Windows.Forms.ColumnHeader
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_FormControls
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_FormControls))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New CS_Component.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chk_Invisible = New System.Windows.Forms.CheckBox
        Me.chk_Disabled = New System.Windows.Forms.CheckBox
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.btn_Cancel = New CS_Component.Btn
        Me.btn_Continue = New CS_Component.Btn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(397, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 386)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "فرم مورد نظر را انتخاب کنید"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(6, 22)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(243, 358)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "FullName"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "عنوان فرم"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.TreeView1)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(372, 384)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Yellow
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chk_Invisible)
        Me.Panel1.Controls.Add(Me.chk_Disabled)
        Me.Panel1.Location = New System.Drawing.Point(63, 283)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(161, 27)
        Me.Panel1.TabIndex = 6
        Me.Panel1.Visible = False
        '
        'chk_Invisible
        '
        Me.chk_Invisible.AutoSize = True
        Me.chk_Invisible.Location = New System.Drawing.Point(6, 3)
        Me.chk_Invisible.Name = "chk_Invisible"
        Me.chk_Invisible.Size = New System.Drawing.Size(63, 20)
        Me.chk_Invisible.TabIndex = 1
        Me.chk_Invisible.Text = "مخفی"
        Me.chk_Invisible.UseVisualStyleBackColor = True
        '
        'chk_Disabled
        '
        Me.chk_Disabled.AutoSize = True
        Me.chk_Disabled.Location = New System.Drawing.Point(84, 3)
        Me.chk_Disabled.Name = "chk_Disabled"
        Me.chk_Disabled.Size = New System.Drawing.Size(72, 20)
        Me.chk_Disabled.TabIndex = 0
        Me.chk_Disabled.Text = "غیر فعال"
        Me.chk_Disabled.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(6, 22)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.Size = New System.Drawing.Size(360, 356)
        Me.TreeView1.TabIndex = 0
        '
        'btn_Cancel
        '
        Me.btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.HeaderText = "انصراف"
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.btn_Cancel.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.btn_Cancel.ImageVerticalAlign = CS_Component.Btn.VerticalAlign.Middle
        Me.btn_Cancel.Location = New System.Drawing.Point(19, 429)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(72, 31)
        Me.btn_Cancel.TabIndex = 9
        '
        'btn_Continue
        '
        Me.btn_Continue.BackColor = System.Drawing.Color.Transparent
        Me.btn_Continue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Continue.HeaderText = "ادامه"
        Me.btn_Continue.Image = CType(resources.GetObject("btn_Continue.Image"), System.Drawing.Bitmap)
        Me.btn_Continue.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.btn_Continue.Location = New System.Drawing.Point(580, 430)
        Me.btn_Continue.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btn_Continue.Name = "btn_Continue"
        Me.btn_Continue.Size = New System.Drawing.Size(72, 31)
        Me.btn_Continue.TabIndex = 8
        '
        'frm_FormControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 495)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Continue)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_FormControls"
        Me.Text = "تخصیص بازدارنده"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btn_Continue, 0)
        Me.Controls.SetChildIndex(Me.btn_Cancel, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As CS_Component.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chk_Invisible As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Disabled As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Cancel As CS_Component.Btn
    Friend WithEvents btn_Continue As CS_Component.Btn
End Class

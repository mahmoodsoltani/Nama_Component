<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Base_Vw_Table1
    Inherits BaseVw

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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New CS_Component.DataGridView
        Me.lbl_Value = New System.Windows.Forms.Label
        Me.tbox_VAlue = New VB_Component.Tbox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Size = New System.Drawing.Size(503, 289)
        Me.GroupBox2.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 294)
        Me.GroupBox1.Size = New System.Drawing.Size(503, 47)
        Me.GroupBox1.TabIndex = 1
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Location = New System.Drawing.Point(211, 15)
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Location = New System.Drawing.Point(309, 15)
        '
        'Btn_new
        '
        Me.Btn_new.Location = New System.Drawing.Point(406, 15)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbox_VAlue)
        Me.GroupBox3.Controls.Add(Me.lbl_Value)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 340)
        Me.GroupBox3.Size = New System.Drawing.Size(503, 44)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(8, 30)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(488, 249)
        Me.DataGridView1.TabIndex = 0
        '
        'lbl_Value
        '
        Me.lbl_Value.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Value.Location = New System.Drawing.Point(424, 19)
        Me.lbl_Value.Name = "lbl_Value"
        Me.lbl_Value.Size = New System.Drawing.Size(72, 14)
        Me.lbl_Value.TabIndex = 0
        Me.lbl_Value.Text = "Label1"
        Me.lbl_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_VAlue
        '
        Me.tbox_VAlue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbox_VAlue.CheckLength = False
        Me.tbox_VAlue.ColorOnFoucus = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.tbox_VAlue.ErrorMessage = Nothing
        Me.tbox_VAlue.Location = New System.Drawing.Point(10, 16)
        Me.tbox_VAlue.Name = "tbox_VAlue"
        Me.tbox_VAlue.Size = New System.Drawing.Size(408, 22)
        Me.tbox_VAlue.TabIndex = 0
        Me.tbox_VAlue.TextPading = False
        Me.tbox_VAlue.TypeOfContains = VB_Component.Tbox.TypeOfValues.All
        Me.tbox_VAlue.ValidateValue = True
        '
        'Base_Vw_Table1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.ClientSize = New System.Drawing.Size(519, 410)
        Me.Name = "Base_Vw_Table1"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As CS_Component.DataGridView
    Friend WithEvents tbox_VAlue As VB_Component.Tbox
    Friend WithEvents lbl_Value As System.Windows.Forms.Label

End Class

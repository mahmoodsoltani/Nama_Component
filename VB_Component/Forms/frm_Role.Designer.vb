<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Role
    Inherits VB_Component.BaseForm_Layer

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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New CS_Component.TextBox
        Me.DataGridView1 = New CS_Component.DataGridView
        Me.SrlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.عنوانبازدارندهDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SecRoleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New DataSet1
        Me.Sec_RoleTableAdapter = New DataSet1TableAdapters.sec_RoleTableAdapter
        Me.gbx_GridViewList.SuspendLayout()
        Me.gbx_Controls.SuspendLayout()
        Me.gbx_Btn.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecRoleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(114, 16)
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(330, 16)
        '
        'btn_Edit
        '
        Me.btn_Edit.Location = New System.Drawing.Point(222, 16)
        '
        'gbx_GridViewList
        '
        Me.gbx_GridViewList.Controls.Add(Me.TextBox1)
        Me.gbx_GridViewList.Controls.Add(Me.Label1)
        Me.gbx_GridViewList.Size = New System.Drawing.Size(438, 54)
        '
        'gbx_Controls
        '
        Me.gbx_Controls.Controls.Add(Me.DataGridView1)
        Me.gbx_Controls.Location = New System.Drawing.Point(12, 147)
        Me.gbx_Controls.Size = New System.Drawing.Size(438, 209)
        '
        'gbx_Btn
        '
        Me.gbx_Btn.Location = New System.Drawing.Point(12, 96)
        Me.gbx_Btn.Size = New System.Drawing.Size(438, 53)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(333, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "عنوان بازدارنده :"
        '
        'TextBox1
        '
        Me.TextBox1.CheckExistValueInDb = False
        Me.TextBox1.ColorOnFocus = System.Drawing.Color.Yellow
        Me.TextBox1.CurrencyUnit = "ریال"
        Me.TextBox1.DefaultValue = ""
        Me.TextBox1.FillWithMaxInDb = False
        Me.TextBox1.IsRequired = False
        Me.TextBox1.Location = New System.Drawing.Point(6, 22)
        Me.TextBox1.MaxDecimalLength = 2
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(321, 23)
        Me.TextBox1.SpellControl = Nothing
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Tag = "RoleName"
        Me.TextBox1.Title = Nothing
        Me.TextBox1.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.TextBox1.UseForData = True
        Me.TextBox1.ValidateCheckExistOnEdit = False
        Me.TextBox1.Value = ""
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
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrlDataGridViewTextBoxColumn, Me.عنوانبازدارندهDataGridViewTextBoxColumn})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.DataSource = Me.SecRoleBindingSource
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
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(426, 181)
        Me.DataGridView1.TabIndex = 0
        '
        'SrlDataGridViewTextBoxColumn
        '
        Me.SrlDataGridViewTextBoxColumn.DataPropertyName = "Srl"
        Me.SrlDataGridViewTextBoxColumn.HeaderText = "Srl"
        Me.SrlDataGridViewTextBoxColumn.Name = "SrlDataGridViewTextBoxColumn"
        Me.SrlDataGridViewTextBoxColumn.ReadOnly = True
        Me.SrlDataGridViewTextBoxColumn.Visible = False
        '
        'عنوانبازدارندهDataGridViewTextBoxColumn
        '
        Me.عنوانبازدارندهDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.عنوانبازدارندهDataGridViewTextBoxColumn.DataPropertyName = "عنوان بازدارنده"
        Me.عنوانبازدارندهDataGridViewTextBoxColumn.HeaderText = "عنوان بازدارنده"
        Me.عنوانبازدارندهDataGridViewTextBoxColumn.Name = "عنوانبازدارندهDataGridViewTextBoxColumn"
        Me.عنوانبازدارندهDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SecRoleBindingSource
        '
        Me.SecRoleBindingSource.DataMember = "sec_Role"
        Me.SecRoleBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sec_RoleTableAdapter
        '
        Me.Sec_RoleTableAdapter.ClearBeforeFill = True
        '
        'frm_Role
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 392)
        Me.DataGridView = Me.DataGridView1
        Me.Name = "frm_Role"
        Me.TableName = "sec_Role"
        Me.Text = "عناوین بازدارنده"
        Me.gbx_GridViewList.ResumeLayout(False)
        Me.gbx_GridViewList.PerformLayout()
        Me.gbx_Controls.ResumeLayout(False)
        Me.gbx_Btn.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecRoleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As CS_Component.TextBox
    Friend WithEvents DataGridView1 As CS_Component.DataGridView
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents SecRoleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_RoleTableAdapter As DataSet1TableAdapters.sec_RoleTableAdapter
    Friend WithEvents SrlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents عنوانبازدارندهDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

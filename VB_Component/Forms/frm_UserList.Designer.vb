<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_UserList
    Inherits VB_Component.BaseForm_View

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New CS_Component.DataGridView
        Me.SrlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.نامDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.نامخانوادگیDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.نامکاربریDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.فعالDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SecUserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New DataSet1
        Me.Sec_UserTableAdapter = New DataSet1TableAdapters.sec_UserTableAdapter
        Me.GroupBox1.SuspendLayout()
        Me.gbx_DataGridView.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbx_DataGridView
        '
        Me.gbx_DataGridView.Controls.Add(Me.DataGridView1)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrlDataGridViewTextBoxColumn, Me.نامDataGridViewTextBoxColumn, Me.نامخانوادگیDataGridViewTextBoxColumn, Me.نامکاربریDataGridViewTextBoxColumn, Me.فعالDataGridViewCheckBoxColumn})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.DataSource = Me.SecUserBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(6, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(542, 230)
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
        'نامDataGridViewTextBoxColumn
        '
        Me.نامDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.نامDataGridViewTextBoxColumn.DataPropertyName = "نام"
        Me.نامDataGridViewTextBoxColumn.HeaderText = "نام"
        Me.نامDataGridViewTextBoxColumn.MinimumWidth = 140
        Me.نامDataGridViewTextBoxColumn.Name = "نامDataGridViewTextBoxColumn"
        Me.نامDataGridViewTextBoxColumn.ReadOnly = True
        '
        'نامخانوادگیDataGridViewTextBoxColumn
        '
        Me.نامخانوادگیDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.نامخانوادگیDataGridViewTextBoxColumn.DataPropertyName = "نام خانوادگی"
        Me.نامخانوادگیDataGridViewTextBoxColumn.HeaderText = "نام خانوادگی"
        Me.نامخانوادگیDataGridViewTextBoxColumn.MinimumWidth = 140
        Me.نامخانوادگیDataGridViewTextBoxColumn.Name = "نامخانوادگیDataGridViewTextBoxColumn"
        Me.نامخانوادگیDataGridViewTextBoxColumn.ReadOnly = True
        '
        'نامکاربریDataGridViewTextBoxColumn
        '
        Me.نامکاربریDataGridViewTextBoxColumn.DataPropertyName = "نام کاربری"
        Me.نامکاربریDataGridViewTextBoxColumn.HeaderText = "نام کاربری"
        Me.نامکاربریDataGridViewTextBoxColumn.MinimumWidth = 120
        Me.نامکاربریDataGridViewTextBoxColumn.Name = "نامکاربریDataGridViewTextBoxColumn"
        Me.نامکاربریDataGridViewTextBoxColumn.ReadOnly = True
        Me.نامکاربریDataGridViewTextBoxColumn.Width = 120
        '
        'فعالDataGridViewCheckBoxColumn
        '
        Me.فعالDataGridViewCheckBoxColumn.DataPropertyName = "فعال"
        Me.فعالDataGridViewCheckBoxColumn.HeaderText = "فعال"
        Me.فعالDataGridViewCheckBoxColumn.MinimumWidth = 50
        Me.فعالDataGridViewCheckBoxColumn.Name = "فعالDataGridViewCheckBoxColumn"
        Me.فعالDataGridViewCheckBoxColumn.ReadOnly = True
        Me.فعالDataGridViewCheckBoxColumn.Width = 50
        '
        'SecUserBindingSource
        '
        Me.SecUserBindingSource.DataMember = "sec_User"
        Me.SecUserBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sec_UserTableAdapter
        '
        Me.Sec_UserTableAdapter.ClearBeforeFill = True
        '
        'frm_UserList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 369)
        Me.DataGridView = Me.DataGridView1
        Me.Name = "frm_UserList"
        Me.TableName = "sec_User"
        Me.Text = "فهرست کاربران سیستم"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbx_DataGridView.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As CS_Component.DataGridView
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents SecUserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_UserTableAdapter As DataSet1TableAdapters.sec_UserTableAdapter
    Friend WithEvents SrlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents نامDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents نامخانوادگیDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents نامکاربریDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents فعالDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class

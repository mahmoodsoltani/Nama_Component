<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RoleGroup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_RoleGroup))
        Me.ComboBox1 = New VB_Component.ComboBox
        Me.SecGroupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New DataSet1
        Me.Label1 = New System.Windows.Forms.Label
        Me.Sec_GroupTableAdapter = New DataSet1TableAdapters.sec_GroupTableAdapter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New CS_Component.DataGridView
        Me.SrlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.عنوانبازدارندهDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SecRoleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView2 = New CS_Component.DataGridView
        Me.btn_AddGroup = New System.Windows.Forms.Button
        Me.btn_Remove = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Sec_RoleTableAdapter = New DataSet1TableAdapters.sec_RoleTableAdapter
        Me.SecRoleGroupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sec_RoleGroupTableAdapter = New DataSet1TableAdapters.sec_RoleGroupTableAdapter
        Me.SrlDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SrlRoleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoleNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.SecGroupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecRoleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecRoleGroupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.SecGroupBindingSource
        Me.ComboBox1.DisplayMember = "عنوان گروه"
        Me.ComboBox1.EnterStop = True
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.IsRequired = False
        Me.ComboBox1.Location = New System.Drawing.Point(18, 44)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.OpenOnFoucus = False
        Me.ComboBox1.Size = New System.Drawing.Size(438, 24)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.ValueMember = "Srl"
        '
        'SecGroupBindingSource
        '
        Me.SecGroupBindingSource.DataMember = "sec_Group"
        Me.SecGroupBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(462, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "عنوان گروه :"
        '
        'Sec_GroupTableAdapter
        '
        Me.Sec_GroupTableAdapter.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(313, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 289)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "فهرست بازدارنده ها"
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
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrlDataGridViewTextBoxColumn, Me.عنوانبازدارندهDataGridViewTextBoxColumn})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.DataSource = Me.SecRoleBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(8, 22)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(206, 261)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 289)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بازدارنده های گروه"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrlDataGridViewTextBoxColumn1, Me.SrlRoleDataGridViewTextBoxColumn, Me.RoleNameDataGridViewTextBoxColumn})
        Me.DataGridView2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView2.DataSource = Me.SecRoleGroupBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.Location = New System.Drawing.Point(6, 22)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 30
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(206, 261)
        Me.DataGridView2.TabIndex = 0
        '
        'btn_AddGroup
        '
        Me.btn_AddGroup.Image = CType(resources.GetObject("btn_AddGroup.Image"), System.Drawing.Image)
        Me.btn_AddGroup.Location = New System.Drawing.Point(249, 136)
        Me.btn_AddGroup.Name = "btn_AddGroup"
        Me.btn_AddGroup.Size = New System.Drawing.Size(56, 52)
        Me.btn_AddGroup.TabIndex = 8
        Me.btn_AddGroup.UseVisualStyleBackColor = True
        '
        'btn_Remove
        '
        Me.btn_Remove.Image = CType(resources.GetObject("btn_Remove.Image"), System.Drawing.Image)
        Me.btn_Remove.Location = New System.Drawing.Point(249, 245)
        Me.btn_Remove.Name = "btn_Remove"
        Me.btn_Remove.Size = New System.Drawing.Size(56, 52)
        Me.btn_Remove.TabIndex = 9
        Me.btn_Remove.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(236, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "افزودن به گروه"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(241, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "حذف از گروه"
        '
        'Sec_RoleTableAdapter
        '
        Me.Sec_RoleTableAdapter.ClearBeforeFill = True
        '
        'SecRoleGroupBindingSource
        '
        Me.SecRoleGroupBindingSource.DataMember = "sec_RoleGroup"
        Me.SecRoleGroupBindingSource.DataSource = Me.DataSet1
        '
        'Sec_RoleGroupTableAdapter
        '
        Me.Sec_RoleGroupTableAdapter.ClearBeforeFill = True
        '
        'SrlDataGridViewTextBoxColumn1
        '
        Me.SrlDataGridViewTextBoxColumn1.DataPropertyName = "Srl"
        Me.SrlDataGridViewTextBoxColumn1.HeaderText = "Srl"
        Me.SrlDataGridViewTextBoxColumn1.Name = "SrlDataGridViewTextBoxColumn1"
        Me.SrlDataGridViewTextBoxColumn1.ReadOnly = True
        Me.SrlDataGridViewTextBoxColumn1.Visible = False
        '
        'SrlRoleDataGridViewTextBoxColumn
        '
        Me.SrlRoleDataGridViewTextBoxColumn.DataPropertyName = "Srl_Role"
        Me.SrlRoleDataGridViewTextBoxColumn.HeaderText = "Srl_Role"
        Me.SrlRoleDataGridViewTextBoxColumn.Name = "SrlRoleDataGridViewTextBoxColumn"
        Me.SrlRoleDataGridViewTextBoxColumn.ReadOnly = True
        Me.SrlRoleDataGridViewTextBoxColumn.Visible = False
        '
        'RoleNameDataGridViewTextBoxColumn
        '
        Me.RoleNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RoleNameDataGridViewTextBoxColumn.DataPropertyName = "RoleName"
        Me.RoleNameDataGridViewTextBoxColumn.HeaderText = "عنوان بازدارنده"
        Me.RoleNameDataGridViewTextBoxColumn.Name = "RoleNameDataGridViewTextBoxColumn"
        Me.RoleNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frm_RoleGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 406)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Remove)
        Me.Controls.Add(Me.btn_AddGroup)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frm_RoleGroup"
        Me.Text = "بازدارنده های گروه"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btn_AddGroup, 0)
        Me.Controls.SetChildIndex(Me.btn_Remove, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.SecGroupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecRoleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecRoleGroupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As VB_Component.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents SecGroupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_GroupTableAdapter As DataSet1TableAdapters.sec_GroupTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_AddGroup As System.Windows.Forms.Button
    Friend WithEvents btn_Remove As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As CS_Component.DataGridView
    Friend WithEvents SecRoleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_RoleTableAdapter As DataSet1TableAdapters.sec_RoleTableAdapter
    Friend WithEvents SrlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents عنوانبازدارندهDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As CS_Component.DataGridView
    Friend WithEvents SrlDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SrlRoleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoleNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SecRoleGroupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_RoleGroupTableAdapter As DataSet1TableAdapters.sec_RoleGroupTableAdapter
End Class

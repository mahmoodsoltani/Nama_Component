<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Group
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New CS_Component.TextBox
        Me.DataGridView1 = New CS_Component.DataGridView
        Me.SrlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.عنوانگروهDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SecGroupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New DataSet1
        Me.Sec_GroupTableAdapter = New DataSet1TableAdapters.sec_GroupTableAdapter
        Me.lnk_Users = New System.Windows.Forms.LinkLabel
        Me.gbx_GridViewList.SuspendLayout()
        Me.gbx_Controls.SuspendLayout()
        Me.gbx_Btn.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecGroupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(185, 16)
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(401, 16)
        '
        'btn_Edit
        '
        Me.btn_Edit.Location = New System.Drawing.Point(293, 16)
        '
        'gbx_GridViewList
        '
        Me.gbx_GridViewList.Controls.Add(Me.lnk_Users)
        Me.gbx_GridViewList.Controls.Add(Me.TextBox1)
        Me.gbx_GridViewList.Controls.Add(Me.CheckBox2)
        Me.gbx_GridViewList.Controls.Add(Me.CheckBox1)
        Me.gbx_GridViewList.Controls.Add(Me.Label1)
        Me.gbx_GridViewList.Size = New System.Drawing.Size(509, 100)
        Me.gbx_GridViewList.TabIndex = 0
        '
        'gbx_Controls
        '
        Me.gbx_Controls.Controls.Add(Me.DataGridView1)
        Me.gbx_Controls.Location = New System.Drawing.Point(12, 201)
        Me.gbx_Controls.Size = New System.Drawing.Size(509, 212)
        '
        'gbx_Btn
        '
        Me.gbx_Btn.Location = New System.Drawing.Point(12, 142)
        Me.gbx_Btn.Size = New System.Drawing.Size(509, 53)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(429, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "عنوان گروه :"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(207, 72)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(296, 20)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Tag = "JoinBlocked"
        Me.CheckBox1.Text = "از ورود کاربران این گروه به سیستم جلوگیری شود."
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(238, 46)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(265, 20)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Tag = "UsersBlocked"
        Me.CheckBox2.Text = "از عضویت کاربران در این گروه جلوگیری شود."
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.CheckExistValueInDb = False
        Me.TextBox1.CurrencyUnit = "ریال"
        Me.TextBox1.IsRequired = False
        Me.TextBox1.Location = New System.Drawing.Point(6, 16)
        Me.TextBox1.MaxDecimalLength = 2
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(417, 23)
        Me.TextBox1.SpellControl = Nothing
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Tag = "GroupName"
        Me.TextBox1.Title = Nothing
        Me.TextBox1.TypeOfContains = CS_Component.TypeOfValues.PersianText
        Me.TextBox1.UseForData = True
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SrlDataGridViewTextBoxColumn, Me.عنوانگروهDataGridViewTextBoxColumn, Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn, Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.DataSource = Me.SecGroupBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(6, 16)
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
        Me.DataGridView1.Size = New System.Drawing.Size(497, 190)
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
        'عنوانگروهDataGridViewTextBoxColumn
        '
        Me.عنوانگروهDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.عنوانگروهDataGridViewTextBoxColumn.DataPropertyName = "عنوان گروه"
        Me.عنوانگروهDataGridViewTextBoxColumn.HeaderText = "عنوان گروه"
        Me.عنوانگروهDataGridViewTextBoxColumn.Name = "عنوانگروهDataGridViewTextBoxColumn"
        Me.عنوانگروهDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ممنوعیتورودکاربرانDataGridViewCheckBoxColumn
        '
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn.DataPropertyName = "ممنوعیت ورود کاربران"
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn.HeaderText = "ممنوعیت ورود کاربران"
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn.Name = "ممنوعیتورودکاربرانDataGridViewCheckBoxColumn"
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ممنوعیتورودکاربرانDataGridViewCheckBoxColumn.Width = 130
        '
        'ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn
        '
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn.DataPropertyName = "ممنوعیت عضویت کاربران"
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn.HeaderText = "ممنوعیت عضویت کاربران"
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn.Name = "ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn"
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn.Width = 149
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
        'Sec_GroupTableAdapter
        '
        Me.Sec_GroupTableAdapter.ClearBeforeFill = True
        '
        'lnk_Users
        '
        Me.lnk_Users.AutoSize = True
        Me.lnk_Users.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnk_Users.Location = New System.Drawing.Point(6, 72)
        Me.lnk_Users.Name = "lnk_Users"
        Me.lnk_Users.Size = New System.Drawing.Size(111, 16)
        Me.lnk_Users.TabIndex = 3
        Me.lnk_Users.TabStop = True
        Me.lnk_Users.Text = "نمایش کاربران گروه"
        '
        'frm_Group
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 449)
        Me.DataGridView = Me.DataGridView1
        Me.Name = "frm_Group"
        Me.TableName = "sec_Group"
        Me.Text = "تعریف گروه های کاربری"
        Me.gbx_GridViewList.ResumeLayout(False)
        Me.gbx_GridViewList.PerformLayout()
        Me.gbx_Controls.ResumeLayout(False)
        Me.gbx_Btn.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecGroupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As CS_Component.TextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As CS_Component.DataGridView
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents SecGroupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_GroupTableAdapter As DataSet1TableAdapters.sec_GroupTableAdapter
    Friend WithEvents SrlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents عنوانگروهDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ممنوعیتورودکاربرانDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ممنوعیتعضویتکاربرانDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lnk_Users As System.Windows.Forms.LinkLabel
End Class

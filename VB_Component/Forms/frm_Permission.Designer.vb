<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Permission
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Permission))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New VB_Component.ComboBox
        Me.DataSet1 = New DataSet1
        Me.SecRoleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sec_RoleTableAdapter = New DataSet1TableAdapters.sec_RoleTableAdapter
        Me.btn_Continue = New CS_Component.Btn
        Me.btn_Cancel = New CS_Component.Btn
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecRoleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(412, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "بازدارنده مورد نظر جهت تخصیص بازدارنده به فرم های برنامه را انتخاب کنید."
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.DataSource = Me.SecRoleBindingSource
        Me.ComboBox1.DisplayMember = "عنوان بازدارنده"
        Me.ComboBox1.EnterStop = True
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.IsRequired = False
        Me.ComboBox1.Location = New System.Drawing.Point(14, 88)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.OpenOnFoucus = False
        Me.ComboBox1.Size = New System.Drawing.Size(409, 24)
        Me.ComboBox1.TabIndex = 5
        Me.ComboBox1.ValueMember = "Srl"
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SecRoleBindingSource
        '
        Me.SecRoleBindingSource.DataMember = "sec_Role"
        Me.SecRoleBindingSource.DataSource = Me.DataSet1
        '
        'Sec_RoleTableAdapter
        '
        Me.Sec_RoleTableAdapter.ClearBeforeFill = True
        '
        'btn_Continue
        '
        Me.btn_Continue.BackColor = System.Drawing.Color.Transparent
        Me.btn_Continue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Continue.HeaderText = "ادامه"
        Me.btn_Continue.Image = CType(resources.GetObject("btn_Continue.Image"), System.Drawing.Bitmap)
        Me.btn_Continue.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.btn_Continue.Location = New System.Drawing.Point(349, 120)
        Me.btn_Continue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Continue.Name = "btn_Continue"
        Me.btn_Continue.Size = New System.Drawing.Size(74, 32)
        Me.btn_Continue.TabIndex = 6
        '
        'btn_Cancel
        '
        Me.btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.HeaderText = "انصراف"
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.btn_Cancel.ImageScalingSize = New System.Drawing.Size(16, 16)
        Me.btn_Cancel.ImageVerticalAlign = CS_Component.Btn.VerticalAlign.Middle
        Me.btn_Cancel.Location = New System.Drawing.Point(14, 120)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(74, 32)
        Me.btn_Cancel.TabIndex = 7
        '
        'frm_Permission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 202)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btn_Continue)
        Me.Name = "frm_Permission"
        Me.Text = "اختصاص بازدارنده"
        Me.Controls.SetChildIndex(Me.btn_Continue, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btn_Cancel, 0)
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecRoleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As VB_Component.ComboBox
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents SecRoleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Sec_RoleTableAdapter As DataSet1TableAdapters.sec_RoleTableAdapter
    Friend WithEvents btn_Continue As CS_Component.Btn
    Friend WithEvents btn_Cancel As CS_Component.Btn
End Class

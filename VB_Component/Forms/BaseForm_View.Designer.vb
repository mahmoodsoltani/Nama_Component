<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseForm_View
    Inherits BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm_View))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_Cancel = New CS_Component.Btn
        Me.btn_Delete = New CS_Component.Btn
        Me.btn_Edit = New CS_Component.Btn
        Me.btn_New = New CS_Component.Btn
        Me.gbx_DataGridView = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_Cancel)
        Me.GroupBox1.Controls.Add(Me.btn_Delete)
        Me.GroupBox1.Controls.Add(Me.btn_Edit)
        Me.GroupBox1.Controls.Add(Me.btn_New)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 286)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 47)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.HeaderText = "انصراف"
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.btn_Cancel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.btn_Cancel.Location = New System.Drawing.Point(14, 14)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(87, 26)
        Me.btn_Cancel.TabIndex = 3
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Delete.BackColor = System.Drawing.Color.Transparent
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.HeaderText = "حذف"
        Me.btn_Delete.Image = CType(resources.GetObject("btn_Delete.Image"), System.Drawing.Bitmap)
        Me.btn_Delete.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.btn_Delete.Location = New System.Drawing.Point(269, 15)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(88, 26)
        Me.btn_Delete.TabIndex = 2
        '
        'btn_Edit
        '
        Me.btn_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Edit.BackColor = System.Drawing.Color.Transparent
        Me.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit.HeaderText = "ویرایش"
        Me.btn_Edit.Image = CType(resources.GetObject("btn_Edit.Image"), System.Drawing.Bitmap)
        Me.btn_Edit.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.btn_Edit.Location = New System.Drawing.Point(363, 15)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(88, 26)
        Me.btn_Edit.TabIndex = 1
        Me.btn_Edit.Tag = "0"
        '
        'btn_New
        '
        Me.btn_New.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_New.BackColor = System.Drawing.Color.Transparent
        Me.btn_New.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_New.HeaderText = "جدید"
        Me.btn_New.Image = CType(resources.GetObject("btn_New.Image"), System.Drawing.Bitmap)
        Me.btn_New.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.btn_New.Location = New System.Drawing.Point(457, 15)
        Me.btn_New.Name = "btn_New"
        Me.btn_New.Size = New System.Drawing.Size(88, 26)
        Me.btn_New.TabIndex = 0
        '
        'gbx_DataGridView
        '
        Me.gbx_DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_DataGridView.Location = New System.Drawing.Point(12, 36)
        Me.gbx_DataGridView.Name = "gbx_DataGridView"
        Me.gbx_DataGridView.Size = New System.Drawing.Size(554, 248)
        Me.gbx_DataGridView.TabIndex = 0
        Me.gbx_DataGridView.TabStop = False
        '
        'BaseForm_View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 369)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbx_DataGridView)
        Me.Name = "BaseForm_View"
        Me.Text = "BaseForm_View"
        Me.Controls.SetChildIndex(Me.gbx_DataGridView, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btn_Cancel As CS_Component.Btn
    Public WithEvents btn_Delete As CS_Component.Btn
    Public WithEvents btn_Edit As CS_Component.Btn
    Public WithEvents btn_New As CS_Component.Btn
    Public WithEvents gbx_DataGridView As System.Windows.Forms.GroupBox
End Class

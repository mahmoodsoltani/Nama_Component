<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseForm_Layer
    Inherits BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm_Layer))
        Me.gbx_GridViewList = New System.Windows.Forms.GroupBox
        Me.gbx_Controls = New System.Windows.Forms.GroupBox
        Me.gbx_Btn = New System.Windows.Forms.GroupBox
        Me.btn_Cancel = New CS_Component.Btn
        Me.btn_Delete = New CS_Component.Btn
        Me.btn_new = New CS_Component.Btn
        Me.btn_Edit = New CS_Component.Btn
        Me.gbx_Btn.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx_GridViewList
        '
        Me.gbx_GridViewList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_GridViewList.Location = New System.Drawing.Point(12, 36)
        Me.gbx_GridViewList.Name = "gbx_GridViewList"
        Me.gbx_GridViewList.Size = New System.Drawing.Size(625, 144)
        Me.gbx_GridViewList.TabIndex = 2
        Me.gbx_GridViewList.TabStop = False
        '
        'gbx_Controls
        '
        Me.gbx_Controls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Controls.Location = New System.Drawing.Point(12, 233)
        Me.gbx_Controls.Name = "gbx_Controls"
        Me.gbx_Controls.Size = New System.Drawing.Size(625, 144)
        Me.gbx_Controls.TabIndex = 0
        Me.gbx_Controls.TabStop = False
        Me.gbx_Controls.Tag = ""
        '
        'gbx_Btn
        '
        Me.gbx_Btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Btn.Controls.Add(Me.btn_Cancel)
        Me.gbx_Btn.Controls.Add(Me.btn_Delete)
        Me.gbx_Btn.Controls.Add(Me.btn_new)
        Me.gbx_Btn.Controls.Add(Me.btn_Edit)
        Me.gbx_Btn.Location = New System.Drawing.Point(12, 180)
        Me.gbx_Btn.Name = "gbx_Btn"
        Me.gbx_Btn.Size = New System.Drawing.Size(625, 53)
        Me.gbx_Btn.TabIndex = 1
        Me.gbx_Btn.TabStop = False
        '
        'btn_Cancel
        '
        Me.btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.HeaderText = "Esc انصراف"
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.btn_Cancel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.btn_Cancel.Location = New System.Drawing.Point(6, 15)
        Me.btn_Cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(102, 28)
        Me.btn_Cancel.TabIndex = 3
        '
        'btn_Delete
        '
        Me.btn_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Delete.BackColor = System.Drawing.Color.Transparent
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.HeaderText = "   حذف   "
        Me.btn_Delete.Image = CType(resources.GetObject("btn_Delete.Image"), System.Drawing.Bitmap)
        Me.btn_Delete.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.btn_Delete.Location = New System.Drawing.Point(301, 16)
        Me.btn_Delete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(102, 28)
        Me.btn_Delete.TabIndex = 2
        '
        'btn_new
        '
        Me.btn_new.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_new.BackColor = System.Drawing.Color.Transparent
        Me.btn_new.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_new.HeaderText = "F2 ذخيره"
        Me.btn_new.Image = CType(resources.GetObject("btn_new.Image"), System.Drawing.Bitmap)
        Me.btn_new.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.btn_new.Location = New System.Drawing.Point(517, 16)
        Me.btn_new.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(102, 28)
        Me.btn_new.TabIndex = 0
        '
        'btn_Edit
        '
        Me.btn_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Edit.BackColor = System.Drawing.Color.Transparent
        Me.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit.HeaderText = "F3 ویرایش"
        Me.btn_Edit.Image = CType(resources.GetObject("btn_Edit.Image"), System.Drawing.Bitmap)
        Me.btn_Edit.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.btn_Edit.Location = New System.Drawing.Point(409, 16)
        Me.btn_Edit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(102, 28)
        Me.btn_Edit.TabIndex = 1
        Me.btn_Edit.Tag = "0"
        '
        'BaseForm_Layer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(649, 413)
        Me.Controls.Add(Me.gbx_Controls)
        Me.Controls.Add(Me.gbx_Btn)
        Me.Controls.Add(Me.gbx_GridViewList)
        Me.Name = "BaseForm_Layer"
        Me.Controls.SetChildIndex(Me.gbx_GridViewList, 0)
        Me.Controls.SetChildIndex(Me.gbx_Btn, 0)
        Me.Controls.SetChildIndex(Me.gbx_Controls, 0)
        Me.gbx_Btn.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btn_Cancel As CS_Component.Btn
    Public WithEvents btn_Delete As CS_Component.Btn
    Public WithEvents btn_new As CS_Component.Btn
    Public WithEvents btn_Edit As CS_Component.Btn
    Public WithEvents gbx_GridViewList As System.Windows.Forms.GroupBox
    Public WithEvents gbx_Controls As System.Windows.Forms.GroupBox
    Public WithEvents gbx_Btn As System.Windows.Forms.GroupBox

End Class

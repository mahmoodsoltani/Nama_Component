<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseVw
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseVw))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btn_Cancel = New CS_Component.Btn
        Me.Btn_Delete = New CS_Component.Btn
        Me.Btn_Edit = New CS_Component.Btn
        Me.Btn_new = New CS_Component.Btn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(683, 185)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Btn_Cancel)
        Me.GroupBox1.Controls.Add(Me.Btn_Delete)
        Me.GroupBox1.Controls.Add(Me.Btn_Edit)
        Me.GroupBox1.Controls.Add(Me.Btn_new)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(683, 47)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Cancel.HeaderText = "Esc انصراف"
        Me.Btn_Cancel.Image = CType(resources.GetObject("Btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.Btn_Cancel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Btn_Cancel.Location = New System.Drawing.Point(10, 14)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(94, 26)
        Me.Btn_Cancel.TabIndex = 3
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Delete.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Delete.HeaderText = "حذف"
        Me.Btn_Delete.Image = CType(resources.GetObject("Btn_Delete.Image"), System.Drawing.Bitmap)
        Me.Btn_Delete.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.Btn_Delete.Location = New System.Drawing.Point(390, 15)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(94, 26)
        Me.Btn_Delete.TabIndex = 2
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Edit.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Edit.HeaderText = "F3 ویرایش"
        Me.Btn_Edit.Image = CType(resources.GetObject("Btn_Edit.Image"), System.Drawing.Bitmap)
        Me.Btn_Edit.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.Btn_Edit.Location = New System.Drawing.Point(488, 15)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(94, 26)
        Me.Btn_Edit.TabIndex = 1
        Me.Btn_Edit.Tag = "0"
        '
        'Btn_new
        '
        Me.Btn_new.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_new.BackColor = System.Drawing.Color.Transparent
        Me.Btn_new.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_new.HeaderText = "F2 ذخيره"
        Me.Btn_new.Image = CType(resources.GetObject("Btn_new.Image"), System.Drawing.Bitmap)
        Me.Btn_new.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.Btn_new.Location = New System.Drawing.Point(586, 15)
        Me.Btn_new.Name = "Btn_new"
        Me.Btn_new.Size = New System.Drawing.Size(94, 26)
        Me.Btn_new.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 242)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(683, 195)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'BaseVw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.ClientSize = New System.Drawing.Size(699, 462)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "BaseVw"
        Me.PromtOnClose = True
        Me.Text = "فرم"
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Btn_Cancel As CS_Component.Btn
    Public WithEvents Btn_Delete As CS_Component.Btn
    Public WithEvents Btn_Edit As CS_Component.Btn
    Public WithEvents Btn_new As CS_Component.Btn
    Public WithEvents GroupBox3 As System.Windows.Forms.GroupBox

End Class

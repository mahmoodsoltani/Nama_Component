<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tree_Vw_Select2
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
        Me.components = New System.ComponentModel.Container
        Me.Tree_Vw1 = New VB_Component.Tree_Vw
        Me.Btn_Select = New CS_Component.Btn
        Me.Btn_Cancel = New CS_Component.Btn
        Me.SuspendLayout()
        '
        'Tree_Vw1
        '
        Me.Tree_Vw1.BackColor = System.Drawing.Color.White
        Me.Tree_Vw1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tree_Vw1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tree_Vw1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Tree_Vw1.Location = New System.Drawing.Point(6, 33)
        Me.Tree_Vw1.Name = "Tree_Vw1"
        Me.Tree_Vw1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tree_Vw1.Size = New System.Drawing.Size(488, 367)
        Me.Tree_Vw1.TabIndex = 4
        '
        'Btn_Select
        '
        Me.Btn_Select.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Select.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Select.HeaderText = "انتخاب"
        Me.Btn_Select.Location = New System.Drawing.Point(350, 426)
        Me.Btn_Select.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Select.Name = "Btn_Select"
        Me.Btn_Select.Size = New System.Drawing.Size(93, 26)
        Me.Btn_Select.TabIndex = 5
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Cancel.HeaderText = "انصراف"
        Me.Btn_Cancel.Location = New System.Drawing.Point(62, 426)
        Me.Btn_Cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(93, 26)
        Me.Btn_Cancel.TabIndex = 6
        '
        'Tree_Vw_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 556)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Select)
        Me.Controls.Add(Me.Tree_Vw1)
        Me.Name = "Tree_Vw_Select"
        Me.Text = "Tree_Vw_Select"
        Me.Controls.SetChildIndex(Me.Tree_Vw1, 0)
        Me.Controls.SetChildIndex(Me.Btn_Select, 0)
        Me.Controls.SetChildIndex(Me.Btn_Cancel, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tree_Vw1 As VB_Component.Tree_Vw
    Friend WithEvents Btn_Select As CS_Component.Btn
    Friend WithEvents Btn_Cancel As CS_Component.Btn
End Class

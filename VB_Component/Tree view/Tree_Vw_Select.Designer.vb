<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tree_Vw_Select
    Inherits BaseForm_Info_Single

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
        Me.gbx_Buttons.SuspendLayout()
        Me.gbx_Fields.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx_Buttons
        '
        Me.gbx_Buttons.Location = New System.Drawing.Point(12, 471)
        Me.gbx_Buttons.Size = New System.Drawing.Size(528, 50)
        '
        'btn_Cancel
        '
        '
        'btn_Save
        '
        Me.btn_Save.HeaderText = "انتخاب"
        Me.btn_Save.Location = New System.Drawing.Point(437, 17)
        '
        'gbx_Fields
        '
        Me.gbx_Fields.Controls.Add(Me.Tree_Vw1)
        Me.gbx_Fields.Size = New System.Drawing.Size(528, 437)
        '
        'Tree_Vw1
        '
        Me.Tree_Vw1.BackColor = System.Drawing.Color.White
        Me.Tree_Vw1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tree_Vw1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree_Vw1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Tree_Vw1.Location = New System.Drawing.Point(3, 19)
        Me.Tree_Vw1.Name = "Tree_Vw1"
        Me.Tree_Vw1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tree_Vw1.Size = New System.Drawing.Size(522, 415)
        Me.Tree_Vw1.TabIndex = 0
        '
        'Tree_Vw_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 555)
        Me.GoOnEnter = False
        Me.GoOnUpDown = False
        Me.Name = "Tree_Vw_Select"
        Me.Text = "انتخاب"
        Me.gbx_Buttons.ResumeLayout(False)
        Me.gbx_Fields.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tree_Vw1 As VB_Component.Tree_Vw
End Class

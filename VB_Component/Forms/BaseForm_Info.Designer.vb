<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseForm_Info
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseForm_Info))
        Me.gbx_Buttons = New System.Windows.Forms.GroupBox
        Me.btn_Cancel = New CS_Component.Btn
        Me.btn_Save = New CS_Component.Btn
        Me.gbx_Fields = New System.Windows.Forms.GroupBox
        Me.gbx_Buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx_Buttons
        '
        Me.gbx_Buttons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Buttons.BackColor = System.Drawing.Color.Transparent
        Me.gbx_Buttons.Controls.Add(Me.btn_Cancel)
        Me.gbx_Buttons.Controls.Add(Me.btn_Save)
        Me.gbx_Buttons.Location = New System.Drawing.Point(12, 241)
        Me.gbx_Buttons.Name = "gbx_Buttons"
        Me.gbx_Buttons.Size = New System.Drawing.Size(479, 50)
        Me.gbx_Buttons.TabIndex = 1
        Me.gbx_Buttons.TabStop = False
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.HeaderText = "انصراف"
        Me.btn_Cancel.Image = CType(resources.GetObject("btn_Cancel.Image"), System.Drawing.Bitmap)
        Me.btn_Cancel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.btn_Cancel.Location = New System.Drawing.Point(10, 17)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(80, 26)
        Me.btn_Cancel.TabIndex = 1
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.BackColor = System.Drawing.Color.Transparent
        Me.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Save.HeaderText = "ذخيره"
        Me.btn_Save.Image = CType(resources.GetObject("btn_Save.Image"), System.Drawing.Bitmap)
        Me.btn_Save.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.btn_Save.Location = New System.Drawing.Point(388, 17)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(80, 26)
        Me.btn_Save.TabIndex = 0
        '
        'gbx_Fields
        '
        Me.gbx_Fields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Fields.Location = New System.Drawing.Point(12, 36)
        Me.gbx_Fields.Name = "gbx_Fields"
        Me.gbx_Fields.Size = New System.Drawing.Size(479, 203)
        Me.gbx_Fields.TabIndex = 0
        Me.gbx_Fields.TabStop = False
        '
        'BaseForm_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(503, 327)
        Me.Controls.Add(Me.gbx_Buttons)
        Me.Controls.Add(Me.gbx_Fields)
        Me.Name = "BaseForm_Info"
        Me.Text = "BaseForm_Info"
        Me.Controls.SetChildIndex(Me.gbx_Fields, 0)
        Me.Controls.SetChildIndex(Me.gbx_Buttons, 0)
        Me.gbx_Buttons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents gbx_Buttons As System.Windows.Forms.GroupBox
    Public WithEvents btn_Cancel As CS_Component.Btn
    Public WithEvents btn_Save As CS_Component.Btn
    Public WithEvents gbx_Fields As System.Windows.Forms.GroupBox

End Class

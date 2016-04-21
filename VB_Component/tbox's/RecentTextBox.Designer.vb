<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecentTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Tbox = New System.Windows.Forms.TextBox
        Me.lb = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Tbox
        '
        Me.Tbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.Tbox.Location = New System.Drawing.Point(0, 0)
        Me.Tbox.Name = "Tbox"
        Me.Tbox.Size = New System.Drawing.Size(278, 20)
        Me.Tbox.TabIndex = 0
        '
        'lb
        '
        Me.lb.FormattingEnabled = True
        Me.lb.Location = New System.Drawing.Point(0, 20)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(278, 147)
        Me.lb.TabIndex = 1
        Me.lb.TabStop = False
        '
        'RecentTextBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Tbox)
        Me.Controls.Add(Me.lb)
        Me.Name = "RecentTextBox"
        Me.Size = New System.Drawing.Size(278, 167)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tbox As System.Windows.Forms.TextBox
    Friend WithEvents lb As System.Windows.Forms.ListBox

End Class

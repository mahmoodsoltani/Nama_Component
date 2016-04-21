<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LookUpButton
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
        Me.components = New System.ComponentModel.Container
        Me.tbox_Code = New System.Windows.Forms.TextBox
        Me.btn_LoadLookUp = New System.Windows.Forms.Button
        Me.tbox_Result = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_LoadForm = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'tbox_Code
        '
        Me.tbox_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox_Code.Location = New System.Drawing.Point(184, 0)
        Me.tbox_Code.Name = "tbox_Code"
        Me.tbox_Code.Size = New System.Drawing.Size(42, 22)
        Me.tbox_Code.TabIndex = 0
        Me.tbox_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_LoadLookUp
        '
        Me.btn_LoadLookUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_LoadLookUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_LoadLookUp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btn_LoadLookUp.Location = New System.Drawing.Point(131, 0)
        Me.btn_LoadLookUp.Name = "btn_LoadLookUp"
        Me.btn_LoadLookUp.Size = New System.Drawing.Size(53, 22)
        Me.btn_LoadLookUp.TabIndex = 1
        Me.btn_LoadLookUp.TabStop = False
        Me.btn_LoadLookUp.Text = "انتخاب"
        Me.btn_LoadLookUp.UseVisualStyleBackColor = True
        '
        'tbox_Result
        '
        Me.tbox_Result.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbox_Result.BackColor = System.Drawing.SystemColors.Info
        Me.tbox_Result.Location = New System.Drawing.Point(0, 0)
        Me.tbox_Result.Name = "tbox_Result"
        Me.tbox_Result.Size = New System.Drawing.Size(131, 22)
        Me.tbox_Result.TabIndex = 2
        Me.tbox_Result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'btn_LoadForm
        '
        Me.btn_LoadForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_LoadForm.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_LoadForm.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btn_LoadForm.Location = New System.Drawing.Point(0, 0)
        Me.btn_LoadForm.Name = "btn_LoadForm"
        Me.btn_LoadForm.Size = New System.Drawing.Size(38, 22)
        Me.btn_LoadForm.TabIndex = 3
        Me.btn_LoadForm.TabStop = False
        Me.btn_LoadForm.Text = "جديد"
        Me.ToolTip1.SetToolTip(Me.btn_LoadForm, "جديد")
        Me.btn_LoadForm.UseVisualStyleBackColor = True
        Me.btn_LoadForm.Visible = False
        '
        'LookUpButton
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btn_LoadForm)
        Me.Controls.Add(Me.tbox_Result)
        Me.Controls.Add(Me.btn_LoadLookUp)
        Me.Controls.Add(Me.tbox_Code)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "LookUpButton"
        Me.Size = New System.Drawing.Size(226, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tbox_Code As System.Windows.Forms.TextBox
    Public WithEvents btn_LoadLookUp As System.Windows.Forms.Button
    Public WithEvents tbox_Result As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents btn_LoadForm As System.Windows.Forms.Button

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class

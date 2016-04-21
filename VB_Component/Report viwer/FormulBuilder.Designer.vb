<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormulBuilder
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormulBuilder))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtn_Ya = New System.Windows.Forms.RadioButton
        Me.rbtn_Va = New System.Windows.Forms.RadioButton
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.Add_Button = New System.Windows.Forms.Button
        Me.label2_ta = New System.Windows.Forms.Label
        Me.label_az = New System.Windows.Forms.Label
        Me.Action_Combo = New System.Windows.Forms.ComboBox
        Me.Ta_textbox = New System.Windows.Forms.TextBox
        Me.Column_name_textbox = New System.Windows.Forms.TextBox
        Me.AZ_textbox = New System.Windows.Forms.TextBox
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btn_selectAll = New System.Windows.Forms.Button
        Me.Filter_condition_Listbox = New System.Windows.Forms.ListBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.lstvwINFO = New System.Windows.Forms.ListView
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader("(none)")
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.btn_Save = New System.Windows.Forms.Button
        Me.btn_SelectReport = New System.Windows.Forms.Button
        Me.Btn_Ok = New System.Windows.Forms.Button
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtn_Ya)
        Me.GroupBox1.Controls.Add(Me.rbtn_Va)
        Me.GroupBox1.Location = New System.Drawing.Point(191, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 39)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'rbtn_Ya
        '
        Me.rbtn_Ya.AutoSize = True
        Me.rbtn_Ya.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtn_Ya.Location = New System.Drawing.Point(29, 15)
        Me.rbtn_Ya.Name = "rbtn_Ya"
        Me.rbtn_Ya.Size = New System.Drawing.Size(33, 18)
        Me.rbtn_Ya.TabIndex = 1
        Me.rbtn_Ya.Text = "يا"
        Me.rbtn_Ya.UseVisualStyleBackColor = True
        '
        'rbtn_Va
        '
        Me.rbtn_Va.AutoSize = True
        Me.rbtn_Va.Checked = True
        Me.rbtn_Va.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtn_Va.Location = New System.Drawing.Point(73, 15)
        Me.rbtn_Va.Name = "rbtn_Va"
        Me.rbtn_Va.Size = New System.Drawing.Size(32, 18)
        Me.rbtn_Va.TabIndex = 0
        Me.rbtn_Va.TabStop = True
        Me.rbtn_Va.Text = "و"
        Me.rbtn_Va.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.groupBox5)
        Me.groupBox3.Controls.Add(Me.Btn_Ok)
        Me.groupBox3.Controls.Add(Me.groupBox4)
        Me.groupBox3.Location = New System.Drawing.Point(16, 92)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(474, 411)
        Me.groupBox3.TabIndex = 32
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "شروط گزارش"
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.Add_Button)
        Me.groupBox5.Controls.Add(Me.label2_ta)
        Me.groupBox5.Controls.Add(Me.label_az)
        Me.groupBox5.Controls.Add(Me.Action_Combo)
        Me.groupBox5.Controls.Add(Me.Ta_textbox)
        Me.groupBox5.Controls.Add(Me.Column_name_textbox)
        Me.groupBox5.Controls.Add(Me.AZ_textbox)
        Me.groupBox5.Controls.Add(Me.GroupBox1)
        Me.groupBox5.Location = New System.Drawing.Point(54, 33)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(393, 145)
        Me.groupBox5.TabIndex = 16
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "ايجاد شرط"
        '
        'Add_Button
        '
        Me.Add_Button.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Add_Button.Image = CType(resources.GetObject("Add_Button.Image"), System.Drawing.Image)
        Me.Add_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Add_Button.Location = New System.Drawing.Point(8, 102)
        Me.Add_Button.Name = "Add_Button"
        Me.Add_Button.Size = New System.Drawing.Size(140, 34)
        Me.Add_Button.TabIndex = 21
        Me.Add_Button.Text = "اضافه شدن شرط"
        Me.Add_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Add_Button.UseVisualStyleBackColor = True
        '
        'label2_ta
        '
        Me.label2_ta.Location = New System.Drawing.Point(151, 62)
        Me.label2_ta.Name = "label2_ta"
        Me.label2_ta.Size = New System.Drawing.Size(34, 16)
        Me.label2_ta.TabIndex = 20
        '
        'label_az
        '
        Me.label_az.Location = New System.Drawing.Point(343, 61)
        Me.label_az.Name = "label_az"
        Me.label_az.Size = New System.Drawing.Size(39, 16)
        Me.label_az.TabIndex = 19
        '
        'Action_Combo
        '
        Me.Action_Combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Action_Combo.Enabled = False
        Me.Action_Combo.Location = New System.Drawing.Point(8, 25)
        Me.Action_Combo.Name = "Action_Combo"
        Me.Action_Combo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Action_Combo.Size = New System.Drawing.Size(177, 22)
        Me.Action_Combo.TabIndex = 16
        '
        'Ta_textbox
        '
        Me.Ta_textbox.Location = New System.Drawing.Point(8, 61)
        Me.Ta_textbox.Name = "Ta_textbox"
        Me.Ta_textbox.Size = New System.Drawing.Size(140, 22)
        Me.Ta_textbox.TabIndex = 18
        '
        'Column_name_textbox
        '
        Me.Column_name_textbox.BackColor = System.Drawing.SystemColors.Info
        Me.Column_name_textbox.Location = New System.Drawing.Point(191, 25)
        Me.Column_name_textbox.Name = "Column_name_textbox"
        Me.Column_name_textbox.ReadOnly = True
        Me.Column_name_textbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Column_name_textbox.Size = New System.Drawing.Size(146, 22)
        Me.Column_name_textbox.TabIndex = 15
        '
        'AZ_textbox
        '
        Me.AZ_textbox.Location = New System.Drawing.Point(191, 59)
        Me.AZ_textbox.Name = "AZ_textbox"
        Me.AZ_textbox.Size = New System.Drawing.Size(146, 22)
        Me.AZ_textbox.TabIndex = 17
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.btn_Delete)
        Me.groupBox4.Controls.Add(Me.btn_selectAll)
        Me.groupBox4.Controls.Add(Me.Filter_condition_Listbox)
        Me.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox4.Location = New System.Drawing.Point(26, 184)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.groupBox4.Size = New System.Drawing.Size(421, 159)
        Me.groupBox4.TabIndex = 15
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "شروط ثبت شده تاكنون"
        '
        'btn_Delete
        '
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.Image = CType(resources.GetObject("btn_Delete.Image"), System.Drawing.Image)
        Me.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete.Location = New System.Drawing.Point(8, 75)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(96, 32)
        Me.btn_Delete.TabIndex = 33
        Me.btn_Delete.Text = "     حذف"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_selectAll
        '
        Me.btn_selectAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectAll.Location = New System.Drawing.Point(8, 37)
        Me.btn_selectAll.Name = "btn_selectAll"
        Me.btn_selectAll.Size = New System.Drawing.Size(96, 32)
        Me.btn_selectAll.TabIndex = 32
        Me.btn_selectAll.Text = "انتخاب همه"
        Me.btn_selectAll.UseVisualStyleBackColor = True
        '
        'Filter_condition_Listbox
        '
        Me.Filter_condition_Listbox.BackColor = System.Drawing.SystemColors.Window
        Me.Filter_condition_Listbox.HorizontalScrollbar = True
        Me.Filter_condition_Listbox.ItemHeight = 14
        Me.Filter_condition_Listbox.Location = New System.Drawing.Point(110, 26)
        Me.Filter_condition_Listbox.Name = "Filter_condition_Listbox"
        Me.Filter_condition_Listbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Filter_condition_Listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.Filter_condition_Listbox.Size = New System.Drawing.Size(292, 116)
        Me.Filter_condition_Listbox.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.lstvwINFO)
        Me.groupBox2.Location = New System.Drawing.Point(496, 94)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(168, 409)
        Me.groupBox2.TabIndex = 31
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "آيتم هاي گزارش"
        '
        'lstvwINFO
        '
        Me.lstvwINFO.AllowColumnReorder = True
        Me.lstvwINFO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstvwINFO.CausesValidation = False
        Me.lstvwINFO.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader3})
        Me.lstvwINFO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstvwINFO.FullRowSelect = True
        Me.lstvwINFO.GridLines = True
        Me.lstvwINFO.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstvwINFO.HideSelection = False
        Me.lstvwINFO.LabelWrap = False
        Me.lstvwINFO.Location = New System.Drawing.Point(7, 23)
        Me.lstvwINFO.MultiSelect = False
        Me.lstvwINFO.Name = "lstvwINFO"
        Me.lstvwINFO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstvwINFO.RightToLeftLayout = True
        Me.lstvwINFO.Size = New System.Drawing.Size(154, 376)
        Me.lstvwINFO.SmallImageList = Me.ImageList1
        Me.lstvwINFO.TabIndex = 23
        Me.lstvwINFO.UseCompatibleStateImageBehavior = False
        Me.lstvwINFO.View = System.Windows.Forms.View.Details
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "نام آيتم گزارش"
        Me.columnHeader3.Width = 150
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "sitemap.png")
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(125, 35)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(175, 14)
        Me.label2.TabIndex = 41
        Me.label2.Text = "ذخيره سازي تنظيمات گزارش"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(387, 35)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(172, 14)
        Me.label1.TabIndex = 40
        Me.label1.Text = "بارگزاري فايـل شروط گزارش"
        '
        'btn_Save
        '
        Me.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Save.Image = CType(resources.GetObject("btn_Save.Image"), System.Drawing.Image)
        Me.btn_Save.Location = New System.Drawing.Point(76, 21)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(43, 42)
        Me.btn_Save.TabIndex = 39
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_SelectReport
        '
        Me.btn_SelectReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_SelectReport.Image = CType(resources.GetObject("btn_SelectReport.Image"), System.Drawing.Image)
        Me.btn_SelectReport.Location = New System.Drawing.Point(338, 21)
        Me.btn_SelectReport.Name = "btn_SelectReport"
        Me.btn_SelectReport.Size = New System.Drawing.Size(43, 42)
        Me.btn_SelectReport.TabIndex = 38
        Me.btn_SelectReport.UseVisualStyleBackColor = True
        '
        'Btn_Ok
        '
        Me.Btn_Ok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Ok.Image = CType(resources.GetObject("Btn_Ok.Image"), System.Drawing.Image)
        Me.Btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Ok.Location = New System.Drawing.Point(129, 363)
        Me.Btn_Ok.Name = "Btn_Ok"
        Me.Btn_Ok.Size = New System.Drawing.Size(216, 36)
        Me.Btn_Ok.TabIndex = 42
        Me.Btn_Ok.Text = "اعمال شروط بر روي گزارش"
        Me.Btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Ok.UseVisualStyleBackColor = True
        '
        'saveFileDialog1
        '
        Me.saveFileDialog1.Filter = "Xml File|*.Xml"
        '
        'openFileDialog1
        '
        Me.openFileDialog1.Filter = "Xml File |*.xml"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_Save)
        Me.GroupBox6.Controls.Add(Me.btn_SelectReport)
        Me.GroupBox6.Controls.Add(Me.label2)
        Me.GroupBox6.Controls.Add(Me.label1)
        Me.GroupBox6.Location = New System.Drawing.Point(16, 7)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(648, 74)
        Me.GroupBox6.TabIndex = 43
        Me.GroupBox6.TabStop = False
        '
        'FormulBuilder
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(676, 515)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormulBuilder"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ايجاد فرمول براي خلاصه سازي گزارش"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtn_Ya As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_Va As System.Windows.Forms.RadioButton
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents Add_Button As System.Windows.Forms.Button
    Private WithEvents label2_ta As System.Windows.Forms.Label
    Private WithEvents label_az As System.Windows.Forms.Label
    Private WithEvents Action_Combo As System.Windows.Forms.ComboBox
    Private WithEvents Ta_textbox As System.Windows.Forms.TextBox
    Private WithEvents Column_name_textbox As System.Windows.Forms.TextBox
    Private WithEvents AZ_textbox As System.Windows.Forms.TextBox
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents btn_Delete As System.Windows.Forms.Button
    Private WithEvents btn_selectAll As System.Windows.Forms.Button
    Private WithEvents Filter_condition_Listbox As System.Windows.Forms.ListBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lstvwINFO As System.Windows.Forms.ListView
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btn_Save As System.Windows.Forms.Button
    Private WithEvents btn_SelectReport As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Private WithEvents Btn_Ok As System.Windows.Forms.Button
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox

End Class

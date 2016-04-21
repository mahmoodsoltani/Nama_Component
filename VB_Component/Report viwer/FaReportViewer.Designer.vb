<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FaReportViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FaReportViewer))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_FirstPage = New System.Windows.Forms.ToolStripButton
        Me.btn_PerPage = New System.Windows.Forms.ToolStripButton
        Me.btn_NextPage = New System.Windows.Forms.ToolStripButton
        Me.btn_EndPage = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.Btb_Exporrt = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn_Zoom = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cmb_Search = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.lbl_MoratabSazy = New System.Windows.Forms.ToolStripLabel
        Me.cmb_OrderField = New System.Windows.Forms.ToolStripComboBox
        Me.cmb_OrderBy = New System.Windows.Forms.ToolStripComboBox
        Me.btn_Refresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Filter = New System.Windows.Forms.ToolStripDropDownButton
        Me.ايجادفرمولشرطToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.tls_Zoom = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
        Me.tls_TotalPage = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.tls_PageNumber = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel
        Me.tls_Order = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.tlst_UseFourmol = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.CrpViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_FirstPage, Me.btn_PerPage, Me.btn_NextPage, Me.btn_EndPage, Me.ToolStripSeparator1, Me.btn_Print, Me.ToolStripSeparator7, Me.Btb_Exporrt, Me.ToolStripSeparator2, Me.Btn_Zoom, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.cmb_Search, Me.ToolStripSeparator4, Me.lbl_MoratabSazy, Me.cmb_OrderField, Me.cmb_OrderBy, Me.btn_Refresh, Me.ToolStripSeparator5, Me.btn_Filter, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(978, 38)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_FirstPage
        '
        Me.btn_FirstPage.AutoSize = False
        Me.btn_FirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_FirstPage.Image = CType(resources.GetObject("btn_FirstPage.Image"), System.Drawing.Image)
        Me.btn_FirstPage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_FirstPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_FirstPage.Name = "btn_FirstPage"
        Me.btn_FirstPage.Size = New System.Drawing.Size(35, 35)
        Me.btn_FirstPage.Text = "ToolStripButton1"
        Me.btn_FirstPage.ToolTipText = "اولين صفحه"
        '
        'btn_PerPage
        '
        Me.btn_PerPage.AutoSize = False
        Me.btn_PerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_PerPage.Image = CType(resources.GetObject("btn_PerPage.Image"), System.Drawing.Image)
        Me.btn_PerPage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_PerPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_PerPage.Name = "btn_PerPage"
        Me.btn_PerPage.Size = New System.Drawing.Size(35, 35)
        Me.btn_PerPage.Text = "بزرگنمايي"
        Me.btn_PerPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_PerPage.ToolTipText = "صفحه قبل"
        '
        'btn_NextPage
        '
        Me.btn_NextPage.AutoSize = False
        Me.btn_NextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_NextPage.Image = CType(resources.GetObject("btn_NextPage.Image"), System.Drawing.Image)
        Me.btn_NextPage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_NextPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_NextPage.Name = "btn_NextPage"
        Me.btn_NextPage.Size = New System.Drawing.Size(35, 35)
        Me.btn_NextPage.Text = "بزرگنمايي"
        Me.btn_NextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_NextPage.ToolTipText = "صفحه بعد"
        '
        'btn_EndPage
        '
        Me.btn_EndPage.AutoSize = False
        Me.btn_EndPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_EndPage.Image = CType(resources.GetObject("btn_EndPage.Image"), System.Drawing.Image)
        Me.btn_EndPage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_EndPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_EndPage.Name = "btn_EndPage"
        Me.btn_EndPage.Size = New System.Drawing.Size(35, 35)
        Me.btn_EndPage.Text = "بزرگنمايي"
        Me.btn_EndPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_EndPage.ToolTipText = "آخرين صفحه"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'btn_Print
        '
        Me.btn_Print.AutoSize = False
        Me.btn_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Print.Image = CType(resources.GetObject("btn_Print.Image"), System.Drawing.Image)
        Me.btn_Print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(35, 35)
        Me.btn_Print.Text = "بزرگنمايي"
        Me.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Print.ToolTipText = "ارسال به چاپگر"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 38)
        '
        'Btb_Exporrt
        '
        Me.Btb_Exporrt.AutoSize = False
        Me.Btb_Exporrt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btb_Exporrt.Image = CType(resources.GetObject("Btb_Exporrt.Image"), System.Drawing.Image)
        Me.Btb_Exporrt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btb_Exporrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btb_Exporrt.Name = "Btb_Exporrt"
        Me.Btb_Exporrt.Size = New System.Drawing.Size(35, 35)
        Me.Btb_Exporrt.Text = "بزرگنمايي"
        Me.Btb_Exporrt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Btb_Exporrt.ToolTipText = "...ارسال به"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'Btn_Zoom
        '
        Me.Btn_Zoom.AutoSize = False
        Me.Btn_Zoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9})
        Me.Btn_Zoom.Image = CType(resources.GetObject("Btn_Zoom.Image"), System.Drawing.Image)
        Me.Btn_Zoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Zoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_Zoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Zoom.Name = "Btn_Zoom"
        Me.Btn_Zoom.Size = New System.Drawing.Size(80, 35)
        Me.Btn_Zoom.Text = "100%"
        Me.Btn_Zoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Zoom.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Btn_Zoom.ToolTipText = "بزرگنمايي"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem2.Text = "25%"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem3.Text = "50%"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem4.Text = "100%"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem5.Text = "125%"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem6.Text = "150%"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem7.Text = "200%"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem8.Text = "300%"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripMenuItem9.Text = "400%"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(49, 35)
        Me.ToolStripLabel1.Text = "جستجو :"
        '
        'cmb_Search
        '
        Me.cmb_Search.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmb_Search.Name = "cmb_Search"
        Me.cmb_Search.Size = New System.Drawing.Size(121, 38)
        Me.cmb_Search.ToolTipText = "جستجو"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 38)
        '
        'lbl_MoratabSazy
        '
        Me.lbl_MoratabSazy.Name = "lbl_MoratabSazy"
        Me.lbl_MoratabSazy.Size = New System.Drawing.Size(69, 35)
        Me.lbl_MoratabSazy.Text = "مرتب سازي :"
        '
        'cmb_OrderField
        '
        Me.cmb_OrderField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_OrderField.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmb_OrderField.Name = "cmb_OrderField"
        Me.cmb_OrderField.Size = New System.Drawing.Size(121, 38)
        '
        'cmb_OrderBy
        '
        Me.cmb_OrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_OrderBy.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmb_OrderBy.Items.AddRange(New Object() {"به ترتيب‌ صعودي", "به ترتيب نزولي"})
        Me.cmb_OrderBy.Name = "cmb_OrderBy"
        Me.cmb_OrderBy.Size = New System.Drawing.Size(121, 38)
        '
        'btn_Refresh
        '
        Me.btn_Refresh.AutoSize = False
        Me.btn_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Refresh.Image = CType(resources.GetObject("btn_Refresh.Image"), System.Drawing.Image)
        Me.btn_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Refresh.Name = "btn_Refresh"
        Me.btn_Refresh.Size = New System.Drawing.Size(35, 35)
        Me.btn_Refresh.Text = "بزرگنمايي"
        Me.btn_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Refresh.ToolTipText = "بار گزاري مجدد گزارش"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 38)
        '
        'btn_Filter
        '
        Me.btn_Filter.AutoSize = False
        Me.btn_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Filter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ايجادفرمولشرطToolStripMenuItem, Me.بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem})
        Me.btn_Filter.Image = CType(resources.GetObject("btn_Filter.Image"), System.Drawing.Image)
        Me.btn_Filter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Filter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_Filter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Filter.Name = "btn_Filter"
        Me.btn_Filter.Size = New System.Drawing.Size(60, 35)
        Me.btn_Filter.ToolTipText = "اعمال شرط روي گزارش"
        '
        'ايجادفرمولشرطToolStripMenuItem
        '
        Me.ايجادفرمولشرطToolStripMenuItem.Image = CType(resources.GetObject("ايجادفرمولشرطToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ايجادفرمولشرطToolStripMenuItem.Name = "ايجادفرمولشرطToolStripMenuItem"
        Me.ايجادفرمولشرطToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ايجادفرمولشرطToolStripMenuItem.Text = "ايجاد فرمول شرط"
        '
        'بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem
        '
        Me.بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem.Image = CType(resources.GetObject("بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem.Image"), System.Drawing.Image)
        Me.بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem.Name = "بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem"
        Me.بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem.Text = "بازگرداني گزارش به اطلاعات اوليه"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 38)
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.AutoSize = False
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel3.Text = "بزرگنمايي:"
        '
        'tls_Zoom
        '
        Me.tls_Zoom.AutoSize = False
        Me.tls_Zoom.Name = "tls_Zoom"
        Me.tls_Zoom.Size = New System.Drawing.Size(80, 22)
        Me.tls_Zoom.Text = "100%"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(88, 22)
        Me.ToolStripLabel4.Text = "تعداد كل صفحات :"
        '
        'tls_TotalPage
        '
        Me.tls_TotalPage.AutoSize = False
        Me.tls_TotalPage.Name = "tls_TotalPage"
        Me.tls_TotalPage.Size = New System.Drawing.Size(80, 22)
        Me.tls_TotalPage.Text = "1"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel5.Text = "صفحه فعلي:"
        '
        'tls_PageNumber
        '
        Me.tls_PageNumber.AutoSize = False
        Me.tls_PageNumber.Name = "tls_PageNumber"
        Me.tls_PageNumber.Size = New System.Drawing.Size(80, 22)
        Me.tls_PageNumber.Text = "1"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripLabel7.Text = "مرتب سازي بر اساس :"
        '
        'tls_Order
        '
        Me.tls_Order.AutoSize = False
        Me.tls_Order.Name = "tls_Order"
        Me.tls_Order.Size = New System.Drawing.Size(200, 22)
        Me.tls_Order.Text = "هنوز مرتب سازي انجام نشده"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'tlst_UseFourmol
        '
        Me.tlst_UseFourmol.Name = "tlst_UseFourmol"
        Me.tlst_UseFourmol.Size = New System.Drawing.Size(152, 22)
        Me.tlst_UseFourmol.Text = "فرمول شروط گزارش اعمال نشده"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.tls_Zoom, Me.ToolStripSeparator8, Me.ToolStripLabel4, Me.tls_TotalPage, Me.ToolStripSeparator10, Me.ToolStripLabel5, Me.tls_PageNumber, Me.ToolStripSeparator9, Me.ToolStripLabel7, Me.tls_Order, Me.ToolStripSeparator11, Me.tlst_UseFourmol})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 543)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(978, 25)
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'CrpViewer
        '
        Me.CrpViewer.ActiveViewIndex = -1
        Me.CrpViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrpViewer.DisplayGroupTree = False
        Me.CrpViewer.DisplayStatusBar = False
        Me.CrpViewer.DisplayToolbar = False
        Me.CrpViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrpViewer.Location = New System.Drawing.Point(0, 38)
        Me.CrpViewer.Name = "CrpViewer"
        Me.CrpViewer.SelectionFormula = ""
        Me.CrpViewer.Size = New System.Drawing.Size(978, 505)
        Me.CrpViewer.TabIndex = 3
        Me.CrpViewer.ViewTimeSelectionFormula = ""
        '
        'FaReportViewer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.CrpViewer)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "FaReportViewer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(978, 568)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_FirstPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_PerPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_NextPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_EndPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btb_Exporrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn_Zoom As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmb_Search As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_MoratabSazy As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmb_OrderField As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cmb_OrderBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btn_Refresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btn_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Filter As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ايجادفرمولشرطToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tls_Zoom As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tls_TotalPage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tls_PageNumber As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tls_Order As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlst_UseFourmol As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents CrpViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class

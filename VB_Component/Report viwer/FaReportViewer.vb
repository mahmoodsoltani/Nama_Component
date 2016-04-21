Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms

Public Class FaReportViewer

    Dim rp As New Object()
    Dim FindTotalPageh As Boolean = False
    Dim RpDataview As New DataView()
    Dim firstLoadCondition As Boolean = True
    Public HidenField() As Integer

    Public WriteOnly Property NameOfReport() As String
        Set(ByVal value As String)
            CrystalHelper.ReplaceReportName(CrpViewer, value)
        End Set
    End Property

    Public Property ShowSortOption() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                cmb_OrderField.Enabled = True
                cmb_OrderBy.Enabled = True
                btn_Refresh.Enabled = True
            Else
                cmb_OrderField.Enabled = False
                cmb_OrderBy.Enabled = False
                btn_Refresh.Enabled = False
            End If
        End Set
        Get
            Return cmb_OrderField.Enabled
        End Get
    End Property

    Public Property ShowFilterOption() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                btn_Filter.Enabled = True
            Else
                btn_Filter.Enabled = False
            End If
        End Set
        Get
            Return btn_Filter.Enabled = True
        End Get
    End Property

    Private Sub btn_FirstPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_FirstPage.Click
        CrpViewer.ShowFirstPage()
    End Sub

    Private Sub btn_PerPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PerPage.Click
        CrpViewer.ShowPreviousPage()
    End Sub

    Private Sub btn_NextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NextPage.Click
        CrpViewer.ShowNextPage()
    End Sub

    Private Sub btn_EndPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EndPage.Click
        CrpViewer.ShowLastPage()
    End Sub

    Public Sub btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Print.Click
        CrpViewer.PrintReport()
    End Sub

    Private Sub Btb_Exporrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btb_Exporrt.Click
        CrpViewer.ExportReport()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(25))
        tls_Zoom.Text = ToolStripMenuItem2.Text
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(50))
        tls_Zoom.Text = ToolStripMenuItem3.Text
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(100))
        tls_Zoom.Text = ToolStripMenuItem4.Text
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(125))
        tls_Zoom.Text = ToolStripMenuItem5.Text
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(150))
        tls_Zoom.Text = ToolStripMenuItem6.Text
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(200))
        tls_Zoom.Text = ToolStripMenuItem7.Text
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(300))
        tls_Zoom.Text = ToolStripMenuItem8.Text
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Btn_Zoom.Text = ToolStripMenuItem2.Text
        CrpViewer.Zoom(Convert.ToInt32(400))
        tls_Zoom.Text = ToolStripMenuItem9.Text
    End Sub

    Private Sub cmbox_Zoom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_Search.KeyDown
        If (e.KeyCode = Keys.Return) Then
            CrpViewer.SearchForText(cmb_Search.Text)
            Dim index As Integer = cmb_Search.FindString(cmb_Search.Text)
            cmb_Search.SelectedIndex = index
            If (index = -1) Then
                cmb_Search.Items.Add(cmb_Search.Text)
            End If
        End If
    End Sub

    Private Sub Btn_Zoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Zoom.Click
        Try
            Btn_Zoom.Text = "100%"
            CrpViewer.Zoom(Convert.ToInt32(100))
            tls_Zoom.Text = "100%"
        Catch ex As Exception

        End Try
    End Sub

    Public Property ReportDataview() As DataTable
        Set(ByVal value As DataTable)
            If value Is Nothing Then
                Return
            End If
            RpDataview = New DataView(value)
        End Set
        Get
            Return RpDataview.Table
        End Get
    End Property

    Public Property ReportSource() As Object
        Set(ByVal value As Object)
            If value Is Nothing Then
                Return
            End If
            CrpViewer.ReportSource = value
            intRp()
        End Set
        Get
            Return CrpViewer.ReportSource
        End Get
    End Property

    Private Sub intRp()
        If Not CrpViewer.ReportSource Is Nothing Then
            rp = CrpViewer.ReportSource
        End If
        Try
            If rp.Database.Tables.Count > 0 Then
                For Each ob As Object In rp.Database.Tables(0).Fields
                    cmb_OrderField.Items.Add(ob.Name.ToString)
                Next
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub FaReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If VB_Component.Windows.ArrayOfString("temp") Then
        '    Me.Dispose()
        'End If
        CrpViewer.Zoom(100)
        tls_TotalPage.Text = 1
        FindTotalPageh = True
        btn_EndPage_Click(sender, e)
        FindTotalPageh = False
        btn_FirstPage_Click(sender, e)
        'CrystalHelper.ReplaceReportName(Me.CrpViewer, "MainReport", "نمايش گزارش")
    End Sub

    Private Sub CrpViewer_Navigate(ByVal source As System.Object, ByVal e As CrystalDecisions.Windows.Forms.NavigateEventArgs) Handles CrpViewer.Navigate
        If FindTotalPageh Then
            tls_TotalPage.Text = e.NewPageNumber
            btn_PerPage.Enabled = False
        Else
            tls_PageNumber.Text = e.NewPageNumber

            If tls_PageNumber.Text < tls_TotalPage.Text And tls_PageNumber.Text > 1 Then
                btn_NextPage.Enabled = True
                btn_PerPage.Enabled = True
            ElseIf tls_PageNumber.Text = tls_TotalPage.Text Then
                btn_NextPage.Enabled = False
                btn_PerPage.Enabled = True
            ElseIf (tls_PageNumber.Text = 1 Or tls_PageNumber.Text = 0) And tls_TotalPage.Text = 1 Then
                If tls_PageNumber.Text = 0 Then
                    tls_PageNumber.Text += 1
                End If
                btn_NextPage.Enabled = False
                btn_PerPage.Enabled = False
            ElseIf tls_PageNumber.Text = 1 And tls_TotalPage.Text > 1 Then
                btn_NextPage.Enabled = True
                btn_PerPage.Enabled = False
            End If

            If tls_PageNumber.Text = 1 And tls_TotalPage.Text = 1 Then
                btn_EndPage.Enabled = False
                btn_FirstPage.Enabled = False
                btn_NextPage.Enabled = False
                btn_PerPage.Enabled = False
            End If
        End If
    End Sub

    Private Sub btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Refresh.Click
        Try
            If String.IsNullOrEmpty(cmb_OrderField.Text) Then
                Return
            End If

            Dim crDatabaseFieldDefinition As CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition
            crDatabaseFieldDefinition = rp.Database.Tables(0).Fields(cmb_OrderField.Text)
            rp.DataDefinition.SortFields.Item(0).Field = crDatabaseFieldDefinition

            If cmb_OrderBy.Text <> "" Then
                If cmb_OrderBy.Text = "به ترتيب‌ صعودي" Then
                    rp.DataDefinition.SortFields(0).SortDirection = CrystalDecisions.Shared.SortDirection.AscendingOrder
                    tls_Order.Text = cmb_OrderField.Text + "  " + "به ترتيب‌ صعودي"
                Else
                    rp.DataDefinition.SortFields(0).SortDirection = CrystalDecisions.Shared.SortDirection.DescendingOrder
                    tls_Order.Text = cmb_OrderField.Text + "  " + "به ترتيب‌ نزولي"
                End If
            Else
                tls_Order.Text = cmb_OrderField.Text + "  " + "به ترتيب‌ صعودي"
            End If

            CrpViewer.ReportSource = rp
        Catch ex As Exception
            MessageBoxFa.Show("مرتب سازي براي اين گزارش نعريف نشده", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles بازگردانيگزارشبهاطلاعاتاوليهToolStripMenuItem.Click
        If MessageBoxFa.Show("مايل به بازگشت اطلاعات گزارش به حالت اوليه ( حذف شرط گزارش ) هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        If ReportDataview Is Nothing Then

        Else
            'get current value of field in report
            Dim Fields As New List(Of node)
            For Each paname As CrystalDecisions.Shared.ParameterField In rp.ParameterFields
                Dim nodak As New node
                nodak.name = paname.Name
                nodak.value = DirectCast(paname.CurrentValues.Item(0), CrystalDecisions.Shared.ParameterDiscreteValue).Value.ToString
                Fields.Add(nodak)
            Next

            Dim dv As New DataView(ReportDataview)
            rp.SetDataSource(dv)

            For Each no As node In Fields
                rp.SetParameterValue(no.name, no.value)
            Next

            CrpViewer.ReportSource = rp
            tlst_UseFourmol.Text = "فرمول شروط گزارش اعمال نشده"
        End If
    End Sub

    Private Sub ايجادفرمولشرطToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ايجادفرمولشرطToolStripMenuItem.Click
        If ReportDataview Is Nothing Then
            MessageBoxFa.Show("data not seted")
        Else
            If File.Exists(Path.GetTempPath() + "\lastshow.xml") AndAlso firstLoadCondition = True Then
                File.Delete(Path.GetTempPath() + "\lastshow.xml")
            End If
            firstLoadCondition = False
            Dim s As New FormulBuilder(New DataView(ReportDataview) _
            , rp.ResourceName.ToString().Replace(".rpt", "").Replace("Rp", "").Replace("rp", "").Replace("rP", ""))
            s.HidenField = HidenField

            s.ShowDialog()
            If Not s.Result Is Nothing Then

                'get current value of field in report
                Dim Fields As New List(Of node)
                For Each paname As CrystalDecisions.Shared.ParameterField In rp.ParameterFields
                    Dim nodak As New node
                    nodak.name = paname.Name
                    nodak.value = DirectCast(paname.CurrentValues.Item(0), CrystalDecisions.Shared.ParameterDiscreteValue).Value.ToString
                    Fields.Add(nodak)
                Next

                rp.SetDataSource(s.Result)

                'assign the value to new database of report
                For Each no As node In Fields
                    rp.SetParameterValue(no.name, no.value)
                Next

                CrpViewer.ReportSource = rp
                tlst_UseFourmol.Text = "گزارش توسط فرمول ساز خلاصه شده"
            End If
        End If
    End Sub
End Class

Class node
    Public name As String
    Public value As String
End Class


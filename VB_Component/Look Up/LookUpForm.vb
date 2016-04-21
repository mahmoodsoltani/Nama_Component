Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class LookUpForm

#Region "variables"
    Dim _Lang As Language = Language.Farsi
    Dim dt As New DataTable
    Dim ShowSrl As Boolean = False
    Dim dr As DataRowView = Nothing
    Public HidenField As Integer()
    Public ShowField As Boolean
    Private check_DataSource As Boolean = False
    Private DtSource As Boolean = False
    Public int_SearchColumnIndex As Integer = 1
    Dim InitSearch As String = ""

#End Region

#Region "property"

    Public Enum Language
        Farsi = 0
        English
    End Enum

    Public WriteOnly Property FormLangeuge() As Language
        Set(ByVal value As Language)
            _Lang = value
        End Set
    End Property

    Public Property Result() As DataRowView
        Get
            Return dr
        End Get
        Set(ByVal value As DataRowView)
            dr = value
        End Set
    End Property

    Public Property HiddenFields() As Integer()
        Get
            Return HidenField
        End Get
        Set(ByVal value As Integer())
            HidenField = value
            ShowField = False
        End Set

    End Property
    Public Property ShowFields() As Integer()
        Get
            Return HidenField
        End Get
        Set(ByVal value As Integer())
            HidenField = value
            ShowField = True
        End Set
    End Property
#End Region

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal CodeFieldIndex As Integer, ByVal ResultFieldIndex As Integer _
    , ByVal FormCaption As String, ByVal ShowSerial As Boolean, ByVal ShowOrHidenField As Integer(), ByVal _ShowField As Boolean _
    , Optional ByVal LastResult As DataRowView = Nothing, Optional ByVal InitialSearch As String = Nothing _
    , Optional ByVal SortIndex As Integer = 0, Optional ByVal SortDirection As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Ascending)

        If dt Is Nothing Then
            Return
        End If

        ShowField = _ShowField
        ShowSrl = ShowSerial
        Me.int_SearchColumnIndex = ResultFieldIndex
        FillDGrid(dt)
        Application.DoEvents()
        Me.Text = FormCaption
        HidenField = ShowOrHidenField

        If Not LastResult Is Nothing Then
            dr = LastResult
        End If

        If Not InitSearch Is Nothing Then
            InitSearch = InitialSearch
        End If

        If (DataGridView1.Rows.Count > 0) Then
            Dim i As Integer
            For i = 0 To DataGridView1.Rows.Count
                If (DataGridView1.Columns(i).Visible = True) Then
                    DataGridView1.CurrentCell = DataGridView1(i, 0)
                    Exit For
                End If
            Next
        End If

        DataGridView1.Sort(DataGridView1.Columns(SortIndex), SortDirection)
    End Sub

    Public Sub LoadLookUp(ByVal dt As DataTable, ByVal FormCaption As String _
    , Optional ByVal ShowSerial As Boolean = False, Optional ByVal int_SearchColumnIndex As Integer = 1 _
    , Optional ByVal _InitSearch As String = "", Optional ByVal LastResult As DataRowView = Nothing _
    , Optional ByVal SortIndex As Integer = 0, Optional ByVal SortDirection As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Ascending)

        If dt Is Nothing Then
            Return
        End If

        ShowSrl = ShowSerial
        Me.int_SearchColumnIndex = int_SearchColumnIndex
        FillDGrid(dt)
        Application.DoEvents()
        Me.Text = FormCaption

        If Not LastResult Is Nothing Then
            dr = LastResult
        Else
            InitSearch = _InitSearch
        End If

        If (DataGridView1.Rows.Count > 0) Then
            Dim i As Integer
            For i = 0 To DataGridView1.Rows.Count
                If (DataGridView1.Columns(i).Visible = True) Then
                    DataGridView1.CurrentCell = DataGridView1(i, 0)
                    Exit For
                End If
            Next
        End If
        DataGridView1.Sort(DataGridView1.Columns(SortIndex), SortDirection)
    End Sub

    Private Sub FillDGrid(ByVal dt As DataTable)
        If dt Is Nothing Then
            Return
        End If
        DataGridView1.DataSource = Nothing
        Me.dt = dt
        DataGridView1.DataSource = dt
        DataGridView1.Columns(0).Visible = ShowSrl
    End Sub

    Private Sub LookUpForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If VB_Component.Windows.ArrayOfString("temp") Then
        '    Me.Dispose()
        'End If
        InitializeLookUp()
        If dt.Columns.Count = 0 Then
            MessageBoxFa.Show("data Source not set or count of data table column is zero")
            Close()
            Return
        End If
        lbl_SearchField.Text = DataGridView1.Columns.Item(int_SearchColumnIndex).HeaderText
        If Not Me.check_DataSource Then
            Try
                Dim s As String = DirectCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter
                Me.DtSource = True
            Catch
                Me.DtSource = False
            End Try
            Me.check_DataSource = True
        End If
        Call CalculateWideOfColomn(Me.CreateGraphics)
        Me.TopMost = True
        Me.BringToFront()
        Me.Location = New Drawing.Point(SystemInformation.WorkingArea.Width / 2 - Me.Size.Width / 2 _
        , SystemInformation.WorkingArea.Height / 2 - Me.Size.Height / 2.5)

        For j As Integer = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(j).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Next

        If Not HidenField Is Nothing Then
            If (ShowField) Then
                Dim i As Integer
                For i = 0 To DataGridView1.Columns.Count - 1
                    DataGridView1.Columns(i).Visible = False
                Next

                For i = 0 To DataGridView1.Columns.Count
                    For Each Item2 As Integer In HidenField
                        If i = Item2 Then
                            DataGridView1.Columns(i).Visible = True
                            Exit For
                        End If
                    Next
                Next
            Else
                For Each Item As DataGridViewColumn In DataGridView1.Columns
                    For Each Item1 As Integer In HidenField
                        If Item.Index = Item1 Then
                            Item.Visible = False
                        End If
                    Next
                Next
            End If
        End If

        Tbox_Search.Text = InitSearch
        Tbox_Search.SelectionStart = Tbox_Search.Text.Length
        Tbox_Search_TextChanged(sender, e)
        lbl_SearchField.Text = DataGridView1.Columns.Item(Me.int_SearchColumnIndex).HeaderText
        If DataGridView1.RowCount > 0 Then
            For d As Integer = 1 To 10
                If DataGridView1.Columns(d).Visible Then
                    DataGridView1.CurrentCell = DataGridView1(d, 0)
                    Exit For
                End If
            Next
        End If
        Application.DoEvents()
    End Sub

    Private Sub CalculateWideOfColomn(ByVal g As Graphics)
        'Dim tmpSize As New SizeF
        'For i As Integer = 0 To DataGridView1.Columns.Count - 1
        '    Dim tmpFont As Font = DataGridView1.DefaultCellStyle.Font
        '    tmpSize = g.MeasureString(DataGridView1.Columns.Item(i).HeaderText, tmpFont)
        '    Dim tmpWidth As Single = tmpSize.Width
        '    Dim RowHeaderHeight As Single = tmpSize.Height
        '    For j As Integer = 0 To DataGridView1.Rows.Count - 1
        '        tmpSize = g.MeasureString(DataGridView1.Rows.Item(j).Cells.Item(i).EditedFormattedValue.ToString, tmpFont)
        '        If (tmpSize.Width > tmpWidth) Then
        '            tmpWidth = tmpSize.Width
        '        End If
        '    Next j
        'Next i

        Dim visibleColumn As Integer = 0
        If HidenField Is Nothing Then
            visibleColumn = DataGridView1.Columns.Count
        Else
            If ShowField Then
                visibleColumn = HidenField.Length
            Else
                visibleColumn = DataGridView1.Columns.Count - HidenField.Length
            End If
        End If

        Dim totalSize As Integer = visibleColumn * 100

        If totalSize < 875 Then
            If Integer.Parse(Me.Width) < Integer.Parse(totalSize) Then
                Me.Size = New Size(totalSize, Me.Height)
            End If
        Else
            Me.Size = New Size(875, Me.Height)
        End If

        'If DataGridView1.Rows.Count > 12 Then
        '    Return
        'Else
        '    Dim tempSize As Integer = 0
        '    For j As Integer = 0 To DataGridView1.Rows.Count - 1
        '        tempSize += 22
        '    Next j
        '    Me.Size = New Size(Me.Width, tempSize + 18 + 45 + 35)
        'End If
    End Sub

    Private Sub InitializeLookUp()
        If _Lang = Language.Farsi Then
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"))
        Else
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
        End If
    End Sub

    Public Function SetDigitalRefByIndex(ByRef LK As LookUpButton) As Boolean

        'If String.IsNullOrEmpty(LK.tbox_Code.Text.Trim) Then
        '    Return False
        'End If

        InitializeLookUp()

        Dim dv As New DataView(dt)
        dv.RowFilter = ""
        If dt.Columns(int_SearchColumnIndex).DataType.ToString().Equals("System.String") Then
            dv.RowFilter = "[" + dv.Table.Columns(int_SearchColumnIndex).ColumnName + "] like '" + InitSearch + "'"
        Else
            dv.RowFilter = "[" + dv.Table.Columns(int_SearchColumnIndex).ColumnName + "]=" + InitSearch
        End If

        DataGridView1.DataSource = dv
        For Each drow As DataGridViewRow In DataGridView1.Rows
            drow.Selected = False
        Next

        If DataGridView1.Rows.Count = 0 Then
            Me.dr = Nothing
            Return False
        End If

        DataGridView1.Rows(0).Selected = True

        If Not selectedREf() Then
            dr = Nothing
            Return False
        End If

        Return True
    End Function

    Public Function SetDigitalRef(ByVal Serial As Integer) As Boolean

        InitializeLookUp()

        Dim dv As New DataView(dt)
        dv.RowFilter = ""

        Try
            dv.RowFilter = "[" + dv.Table.Columns(0).ColumnName + "]=" + Serial.ToString
        Catch

        End Try

        DataGridView1.DataSource = dv
        For Each drow As DataGridViewRow In DataGridView1.Rows
            drow.Selected = False
        Next

        If DataGridView1.Rows.Count = 0 Then
            Me.dr = Nothing
            Return False
        End If

        DataGridView1.Rows(0).Selected = True

        If Not selectedREf() Then
            dr = Nothing
            Return False
        End If

        Return True
    End Function

    Public Function SetDigitalRef(ByVal Index_Search As Integer, ByVal Init_Search As String) As Boolean

        'If String.IsNullOrEmpty(LK.tbox_Code.Text.Trim) Then
        '    Return False
        'End If

        InitializeLookUp()

        Dim dv As New DataView(dt)
        dv.RowFilter = ""
        If dt.Columns(Index_Search).DataType.ToString().Equals("System.String") Then
            dv.RowFilter = "[" + dv.Table.Columns(Index_Search).ColumnName + "] like '" + Init_Search + "'"
        Else
            Try
                dv.RowFilter = "[" + dv.Table.Columns(Index_Search).ColumnName + "]=" + Init_Search.Trim
            Catch

            End Try

        End If

        DataGridView1.DataSource = dv
        For Each drow As DataGridViewRow In DataGridView1.Rows
            drow.Selected = False
        Next

        If DataGridView1.Rows.Count = 0 Then
            Me.dr = Nothing
            Return False
        End If

        DataGridView1.Rows(0).Selected = True

        If Not selectedREf() Then
            dr = Nothing
            Return False
        End If
        'Call CalculateWideOfColomn(Me.CreateGraphics)
        Return True
    End Function

    Public Function SetDigitalRef(ByRef LK As LookUpButton) As Boolean

        'If String.IsNullOrEmpty(LK.tbox_Code.Text.Trim) Then
        '    Return False
        'End If

        InitializeLookUp()

        Dim dv As New DataView(dt)
        dv.RowFilter = ""
        If dt.Columns(int_SearchColumnIndex).DataType.ToString().Equals("System.String") Then
            dv.RowFilter = "[" + dv.Table.Columns(int_SearchColumnIndex).ColumnName + "] like '" + LK.tbox_Code.Text + "'"
        Else
            Try
                dv.RowFilter = "[" + dv.Table.Columns(int_SearchColumnIndex).ColumnName + "]=" + LK.tbox_Code.Text.Trim
            Catch

            End Try

        End If

        DataGridView1.DataSource = dv
        For Each drow As DataGridViewRow In DataGridView1.Rows
            drow.Selected = False
        Next

        If DataGridView1.Rows.Count = 0 Then
            Me.dr = Nothing
            Return False
        End If

        DataGridView1.Rows(0).Selected = True

        If Not selectedREf() Then
            dr = Nothing
            Return False
        End If
        'Call CalculateWideOfColomn(Me.CreateGraphics)
        Return True
    End Function

    Private Sub LookUpForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case System.Windows.Forms.Keys.Enter
                selected()
            Case System.Windows.Forms.Keys.Escape
                Close()
            Case System.Windows.Forms.Keys.PageDown
                If DataGridView1.Rows.Count > 0 Then
                    DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows.Count - 1
                    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True

                    For d As Integer = 1 To 10
                        If DataGridView1.Columns(d).Visible Then
                            DataGridView1.CurrentCell = DataGridView1(d, DataGridView1.Rows.Count - 1)
                            Exit For
                        End If
                    Next

                End If
            Case System.Windows.Forms.Keys.PageUp
                If DataGridView1.RowCount > 0 Then
                    DataGridView1.FirstDisplayedScrollingRowIndex = 0
                    DataGridView1.Rows(0).Selected = True

                    For d As Integer = 1 To 10
                        If DataGridView1.Columns(d).Visible Then
                            DataGridView1.CurrentCell = DataGridView1(d, 0)
                            Exit For
                        End If
                    Next

                End If
            Case System.Windows.Forms.Keys.Down
                If DataGridView1.RowCount = 0 OrElse DataGridView1.RowCount - 1 = DataGridView1.CurrentRow.Index Then
                    Return
                Else
                    DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.CurrentRow.Index + 1
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index + 1).Selected = True
                    For d As Integer = 1 To 10
                        If DataGridView1.Columns(d).Visible Then
                            DataGridView1.CurrentCell = DataGridView1(d, DataGridView1.CurrentRow.Index + 1)
                            Exit For
                        End If
                    Next

                End If
            Case System.Windows.Forms.Keys.Up
                If DataGridView1.Rows.Count = 0 OrElse DataGridView1.CurrentRow.Index = 0 Then
                    Return
                Else
                    DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.CurrentRow.Index - 1
                    DataGridView1.Rows(DataGridView1.CurrentRow.Index - 1).Selected = True
                    For d As Integer = 1 To 10
                        If DataGridView1.Columns(d).Visible Then
                            DataGridView1.CurrentCell = DataGridView1(d, DataGridView1.CurrentRow.Index - 1)
                            Exit For
                        End If
                    Next
                End If
            Case System.Windows.Forms.Keys.ControlKey

                Me.int_SearchColumnIndex = FindNextVisibleField()

                If DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.String") Then
                    Tbox_Search.TypeOfContains = Tbox.TypeOfValues.All
                ElseIf DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.Int32") Then
                    Tbox_Search.TypeOfContains = Tbox.TypeOfValues.Digit
                ElseIf DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.Double") Then
                    Tbox_Search.TypeOfContains = Tbox.TypeOfValues.DigitDot
                Else
                    Tbox_Search.TypeOfContains = Tbox.TypeOfValues.Digit
                End If

                lbl_SearchField.Text = DataGridView1.Columns.Item(Me.int_SearchColumnIndex).HeaderText
        End Select
    End Sub

    Function FindNextVisibleField() As Integer
        Dim findIndex As Integer = int_SearchColumnIndex
        Dim find As Boolean = False

        For i As Integer = int_SearchColumnIndex + 1 To DataGridView1.Columns.Count - 1
            If DataGridView1.Columns(i).Visible Then
                findIndex = i
                find = True
                Exit For
            End If
        Next

        If Not find Then
            For i As Integer = 0 To int_SearchColumnIndex - 1
                If DataGridView1.Columns(i).Visible Then
                    findIndex = i
                    Exit For
                End If
            Next
        End If

        Return findIndex
    End Function

    Private Function selectedREf() As Boolean
        If DataGridView1.DataSource Is Nothing OrElse DataGridView1.SelectedRows.Count = 0 Then
            Me.dr = Nothing
            Return False
        End If
        Me.dr = CType(DataGridView1.SelectedRows.Item(0).DataBoundItem, DataRowView)
        Return True
    End Function

    Private Sub selected()
        If DataGridView1.DataSource Is Nothing OrElse DataGridView1.SelectedRows.Count = 0 Then
            Me.dr = Nothing
            Return
        End If

        Me.dr = CType(DataGridView1.SelectedRows(0).DataBoundItem, DataRowView)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub LookUpForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If dr Is Nothing Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub DataGridView1_RiseEnterKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        LookUpForm_KeyDown(sender, e)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        selected()
    End Sub

    Public Sub LoadBySerial(ByRef LK As LookUpButton, ByVal serial As Integer, ByVal CodeFieldIndex As Integer)
        InitializeLookUp()

        Dim dv As New DataView(dt)
        dv.RowFilter = ""
        dv.RowFilter = "[" + dv.Table.Columns(0).ColumnName + "]=" + serial.ToString
        LK.tbox_Code.Text = dv(0).Item(CodeFieldIndex).ToString

    End Sub

    Private Sub Tbox_Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbox_Search.TextChanged
        If Me.DtSource Then
            Try
                Dim count As Integer = DirectCast(DataGridView1.DataSource, DataTable).Rows.Count
                If (Tbox_Search.Text.Trim = "") Then
                    DirectCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter = ""
                ElseIf DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.String") Then
                    DirectCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() {"[", DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).ColumnName, "] like '%", Tbox_Search.Text, "%'"})
                ElseIf DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.Int32") _
                OrElse DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.Double") Then
                    DirectCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter = ("[" & DirectCast(DataGridView1.DataSource, DataTable).DefaultView.Table.Columns.Item(Me.int_SearchColumnIndex).ColumnName & "] = " & Tbox_Search.Text.Trim)
                End If
                'If (DirectCast(DataGridView1.DataSource, DataTable).Rows.Count > count) Then
                'Call CalculateWideOfColomn(Me.CreateGraphics)
                'End If
            Catch

            End Try

        Else
            If (Tbox_Search.Text.Trim = "") Then
                DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).RowFilter = ""
            ElseIf DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.String") Then
                DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).RowFilter = ("[" & DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).Table.Columns.Item(Me.int_SearchColumnIndex).ColumnName & "] like '%" & Tbox_Search.Text & "%'")
            ElseIf DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.Int32") _
            OrElse DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).Table.Columns.Item(Me.int_SearchColumnIndex).DataType.ToString.Equals("System.Double") Then
                DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).RowFilter = ("[" & DirectCast(DirectCast(DataGridView1.DataSource, BindingSource).List, DataView).Table.Columns.Item(Me.int_SearchColumnIndex).ColumnName & "] = " & Tbox_Search.Text.Trim)
            End If
        End If
    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        Me.int_SearchColumnIndex = e.ColumnIndex
        lbl_SearchField.Text = DataGridView1.Columns.Item(e.ColumnIndex).HeaderText
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        e.Handled = False
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal SearchIndex As Integer, ByVal SearchStr As String)
        InitializeComponent()
        Me.int_SearchColumnIndex = SearchIndex
        InitSearch = SearchStr
    End Sub

    Private Sub Pic_Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_Help.Click
        MessageBoxFa.Show("كاربر گرامي  با زدن دكمه control  ميتوانيد فيلد جستجو را تغيير دهيد", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tbox_Search.Focus()
    End Sub
End Class
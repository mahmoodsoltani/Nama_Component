Imports System.Collections
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Public Class FormulBuilder

    Dim input_rowfilter As String
    Dim Formol As String = ""
    Dim filterstring_arraylist As New ArrayList
    Dim mytable As DataTable
    Dim ResultView As DataView
    Dim reportName As String
    Public HidenField() As Integer

    Public ReadOnly Property Result() As DataView
        Get
            Return ResultView
        End Get
    End Property

    Public Sub New(ByVal DV As DataView, ByVal reportName As String)
        InitializeComponent()
        mytable = DV.Table
        input_rowfilter = DV.RowFilter

        If File.Exists(Path.GetTempPath() + "\lastshow.xml") Then
            Me.Filter_condition_Listbox.Items.Clear()
            Me.filterstring_arraylist.Clear()
            Using XmlRdr As New Xml.XmlTextReader(Path.GetTempPath() + "\lastshow.xml")
                Do While XmlRdr.Read
                    If ((XmlRdr.NodeType = Xml.XmlNodeType.Element) AndAlso (XmlRdr.Name = "Code")) Then
                        Dim tempText As String = ""
                        Dim tempCode As String = XmlRdr.ReadString
                        Do While XmlRdr.Read
                            If ((XmlRdr.NodeType = Xml.XmlNodeType.Element) AndAlso (XmlRdr.Name = "Text")) Then
                                tempText = XmlRdr.ReadString.Replace("[", "").Replace("]", "")
                                Exit Do
                            End If
                        Loop
                        If (tempText = "empty") Then
                            Continue Do
                        End If
                        Me.Filter_condition_Listbox.Items.Add(tempText)
                        Me.filterstring_arraylist.Add(tempCode)
                    End If
                Loop
            End Using
        End If
        Me.reportName = reportName
    End Sub

    Private Sub FormulBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If VB_Component.Windows.ArrayOfString(Me.Text) Then
        '    Me.Dispose()
        'End If
        lstvwINFO.Items.Clear()
        Dim columnName As String = ""

        For i As Integer = 0 To Me.mytable.Columns.Count - 1
            columnName = Me.mytable.Columns.Item(i).ColumnName
            Do While ((columnName.IndexOf(" "c) = 0) OrElse (columnName.IndexOf(" "c) = (columnName.Length - 1)))
                columnName = columnName.Remove(columnName.IndexOf(" "c), 1)
            Loop
            If HidenField Is Nothing Then
                Me.mytable.Columns.Item(i).ColumnName = columnName
            Else
                If Array.IndexOf(HidenField, i) = -1 Then
                    Me.mytable.Columns.Item(i).ColumnName = columnName
                End If
            End If
        Next i

        For j As Integer = 0 To Me.mytable.Columns.Count - 1
            If HidenField Is Nothing Then
                lstvwINFO.Items.Add(Me.mytable.Columns.Item(j).ColumnName)
            Else
                If Array.IndexOf(HidenField, j) = -1 Then
                    lstvwINFO.Items.Add(Me.mytable.Columns.Item(j).ColumnName)
                End If
            End If
        Next j

    End Sub

    Private Sub lstvwINFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstvwINFO.SelectedIndexChanged
        Try
            Me.Column_name_textbox.Text = Me.lstvwINFO.SelectedItems.Item(0).Text
            AZ_textbox.Enabled = False
            Ta_textbox.Enabled = False
            Action_Combo.Enabled = True
            Add_Button.Enabled = False
        Catch
        End Try
    End Sub

    Private Sub Column_name_textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Column_name_textbox.TextChanged
        Me.Action_Combo.Items.Clear()
        Me.Action_Combo.Text = ""

        Try
            If (Me.mytable.Columns.Item(Me.Column_name_textbox.Text).DataType.ToString = "System.String") Then
                Dim flag As Boolean = False
                If (Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString.Length > 6) Then
                    If ((Not Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString Is Nothing) AndAlso (Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString.Replace(" ", "") = "//")) Then
                        flag = True
                    ElseIf (((Not Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString Is Nothing) AndAlso (Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString.Chars((Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString.Length - 6)) = "/"c)) AndAlso (Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString.Chars((Me.mytable.Rows.Item(0).Item(Me.Column_name_textbox.Text).ToString.Length - 3)) = "/"c)) Then
                        flag = True
                    End If
                End If

                If flag Then
                    Action_Combo.Items.Add("از تاريخ.....تا تاريخ.....")
                    Action_Combo.Items.Add("بعد از تاريخ.......")
                    Action_Combo.Items.Add("قبل از تاريخ......")
                    Action_Combo.Items.Add("مساوی با......")
                    Action_Combo.Items.Add("مخالف با......")
                Else
                    Action_Combo.Items.Add("مساوی با......")
                    Action_Combo.Items.Add("مخالف با......")
                    Action_Combo.Items.Add("شروع شده با....")
                    Action_Combo.Items.Add("شامل....")
                End If
            Else

                Action_Combo.Items.Add("از....تا....")
                Action_Combo.Items.Add("کوچکتر از...")
                Action_Combo.Items.Add("بزرگتر از...")
                Action_Combo.Items.Add("مساوی با....")
                Action_Combo.Items.Add("کوچکتر مساوی با....")
                Action_Combo.Items.Add("بزرگتر مساوی با....")
                Action_Combo.Items.Add("مخالف با....")
            End If
        Catch
        End Try
    End Sub

    Private Sub fill_data()
        Dim text1 As String = ""
        Dim text2 As String = ""
        If (Action_Combo.Text = "از....تا....") Then
            text1 = "از  " + AZ_textbox.Text + "  تا  " + Ta_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] >= " + AZ_textbox.Text + " AND [" + Column_name_textbox.Text + "] <= " + Ta_textbox.Text
        ElseIf Action_Combo.Text = "کوچکتر از..." Then
            text1 = "کوچکتر از " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] < " + AZ_textbox.Text
        ElseIf Action_Combo.Text = "بزرگتر از..." Then
            text1 = "بزرگتر از " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] > " + AZ_textbox.Text
        ElseIf Action_Combo.Text = "مساوی با...." Then
            text1 = "مساوی با " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] = " + AZ_textbox.Text
        ElseIf Action_Combo.Text = "کوچکتر مساوی با...." Then
            text1 = "کوچکتر مساوی با " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] <= " + AZ_textbox.Text
        ElseIf Action_Combo.Text = "بزرگتر مساوی با...." Then
            text1 = " بزرگتر مساوی با " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] >= " + AZ_textbox.Text
        ElseIf Action_Combo.Text = "مخالف با...." Then
            text1 = "مخالف با " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] <> " + AZ_textbox.Text
        ElseIf Action_Combo.Text = "شامل...." Then
            text1 = "شامل   " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] like '%" + AZ_textbox.Text + "%'"
        ElseIf Action_Combo.Text = "شروع شده با...." Then
            text1 = "شروع شده با  " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] like '" + AZ_textbox.Text + "%'"
        ElseIf Action_Combo.Text = "مساوی با......" Then
            text1 = "مساوی با " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] = '" + AZ_textbox.Text + "'"
        ElseIf Action_Combo.Text = "مخالف با......" Then
            text1 = "مخالف با " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] <> '" + AZ_textbox.Text + "'"
        ElseIf Action_Combo.Text = "از تاريخ.....تا تاريخ....." Then
            text1 = "از تاريخ " + AZ_textbox.Text + " تا تاريخ  " + Ta_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] >= '" + AZ_textbox.Text + "' AND [" + Column_name_textbox.Text + "] <= '" + Ta_textbox.Text + "'"
        ElseIf Action_Combo.Text = "بعد از تاريخ......." Then
            text1 = "بعد از تاريخ " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] > '" + AZ_textbox.Text + "'"
        ElseIf Action_Combo.Text = "قبل از تاريخ......" Then
            text1 = "قبل از تاريخ " + AZ_textbox.Text
            text2 = "[" + Column_name_textbox.Text + "] < '" + AZ_textbox.Text + "'"
        End If

        If rbtn_Va.Checked Then
            Me.Filter_condition_Listbox.Items.Add("و " & (Me.Column_name_textbox.Text & " " & text1))
        ElseIf rbtn_Ya.Checked Then
            Me.Filter_condition_Listbox.Items.Add("يا " & (Me.Column_name_textbox.Text & " " & text1))
        End If

        If rbtn_Va.Checked Then
            Me.filterstring_arraylist.Add(" AND " & text2)
        ElseIf rbtn_Ya.Checked Then
            Me.filterstring_arraylist.Add(" OR " & text2)
        End If

        Me.AZ_textbox.Text = ""
        Me.Ta_textbox.Text = ""
    End Sub

    Private Sub Add_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_Button.Click
        If (AZ_textbox.Text = "") Then
            MessageBoxFa.Show("ابتدا عبارت مورد نظر را وارد کنيد", " ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand)
            AZ_textbox.Focus()
        ElseIf (Ta_textbox.Enabled AndAlso (Ta_textbox.Text = "")) Then
            MessageBoxFa.Show("ابتدا عبارت مورد نظر را وارد کنيد", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand)
            Ta_textbox.Focus()
        Else
            If (Me.mytable.Columns.Item(Me.Column_name_textbox.Text).DataType.ToString <> "System.String") Then
                Try
                    Long.Parse(AZ_textbox.Text)
                Catch
                    MessageBoxFa.Show("داده وارده نا معتبر است ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand)
                    AZ_textbox.Focus()
                    AZ_textbox.SelectAll()
                    Return
                End Try
                Try
                    If Ta_textbox.Enabled Then
                        Long.Parse(Ta_textbox.Text)
                    End If
                Catch
                    MessageBoxFa.Show("داده اي غير عددي وارد شده است ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand)
                    Ta_textbox.Focus()
                    Ta_textbox.SelectAll()
                    Return
                End Try
            End If
            fill_data()
        End If
    End Sub

    Private Sub Btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click
        If filterstring_arraylist.Count <> 0 Then
            If (Filter_condition_Listbox.Items.Count = 0) Then
                If File.Exists(Path.GetTempPath() + "\lastshow.xml") Then
                    File.Delete(Path.GetTempPath() + "\lastshow.xml")
                    Application.DoEvents()
                End If
            Else
                Using XmlDoc As New Xml.XmlTextWriter(Path.GetTempPath() + "\lastshow.xml", Encoding.UTF8)
                    XmlDoc.Formatting = Xml.Formatting.Indented
                    XmlDoc.WriteStartDocument()
                    XmlDoc.WriteStartElement("Report")

                    XmlDoc.WriteStartElement("ReportName")
                    XmlDoc.WriteElementString("Name", reportName)
                    XmlDoc.WriteEndElement()

                    XmlDoc.WriteStartElement("Conditions")
                    Dim i1 As Integer
                    For i1 = 0 To Me.filterstring_arraylist.Count - 1
                        XmlDoc.WriteStartElement("Condition")
                        XmlDoc.WriteElementString("Code", Me.filterstring_arraylist.Item(i1).ToString)
                        XmlDoc.WriteElementString("Text", Me.Filter_condition_Listbox.Items.Item(i1).ToString)
                        XmlDoc.WriteEndElement()
                    Next i1
                    XmlDoc.WriteEndElement()
                    XmlDoc.WriteEndElement()
                    XmlDoc.Flush()
                    XmlDoc.Close()
                    Application.DoEvents()
                End Using
            End If

            Dim s As String = ""
            Dim i As Integer
            For i = 0 To filterstring_arraylist.Count - 1
                s += filterstring_arraylist.Item(i).ToString
                'If (i <> (Me.filterstring_arraylist.Count - 1)) Then
                '    s += " AND "
                'End If
            Next i

            Formol = s.Remove(0, 4)

            Try
                ResultView = New DataView(Me.mytable)
                ResultView.RowFilter = Me.input_rowfilter
                If ((ResultView.RowFilter <> "") AndAlso (Not ResultView.RowFilter Is Nothing)) Then
                    ResultView.RowFilter = (Formol & " AND " & ResultView.RowFilter)
                Else
                    ResultView.RowFilter = Formol
                End If

            Catch e1 As Exception
                MessageBoxFa.Show("فايل گزارش مربوط به اين گزارش نيست ...لطفا دوباره امتحان كنيد", "خطا در بازيابي اطلاعات", MessageBoxButtons.OK)
                Exit Sub
            End Try
        End If

        Close()
    End Sub

    Private Sub Action_Combo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Action_Combo.TextChanged
        Me.Ta_textbox.Enabled = False
        Me.AZ_textbox.Enabled = False
        label2_ta.Text = ""
        label_az.Text = ""
        Ta_textbox.Text = ""
        AZ_textbox.Text = ""
        If ((Me.Action_Combo.Text = "از....تا....") OrElse (Me.Action_Combo.Text = "از تاريخ.....تا تاريخ.....")) Then
            Me.Ta_textbox.Enabled = True
            Me.AZ_textbox.Enabled = True
            Me.Add_Button.Enabled = True
            Me.label_az.Text = "از"
            Me.label2_ta.Text = "تا"
        ElseIf ((((Me.Action_Combo.Text = "مساوی با....") _
                OrElse (Me.Action_Combo.Text = "کوچکتر مساوی با....")) _
                OrElse ((Me.Action_Combo.Text = "بزرگتر مساوی با....") _
                OrElse (Me.Action_Combo.Text = "مخالف با...."))) _
                OrElse (((Me.Action_Combo.Text = "شامل....") _
                OrElse (Me.Action_Combo.Text = "شروع شده با....")) _
                OrElse ((Me.Action_Combo.Text = "مساوی با......") _
                OrElse (Me.Action_Combo.Text = "مخالف با......")))) Then
            Me.Add_Button.Enabled = True
            Me.AZ_textbox.Enabled = True
            Me.label_az.Text = "با"
        ElseIf (((Me.Action_Combo.Text = "کوچکتر از...") _
        OrElse (Me.Action_Combo.Text = "بزرگتر از...")) _
        OrElse ((Me.Action_Combo.Text = "بعد از تاريخ.......") _
        OrElse (Me.Action_Combo.Text = "قبل از تاريخ......"))) Then
            Me.Add_Button.Enabled = True
            Me.AZ_textbox.Enabled = True
            Me.label_az.Text = "از"
        Else
            Me.Action_Combo.Text = ""
        End If
    End Sub

    Private Sub btn_SelectReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SelectReport.Click
        If ((Me.openFileDialog1.ShowDialog <> System.Windows.Forms.DialogResult.Cancel) AndAlso (Me.openFileDialog1.FileName.Trim <> "")) Then
            Me.Filter_condition_Listbox.Items.Clear()
            Me.filterstring_arraylist.Clear()
            Using XmlRdr As New Xml.XmlTextReader(Me.openFileDialog1.FileName)
                Do While XmlRdr.Read
                    If ((XmlRdr.NodeType = Xml.XmlNodeType.Element) AndAlso (XmlRdr.Name = "Name")) Then
                        Dim TEmpReportname As String = XmlRdr.ReadString
                        If TEmpReportname.ToLower <> reportName.ToLower Then
                            If MessageBoxFa.Show("فايل گزارش انتخاب شده مربوط به اين گزارش نيست" & vbNewLine _
                            & "ادامه نمايش گزارش با اين فايل امكان ايجاد خطا در برنامه را دارد مايل به ادامه هستيد؟", "", MessageBoxButtons.YesNo) _
                            = System.Windows.Forms.DialogResult.No Then
                                Exit Do
                            End If
                        End If
                        Continue Do
                    End If
                    If ((XmlRdr.NodeType = Xml.XmlNodeType.Element) AndAlso (XmlRdr.Name = "Code")) Then
                        Dim tempText As String = ""
                        Dim tempCode As String = XmlRdr.ReadString
                        Do While XmlRdr.Read
                            If ((XmlRdr.NodeType = Xml.XmlNodeType.Element) AndAlso (XmlRdr.Name = "Text")) Then
                                tempText = XmlRdr.ReadString.Replace("[", "").Replace("]", "")
                                Exit Do
                            End If
                        Loop
                        If (tempText = "empty") Then
                            Continue Do
                        End If
                        Me.Filter_condition_Listbox.Items.Add(tempText)
                        Me.filterstring_arraylist.Add(tempCode)
                    End If
                Loop
                XmlRdr.Close()
            End Using
        End If
    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If (Filter_condition_Listbox.Items.Count = 0) Then
            MessageBoxFa.Show("لطفا ابتدا شروط گزارش را براي ذخيره شدن انتخاب كنيد")
        Else
            If Me.saveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                Return
            End If
            If (Me.saveFileDialog1.FileName <> "") Then
                Using XmlDoc As New Xml.XmlTextWriter(Me.saveFileDialog1.FileName, Encoding.UTF8)
                    XmlDoc.Formatting = Xml.Formatting.Indented
                    XmlDoc.WriteStartDocument()
                    XmlDoc.WriteStartElement("Report")

                    XmlDoc.WriteStartElement("ReportName")
                    XmlDoc.WriteElementString("Name", reportName)
                    XmlDoc.WriteEndElement()

                    XmlDoc.WriteStartElement("Conditions")
                    Dim i As Integer
                    For i = 0 To Me.filterstring_arraylist.Count - 1
                        XmlDoc.WriteStartElement("Condition")
                        XmlDoc.WriteElementString("Code", Me.filterstring_arraylist.Item(i).ToString)
                        XmlDoc.WriteElementString("Text", Me.Filter_condition_Listbox.Items.Item(i).ToString)
                        XmlDoc.WriteEndElement()
                    Next i
                    XmlDoc.WriteEndElement()
                    XmlDoc.WriteEndElement()
                    XmlDoc.Close()
                End Using
            End If
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If (Me.Filter_condition_Listbox.Items.Count = 0) Then
            MessageBoxFa.Show("هيچ شرطی برای حذف شدن وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf (Me.Filter_condition_Listbox.SelectedItems.Count = 0) Then
            MessageBoxFa.Show("هيچ شرطی برای حذف انتخاب نشده", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        ElseIf (MessageBoxFa.Show("شروط انتخاب شده حذف شوند؟", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.No) Then
            Dim i As Integer
            For i = 0 To Me.Filter_condition_Listbox.Items.Count
                Try
                    If Me.Filter_condition_Listbox.GetSelected(i) Then
                        Me.Filter_condition_Listbox.Items.RemoveAt(i)
                        Me.filterstring_arraylist.RemoveAt(i)
                        i -= 1
                    End If
                Catch ex As Exception
                End Try
            Next i
        End If
    End Sub

    Private Sub btn_selectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectAll.Click
        If (Me.Filter_condition_Listbox.Items.Count = 0) Then
            MessageBoxFa.Show("هيچ شرطی برای انتخاب شدن وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Else
            Dim i As Integer
            For i = 0 To Me.Filter_condition_Listbox.Items.Count - 1
                Me.Filter_condition_Listbox.SetSelected(i, True)
            Next i
        End If
    End Sub

    Private Sub FormulBuilder_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class

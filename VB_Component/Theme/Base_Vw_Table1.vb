Public Class Base_Vw_Table1

    Dim tablenames As String = ""
    Dim FieldName As String = ""
    Dim Condition As String = ""
    Dim SaveMode As Boolean = True
    Dim da As CS_Component.DataAccess

    Public Overrides Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            Btn_new_Click(sender, e)
            Btn_Delete.Enabled = True
            Btn_Edit.Enabled = True
        ElseIf e.KeyCode = Keys.F3 Then
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBoxFa.Show("لطفا يك رديف را انتخاب كنيد")
            End If
            If MessageBoxFa.Show("مايل به ويرايش رديف هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.No Then
                Return
            End If
            MyBase.Btn_Edit_Click(sender, e)
            Btn_Edit_Click(sender, e)
        ElseIf e.KeyCode = Keys.Escape AndAlso MyBase.FormState = FormStates.Edit Then
            Btn_Edit.Tag = 0
            Btn_Delete.Enabled = True
            Btn_Edit.Enabled = True
            VB_Component.Windows.EmptyControls(GroupBox3)
            DataGridView1.Enabled = True
            MyBase.FormState = FormStates.Submit
        Else
            MyBase.Form1_KeyDown(sender, e)
        End If
    End Sub

    Private Sub FillDatagrid()
        Dim dt As New Data.DataTable()
        dt.Load(da.GetRows(tablenames, Condition))
        DataGridView1.DataSource = dt
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = lbl_Value.Text
        DataGridView1.Columns(1).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill

        For index As Integer = 2 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(index).Visible = False
        Next
    End Sub

    Public Sub New(ByRef da As CS_Component.DataAccess, ByVal TableName As String, ByVal NameOfLable As String, ByVal CaptionName As String _
    , ByVal Condition As String, ByVal FieldName As String)
        InitializeComponent()
        Me.tablenames = TableName
        lbl_Value.Text = NameOfLable
        Me.Condition = Condition
        Me.FieldName = FieldName
        Text = CaptionName
        Me.da = da
    End Sub

    Private Sub Btn_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Delete.Click
        Dim str As String = VB_Component.Windows.GetSrl(DataGridView1, True, True)
        If str = -1 Then
            Return
        End If
        da.Delete(tablenames, Integer.Parse(str))
        FillDatagrid()
    End Sub

    Private Sub Btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_new.Click
        If VB_Component.Windows.ValidateFields(GroupBox2, False) = False Then
            Return
        End If

        If da.ExistNum(tablenames, FieldName, tbox_VAlue.Text) <> 0 Then
            MessageBoxFa.Show("اين مقدار قبلا وارد شده")
            Return
        End If

        If SaveMode Then
            Dim dr As Data.DataRow = da.NewRow(tablenames)

            dr(FieldName) = tbox_VAlue.Text
            If Not da.Insert(dr, False) Then
                MessageBoxFa.Show("خطا")
            End If
        Else
            Dim dr As Data.DataRow = da.NewRow(tablenames)

            Try
                For index As Integer = 0 To dr.Table.Columns.Count - 1
                    If dr.Table.PrimaryKey(0).ColumnName = dr.Table.Columns(index).Caption Then
                        Continue For
                    End If
                    If dr.Table.Columns(index).Caption <> FieldName Then
                        dr.Table.Columns.Remove(dr.Table.Columns(index))
                        index = index - 1
                    End If
                Next
            Catch ex As Exception

            End Try

            dr("srl") = DataGridView1.CurrentRow.Cells(0).Value.ToString
            dr(FieldName) = tbox_VAlue.Text

            If Not da.Update(dr, 0) Then
                MessageBoxFa.Show("خطا")
            End If
            SaveMode = True
        End If

        FillDatagrid()
        Btn_new.Focus()
        VB_Component.Windows.EmptyControls(GroupBox3)

    End Sub

    Public Sub Btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Edit.Click
        If Not DataGridView1.CurrentRow Is Nothing Then
            If MessageBoxFa.Show("مايل به ويرايش رديف هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.No Then
                Return
            End If
            tbox_VAlue.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            SaveMode = False
        Else
            MessageBoxFa.Show("لطفا يك رديف را انتخاب كنيد")
        End If
    End Sub

    Private Sub Base_Vw_Table1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDatagrid()
    End Sub
End Class

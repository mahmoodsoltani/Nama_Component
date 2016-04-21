Imports System
Imports System.Windows.Forms

Public Class TimeColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New TimeCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a TimeCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(TimeCell)) _
                Then
                Throw New InvalidCastException("Must be a TimeCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class TimeCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        ' Me.Style.Format = "d"
        Me.Value = "00:00"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As TimeEditingControl = _
            CType(DataGridView.EditingControl, TimeEditingControl)
        ctl.ShowSecond = False
        ' Use the default row value when Value property is null.
        If (Me.Value Is Nothing Or Me.Value Is DBNull.Value) Then
            ctl.Value = CType(Me.DefaultNewRowValue, String)
        Else
            ctl.Value = CType(Me.Value, String)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that TimeCell uses.
            Return GetType(TimeEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that TimeCell contains.
            Return GetType(String)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return "00:00:00"
        End Get
    End Property

End Class

Class TimeEditingControl
    Inherits TimeSelect
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        'Me.Format = DateTimePickerFormat.Short
        Me.ShowSecond = False
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is 
                ' null, empty, or not in the format of a date.
                Me.ShowSecond = False
                Me.Value = value
            Catch
                ' In the case of an exception, just use the default
                Me.ShowSecond = False
                ' value so we're not left with a null value.
                Me.Value = "00:00:00"
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Me.ShowSecond = False
        Return Me.Value

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ShowSecond = False
        'Me.TimeForeColor = dataGridViewCellStyle.ForeColor
        'Me.TimeMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property


    'Public Overrides Sub NDU_Hour_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim i As Integer = 0
    '    i = i / i
    '    'MyBase.NDU_Hour_ValueChanged(sender, e)
    '    'Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
    '    'valueIsChanged = True
    'End Sub
    'Public Overrides Sub NDU_Second_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MyBase.NDU_Second_ValueChanged(sender, e)
    '    Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
    '    valueIsChanged = True
    'End Sub
    'Public Overrides Sub NDU_Min_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MyBase.NDU_Min_ValueChanged(sender, e)
    '    Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
    '    valueIsChanged = True
    'End Sub

    'Public Overrides (ByVal eventargs As EventArgs)

    '' Notify the DataGridView that the contents of the cell have changed.
    '    valueIsChanged = True
    '    Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
    '    MyBase.Finalize_Result ()

    'End Sub

End Class
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class ComboBox
    Inherits System.Windows.Forms.ComboBox
    Dim Str_Temp As String = ""
    Dim _OpenOnFoucus As Boolean = False
    Dim _IsRequired As Boolean = False
    Private _EnterStop As Boolean = True
    Private _AutoComplete As Boolean = True
    Private _LimitedToList As Boolean = True

    <Category("Nama"), Description("If true go on to the  next control by enter"), Browsable(True)> _
   Public Property EnterStop() As Boolean
        Get
            Return _EnterStop
        End Get
        Set(ByVal value As Boolean)
            _EnterStop = value
        End Set
    End Property

    <Category("Nama"), Description("If true Search List Item By Type Each Letter"), Browsable(True)> _
    Public Property AutoComplete() As Boolean
        Get
            Return _AutoComplete
        End Get
        Set(ByVal value As Boolean)
            _AutoComplete = value
        End Set
    End Property

    <Category("Nama"), Description("If true Search Just Combobox Item"), Browsable(True)> _
    Public Property LimitedToList() As Boolean
        Get
            Return _LimitedToList
        End Get
        Set(ByVal value As Boolean)
            _LimitedToList = value
        End Set
    End Property

    <Category("Nama"), Description("true if u want Validate value Of ComboBox after click save"), Browsable(True)> _
    Public Property IsRequired() As Boolean
        Get
            Return _IsRequired
        End Get
        Set(ByVal value As Boolean)
            _IsRequired = value
        End Set
    End Property

    <Category("Nama"), Description("Open ComboBox On Got Focus"), Browsable(True)> _
    Public Property OpenOnFoucus() As Boolean
        Get
            Return Me._OpenOnFoucus
        End Get
        Set(ByVal value As Boolean)
            Me._OpenOnFoucus = value
        End Set
    End Property

    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        If _OpenOnFoucus Then
            Me.DroppedDown = True
        End If
        MyBase.OnGotFocus(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim s As Integer = e.KeyCode
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    'Added By iman For Auto Complete
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If _AutoComplete Then
            DoAutoComplete(Me, e, _LimitedToList)
        End If
    End Sub

    Public Sub DoAutoComplete(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal blnLimitToList As Boolean = False)
        Dim strFindStr As String
        If e.KeyChar = Chr(8) Then  'Backspace
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Exit Sub
            End If
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text & e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
            End If
        End If

        Dim intIdx As Integer = -1

        ' Search the string in the Combo Box List.
        intIdx = cb.FindString(strFindStr)

        If intIdx <> -1 Then ' String found in the List.
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            If blnLimitToList = True Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub

End Class

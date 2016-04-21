Option Explicit On
Imports System.ComponentModel

Public Class BaseForm_Old

    Dim _PromtOnClose As Boolean = False
    Dim _GoOnEnter As Boolean = True
    Dim _GoOnUpDown As Boolean = True
    Private xCapture As Integer = 0
    Private yCapture As Integer = 0
    Private CaptionMoving As Boolean = False
    Dim _MaximizeToDesktopBound As Boolean = False
    Dim _ShowFoterStatusStrip As Boolean = True
    Public FormState As FormStates = FormStates.Submit

    Public TableName As String
    Public BaseSrl As Integer

    Public Enum FormStates
        Edit
        Submit
        Normal
    End Enum

    'Private Const CS_DROPSHADOW As Integer = 131072
    '' Override the CreateParams property
    'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
    '        Return cp
    '    End Get
    'End Property

    <Category("ALis Config"), Description("نمايش استتوس استريپ در پايين صفحه"), Browsable(True)> _
     Public Property ShowFoterStatusStrip() As Boolean
        Get
            Return _ShowFoterStatusStrip
        End Get
        Set(ByVal value As Boolean)
            _ShowFoterStatusStrip = value
            statusStrip1.Visible = _ShowFoterStatusStrip
        End Set
    End Property

    <Category("ALis Config"), Description("اندازه فرم را به بيشترين اندازه دسكتاپ تغيير ميدهد"), Browsable(True)> _
     Public Property MaximizeToDesktopBound() As Boolean
        Get
            Return _MaximizeToDesktopBound
        End Get
        Set(ByVal value As Boolean)
            _MaximizeToDesktopBound = value
        End Set
    End Property

    <Category("ALis Config"), Description("نمايش پيغام هنگام بستن برنامه"), Browsable(True)> _
   Public Property PromtOnClose() As Boolean
        Get
            Return _PromtOnClose
        End Get
        Set(ByVal value As Boolean)
            _PromtOnClose = value
        End Set
    End Property

    <Category("ALis Config"), Description("حركت روي كنترل هاي فرم با اينتر"), Browsable(True)> _
    Public Property GoOnEnter() As Boolean
        Get
            Return _GoOnEnter
        End Get
        Set(ByVal value As Boolean)
            _GoOnEnter = value
        End Set
    End Property

    <Category("ALis Config"), Description("حركت روي كنترل هاي فرم باآپ دون"), Browsable(True)> _
    Public Property GoOnUpDown() As Boolean
        Get
            Return _GoOnUpDown
        End Get
        Set(ByVal value As Boolean)
            _GoOnUpDown = value
        End Set
    End Property

    Public Overridable Sub Base_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If VB_Component.Windows.ArrayOfString("temp") Then
        '    Me.Dispose()
        'End If
        If _MaximizeToDesktopBound Then
            Me.Location = New Point(0, 0)
            Me.Size = New Drawing.Size(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height)
            Application.DoEvents()
            OnResize(e)
        End If
    End Sub

    Public Overridable Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        If _PromtOnClose Then
            If MessageBoxFa.Show("مايل به خروج از فرم هستيد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = System.Windows.Forms.DialogResult.Yes Then
                Close()
            Else
                Return
            End If
        Else
            Close()
        End If
    End Sub

    Public Overridable Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If FormState <> FormStates.Edit Then
                btn_close_Click(sender, e)
            End If
        End If

        If e.KeyCode = Keys.Enter Then
            If TypeOf MyBase.ActiveControl Is CS_Component.DataGridView OrElse _
            TypeOf MyBase.ActiveControl Is CS_Component.Btn Then
                Return
            End If

            If _GoOnEnter Then
                Me.ProcessTabKey(True)
            End If
        End If

        If e.KeyCode = Keys.F10 Then
            Dim currentlang As String = InputLanguage.CurrentInputLanguage.LayoutName
            If (currentlang = "US") Then
                VB_Component.Windows.ChangeLangToFarsi(True)
            Else
                VB_Component.Windows.ChangeLangToFarsi(False)
            End If
        End If

        If e.KeyCode = Keys.Up Then
            If _GoOnEnter Then
                If TypeOf MyBase.ActiveControl Is ListBox _
                OrElse TypeOf MyBase.ActiveControl Is CS_Component.DataGridView _
                OrElse TypeOf MyBase.ActiveControl Is DataGridViewComboBoxEditingControl _
                OrElse TypeOf MyBase.ActiveControl Is VB_Component.ComboBox Then
                    Return
                End If
                ProcessTabKey(False)
            End If
        End If

        If e.KeyCode = Keys.Down Then
            If _GoOnEnter Then
                If TypeOf MyBase.ActiveControl Is ListBox _
                OrElse TypeOf MyBase.ActiveControl Is DataGridViewComboBoxEditingControl _
                OrElse TypeOf MyBase.ActiveControl Is CS_Component.DataGridView _
                OrElse TypeOf MyBase.ActiveControl Is VB_Component.ComboBox Then
                    Return
                End If
                ProcessTabKey(True)
            End If
        End If

        If e.KeyCode = Keys.Left Then
            If _GoOnEnter Then
                If TypeOf MyBase.ActiveControl Is VB_Component.ComboBox Then
                    ProcessTabKey(True)
                End If
            End If
        End If

        If e.KeyCode = Keys.Right Then
            If _GoOnEnter Then
                If TypeOf MyBase.ActiveControl Is VB_Component.ComboBox Then
                    ProcessTabKey(False)
                End If
            End If
        End If
    End Sub

    Private Sub Base_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
        End If
        If e.KeyChar = Convert.ToChar(27) Then
            e.Handled = True
        End If

        If e.KeyChar = "ك"c Then
            e.KeyChar = "ک"c
        End If

        If e.KeyChar = "ی"c Then
            e.KeyChar = "ي"c
        End If
    End Sub

    'Private Sub BaseForm_ClientSizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ClientSizeChanged
    '    If Me.WindowState = FormWindowState.Minimized Then
    '        'For Each frmForm As Form In Application.OpenForms
    '        '    frmForm.WindowState = FormWindowState.Minimized
    '        'Next
    '        'Call ShowDesktop()
    '    End If
    'End Sub
End Class
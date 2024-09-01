Imports System.Runtime.InteropServices
Imports System.Text

Public Class MessageBoxFa
    Public Delegate Function CallBack_WinProc(ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Public Delegate Function CallBack_EnumWinProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowLong(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    End Function
    <DllImport("kernel32.dll")> _
    Private Shared Function GetCurrentThreadId() As Integer
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As CallBack_WinProc, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function UnhookWindowsHookEx(ByVal hHook As Integer) As Integer
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SetWindowText(ByVal hwnd As Integer, ByVal lpString As String) As Integer
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function EnumChildWindows(ByVal hWndParent As Integer, ByVal lpEnumFunc As CallBack_EnumWinProc, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function GetClassName(ByVal hwnd As Integer, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

    Shared TopCount As Integer
    Shared ButtonCount As Integer
    Private Const GWL_HINSTANCE As Integer = (-6)
    Private Const HCBT_ACTIVATE As Integer = 5
    Private Const WH_CBT As Integer = 5
    Private Shared hHook As Integer
    Shared strCaption1 As String = ""
    Shared strCaption2 As String = ""
    Shared strCaption3 As String = ""
    Shared Drk As New Form

    Shared Function Show(ByVal Prompt As String _
        , ByVal Title As String _
        , ByVal buttons As MessageBoxButtons _
        , ByVal icon As MessageBoxIcon _
        , ByVal DefaultButton As MessageBoxDefaultButton _
        , ByVal options As MessageBoxOptions _
        , ByVal m As MsgBoxStyle) As DialogResult

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Shared Function Show(ByVal Prompt As String _
        , ByVal Title As String _
        , ByVal buttons As MessageBoxButtons _
        , ByVal icon As MessageBoxIcon _
        , ByVal DefaultButton As MessageBoxDefaultButton _
        , ByVal options As MessageBoxOptions) As DialogResult

        Dim m As MsgBoxStyle = MsgBoxStyle.ApplicationModal

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Shared Function Show(ByVal Prompt As String _
      , ByVal Title As String _
      , ByVal buttons As MessageBoxButtons _
      , ByVal icon As MessageBoxIcon _
      , ByVal DefaultButton As MessageBoxDefaultButton) As DialogResult

        Dim options As MessageBoxOptions = MessageBoxOptions.RtlReading
        Dim m As MsgBoxStyle = MsgBoxStyle.ApplicationModal

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Shared Function Show(ByVal Prompt As String _
    , ByVal Title As String _
    , ByVal buttons As MessageBoxButtons _
    , ByVal icon As MessageBoxIcon) As DialogResult

        Dim DefaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
        Dim options As MessageBoxOptions = MessageBoxOptions.RtlReading
        Dim m As MsgBoxStyle = MsgBoxStyle.ApplicationModal

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Shared Function Show(ByVal Prompt As String _
     , ByVal Title As String _
     , ByVal buttons As MessageBoxButtons) As DialogResult

        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Dim DefaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
        Dim options As MessageBoxOptions = MessageBoxOptions.RtlReading
        Dim m As MsgBoxStyle = MsgBoxStyle.ApplicationModal

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Shared Function Show(ByVal Prompt As String _
     , ByVal Title As String) As DialogResult

        Dim buttons As MessageBoxButtons = MessageBoxButtons.OK
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Dim DefaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
        Dim options As MessageBoxOptions = MessageBoxOptions.RtlReading
        Dim m As MsgBoxStyle = MsgBoxStyle.ApplicationModal

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Shared Function Show(ByVal Prompt As String) As DialogResult

        Dim Title As String = ""
        Dim buttons As MessageBoxButtons = MessageBoxButtons.OK
        Dim icon As MessageBoxIcon = MessageBoxIcon.None
        Dim DefaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1
        Dim options As MessageBoxOptions = MessageBoxOptions.RtlReading
        Dim m As MsgBoxStyle = MsgBoxStyle.ApplicationModal

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0
        Select Case (buttons)
            Case MessageBoxButtons.AbortRetryIgnore
                strCaption1 = "رها کردن"
                strCaption2 = "کوشش مجدد"
                strCaption3 = "چشم پوشی"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
            Case MessageBoxButtons.OKCancel
                strCaption1 = "تایید"
                strCaption2 = "لغو"
            Case MessageBoxButtons.RetryCancel
                strCaption1 = "کوشش مجدد"
                strCaption2 = "لغو"
            Case MessageBoxButtons.YesNo
                strCaption1 = "بله"
                strCaption2 = "خیر"
            Case MessageBoxButtons.YesNoCancel
                strCaption1 = "بله"
                strCaption2 = "خیر"
                strCaption3 = "لغو"
            Case MessageBoxButtons.OK
                strCaption1 = "تایید"
        End Select
        'If Title = "" Then Title = Application.ProductName
        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)
        hInst = GetWindowLong(1, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)
        'Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
        Return MsgBox(Prompt, buttons + icon + DefaultButton + MsgBoxStyle.MsgBoxRight + options + m, Title)
    End Function

    Private Shared Function WinProc(ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        Dim myEnumProc As CallBack_EnumWinProc = New CallBack_EnumWinProc(AddressOf EnumWinProc)
        If uMsg = HCBT_ACTIVATE Then
            EnumChildWindows(wParam, myEnumProc, 0)
            UnhookWindowsHookEx(hHook)
        End If
        Return 0
    End Function

    Private Shared Function EnumWinProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer
        Dim strBuffer As StringBuilder = New StringBuilder(256)
        TopCount += 1
        GetClassName(hWnd, strBuffer, strBuffer.Capacity)
        Dim ss As String = strBuffer.ToString()
        If (ss.ToUpper().StartsWith("BUTTON")) Then
            ButtonCount += 1
            Select Case (ButtonCount)
                Case 1
                    SetWindowText(hWnd, strCaption1)
                    Exit Select
                Case 2
                    SetWindowText(hWnd, strCaption2)
                    Exit Select
                Case 3
                    SetWindowText(hWnd, strCaption3)
                    Exit Select
            End Select
        End If
        Return 1
    End Function
End Class


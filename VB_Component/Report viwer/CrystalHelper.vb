Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions
Imports System.Diagnostics.CodeAnalysis
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing

Public Class CrystalHelper

    <SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")> _
 Public Shared Sub ReplaceReportName(ByVal viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal newName As String)
        If (viewer Is Nothing) Then
            Throw New ArgumentNullException("viewer")
        End If
        'If ((oldName Is Nothing) OrElse (oldName.Length = 0)) Then
        '    Throw New ArgumentException("May not be empty.", "oldName")
        'End If
        Dim control As System.Windows.Forms.Control
        For Each control In viewer.Controls
            If (String.Compare(control.GetType.Name, "PageView", True, CultureInfo.InvariantCulture) = 0) Then
                Dim controlInPage As System.Windows.Forms.Control
                For Each controlInPage In control.Controls
                    If (String.Compare(controlInPage.GetType.Name, "TabControl", True, CultureInfo.InvariantCulture) = 0) Then
                        Dim tabs As TabControl = DirectCast(controlInPage, TabControl)
                        Dim tabPage As TabPage
                        For Each tabPage In tabs.TabPages
                            'If (String.Compare(tabPage.Text, oldName, False, CultureInfo.InvariantCulture) = 0) Then
                            tabPage.Text = newName
                            'Return
                            'End If
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    <SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")> _
    Public Shared Sub ViewerTabs(ByVal viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal visible As Boolean)
        If (viewer Is Nothing) Then
            Throw New ArgumentNullException("viewer")
        End If
        Dim control As System.Windows.Forms.Control
        For Each control In viewer.Controls
            If (String.Compare(control.GetType.Name, "PageView", True, CultureInfo.InvariantCulture) = 0) Then
                Dim tab As TabControl = DirectCast(DirectCast(control, CrystalDecisions.Windows.Forms.PageView).Controls.Item(0), TabControl)
                If Not visible Then
                    tab.ItemSize = New Size(0, 1)
                    tab.SizeMode = TabSizeMode.Fixed
                    tab.Appearance = TabAppearance.Buttons
                Else
                    tab.ItemSize = New Size(67, 18)
                    tab.SizeMode = TabSizeMode.Normal
                    tab.Appearance = TabAppearance.Normal
                End If
            End If
        Next
    End Sub
End Class

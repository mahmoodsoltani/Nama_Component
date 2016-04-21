Imports System.ComponentModel
Public Class BackgroundLoading
    Public Bw As BackgroundWorker
    Private newLoading As LoadingForm
    Public thisFunction As RunFunction
    Public Delegate Sub RunFunction()
    Dim lable As String

    Public Sub New(ByVal newFunction As RunFunction, ByVal lable As String)
        Me.thisFunction = newFunction
        Me.Bw = New BackgroundWorker
        AddHandler Me.Bw.DoWork, New DoWorkEventHandler(AddressOf Me.Bw_DoWork)
        AddHandler Me.Bw.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf Me.Bw_RunWorkerCompleted)
        Me.lable = lable
    End Sub

    Private Sub Bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        thisFunction.Invoke()
    End Sub

    Private Sub Bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If Not newLoading Is Nothing Then
            newLoading.Dispose()
        End If
    End Sub

    Public Sub Start()
        Bw.RunWorkerAsync()
        newLoading = New LoadingForm(lable)
        newLoading.ShowDialog()
    End Sub
End Class



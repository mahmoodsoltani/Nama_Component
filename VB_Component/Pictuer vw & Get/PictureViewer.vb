Public Class PictureViewer

    Private Sub btn_ZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ZoomIn.Click
        ImageControl1.StretchImageToFit = False
        ImageControl1.ZoomIn()
    End Sub

    Private Sub btn_ZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ZoomOut.Click
        ImageControl1.StretchImageToFit = False
        ImageControl1.ZoomOut()
    End Sub

    Private Sub btn_RotatRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RotatRight.Click
        ImageControl1.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub btn_Stresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stresh.Click
        ImageControl1.StretchImageToFit = True
        ImageControl1.Refresh()
    End Sub

    Private Sub btn_NormalSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NormalSize.Click
        ImageControl1.fittoscreen()
        ImageControl1.Refresh()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GrayScale.Click
        ImageControl1.DoGrayeScale()
        ImageControl1.Refresh()
    End Sub
End Class

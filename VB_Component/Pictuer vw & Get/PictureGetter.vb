Imports System.IO

Public Class PictureGetter

    Private Sub lnk_clear_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnk_clear.LinkClicked
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PictureGetter))
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    End Sub

    Private Sub lnk_SelectPic_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnk_SelectPic.LinkClicked
        Try
            If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim p As New Bitmap(OpenFileDialog1.FileName)

                If _SizeOfImage <> 0 Then
                    Dim f As New FileInfo(OpenFileDialog1.FileName)
                    Dim fileSizeKB As Double = f.Length / 1024
                    If _SizeOfImage < fileSizeKB Then
                        MessageBoxFa.Show("سايز عکس از حد مجاز بيشتر است")
                        OpenFileDialog1.FileName = ""
                        Return
                    End If
                End If
             
                PictureBox1.Image = p
            End If
        Catch ex As Exception
            MessageBoxFa.Show("لطفا فايل ورودي را بدرستي انتخاب كنيد")
        End Try
    End Sub

    Public _SizeOfImage As String
    Public Property SizeOfImage() As Double
        Get
            Return _SizeOfImage
        End Get
        Set(ByVal value As Double)
            _SizeOfImage = value
        End Set
    End Property

    Public Property Image() As Byte()
        Get
            If PictureBox1.Image Is Nothing Then
                Return Nothing
            End If
            Return Graphic.ImageToStream(PictureBox1)
        End Get
        Set(ByVal value As Byte())
            If value Is Nothing Then
                Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PictureGetter))
                PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
            Else
                PictureBox1.Image = Graphic.ByteToImage(value)
            End If
        End Set
    End Property

    Public Event ImageClicked As EventHandler

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        RaiseEvent ImageClicked(Nothing, Nothing)
    End Sub
End Class

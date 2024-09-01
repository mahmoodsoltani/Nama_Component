Imports System.Drawing.Drawing2D
Imports System.IO

Public Class Graphic

#Region "Gradiant"
    'PaintGradient(panel1, LinearGradientMode.ForwardDiagonal, Color.White, Color.DarkBlue);
    Public Shared Sub PaintGradient(ByVal _control As Control, ByVal _direction As LinearGradientMode, ByVal _gradientColorStart As Color, ByVal _gradientColorEnd As Color)
        Dim gradBrush As New LinearGradientBrush(New Rectangle(0, 0, _control.Width, _control.Height), _gradientColorStart, _gradientColorEnd, _direction)
        Dim bmp As New Bitmap(_control.Width, _control.Height)
        Graphics.FromImage(bmp).FillRectangle(gradBrush, New Rectangle(0, 0, _control.Width, _control.Height))
        _control.BackgroundImage = bmp
        _control.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
#End Region

#Region "GrayScaleImage"
    '  Me.GrayScaleImage(Me.pictureBox2.CreateGraphics, Me.pictureBox1.Image, 0, 0)
    Public Shared Function GrayScaleImage(ByVal graph As Graphics, ByVal img As Image, ByVal left As Integer, ByVal top As Integer) As Image
        Dim colorMix As New Imaging.ColorMatrix With {
            .Matrix00 = 0.3333333!,
            .Matrix01 = 0.3333333!,
            .Matrix02 = 0.3333333!,
            .Matrix10 = 0.3333333!,
            .Matrix11 = 0.3333333!,
            .Matrix12 = 0.3333333!,
            .Matrix20 = 0.3333333!,
            .Matrix21 = 0.3333333!,
            .Matrix22 = 0.3333333!
        }
        Dim imgAttrib As New Imaging.ImageAttributes
        imgAttrib.SetColorMatrix(colorMix)
        graph.DrawImage(img, New Rectangle(left, top, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttrib)
        Return New Bitmap(img)
    End Function

    Public Shared Function GrayScaleImage(ByVal graph As Graphics, ByVal img As Image) As Image
        Dim colorMix As New Imaging.ColorMatrix With {
            .Matrix00 = 0.3333333!,
            .Matrix01 = 0.3333333!,
            .Matrix02 = 0.3333333!,
            .Matrix10 = 0.3333333!,
            .Matrix11 = 0.3333333!,
            .Matrix12 = 0.3333333!,
            .Matrix20 = 0.3333333!,
            .Matrix21 = 0.3333333!,
            .Matrix22 = 0.3333333!
        }
        Dim imgAttrib As New Imaging.ImageAttributes
        imgAttrib.SetColorMatrix(colorMix)
        graph.DrawImage(img, New Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttrib)
        Return New Bitmap(img)
    End Function
#End Region

#Region "ImageToStream"
    Public Shared Function ByteArrayToFile(ByVal PathToSave As String _
                                           , ByVal Buffer As Byte()) As Boolean
        Try
            Using stream As New FileStream(PathToSave, FileMode.Create, FileAccess.Write)
                stream.Write(Buffer, 0, Buffer.Length)
                stream.Close()
            End Using
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Shared Function FileToByteArray(ByVal FilePath As String) As Byte()
        Using stream As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Using reader As New BinaryReader(stream)
                Dim ByteFile As Byte() = reader.ReadBytes(stream.Length)
                reader.Close()
                stream.Close()
                Return ByteFile
            End Using
        End Using
    End Function

    Public Shared Function ImageToStream(ByVal obj As PictureBox) As Byte()
        If obj.Image Is Nothing Then
            Return Nothing
        End If
        Dim image As New Bitmap(obj.Image)
        Dim stream As New System.IO.MemoryStream
        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
        Return stream.ToArray
    End Function

    Public Shared Function ImageToStream(ByVal obj As System.Drawing.Image) As Byte()
        If obj Is Nothing Then
            Return Nothing
        End If
        Dim image As New Bitmap(obj)
        Dim stream As New System.IO.MemoryStream
        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
        Return stream.ToArray
    End Function

    Public Shared Function ImageToStream(ByVal obj As System.Drawing.Bitmap) As Byte()
        If obj Is Nothing Then
            Return Nothing
        End If
        Dim stream As New System.IO.MemoryStream
        obj.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
        Return stream.ToArray
    End Function

    Public Shared Function ByteToImage(ByVal obj As Byte()) As Image
        If obj Is Nothing Then
            Return Nothing
        End If
        Dim streamData As New MemoryStream(obj)
        Try
            Return Image.FromStream(streamData)
        Catch
        End Try
        Return Nothing
    End Function

#End Region

End Class

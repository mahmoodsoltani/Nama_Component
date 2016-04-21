Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace PictuerViewer
    <ComVisible(False), DesignerGenerated()> _
    Friend Class DrawingBoard
        Inherits UserControl
        ' Events
        Public Event SetScrollPositions As SetScrollPositionsEventHandler

        ' Methods
        Public Sub New()
            AddHandler MyBase.MouseUp, New MouseEventHandler(AddressOf Me.DrawingBoard_MouseUp)
            AddHandler MyBase.MouseWheel, New MouseEventHandler(AddressOf Me.ImageViewer_MouseWheel)
            AddHandler MyBase.Resize, New EventHandler(AddressOf Me.DrawingBoard_Resize)
            AddHandler MyBase.MouseDown, New MouseEventHandler(AddressOf Me.ImageViewer_MouseDown)
            AddHandler MyBase.MouseMove, New MouseEventHandler(AddressOf Me.ImageViewer_MouseMove)
            Me.m_MouseButtons = System.Windows.Forms.MouseButtons.Left
            Me.m_Origin = New Point(0, 0)
            Me.m_ZoomOnMouseWheel = True
            Me.m_ZoomFactor = 1
            Me.m_ApparentImageSize = New Size(0, 0)
            Me.m_PanMode = True
            Me.m_StretchImageToFit = False
            Me.m_Select_Pen = New Pen(Color.Blue, 2.0!)
            Me.InitializeComponent()
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
        End Sub

        Private Sub CheckBounds()
            If (Not Me.m_OriginalImage Is Nothing) Then
                If (Me.m_Origin.X < 0) Then
                    Me.m_Origin.X = 0
                End If
                If (Me.m_Origin.Y < 0) Then
                    Me.m_Origin.Y = 0
                End If
                If (Me.m_Origin.X > (Me.m_OriginalImage.Width - (CDbl(Me.ClientSize.Width) / Me.m_ZoomFactor))) Then
                    Me.m_Origin.X = CInt(Math.Round(CDbl((Me.m_OriginalImage.Width - (CDbl(Me.ClientSize.Width) / Me.m_ZoomFactor)))))
                End If
                If (Me.m_Origin.Y > (Me.m_OriginalImage.Height - (CDbl(Me.ClientSize.Height) / Me.m_ZoomFactor))) Then
                    Me.m_Origin.Y = CInt(Math.Round(CDbl((Me.m_OriginalImage.Height - (CDbl(Me.ClientSize.Height) / Me.m_ZoomFactor)))))
                End If
                If (Me.m_Origin.X < 0) Then
                    Me.m_Origin.X = 0
                End If
                If (Me.m_Origin.Y < 0) Then
                    Me.m_Origin.Y = 0
                End If
            End If
        End Sub

        Private Sub ComputeDrawingArea()
            Me.m_DrawHeight = CInt(Math.Round(CDbl((CDbl(Me.Height) / Me.m_ZoomFactor))))
            Me.m_DrawWidth = CInt(Math.Round(CDbl((CDbl(Me.Width) / Me.m_ZoomFactor))))
        End Sub

        <DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (IIf((disposing AndAlso (Not Me.components Is Nothing)), 1, 0) <> 0) Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub Draw_Rectangle(ByVal e As MouseEventArgs)
            Dim rectangle As New Rectangle(0, 0, Me.Width, Me.Height)
            Dim rectangle2 As Rectangle = rectangle
            If rectangle2.Contains(Me.PointToClient(System.Windows.Forms.Cursor.Position)) Then
                Dim width As Integer = Math.Abs(CInt((Me.m_StartPoint.X - e.X)))
                Dim height As Integer = Math.Abs(CInt((Me.m_StartPoint.Y - e.Y)))
                Dim point As New Point(Math.Min(Me.m_StartPoint.X, e.X), Math.Min(Me.m_StartPoint.Y, e.Y))
                rectangle2 = New Rectangle(point.X, point.Y, width, height)
                Me.Selected_Rectangle = rectangle2
            End If
        End Sub

        Private Sub DrawImage(ByRef g As Graphics)
            If (Not Me.m_OriginalImage Is Nothing) Then
                g.PixelOffsetMode = PixelOffsetMode.Half
                g.SmoothingMode = SmoothingMode.None
                g.InterpolationMode = InterpolationMode.NearestNeighbor
                If Me.m_StretchImageToFit Then
                    Me.SrcRect = New Rectangle(0, 0, Me.m_OriginalImage.Width, Me.m_OriginalImage.Height)
                Else
                    Me.SrcRect = New Rectangle(Me.m_Origin.X, Me.m_Origin.Y, Me.m_DrawWidth, Me.m_DrawHeight)
                End If
                g.DrawImage(Me.m_OriginalImage, Me.DestRect, Me.SrcRect, GraphicsUnit.Pixel)
                If Not Me.PanMode Then
                    g.DrawRectangle(Me.m_Select_Pen, Me.Selected_Rectangle)
                End If
                Dim setScrollPositionsEvent As SetScrollPositionsEventHandler = Me.SetScrollPositionsEvent
                If (Not setScrollPositionsEvent Is Nothing) Then
                    setScrollPositionsEvent.Invoke()
                End If
            End If
        End Sub

        Private Sub DrawingBoard_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ((Not Me.m_OriginalImage Is Nothing) AndAlso Not Me.PanMode) Then
                Dim rectangle As Rectangle
                Me.EndPoint = New Point(e.X, e.Y)
                If (Me.Selected_Rectangle <> rectangle) Then
                    Me.ZoomSelection()
                End If
            End If
        End Sub

        Private Sub DrawingBoard_Resize(ByVal sender As Object, ByVal e As EventArgs)
            Me.ComputeDrawingArea()
            If Me.StretchImageToFit Then
                Me.Invalidate()
            End If
        End Sub

        Public Sub fittoscreen()
            Me.StretchImageToFit = False
            Dim point As New Point(0, 0)
            Me.Origin = point
            If (Not Me.m_OriginalImage Is Nothing) Then
                Me.ZoomFactor = Math.Min(CDbl((CDbl(Me.ClientSize.Width) / CDbl(Me.m_OriginalImage.Width))), CDbl((CDbl(Me.ClientSize.Height) / CDbl(Me.m_OriginalImage.Height))))
            End If
        End Sub

        Private Sub ImageViewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            If (Not Me.m_OriginalImage Is Nothing) Then
                Dim rectangle As Rectangle
                Me.EndPoint = New Point
                Me.Selected_Rectangle = rectangle
                Me.m_StartPoint = New Point(e.X, e.Y)
                Me.Focus()
            End If
        End Sub

        Private Sub ImageViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ((Not Me.m_OriginalImage Is Nothing) AndAlso (e.Button = Me.m_MouseButtons)) Then
                Dim num As Integer = (Me.m_StartPoint.X - e.X)
                Dim num2 As Integer = (Me.m_StartPoint.Y - e.Y)
                If Me.PanMode Then
                    Me.m_Origin.X = CInt(Math.Round(CDbl((Me.m_Origin.X + (CDbl(num) / Me.m_ZoomFactor)))))
                    Me.m_Origin.Y = CInt(Math.Round(CDbl((Me.m_Origin.Y + (CDbl(num2) / Me.m_ZoomFactor)))))
                    Me.CheckBounds()
                    Me.m_StartPoint.X = e.X
                    Me.m_StartPoint.Y = e.Y
                    Me.Invalidate()
                Else
                    Me.Draw_Rectangle(e)
                End If
            End If
        End Sub

        Private Sub ImageViewer_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            If Me.ZoomOnMouseWheel Then
                Me.StretchImageToFit = False
                If (e.Delta > 0) Then
                    Me.ZoomImage(True)
                ElseIf (e.Delta < 0) Then
                    Me.ZoomImage(False)
                End If
            End If
        End Sub

        <DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            Dim ef As New SizeF(6.0!, 13.0!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Name = "DrawingBoard"
            Dim size As New Size(&HBD, &HA5)
            Me.Size = size
            Me.ResumeLayout(False)
        End Sub

        Public Sub InvertColors()
            Try
                Me.Cursor = Cursors.WaitCursor
                If (Not Me.m_OriginalImage Is Nothing) Then
                    Dim newColorMatrix As New ColorMatrix(New Single()() {New Single() {-1.0!, 0.0!, 0.0!, 0.0!, 0.0!}, New Single() {0.0!, -1.0!, 0.0!, 0.0!, 0.0!}, New Single() {0.0!, 0.0!, -1.0!, 0.0!, 0.0!}, New Single() {0.0!, 0.0!, 0.0!, 1.0!, 0.0!}, New Single() {1.0!, 1.0!, 1.0!, 1.0!, 1.0!}})
                    Dim imageAttr As New ImageAttributes
                    imageAttr.SetColorMatrix(newColorMatrix)
                    Dim graphics As Graphics = Drawing.Graphics.FromImage(Me.m_OriginalImage)
                    Dim destRect As New Rectangle(0, 0, Me.m_OriginalImage.Width, Me.m_OriginalImage.Height)
                    graphics.DrawImage(Me.m_OriginalImage, destRect, 0, 0, Me.m_OriginalImage.Width, Me.m_OriginalImage.Height, GraphicsUnit.Pixel, imageAttr)
                    Me.Invalidate()
                End If
            Catch exception1 As Exception
                MessageBox.Show(exception1.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Dim m_OriginalImage_Bc As Bitmap

        Public Sub DoGrayscale()
            Try
                Me.Cursor = Cursors.WaitCursor
                If (Not Me.m_OriginalImage Is Nothing) Then
                    'Dim newColorMatrix As New ColorMatrix(New Single()() {New Single() {-1.0!, 0.0!, 0.0!, 0.0!, 0.0!} _
                    ', New Single() {0.0!, -1.0!, 0.0!, 0.0!, 0.0!}, New Single() {0.0!, 0.0!, -1.0!, 0.0!, 0.0!} _
                    ', New Single() {0.0!, 0.0!, 0.0!, 1.0!, 0.0!}, New Single() {1.0!, 1.0!, 1.0!, 1.0!, 1.0!}})

                    'Dim imageAttr As New ImageAttributes
                    'imageAttr.SetColorMatrix(newColorMatrix)
                    'Dim graphics As Graphics = Drawing.Graphics.FromImage(MakeGrayscale(Me.m_OriginalImage))
                    ''Dim destRect As New Rectangle(0, 0, Me.m_OriginalImage.Width, Me.m_OriginalImage.Height)
                    'graphics.DrawImage(MakeGrayscale(Me.m_OriginalImage), DestRect, 0, 0, Me.m_OriginalImage.Width _
                    ', Me.m_OriginalImage.Height, GraphicsUnit.)
                    m_OriginalImage_Bc = m_OriginalImage
                    Me.Image = MakeGrayscale(m_OriginalImage)

                    Me.Invalidate()
                End If
            Catch exception1 As Exception
                MessageBox.Show(exception1.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Public Shared Function MakeGrayscale(ByVal original As Bitmap) As Bitmap
            Dim newBitmap As New Bitmap(original.Width, original.Height)
            Dim g As Graphics = Graphics.FromImage(newBitmap)

            Dim _colorMatrix As ColorMatrix = New ColorMatrix(New Single()() _
            {New Single() {0.3!, 0.3!, 0.3!, 0.0!, 0.0!} _
            , New Single() {0.59F, 0.59F, 0.59F, 0, 0} _
            , New Single() {0.11F, 0.11F, 0.11F, 0, 0} _
            , New Single() {0, 0, 0, 1, 0} _
            , New Single() {0, 0, 0, 0, 1}})

            Dim attributes As New ImageAttributes
            attributes.SetColorMatrix(_colorMatrix)
            g.DrawImage(original, New Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes)
            g.Dispose()
            Return newBitmap
        End Function

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            e.Graphics.Clear(Me.BackColor)
            Me.DrawImage((e.Graphics))
            MyBase.OnPaint(e)
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            Me.DestRect = New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height)
            Me.ComputeDrawingArea()
            MyBase.OnSizeChanged(e)
        End Sub

        Public Sub RotateFlip(ByVal RotateFlipType As RotateFlipType)
            If (Not Me.m_OriginalImage Is Nothing) Then
                Me.m_OriginalImage.RotateFlip(RotateFlipType)
                Me.Invalidate()
            End If
        End Sub

        Private Sub ZoomImage(ByVal ZoomIn As Boolean)
            Me.m_centerpoint.X = CInt(Math.Round(CDbl((Me.m_Origin.X + (CDbl(Me.SrcRect.Width) / 2)))))
            Me.m_centerpoint.Y = CInt(Math.Round(CDbl((Me.m_Origin.Y + (CDbl(Me.SrcRect.Height) / 2)))))
            If ZoomIn Then
                Me.ZoomFactor = Math.Round(CDbl((Me.ZoomFactor * 1.1)), 2)
            Else
                Me.ZoomFactor = Math.Round(CDbl((Me.ZoomFactor * 0.9)), 2)
            End If
            Me.m_Origin.X = CInt(Math.Round(CDbl((Me.m_centerpoint.X - ((CDbl(Me.ClientSize.Width) / Me.m_ZoomFactor) / 2)))))
            Me.m_Origin.Y = CInt(Math.Round(CDbl((Me.m_centerpoint.Y - ((CDbl(Me.ClientSize.Height) / Me.m_ZoomFactor) / 2)))))
            Me.CheckBounds()
        End Sub

        Public Sub ZoomIn()
            Me.ZoomImage(True)
        End Sub

        Public Sub ZoomOut()
            Me.ZoomImage(False)
        End Sub

        Private Sub ZoomSelection()
            If (Not Me.m_OriginalImage Is Nothing) Then
                Dim rectangle4 As Rectangle
                Try
                    Dim num As Double
                    Dim point As New Point(CInt(Math.Round(CDbl((Me.Origin.X + (CDbl(Me.Selected_Rectangle.X) / Me.ZoomFactor))))), CInt(Math.Round(CDbl((Me.Origin.Y + (CDbl(Me.Selected_Rectangle.Y) / Me.ZoomFactor))))))
                    If (Me.Selected_Rectangle.Width > Me.Selected_Rectangle.Height) Then
                        num = (CDbl(Me.ClientSize.Width) / (CDbl(Me.Selected_Rectangle.Width) / Me.ZoomFactor))
                    Else
                        num = (CDbl(Me.ClientSize.Height) / (CDbl(Me.Selected_Rectangle.Height) / Me.ZoomFactor))
                    End If
                    Me.Origin = point
                    Me.ZoomFactor = num
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Throw exception
                    ProjectData.ClearProjectError()
                End Try
                Me.Selected_Rectangle = rectangle4
            End If
        End Sub


        ' Properties
        Public ReadOnly Property ApparentImageSize() As Size
            Get
                Return Me.m_ApparentImageSize
            End Get
        End Property

        'Public Property BackgroundImage As Image
        '    Get
        '        Return Nothing
        '    End Get
        '    Set(ByVal Value As Image)
        '        Me.Image = Value
        '        Me.ZoomFactor = 1
        '    End Set
        'End Property

        Public Property Image() As Image
            Get
                Return Me.m_OriginalImage
            End Get
            Set(ByVal Value As Image)
                If (Not Me.m_OriginalImage Is Nothing) Then
                    Me.m_OriginalImage.Dispose()
                    Me.m_Select_Rect = New Rectangle
                    Me.m_Origin = New Point(0, 0)
                    Me.m_ApparentImageSize = New Size(0, 0)
                    Me.m_ZoomFactor = 1
                    GC.Collect()
                End If
                If (Value Is Nothing) Then
                    Me.m_OriginalImage = Nothing
                    Me.Invalidate()
                Else
                    Dim rect As New Rectangle(0, 0, Value.Width, Value.Height)
                    Me.m_OriginalImage = New Bitmap(Value)
                    Dim data As New BitmapData
                    Me.m_OriginalImage = Me.m_OriginalImage.Clone(rect, PixelFormat.Format32bppPArgb)
                    Me.Invalidate()
                End If
            End Set
        End Property

        Public Property initialimage() As Image
            Get
                Return Me.m_OriginalImage
            End Get
            Set(ByVal value As Image)
                Me.Image = value
                Me.ZoomFactor = 1
            End Set
        End Property

        Public Property Origin() As Point
            Get
                Return Me.m_Origin
            End Get
            Set(ByVal value As Point)
                Me.m_Origin = value
                Me.Invalidate()
            End Set
        End Property

        Public Property PanButton() As MouseButtons
            Get
                Return Me.m_MouseButtons
            End Get
            Set(ByVal value As MouseButtons)
                Me.m_MouseButtons = value
            End Set
        End Property

        Public Property PanMode() As Boolean
            Get
                Return Me.m_PanMode
            End Get
            Set(ByVal value As Boolean)
                Me.m_PanMode = value
            End Set
        End Property

        Private Property Selected_Rectangle() As Rectangle
            Get
                Return Me.m_Select_Rect
            End Get
            Set(ByVal Value As Rectangle)
                Me.m_Select_Rect = Value
                Me.Invalidate()
            End Set
        End Property

        Public Property StretchImageToFit() As Boolean
            Get
                Return Me.m_StretchImageToFit
            End Get
            Set(ByVal value As Boolean)
                Me.m_StretchImageToFit = value
                Me.Invalidate()
            End Set
        End Property

        Public Property ZoomFactor() As Double
            Get
                Return Me.m_ZoomFactor
            End Get
            Set(ByVal value As Double)
                Me.m_ZoomFactor = value
                If (Me.m_ZoomFactor > 15) Then
                    Me.m_ZoomFactor = 15
                End If
                If (Me.m_ZoomFactor < 0.05) Then
                    Me.m_ZoomFactor = 0.05
                End If
                If (Not Me.m_OriginalImage Is Nothing) Then
                    Me.m_ApparentImageSize.Height = CInt(Math.Round(CDbl((Me.m_OriginalImage.Height * Me.m_ZoomFactor))))
                    Me.m_ApparentImageSize.Width = CInt(Math.Round(CDbl((Me.m_OriginalImage.Width * Me.m_ZoomFactor))))
                    Me.ComputeDrawingArea()
                    Me.CheckBounds()
                End If
                Me.Invalidate()
            End Set
        End Property

        Public Property ZoomOnMouseWheel() As Boolean
            Get
                Return Me.m_ZoomOnMouseWheel
            End Get
            Set(ByVal value As Boolean)
                Me.m_ZoomOnMouseWheel = value
            End Set
        End Property


        ' Fields
        Private components As IContainer
        Private DestRect As Rectangle
        Private EndPoint As Point
        Private g As Graphics
        Private m_ApparentImageSize As Size
        Private m_centerpoint As Point
        Private m_DrawHeight As Integer
        Private m_DrawWidth As Integer
        Private m_MouseButtons As MouseButtons
        Private m_Origin As Point
        Private m_OriginalImage As Bitmap
        Private m_PanMode As Boolean
        Private m_Select_Pen As Pen
        Private m_Select_Rect As Rectangle
        Private m_StartPoint As Point
        Private m_StretchImageToFit As Boolean
        Private m_ZoomFactor As Double
        Private m_ZoomOnMouseWheel As Boolean
        Private SrcRect As Rectangle

        ' Nested Types
        Public Delegate Sub SetScrollPositionsEventHandler()
    End Class
End Namespace


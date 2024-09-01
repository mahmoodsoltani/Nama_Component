Imports Microsoft.VisualBasic.CompilerServices
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Namespace PictuerViewer
    <ComVisible(False), DesignerGenerated()> _
    Friend Class DrawingBoard
        Inherits UserControl
        ' Events
        Public Event SetScrollPositions As SetScrollPositionsEventHandler

        ' Methods
        Public Sub New()
            AddHandler MyBase.MouseUp, New MouseEventHandler(AddressOf DrawingBoard_MouseUp)
            AddHandler MyBase.MouseWheel, New MouseEventHandler(AddressOf ImageViewer_MouseWheel)
            AddHandler MyBase.Resize, New EventHandler(AddressOf DrawingBoard_Resize)
            AddHandler MyBase.MouseDown, New MouseEventHandler(AddressOf ImageViewer_MouseDown)
            AddHandler MyBase.MouseMove, New MouseEventHandler(AddressOf ImageViewer_MouseMove)
            m_MouseButtons = System.Windows.Forms.MouseButtons.Left
            m_Origin = New Point(0, 0)
            m_ZoomOnMouseWheel = True
            m_ZoomFactor = 1
            m_ApparentImageSize = New Size(0, 0)
            m_PanMode = True
            m_StretchImageToFit = False
            m_Select_Pen = New Pen(Color.Blue, 2.0!)
            InitializeComponent()
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.DoubleBuffer, True)
        End Sub

        Private Sub CheckBounds()
            If (Not m_OriginalImage Is Nothing) Then
                If (m_Origin.X < 0) Then
                    m_Origin.X = 0
                End If
                If (m_Origin.Y < 0) Then
                    m_Origin.Y = 0
                End If
                If (m_Origin.X > (m_OriginalImage.Width - (CDbl(ClientSize.Width) / m_ZoomFactor))) Then
                    m_Origin.X = CInt(Math.Round(CDbl((m_OriginalImage.Width - (CDbl(ClientSize.Width) / m_ZoomFactor)))))
                End If
                If (m_Origin.Y > (m_OriginalImage.Height - (CDbl(ClientSize.Height) / m_ZoomFactor))) Then
                    m_Origin.Y = CInt(Math.Round(CDbl((m_OriginalImage.Height - (CDbl(ClientSize.Height) / m_ZoomFactor)))))
                End If
                If (m_Origin.X < 0) Then
                    m_Origin.X = 0
                End If
                If (m_Origin.Y < 0) Then
                    m_Origin.Y = 0
                End If
            End If
        End Sub

        Private Sub ComputeDrawingArea()
            m_DrawHeight = CInt(Math.Round(CDbl((CDbl(Height) / m_ZoomFactor))))
            m_DrawWidth = CInt(Math.Round(CDbl((CDbl(Width) / m_ZoomFactor))))
        End Sub

        <DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (IIf((disposing AndAlso (Not components Is Nothing)), 1, 0) <> 0) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub Draw_Rectangle(ByVal e As MouseEventArgs)
            Dim rectangle As New Rectangle(0, 0, Width, Height)
            Dim rectangle2 As Rectangle = rectangle
            If rectangle2.Contains(PointToClient(System.Windows.Forms.Cursor.Position)) Then
                Dim width As Integer = Math.Abs(CInt((m_StartPoint.X - e.X)))
                Dim height As Integer = Math.Abs(CInt((m_StartPoint.Y - e.Y)))
                Dim point As New Point(Math.Min(m_StartPoint.X, e.X), Math.Min(m_StartPoint.Y, e.Y))
                rectangle2 = New Rectangle(point.X, point.Y, width, height)
                Selected_Rectangle = rectangle2
            End If
        End Sub

        Private Sub DrawImage(ByRef g As Graphics)
            If (Not m_OriginalImage Is Nothing) Then
                g.PixelOffsetMode = PixelOffsetMode.Half
                g.SmoothingMode = SmoothingMode.None
                g.InterpolationMode = InterpolationMode.NearestNeighbor
                If m_StretchImageToFit Then
                    SrcRect = New Rectangle(0, 0, m_OriginalImage.Width, m_OriginalImage.Height)
                Else
                    SrcRect = New Rectangle(m_Origin.X, m_Origin.Y, m_DrawWidth, m_DrawHeight)
                End If
                g.DrawImage(m_OriginalImage, DestRect, SrcRect, GraphicsUnit.Pixel)
                If Not PanMode Then
                    g.DrawRectangle(m_Select_Pen, Selected_Rectangle)
                End If
                Dim setScrollPositionsEvent As SetScrollPositionsEventHandler = Me.SetScrollPositionsEvent
                If (Not setScrollPositionsEvent Is Nothing) Then
                    setScrollPositionsEvent.Invoke()
                End If
            End If
        End Sub

        Private Sub DrawingBoard_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ((Not m_OriginalImage Is Nothing) AndAlso Not PanMode) Then
                Dim rectangle As Rectangle
                EndPoint = New Point(e.X, e.Y)
                If (Selected_Rectangle <> rectangle) Then
                    ZoomSelection()
                End If
            End If
        End Sub

        Private Sub DrawingBoard_Resize(ByVal sender As Object, ByVal e As EventArgs)
            ComputeDrawingArea()
            If StretchImageToFit Then
                Invalidate()
            End If
        End Sub

        Public Sub fittoscreen()
            StretchImageToFit = False
            Dim point As New Point(0, 0)
            Origin = point
            If (Not m_OriginalImage Is Nothing) Then
                ZoomFactor = Math.Min(CDbl((CDbl(ClientSize.Width) / CDbl(m_OriginalImage.Width))), CDbl((CDbl(ClientSize.Height) / CDbl(m_OriginalImage.Height))))
            End If
        End Sub

        Private Sub ImageViewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            If (Not m_OriginalImage Is Nothing) Then
                Dim rectangle As Rectangle
                EndPoint = New Point
                Selected_Rectangle = rectangle
                m_StartPoint = New Point(e.X, e.Y)
                Focus()
            End If
        End Sub

        Private Sub ImageViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ((Not m_OriginalImage Is Nothing) AndAlso (e.Button = m_MouseButtons)) Then
                Dim num As Integer = (m_StartPoint.X - e.X)
                Dim num2 As Integer = (m_StartPoint.Y - e.Y)
                If PanMode Then
                    m_Origin.X = CInt(Math.Round(CDbl((m_Origin.X + (CDbl(num) / m_ZoomFactor)))))
                    m_Origin.Y = CInt(Math.Round(CDbl((m_Origin.Y + (CDbl(num2) / m_ZoomFactor)))))
                    CheckBounds()
                    m_StartPoint.X = e.X
                    m_StartPoint.Y = e.Y
                    Invalidate()
                Else
                    Draw_Rectangle(e)
                End If
            End If
        End Sub

        Private Sub ImageViewer_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ZoomOnMouseWheel Then
                StretchImageToFit = False
                If (e.Delta > 0) Then
                    ZoomImage(True)
                ElseIf (e.Delta < 0) Then
                    ZoomImage(False)
                End If
            End If
        End Sub

        <DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            SuspendLayout()
            Dim ef As New SizeF(6.0!, 13.0!)
            AutoScaleDimensions = ef
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Name = "DrawingBoard"
            Dim size As New Size(&HBD, &HA5)
            Me.Size = size
            ResumeLayout(False)
        End Sub

        Public Sub InvertColors()
            Try
                Cursor = Cursors.WaitCursor
                If (Not m_OriginalImage Is Nothing) Then
                    Dim newColorMatrix As New ColorMatrix(New Single()() {New Single() {-1.0!, 0.0!, 0.0!, 0.0!, 0.0!}, New Single() {0.0!, -1.0!, 0.0!, 0.0!, 0.0!}, New Single() {0.0!, 0.0!, -1.0!, 0.0!, 0.0!}, New Single() {0.0!, 0.0!, 0.0!, 1.0!, 0.0!}, New Single() {1.0!, 1.0!, 1.0!, 1.0!, 1.0!}})
                    Dim imageAttr As New ImageAttributes
                    imageAttr.SetColorMatrix(newColorMatrix)
                    Dim graphics As Graphics = Drawing.Graphics.FromImage(m_OriginalImage)
                    Dim destRect As New Rectangle(0, 0, m_OriginalImage.Width, m_OriginalImage.Height)
                    graphics.DrawImage(m_OriginalImage, destRect, 0, 0, m_OriginalImage.Width, m_OriginalImage.Height, GraphicsUnit.Pixel, imageAttr)
                    Invalidate()
                End If
            Catch exception1 As Exception
                MessageBox.Show(exception1.Message)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Dim m_OriginalImage_Bc As Bitmap

        Public Sub DoGrayscale()
            Try
                Cursor = Cursors.WaitCursor
                If (Not m_OriginalImage Is Nothing) Then
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
                    Image = MakeGrayscale(m_OriginalImage)

                    Invalidate()
                End If
            Catch exception1 As Exception
                MessageBox.Show(exception1.Message)
            Finally
                Cursor = Cursors.Default
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
            e.Graphics.Clear(BackColor)
            DrawImage((e.Graphics))
            MyBase.OnPaint(e)
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            DestRect = New Rectangle(0, 0, ClientSize.Width, ClientSize.Height)
            ComputeDrawingArea()
            MyBase.OnSizeChanged(e)
        End Sub

        Public Sub RotateFlip(ByVal RotateFlipType As RotateFlipType)
            If (Not m_OriginalImage Is Nothing) Then
                m_OriginalImage.RotateFlip(RotateFlipType)
                Invalidate()
            End If
        End Sub

        Private Sub ZoomImage(ByVal ZoomIn As Boolean)
            m_centerpoint.X = CInt(Math.Round(CDbl((m_Origin.X + (CDbl(SrcRect.Width) / 2)))))
            m_centerpoint.Y = CInt(Math.Round(CDbl((m_Origin.Y + (CDbl(SrcRect.Height) / 2)))))
            If ZoomIn Then
                ZoomFactor = Math.Round(CDbl((ZoomFactor * 1.1)), 2)
            Else
                ZoomFactor = Math.Round(CDbl((ZoomFactor * 0.9)), 2)
            End If
            m_Origin.X = CInt(Math.Round(CDbl((m_centerpoint.X - ((CDbl(ClientSize.Width) / m_ZoomFactor) / 2)))))
            m_Origin.Y = CInt(Math.Round(CDbl((m_centerpoint.Y - ((CDbl(ClientSize.Height) / m_ZoomFactor) / 2)))))
            CheckBounds()
        End Sub

        Public Sub ZoomIn()
            ZoomImage(True)
        End Sub

        Public Sub ZoomOut()
            ZoomImage(False)
        End Sub

        Private Sub ZoomSelection()
            If (Not m_OriginalImage Is Nothing) Then
                Dim rectangle4 As Rectangle
                Try
                    Dim num As Double
                    Dim point As New Point(CInt(Math.Round(CDbl((Origin.X + (CDbl(Selected_Rectangle.X) / ZoomFactor))))), CInt(Math.Round(CDbl((Origin.Y + (CDbl(Selected_Rectangle.Y) / ZoomFactor))))))
                    If (Selected_Rectangle.Width > Selected_Rectangle.Height) Then
                        num = (CDbl(ClientSize.Width) / (CDbl(Selected_Rectangle.Width) / ZoomFactor))
                    Else
                        num = (CDbl(ClientSize.Height) / (CDbl(Selected_Rectangle.Height) / ZoomFactor))
                    End If
                    Origin = point
                    ZoomFactor = num
                Catch exception1 As Exception
                    ProjectData.SetProjectError(exception1)
                    Dim exception As Exception = exception1
                    Throw exception
                    ProjectData.ClearProjectError()
                End Try
                Selected_Rectangle = rectangle4
            End If
        End Sub


        ' Properties
        Public ReadOnly Property ApparentImageSize() As Size
            Get
                Return m_ApparentImageSize
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
                Return m_OriginalImage
            End Get
            Set(ByVal Value As Image)
                If (Not m_OriginalImage Is Nothing) Then
                    m_OriginalImage.Dispose()
                    m_Select_Rect = New Rectangle
                    m_Origin = New Point(0, 0)
                    m_ApparentImageSize = New Size(0, 0)
                    m_ZoomFactor = 1
                    GC.Collect()
                End If
                If (Value Is Nothing) Then
                    m_OriginalImage = Nothing
                    Invalidate()
                Else
                    Dim rect As New Rectangle(0, 0, Value.Width, Value.Height)
                    m_OriginalImage = New Bitmap(Value)
                    Dim data As New BitmapData
                    m_OriginalImage = m_OriginalImage.Clone(rect, PixelFormat.Format32bppPArgb)
                    Invalidate()
                End If
            End Set
        End Property

        Public Property initialimage() As Image
            Get
                Return m_OriginalImage
            End Get
            Set(ByVal value As Image)
                Image = value
                ZoomFactor = 1
            End Set
        End Property

        Public Property Origin() As Point
            Get
                Return m_Origin
            End Get
            Set(ByVal value As Point)
                m_Origin = value
                Invalidate()
            End Set
        End Property

        Public Property PanButton() As MouseButtons
            Get
                Return m_MouseButtons
            End Get
            Set(ByVal value As MouseButtons)
                m_MouseButtons = value
            End Set
        End Property

        Public Property PanMode() As Boolean
            Get
                Return m_PanMode
            End Get
            Set(ByVal value As Boolean)
                m_PanMode = value
            End Set
        End Property

        Private Property Selected_Rectangle() As Rectangle
            Get
                Return m_Select_Rect
            End Get
            Set(ByVal Value As Rectangle)
                m_Select_Rect = Value
                Invalidate()
            End Set
        End Property

        Public Property StretchImageToFit() As Boolean
            Get
                Return m_StretchImageToFit
            End Get
            Set(ByVal value As Boolean)
                m_StretchImageToFit = value
                Invalidate()
            End Set
        End Property

        Public Property ZoomFactor() As Double
            Get
                Return m_ZoomFactor
            End Get
            Set(ByVal value As Double)
                m_ZoomFactor = value
                If (m_ZoomFactor > 15) Then
                    m_ZoomFactor = 15
                End If
                If (m_ZoomFactor < 0.05) Then
                    m_ZoomFactor = 0.05
                End If
                If (Not m_OriginalImage Is Nothing) Then
                    m_ApparentImageSize.Height = CInt(Math.Round(CDbl((m_OriginalImage.Height * m_ZoomFactor))))
                    m_ApparentImageSize.Width = CInt(Math.Round(CDbl((m_OriginalImage.Width * m_ZoomFactor))))
                    ComputeDrawingArea()
                    CheckBounds()
                End If
                Invalidate()
            End Set
        End Property

        Public Property ZoomOnMouseWheel() As Boolean
            Get
                Return m_ZoomOnMouseWheel
            End Get
            Set(ByVal value As Boolean)
                m_ZoomOnMouseWheel = value
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


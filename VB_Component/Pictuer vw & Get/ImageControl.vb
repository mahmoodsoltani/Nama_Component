Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace PictuerViewer
    <ComVisible(False), DesignerGenerated()> _
    Public Class ImageControl
        Inherits UserControl
        ' Methods
        Public Sub New()
            m_ScrollVisible = True
            InitializeComponent()
        End Sub

        <DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (IIf((disposing AndAlso (Not components Is Nothing)), 1, 0) <> 0) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub DrawingBoard1_SetScrollPositions()
            Dim width As Integer = DrawingBoard1.Image.Width
            Dim height As Integer = DrawingBoard1.Image.Height
            Dim x As Integer = DrawingBoard1.Origin.X
            Dim y As Integer = DrawingBoard1.Origin.Y
            Dim num4 As Integer = CInt(Math.Round(CDbl((CDbl(DrawingBoard1.Width) / DrawingBoard1.ZoomFactor))))
            Dim num3 As Integer = CInt(Math.Round(CDbl((CDbl(DrawingBoard1.Height) / DrawingBoard1.ZoomFactor))))
            HScrollBar1.Maximum = DrawingBoard1.Image.Width
            VScrollBar1.Maximum = DrawingBoard1.Image.Height
            If ((num4 >= DrawingBoard1.Image.Width) Or StretchImageToFit) Then
                HScrollBar1.Enabled = False
                HScrollBar1.Value = 0
            Else
                HScrollBar1.LargeChange = num4
                HScrollBar1.Enabled = True
                HScrollBar1.Value = x
            End If
            If ((num3 >= DrawingBoard1.Image.Height) Or StretchImageToFit) Then
                VScrollBar1.Enabled = False
                VScrollBar1.Value = 0
            Else
                VScrollBar1.Enabled = True
                VScrollBar1.LargeChange = num3
                VScrollBar1.Value = y
            End If
        End Sub

        Public Sub fittoscreen()
            DrawingBoard1.fittoscreen()
        End Sub

        <DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            VScrollBar1 = New VScrollBar
            HScrollBar1 = New HScrollBar
            DrawingBoard1 = New DrawingBoard
            SuspendLayout()
            VScrollBar1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Bottom Or AnchorStyles.Top))
            VScrollBar1.Enabled = False
            VScrollBar1.LargeChange = 20
            Dim point As New Point(&HC7, 0)
            VScrollBar1.Location = point
            VScrollBar1.Name = "VScrollBar1"
            Dim size As New Size(&H11, &H89)
            VScrollBar1.Size = size
            VScrollBar1.TabIndex = 1
            HScrollBar1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Bottom))
            HScrollBar1.Enabled = False
            HScrollBar1.LargeChange = 20
            point = New Point(0, &H89)
            HScrollBar1.Location = point
            HScrollBar1.Name = "HScrollBar1"
            size = New Size(200, &H11)
            HScrollBar1.Size = size
            HScrollBar1.TabIndex = 2
            DrawingBoard1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            DrawingBoard1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            DrawingBoard1.Image = Nothing
            DrawingBoard1.initialimage = Nothing
            point = New Point(0, -1)
            DrawingBoard1.Location = point
            DrawingBoard1.Name = "DrawingBoard1"
            point = New Point(0, 0)
            DrawingBoard1.Origin = point
            DrawingBoard1.PanButton = System.Windows.Forms.MouseButtons.Left
            size = New Size(200, &H8A)
            DrawingBoard1.Size = size
            DrawingBoard1.TabIndex = 0
            DrawingBoard1.ZoomFactor = 1
            DrawingBoard1.ZoomOnMouseWheel = True
            Dim ef As New SizeF(6.0!, 13.0!)
            AutoScaleDimensions = ef
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Controls.Add(HScrollBar1)
            Controls.Add(VScrollBar1)
            Controls.Add(DrawingBoard1)
            Name = "ImageControl"
            size = New Size(&HD9, &H9B)
            Me.Size = size
            ResumeLayout(False)
        End Sub

        Public Sub InvertColors()
            DrawingBoard1.InvertColors()
        End Sub

        Public Sub DoGrayeScale()
            DrawingBoard1.DoGrayscale()
        End Sub

        Public Sub RotateFlip(ByVal RotateFlipType As RotateFlipType)
            DrawingBoard1.RotateFlip(RotateFlipType)
        End Sub

        Private Sub ScrollBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim point As New Point(HScrollBar1.Value, VScrollBar1.Value)
            DrawingBoard1.Origin = point
        End Sub

        Public Sub ZoomIn()
            DrawingBoard1.ZoomIn()
        End Sub

        Public Sub ZoomOut()
            DrawingBoard1.ZoomOut()
        End Sub

        ' Properties
        Public ReadOnly Property ApparentImageSize() As Size
            Get
                Return DrawingBoard1.ApparentImageSize
            End Get
        End Property

        'Public Property BackgroundImage() As Image
        '    Get
        '        Return Me.DrawingBoard1.BackgroundImage
        '    End Get
        '    Set(ByVal Value As Image)
        '        Me.DrawingBoard1.BackgroundImage = Value
        '        If (Value Is Nothing) Then
        '            Me.HScrollBar1.Enabled = False
        '            Me.VScrollBar1.Enabled = False
        '        End If
        '    End Set
        'End Property

        Friend Overridable Property DrawingBoard1() As DrawingBoard
            Get
                Return _DrawingBoard1
            End Get
            Set(ByVal WithEventsValue As DrawingBoard)
                If (Not _DrawingBoard1 Is Nothing) Then
                    RemoveHandler _DrawingBoard1.SetScrollPositions, New DrawingBoard.SetScrollPositionsEventHandler(AddressOf DrawingBoard1_SetScrollPositions)
                End If
                _DrawingBoard1 = WithEventsValue
                If (Not _DrawingBoard1 Is Nothing) Then
                    AddHandler _DrawingBoard1.SetScrollPositions, New DrawingBoard.SetScrollPositionsEventHandler(AddressOf DrawingBoard1_SetScrollPositions)
                End If
            End Set
        End Property

        Friend Overridable Property HScrollBar1() As HScrollBar
            Get
                Return _HScrollBar1
            End Get
            Set(ByVal WithEventsValue As HScrollBar)
                If (Not _HScrollBar1 Is Nothing) Then
                    RemoveHandler _HScrollBar1.ValueChanged, New EventHandler(AddressOf ScrollBar_ValueChanged)
                End If
                _HScrollBar1 = WithEventsValue
                If (Not _HScrollBar1 Is Nothing) Then
                    AddHandler _HScrollBar1.ValueChanged, New EventHandler(AddressOf ScrollBar_ValueChanged)
                End If
            End Set
        End Property

        Public Property Image() As Image
            Get
                Return DrawingBoard1.Image
            End Get
            Set(ByVal Value As Image)
                DrawingBoard1.Image = Value
                If (Value Is Nothing) Then
                    HScrollBar1.Enabled = False
                    VScrollBar1.Enabled = False
                End If
            End Set
        End Property

        Public Property initialimage() As Image
            Get
                Return DrawingBoard1.initialimage
            End Get
            Set(ByVal value As Image)
                DrawingBoard1.initialimage = value
                If (value Is Nothing) Then
                    HScrollBar1.Enabled = False
                    VScrollBar1.Enabled = False
                End If
            End Set
        End Property

        Public Property Origin() As Point
            Get
                Return DrawingBoard1.Origin
            End Get
            Set(ByVal value As Point)
                DrawingBoard1.Origin = value
            End Set
        End Property

        Public Property PanButton() As MouseButtons
            Get
                Return DrawingBoard1.PanButton
            End Get
            Set(ByVal value As MouseButtons)
                DrawingBoard1.PanButton = value
            End Set
        End Property

        Public Property PanMode() As Boolean
            Get
                Return DrawingBoard1.PanMode
            End Get
            Set(ByVal value As Boolean)
                DrawingBoard1.PanMode = value
            End Set
        End Property

        Public Property ScrollbarsVisible() As Boolean
            Get
                Return m_ScrollVisible
            End Get
            Set(ByVal value As Boolean)
                m_ScrollVisible = value
                HScrollBar1.Visible = value
                VScrollBar1.Visible = value
                If Not value Then
                    DrawingBoard1.Dock = DockStyle.Fill
                Else
                    DrawingBoard1.Dock = DockStyle.None
                    Dim point As New Point(0, 0)
                    DrawingBoard1.Location = point
                    DrawingBoard1.Width = (ClientSize.Width - VScrollBar1.Width)
                    DrawingBoard1.Height = (ClientSize.Height - HScrollBar1.Height)
                End If
            End Set
        End Property

        Public Property StretchImageToFit() As Boolean
            Get
                Return DrawingBoard1.StretchImageToFit
            End Get
            Set(ByVal value As Boolean)
                DrawingBoard1.StretchImageToFit = value
            End Set
        End Property

        Friend Overridable Property VScrollBar1() As VScrollBar
            Get
                Return _VScrollBar1
            End Get
            Set(ByVal WithEventsValue As VScrollBar)
                If (Not _VScrollBar1 Is Nothing) Then
                    RemoveHandler _VScrollBar1.ValueChanged, New EventHandler(AddressOf ScrollBar_ValueChanged)
                End If
                _VScrollBar1 = WithEventsValue
                If (Not _VScrollBar1 Is Nothing) Then
                    AddHandler _VScrollBar1.ValueChanged, New EventHandler(AddressOf ScrollBar_ValueChanged)
                End If
            End Set
        End Property

        Public Property ZoomFactor() As Double
            Get
                Return DrawingBoard1.ZoomFactor
            End Get
            Set(ByVal value As Double)
                DrawingBoard1.ZoomFactor = value
            End Set
        End Property

        Public Property ZoomOnMouseWheel() As Boolean
            Get
                Return DrawingBoard1.ZoomOnMouseWheel
            End Get
            Set(ByVal value As Boolean)
                DrawingBoard1.ZoomOnMouseWheel = value
            End Set
        End Property


        ' Fields
        <AccessedThroughProperty("DrawingBoard1")> _
        Private _DrawingBoard1 As DrawingBoard
        <AccessedThroughProperty("HScrollBar1")> _
        Private _HScrollBar1 As HScrollBar
        <AccessedThroughProperty("VScrollBar1")> _
        Private _VScrollBar1 As VScrollBar
        Private components As IContainer
        Private m_ScrollVisible As Boolean
    End Class
End Namespace


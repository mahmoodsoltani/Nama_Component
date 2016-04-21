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
            Me.m_ScrollVisible = True
            Me.InitializeComponent()
        End Sub

        <DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (IIf((disposing AndAlso (Not Me.components Is Nothing)), 1, 0) <> 0) Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub DrawingBoard1_SetScrollPositions()
            Dim width As Integer = Me.DrawingBoard1.Image.Width
            Dim height As Integer = Me.DrawingBoard1.Image.Height
            Dim x As Integer = Me.DrawingBoard1.Origin.X
            Dim y As Integer = Me.DrawingBoard1.Origin.Y
            Dim num4 As Integer = CInt(Math.Round(CDbl((CDbl(Me.DrawingBoard1.Width) / Me.DrawingBoard1.ZoomFactor))))
            Dim num3 As Integer = CInt(Math.Round(CDbl((CDbl(Me.DrawingBoard1.Height) / Me.DrawingBoard1.ZoomFactor))))
            Me.HScrollBar1.Maximum = Me.DrawingBoard1.Image.Width
            Me.VScrollBar1.Maximum = Me.DrawingBoard1.Image.Height
            If ((num4 >= Me.DrawingBoard1.Image.Width) Or Me.StretchImageToFit) Then
                Me.HScrollBar1.Enabled = False
                Me.HScrollBar1.Value = 0
            Else
                Me.HScrollBar1.LargeChange = num4
                Me.HScrollBar1.Enabled = True
                Me.HScrollBar1.Value = x
            End If
            If ((num3 >= Me.DrawingBoard1.Image.Height) Or Me.StretchImageToFit) Then
                Me.VScrollBar1.Enabled = False
                Me.VScrollBar1.Value = 0
            Else
                Me.VScrollBar1.Enabled = True
                Me.VScrollBar1.LargeChange = num3
                Me.VScrollBar1.Value = y
            End If
        End Sub

        Public Sub fittoscreen()
            Me.DrawingBoard1.fittoscreen()
        End Sub

        <DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.VScrollBar1 = New VScrollBar
            Me.HScrollBar1 = New HScrollBar
            Me.DrawingBoard1 = New DrawingBoard
            Me.SuspendLayout()
            Me.VScrollBar1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Bottom Or AnchorStyles.Top))
            Me.VScrollBar1.Enabled = False
            Me.VScrollBar1.LargeChange = 20
            Dim point As New Point(&HC7, 0)
            Me.VScrollBar1.Location = point
            Me.VScrollBar1.Name = "VScrollBar1"
            Dim size As New Size(&H11, &H89)
            Me.VScrollBar1.Size = size
            Me.VScrollBar1.TabIndex = 1
            Me.HScrollBar1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Bottom))
            Me.HScrollBar1.Enabled = False
            Me.HScrollBar1.LargeChange = 20
            point = New Point(0, &H89)
            Me.HScrollBar1.Location = point
            Me.HScrollBar1.Name = "HScrollBar1"
            size = New Size(200, &H11)
            Me.HScrollBar1.Size = size
            Me.HScrollBar1.TabIndex = 2
            Me.DrawingBoard1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.DrawingBoard1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.DrawingBoard1.Image = Nothing
            Me.DrawingBoard1.initialimage = Nothing
            point = New Point(0, -1)
            Me.DrawingBoard1.Location = point
            Me.DrawingBoard1.Name = "DrawingBoard1"
            point = New Point(0, 0)
            Me.DrawingBoard1.Origin = point
            Me.DrawingBoard1.PanButton = System.Windows.Forms.MouseButtons.Left
            size = New Size(200, &H8A)
            Me.DrawingBoard1.Size = size
            Me.DrawingBoard1.TabIndex = 0
            Me.DrawingBoard1.ZoomFactor = 1
            Me.DrawingBoard1.ZoomOnMouseWheel = True
            Dim ef As New SizeF(6.0!, 13.0!)
            Me.AutoScaleDimensions = ef
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.HScrollBar1)
            Me.Controls.Add(Me.VScrollBar1)
            Me.Controls.Add(Me.DrawingBoard1)
            Me.Name = "ImageControl"
            size = New Size(&HD9, &H9B)
            Me.Size = size
            Me.ResumeLayout(False)
        End Sub

        Public Sub InvertColors()
            Me.DrawingBoard1.InvertColors()
        End Sub

        Public Sub DoGrayeScale()
            Me.DrawingBoard1.DoGrayscale()
        End Sub

        Public Sub RotateFlip(ByVal RotateFlipType As RotateFlipType)
            Me.DrawingBoard1.RotateFlip(RotateFlipType)
        End Sub

        Private Sub ScrollBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim point As New Point(Me.HScrollBar1.Value, Me.VScrollBar1.Value)
            Me.DrawingBoard1.Origin = point
        End Sub

        Public Sub ZoomIn()
            Me.DrawingBoard1.ZoomIn()
        End Sub

        Public Sub ZoomOut()
            Me.DrawingBoard1.ZoomOut()
        End Sub

        ' Properties
        Public ReadOnly Property ApparentImageSize() As Size
            Get
                Return Me.DrawingBoard1.ApparentImageSize
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
                Return Me._DrawingBoard1
            End Get
            Set(ByVal WithEventsValue As DrawingBoard)
                If (Not Me._DrawingBoard1 Is Nothing) Then
                    RemoveHandler Me._DrawingBoard1.SetScrollPositions, New DrawingBoard.SetScrollPositionsEventHandler(AddressOf Me.DrawingBoard1_SetScrollPositions)
                End If
                Me._DrawingBoard1 = WithEventsValue
                If (Not Me._DrawingBoard1 Is Nothing) Then
                    AddHandler Me._DrawingBoard1.SetScrollPositions, New DrawingBoard.SetScrollPositionsEventHandler(AddressOf Me.DrawingBoard1_SetScrollPositions)
                End If
            End Set
        End Property

        Friend Overridable Property HScrollBar1() As HScrollBar
            Get
                Return Me._HScrollBar1
            End Get
            Set(ByVal WithEventsValue As HScrollBar)
                If (Not Me._HScrollBar1 Is Nothing) Then
                    RemoveHandler Me._HScrollBar1.ValueChanged, New EventHandler(AddressOf Me.ScrollBar_ValueChanged)
                End If
                Me._HScrollBar1 = WithEventsValue
                If (Not Me._HScrollBar1 Is Nothing) Then
                    AddHandler Me._HScrollBar1.ValueChanged, New EventHandler(AddressOf Me.ScrollBar_ValueChanged)
                End If
            End Set
        End Property

        Public Property Image() As Image
            Get
                Return Me.DrawingBoard1.Image
            End Get
            Set(ByVal Value As Image)
                Me.DrawingBoard1.Image = Value
                If (Value Is Nothing) Then
                    Me.HScrollBar1.Enabled = False
                    Me.VScrollBar1.Enabled = False
                End If
            End Set
        End Property

        Public Property initialimage() As Image
            Get
                Return Me.DrawingBoard1.initialimage
            End Get
            Set(ByVal value As Image)
                Me.DrawingBoard1.initialimage = value
                If (value Is Nothing) Then
                    Me.HScrollBar1.Enabled = False
                    Me.VScrollBar1.Enabled = False
                End If
            End Set
        End Property

        Public Property Origin() As Point
            Get
                Return Me.DrawingBoard1.Origin
            End Get
            Set(ByVal value As Point)
                Me.DrawingBoard1.Origin = value
            End Set
        End Property

        Public Property PanButton() As MouseButtons
            Get
                Return Me.DrawingBoard1.PanButton
            End Get
            Set(ByVal value As MouseButtons)
                Me.DrawingBoard1.PanButton = value
            End Set
        End Property

        Public Property PanMode() As Boolean
            Get
                Return Me.DrawingBoard1.PanMode
            End Get
            Set(ByVal value As Boolean)
                Me.DrawingBoard1.PanMode = value
            End Set
        End Property

        Public Property ScrollbarsVisible() As Boolean
            Get
                Return Me.m_ScrollVisible
            End Get
            Set(ByVal value As Boolean)
                Me.m_ScrollVisible = value
                Me.HScrollBar1.Visible = value
                Me.VScrollBar1.Visible = value
                If Not value Then
                    Me.DrawingBoard1.Dock = DockStyle.Fill
                Else
                    Me.DrawingBoard1.Dock = DockStyle.None
                    Dim point As New Point(0, 0)
                    Me.DrawingBoard1.Location = point
                    Me.DrawingBoard1.Width = (Me.ClientSize.Width - Me.VScrollBar1.Width)
                    Me.DrawingBoard1.Height = (Me.ClientSize.Height - Me.HScrollBar1.Height)
                End If
            End Set
        End Property

        Public Property StretchImageToFit() As Boolean
            Get
                Return Me.DrawingBoard1.StretchImageToFit
            End Get
            Set(ByVal value As Boolean)
                Me.DrawingBoard1.StretchImageToFit = value
            End Set
        End Property

        Friend Overridable Property VScrollBar1() As VScrollBar
            Get
                Return Me._VScrollBar1
            End Get
            Set(ByVal WithEventsValue As VScrollBar)
                If (Not Me._VScrollBar1 Is Nothing) Then
                    RemoveHandler Me._VScrollBar1.ValueChanged, New EventHandler(AddressOf Me.ScrollBar_ValueChanged)
                End If
                Me._VScrollBar1 = WithEventsValue
                If (Not Me._VScrollBar1 Is Nothing) Then
                    AddHandler Me._VScrollBar1.ValueChanged, New EventHandler(AddressOf Me.ScrollBar_ValueChanged)
                End If
            End Set
        End Property

        Public Property ZoomFactor() As Double
            Get
                Return Me.DrawingBoard1.ZoomFactor
            End Get
            Set(ByVal value As Double)
                Me.DrawingBoard1.ZoomFactor = value
            End Set
        End Property

        Public Property ZoomOnMouseWheel() As Boolean
            Get
                Return Me.DrawingBoard1.ZoomOnMouseWheel
            End Get
            Set(ByVal value As Boolean)
                Me.DrawingBoard1.ZoomOnMouseWheel = value
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


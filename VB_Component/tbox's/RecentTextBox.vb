Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports System.Xml
Imports System.Collections
Imports System.ComponentModel

Public Class RecentTextBox

    Dim ItemArray As New ArrayList
    Dim CountItem As Integer = 5
    Public Event Tbox_Enter As EventHandler
    Private _EnterStop As Boolean = True
    <Category("Nama"), Description("If true go on to the  next control by enter"), Browsable(True)> _
   Public Property EnterStop() As Boolean
        Get
            Return _EnterStop
        End Get
        Set(ByVal value As Boolean)
            _EnterStop = value
        End Set
    End Property

    Public Property TboxText() As String
        Get
            Return Tbox.Text
        End Get
        Set(ByVal value As String)
            Tbox.Text = value
        End Set
    End Property

    Private Sub Tbox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbox.GotFocus
        Tbox.Text = ""
        lb.Items.Clear()
        ItemArray.Clear()

        If Not File.Exists(Environment.CurrentDirectory & "\\" & Me.Name & ".Xml") Then

            Dim XmlDoc As XmlTextWriter = New XmlTextWriter(Environment.CurrentDirectory & "\\" & Me.Name & ".Xml", System.Text.Encoding.UTF8)
            XmlDoc.Formatting = Formatting.Indented

            XmlDoc.WriteStartDocument()
            XmlDoc.WriteStartElement("RecentText")
            XmlDoc.WriteEndElement()

            XmlDoc.Flush()
            XmlDoc.Close()
            Application.DoEvents()
        Else
            lb.BringToFront()

            Dim graphics As Graphics = Me.CreateGraphics
            Dim sizeF As SizeF = graphics.MeasureString("HELLO", Me.Font)
            Dim i2 As Integer = Convert.ToInt32(Math.Ceiling(CDbl(sizeF.Height)))
            Dim i3 As Integer = Convert.ToInt32(Math.Ceiling(CDbl(sizeF.Height)))

            Dim XmlRdr As New XmlTextReader(Environment.CurrentDirectory & "\\" & Me.Name & ".Xml")

            While (XmlRdr.Read())
                If XmlRdr.NodeType = XmlNodeType.Element AndAlso XmlRdr.Name = "Text" Then
                    If (Me.lb.Items.Count > CountItem) Then
                        Exit While
                    End If

                    If (Me.lb.Items.Count < CountItem) Then
                        i2 += i3
                    End If
                    Dim str As String = XmlRdr.ReadString()
                    ItemArray.Add(str)
                    lb.Items.Add(str)
                End If
            End While
            XmlRdr.Close()

            If lb.Items.Count > 0 Then
                Tbox.Text = ItemArray(0).ToString()
                lb.Size = New Size(Width, i2)
                Size = New Size(Tbox.Size.Width, Tbox.Size.Height + lb.Size.Height)
                lb.Location = New Point(0, 20)
                Application.DoEvents()
                lb.Show()
            End If

        End If
    End Sub

    Private Sub Tbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tbox.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                lb.SelectedIndex = IIf(((Me.lb.SelectedIndex + 1) < Me.lb.Items.Count), (Me.lb.SelectedIndex + 1), 0)
                Tbox.Text = Me.lb.SelectedItem.ToString
            Case Keys.Up
                Me.lb.SelectedIndex = IIf(((Me.lb.SelectedIndex - 1) >= 0), (Me.lb.SelectedIndex - 1), (Me.lb.Items.Count - 1))
                Tbox.Text = Me.lb.SelectedItem.ToString
            Case Keys.Enter
                If (Me.lb.SelectedItems.Count <> 0) Then
                    Me.Text = Me.lb.SelectedItem.ToString
                End If
                Tbox_LostFocus(sender, e)
                RaiseEvent Tbox_Enter(Me, New EventArgs)
        End Select
    End Sub

    Private Sub Tbox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbox.LostFocus

        If Not File.Exists(Environment.CurrentDirectory & "\\" & Me.Name & ".Xml") Then
            Return
        End If

        Try
            If Tbox.Text <> "" Then
                If ItemArray(0).Equals(Tbox.Text) Then
                    Size = New Size(Tbox.Size.Width, Tbox.Size.Height)
                    lb.Visible = False
                    Return
                End If
                save()
            End If
        Catch ex As Exception
            If Tbox.Text <> "" Then
                save()
            End If
        End Try

        Size = New Size(Tbox.Size.Width, Tbox.Size.Height)
        lb.Visible = False
    End Sub

    Private Sub save()
        Dim XmlDoc As XmlTextWriter = New XmlTextWriter(Environment.CurrentDirectory & "\\" & Me.Name & ".Xml", System.Text.Encoding.UTF8)
        XmlDoc.Formatting = Formatting.Indented
        XmlDoc.WriteStartDocument()
        XmlDoc.WriteStartElement("RecentText")

        XmlDoc.WriteElementString("Text", Tbox.Text)

        If lb.Items.Count <> 0 Then
            For i As Integer = 1 To lb.Items.Count
                If lb.Items.Count - i <= CountItem Then
                    XmlDoc.WriteElementString("Text", lb.Items(i - 1).ToString())
                End If
            Next i
        End If

        XmlDoc.WriteEndElement()
        XmlDoc.Flush()
        XmlDoc.Close()
        Application.DoEvents()
    End Sub

    Public Sub New()
        InitializeComponent()
        lb.Visible = False
        Me.Size = New Size(Tbox.Size.Width, Tbox.Size.Height)
        lb.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Tbox.RightToLeft = System.Windows.Forms.RightToLeft.Inherit
        Application.DoEvents()
    End Sub
End Class

Public Class SecurityControl

    Private str_ControlName As String

    Private str_FormName As String

    Private str_Type As String

    Private bol_Disabled As Boolean

    Private bol_Invisible As Boolean

    Private int_Srl As Integer

    Public Property ControlName() As String
        Get
            Return str_ControlName
        End Get
        Set(ByVal value As String)
            str_ControlName = value
        End Set
    End Property

    Public Property FormName() As String
        Get
            Return str_FormName
        End Get
        Set(ByVal value As String)
            str_FormName = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return str_Type
        End Get
        Set(ByVal value As String)
            str_Type = value
        End Set
    End Property

    Public Property Disabled() As Boolean
        Get
            Return bol_Disabled
        End Get
        Set(ByVal value As Boolean)
            bol_Disabled = value
        End Set
    End Property

    Public Property Invisible() As Boolean
        Get
            Return bol_Invisible
        End Get
        Set(ByVal value As Boolean)
            bol_Invisible = value
        End Set
    End Property

    Public Property Srl() As Integer
        Get
            Return int_Srl
        End Get
        Set(ByVal value As Integer)
            int_Srl = value
        End Set
    End Property
End Class

Public Class SecurityControls
    Inherits List(Of SecurityControl)

    Public ReadOnly Property GetItem(ByVal ControlName As String, ByVal FormName As String) As SecurityControl
        Get
            Dim i As Integer
            For i = 0 To Me.Count - 1
                If (Me(i).ControlName.ToLower() = ControlName.ToLower() And Me(i).FormName.ToLower() = FormName.ToLower()) Then Return Me(i)
            Next
            Return Nothing
        End Get
    End Property
End Class

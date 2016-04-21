Public Class TreeNode
    Inherits System.Windows.Forms.TreeNode

    Private int_Srl As Integer
    Public Property Srl() As Integer
        Get
            Return int_Srl
        End Get
        Set(ByVal value As Integer)
            int_Srl = value
        End Set
    End Property

    Private int_Srl_Parent As Integer
    Public Property Srl_Parent() As Integer
        Get
            Return int_Srl_Parent
        End Get
        Set(ByVal value As Integer)
            int_Srl_Parent = value
        End Set
    End Property

    Private bool_IsRootNode As Boolean = False
    Public Property IsRootNode() As Boolean
        Get
            Return bool_IsRootNode
        End Get
        Set(ByVal value As Boolean)
            bool_IsRootNode = value
        End Set
    End Property
    Private bool_IsLoad As Boolean
    Public Property IsLoad() As Boolean
        Get
            Return bool_IsLoad
        End Get
        Set(ByVal value As Boolean)
            bool_IsLoad = value
        End Set
    End Property

    Public Sub New(ByVal Text As String)
        Me.Text = Text
    End Sub

End Class

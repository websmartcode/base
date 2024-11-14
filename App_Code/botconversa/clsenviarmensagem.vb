Imports Microsoft.VisualBasic

Public Class clsenviarmensagem
    Dim _type As String
    Dim _value As String

    Public Property type As String
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property

    Public Property value As String
        Get
            Return _value
        End Get
        Set(value As String)
            _value = value
        End Set
    End Property
End Class

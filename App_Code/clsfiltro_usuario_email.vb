Imports Microsoft.VisualBasic

Public Class clsfiltro_usuario_email
    Dim _usuario As String
    Dim _email As String

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property
End Class

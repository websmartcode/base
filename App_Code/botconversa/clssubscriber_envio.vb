Imports Microsoft.VisualBasic

Public Class clssubscriber_envio
    Dim _phone As String
    Dim _first_name As String
    Dim _last_name As String

    Public Property phone As String
        Get
            Return _phone
        End Get
        Set(value As String)
            _phone = value
        End Set
    End Property

    Public Property first_name As String
        Get
            Return _first_name
        End Get
        Set(value As String)
            _first_name = value
        End Set
    End Property

    Public Property last_name As String
        Get
            Return _last_name
        End Get
        Set(value As String)
            _last_name = value
        End Set
    End Property
End Class

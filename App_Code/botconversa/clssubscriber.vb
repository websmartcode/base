Imports Microsoft.VisualBasic

Public Class clssubscriber
    Dim _phone As String
    Dim _first_name As String
    Dim _last_name As String
    Dim _id As Integer
    Dim _error_message As String
    Dim _url As String = "https://backend.botconversa.com.br/api/v1/webhook/subscriber/"


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

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property error_message As String
        Get
            Return _error_message
        End Get
        Set(value As String)
            _error_message = value
        End Set
    End Property

    Public Property url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
        End Set
    End Property


End Class

Imports Microsoft.VisualBasic

Public Class clsprocessarAPI_headers
    Dim _headers As String = ""
    Dim _valor As String = ""

    Public Property Headers As String
        Get
            Return _headers
        End Get
        Set(value As String)
            _headers = value
        End Set
    End Property

    Public Property Valor As String
        Get
            Return _valor
        End Get
        Set(value As String)
            _valor = value
        End Set
    End Property
End Class

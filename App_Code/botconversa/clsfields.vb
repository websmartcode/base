Imports Microsoft.VisualBasic
Imports Newtonsoft.Json

Public Class clsfields

    Dim _id As Integer = 0
    Dim _key As String = ""
    Dim _type As String = ""
    Dim _value As String = ""
    Dim _valor As New clsfields_value
    Dim _url As String = "https://backend.botconversa.com.br/api/v1/webhook/bot_fields/"
    Dim _urlenviar As String = "https://backend.botconversa.com.br/api/v1/webhook/subscriber/"
    Dim _complurl As String = "/custom_fields/"
    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property key As String
        Get
            Return _key
        End Get
        Set(value As String)
            _key = value
        End Set
    End Property

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

    Public Property Url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
        End Set
    End Property

    Public Function ProcurarCampo(xcampo As String) As Boolean
        Try
            Dim xbot As New clsbot
            If xbot.enviarAPIbot("", "https://backend.botconversa.com.br/api/v1/webhook/custom_fields/", "GET") Then
                Dim xenviar As New List(Of clsfields)
                xenviar = JsonConvert.DeserializeObject(Of List(Of clsfields))(xbot.Retornosucesso)
                If xcampo <> "" Then
                    For x As Integer = 0 To xenviar.Count - 1
                        If xenviar(x).Key = xcampo Then
                            Id = xenviar(x).Id
                            Return True
                        End If
                    Next
                End If

            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function EnviarCampo(xidusuario As Integer, xcampo As String, xvalor As String) As Boolean
        Try
            _valor.Value = xvalor
            Dim xbot As New clsbot
            _urlenviar = _urlenviar & xidusuario & _complurl & xcampo & "/"
            If xbot.enviarAPIbot(JsonConvert.SerializeObject(_valor), _urlenviar, "POST") Then
                Return True
            Else
                Return False

            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class

Imports Microsoft.VisualBasic
Imports Newtonsoft.Json
Imports clsSmart
Public Class clsflow
    Dim _id As Integer
    Dim _name As String
    Dim _urlenviar As String = "https://backend.botconversa.com.br/api/v1/webhook/subscriber/"
    Dim _valor As New clsflow_value

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Function RetonarIdFlow(xflow As String) As Boolean
        Try
            Dim xbot As New clsbot
            If xbot.enviarAPIbot("", "https://backend.botconversa.com.br/api/v1/webhook/flows/", "GET") Then
                Dim xenviar As New List(Of clsflow)
                xenviar = JsonConvert.DeserializeObject(Of List(Of clsflow))(xbot.Retornosucesso)
                If xflow <> "" Then
                    For x As Integer = 0 To xenviar.Count - 1
                        If xenviar(x).Name = xflow Then
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

    Public Function EnviarFlow(xidusuario As Integer, xidflow As String) As Boolean
        Try
            _valor.flow = xidflow
            Dim xbot As New clsbot
            If xbot.enviarAPIbot(JsonConvert.SerializeObject(_valor), _urlenviar & xidusuario & "/send_flow/", "POST") Then
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

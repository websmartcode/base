Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class clsbot
    Dim _response As WebResponse
    Dim _mensagemerro As String
    Dim _retornosucesso As String = ""
    Dim _API_KEY As String = "3369a7ce-23da-44ee-8987-2db005243b85"
    Dim _listacampos As New List(Of clsfields)
    Public Property API_KEY As String
        Get
            Return _API_KEY
        End Get
        Set(value As String)
            _API_KEY = value
        End Set
    End Property
    Public Property Response As WebResponse
        Get
            Return _response
        End Get
        Set(value As WebResponse)
            _response = value
        End Set
    End Property

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Retornosucesso As String
        Get
            Return _retornosucesso
        End Get
        Set(value As String)
            _retornosucesso = value
        End Set
    End Property

    Public Property Listacampos As List(Of clsfields)
        Get
            Return _listacampos
        End Get
        Set(value As List(Of clsfields))
            _listacampos = value
        End Set
    End Property

    Public Function enviarFlow(xtelefone As String, xnome As String, xnomeflow As String) As Boolean
        Dim xuri As New clssubscriber

        Dim xapi As New clssubscriber_envio

        xapi.phone = xtelefone
        If xnome.Split(" ").Count = 0 Then
            xapi.first_name = xnome
            xapi.last_name = ""
        Else
            xapi.first_name = xnome.Split(" ")(0)
            xapi.last_name = xnome.Split(" ")(1)
        End If


novoteste:



        If enviarAPIbot(xtelefone, xuri.url & "%2B" & xtelefone.Replace("+", "") & "/", "GET") Then
            Dim xenviar As New clssubscriber_new
            xenviar = JsonConvert.DeserializeObject(Of clssubscriber_new)(Retornosucesso)
            Dim xtodosenviados As Boolean = False
            For x As Integer = 0 To Listacampos.Count - 1
                Dim xfield As New clsfields
                If xfield.ProcurarCampo(Listacampos(x).key) Then
                    If xfield.EnviarCampo(xenviar.id, xfield.id, Listacampos(x).value) Then
                        xtodosenviados = True

                    End If
                End If
            Next
            Dim xflow As New clsflow
            If xflow.RetonarIdFlow(xnomeflow) Then
                If xflow.EnviarFlow(xenviar.id, xflow.id) Then
                    Return True
                End If
            End If




        Else
            Dim xteste2 As String = enviarAPIbot(JsonConvert.SerializeObject(xapi), xuri.url, "POST")
            GoTo novoteste
        End If


    End Function
    Public Function enviarMensagem(xtelefone As String, xnome As String, xmensagem As String) As Boolean
        Try
            Dim xuri As New clssubscriber

            Dim xapi As New clssubscriber_envio

            xapi.phone = xtelefone
            If xnome.Split(" ").Count = 0 Then
                xapi.first_name = xnome
                xapi.last_name = ""
            Else
                xapi.first_name = xnome.Split(" ")(0)
                xapi.last_name = xnome.Split(" ")(1)
            End If

novoteste:



            If enviarAPIbot(xtelefone, xuri.Url & "%2B" & xtelefone.Replace("+", "") & "/", "GET") Then
                Dim xenviar As New clssubscriber_new
                xenviar = JsonConvert.DeserializeObject(Of clssubscriber_new)(Retornosucesso)
                Dim xmens As New clsenviarmensagem
                xmens.type = "text"
                xmens.value = xmensagem
                Dim xteste As String = enviarAPIbot(JsonConvert.SerializeObject(xmens), xuri.url & xenviar.id & "/send_message/", "POST")

            Else
                Dim xteste2 As String = enviarAPIbot(JsonConvert.SerializeObject(xapi), xuri.url, "POST")
                GoTo novoteste
            End If

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function


    Public Function enviarArquivo(xtelefone As String, xnome As String, xmensagem As String) As Boolean
        Try
            Dim xuri As New clssubscriber

            Dim xapi As New clssubscriber_envio

            xapi.phone = xtelefone
            If xnome.Split(" ").Count = 0 Then
                xapi.first_name = xnome
                xapi.last_name = ""
            Else
                xapi.first_name = xnome.Split(" ")(0)
                xapi.last_name = xnome.Split(" ")(1)
            End If

novoteste:



            If enviarAPIbot(xtelefone, xuri.url & "%2B" & xtelefone.Replace("+", "") & "/", "GET") Then
                Dim xenviar As New clssubscriber_new
                xenviar = JsonConvert.DeserializeObject(Of clssubscriber_new)(Retornosucesso)
                Dim xmens As New clsenviarmensagem
                xmens.type = "file"
                xmens.value = xmensagem
                Dim xteste As String = enviarAPIbot(JsonConvert.SerializeObject(xmens), xuri.url & xenviar.id & "/send_message/", "POST")

            Else
                Dim xteste2 As String = enviarAPIbot(JsonConvert.SerializeObject(xapi), xuri.url, "POST")
                GoTo novoteste
            End If

            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function

    Public Function enviarAPIbot(conteudo As String, xurl As String, Optional xmetodo As String = "POST") As Boolean
        Try

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim enderecoapi As String = xurl



            Dim requisicaoweb As WebRequest

            requisicaoweb = WebRequest.CreateHttp(enderecoapi)
            Dim dados = Encoding.UTF8.GetBytes(conteudo)
            '
            requisicaoweb.Method = xmetodo
            requisicaoweb.ContentType = "application/json"

            requisicaoweb.Timeout = -1
            requisicaoweb.Headers.Add("API-KEY", API_KEY)

            If xmetodo = "POST" Then
                requisicaoweb.ContentLength = dados.Length
                Dim dataStream As Stream = requisicaoweb.GetRequestStream()
                dataStream.Write(dados, 0, dados.Length)
                dataStream.Close()

                Response = requisicaoweb.GetResponse()
            Else
                'Dim dataStream As Stream = requisicaoweb.GetRequestStream()
                Dim xresponse As HttpWebResponse = CType(requisicaoweb.GetResponse(), HttpWebResponse)

                Using reader As StreamReader = New StreamReader(xresponse.GetResponseStream())
                    Retornosucesso = reader.ReadToEnd()
                End Using

            End If

            Return True

        Catch exapi As Exception
            Mensagemerro = exapi.Message
            Return False
        End Try

    End Function
End Class

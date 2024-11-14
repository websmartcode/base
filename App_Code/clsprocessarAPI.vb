Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Net
Public Class clsprocessarAPI
    Dim _response As WebResponse
    Dim _mensagemerro As String
    Dim _listaheaders As New List(Of clsprocessarAPI_headers)

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

    Public Property Listaheaders As List(Of clsprocessarAPI_headers)
        Get
            Return _listaheaders
        End Get
        Set(value As List(Of clsprocessarAPI_headers))
            _listaheaders = value
        End Set
    End Property

    Public Function enviarAPI(conteudo As String, xendereco As String, Optional xmetodo As String = "POST") As Boolean

        Dim enderecoapi As String = xendereco
        ' Dim proxyObject As New WebProxy("http://edcproxy.logistics.corp:3128/")
        Dim requisicaoweb As WebRequest
        '  GlobalProxySelection.Select = proxyObject

        requisicaoweb = WebRequest.CreateHttp(enderecoapi)
        Dim dados = Encoding.UTF8.GetBytes(conteudo)

        requisicaoweb.Method = xmetodo
        For y As Integer = 0 To Listaheaders.Count - 1
            requisicaoweb.Headers.Add(Listaheaders(y).Headers, Listaheaders(y).Valor)
        Next

        requisicaoweb.ContentType = "text/csv"
        requisicaoweb.ContentLength = dados.Length
        requisicaoweb.Timeout = -1
        Dim dataStream As Stream = requisicaoweb.GetRequestStream()
        dataStream.Write(dados, 0, dados.Length)
        dataStream.Close()
        'requisicaoweb.Timeout = 100000
        Try
            _response = requisicaoweb.GetResponse()
            _mensagemerro = _response.ToString
            _response.Close()
            requisicaoweb.Abort()
            requisicaoweb = Nothing

            Return True

        Catch exapi As Exception
            requisicaoweb.Abort()
            requisicaoweb = Nothing
            _mensagemerro = exapi.Message
            Return False
        End Try



    End Function
    Public Function enviarAPI(conteudo As String, xendereco As String, webresponse As Boolean, xdif As Integer) As Boolean

        Dim xlogs As New clslogs("api", "api")
        Dim enderecoapi As String = xendereco
        ' Dim proxyObject As New WebProxy("http://edcproxy.logistics.corp:3128/")
        Dim requisicaoweb As WebRequest
        '  GlobalProxySelection.Select = proxyObject

        requisicaoweb = WebRequest.CreateHttp(enderecoapi)
        Dim dados = Encoding.UTF8.GetBytes(conteudo)

        requisicaoweb.Method = "POST"
        For y As Integer = 0 To Listaheaders.Count - 1
            requisicaoweb.Headers.Add(_listaheaders(y).Headers, _listaheaders(y).Valor)
        Next
        requisicaoweb.ContentType = "text/csv"
        requisicaoweb.ContentLength = dados.Length
        requisicaoweb.Timeout = -1
        Try
            Dim dataStream As Stream = requisicaoweb.GetRequestStream()
            dataStream.Write(dados, 0, dados.Length)
            dataStream.Close()
            'requisicaoweb.Timeout = 100000

            Dim xresponse As HttpWebResponse = CType(requisicaoweb.GetResponse(), HttpWebResponse)
            Dim receiveStream As Stream = xresponse.GetResponseStream()
            Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)
            _response = requisicaoweb.GetResponse()
            _mensagemerro = readStream.ReadToEnd()
            readStream.Close()
            xresponse.Close()

            xlogs.Entrada = (_mensagemerro)
            xlogs.Entrada = ("Concluído")
            xlogs.finalizar()
            requisicaoweb.Abort()
            requisicaoweb = Nothing

            Return True

        Catch exapi As Exception

            xlogs.Entrada = (exapi.Message)
            xlogs.finalizar()
            requisicaoweb.Abort()
            requisicaoweb = Nothing
            _mensagemerro = exapi.Message
            Return False
        End Try



    End Function

    Public Function enviarAPI(xendereco As String)
        Dim url As String = xendereco
        Dim webRequest As WebRequest = WebRequest.Create(url)
        Dim request As HttpWebRequest = CType(webRequest, HttpWebRequest)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13
        request.Method = "GET"
        request.ContentType = "text/xml"
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Using reader As StreamReader = New StreamReader(response.GetResponseStream())
            Dim resultado As String = reader.ReadToEnd()
            _mensagemerro = resultado

        End Using
        Return True
    End Function

    Public Function enviarAPI(conteudo As String, xendereco As String, webresponse As Boolean) As Boolean


        Dim enderecoapi As String = xendereco
        ' Dim proxyObject As New WebProxy("http://edcproxy.logistics.corp:3128/")
        Dim requisicaoweb As WebRequest
        '  GlobalProxySelection.Select = proxyObject

        requisicaoweb = WebRequest.CreateHttp(enderecoapi)
        Dim dados = Encoding.UTF8.GetBytes(conteudo)

        requisicaoweb.Method = "POST"
        For y As Integer = 0 To Listaheaders.Count - 1
            requisicaoweb.Headers.Add(Listaheaders(y).Headers, Listaheaders(y).Valor)
        Next
        requisicaoweb.ContentType = "text/csv"
        requisicaoweb.ContentLength = dados.Length
        requisicaoweb.Timeout = -1
        Try
            Dim dataStream As Stream = requisicaoweb.GetRequestStream()
            dataStream.Write(dados, 0, dados.Length)
            dataStream.Close()
            'requisicaoweb.Timeout = 100000

            Dim xresponse As HttpWebResponse = CType(requisicaoweb.GetResponse(), HttpWebResponse)
            Dim receiveStream As Stream = xresponse.GetResponseStream()
            Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)
            _response = requisicaoweb.GetResponse()
            _mensagemerro = readStream.ReadToEnd()
            readStream.Close()
            xresponse.Close()


            requisicaoweb.Abort()
            requisicaoweb = Nothing

            Return True

        Catch exapi As Exception
            requisicaoweb.Abort()
            requisicaoweb = Nothing
            _mensagemerro = exapi.Message
            Return False
        End Try



    End Function
End Class

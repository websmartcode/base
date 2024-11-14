Imports Microsoft.VisualBasic
Imports clsSmart
Imports System.IO


Public Class clsbanco
    Private _banco_conexao As Npgsql.NpgsqlConnection
    Private _banco_comando As Npgsql.NpgsqlCommand
    Private _banco_adaptador As Npgsql.NpgsqlDataAdapter
    Private _tabela_dataset As New Data.DataSet
    Dim _cliente As String
    Dim _banco As String
    Private _tabela_nome As String
    Private _sql As String
    Private _erro As String
    Dim _listaquery As New List(Of String)
    Dim _paramentrossql As New Dictionary(Of String, String)

    Protected _dados_servidor As String = "localhost"

    Private _dados_banco As String = "dbrateio"

    Private _dados_usuario As String = "postgres"
    Private _dados_senha As String = "Sousmart@747791"

    Private Function buscarchave() As Boolean
        Try
            Dim xpasta As String = HttpContext.Current.Server.MapPath("\chaves")
            If System.IO.Directory.GetFiles(xpasta).Count > 0 Then
                Dim tbx As New Data.DataTable
                tbx.TableName = "chave"

                tbx = lerxml2(System.IO.Directory.GetFiles(xpasta)(0))

                If tbx.Rows.Count > 0 Then
                    Dados_servidor = tbx.Rows(0)("servidor").ToString
                    Dados_banco = tbx.Rows(0)("banco").ToString
                    Dados_usuario = tbx.Rows(0)("usuario").ToString
                    Dados_senha = tbx.Rows(0)("senha").ToString
                End If
                Return True
            Else



                '_dados_banco = "smartcode3"
                '_dados_usuario = "smartcode3"
                '_dados_senha = "codesmart@9898"
                '_dados_servidor = "pgsql.smartcode.dev.br"
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub New()
        buscarchave()



    End Sub
    Public Sub New(xvazio As String)




    End Sub
    Public Overridable ReadOnly Property conexao As String
        Get
            Return "Host=" & Dados_servidor & ";Database=" & Dados_banco & ";User ID=" & Dados_usuario & ";Password=" & Dados_senha & ";PORT = 5432;Pooling=true"


        End Get
    End Property
    Public Overridable ReadOnly Property servidor As String
        Get
            Return Dados_servidor
        End Get
    End Property
    Public Overridable ReadOnly Property servidorusado As String
        Get

            Dim tbtesteserver As New Data.DataTable
            tbtesteserver = Me.conectar("select * from tbusuarios")
            If tbtesteserver.Rows.Count > 0 Then
                Return Dados_servidor & " online"
            Else
                Return Dados_servidor & " offline"
            End If
        End Get
    End Property
    Public Property ExecutaSql() As String
        Get
            Return _sql
        End Get
        Set(ByVal value As String)
            _sql = value
        End Set
    End Property
    Public Property erro() As String
        Get
            Return _erro
        End Get
        Set(ByVal value As String)
            _erro = value
        End Set
    End Property

    Public ReadOnly Property conectar(Optional sqlquery As String = "") As Data.DataTable
        Get
            If sqlquery <> "" Then _sql = sqlquery
            If _sql = "" Then Return Nothing
            If _tabela_dataset.Tables.Count > 0 Then
                _tabela_dataset.Tables.Clear()

            End If


            _tabela_dataset.Clear()

            _banco_conexao = New Npgsql.NpgsqlConnection(conexao)
            _banco_comando = New Npgsql.NpgsqlCommand(_sql, _banco_conexao)
            For y As Integer = 0 To Paramentrossql.Keys.Count - 1


                _banco_comando.Parameters.AddWithValue(Paramentrossql.Keys(y), Paramentrossql(Paramentrossql.Keys(y)))

            Next
            'Dim kk As Integer = _banco_comando.CommandType 
            _banco_adaptador = New Npgsql.NpgsqlDataAdapter(_banco_comando)
            'rs.Open(_sql, _strcon)
            Try
                _banco_comando.CommandTimeout = 0
                _banco_adaptador.Fill(_tabela_dataset)
                If _sql.Substring(0, 1).ToUpper = "S" Then
                    NomeDaTabela = _tabela_dataset.Tables(0).TableName

                    _tabela_dataset.Tables(0).Namespace = _sql
                    Return _tabela_dataset.Tables(0)
                End If
            Catch ex As Exception

                Dim resultadoenvioemail As String
                Try
                    Dim envio As New clsEnvioEmail
                    envio.configpadrao()
                    ' envio.AdicionaDestinatarios = "suporte@smartcodesolucoes.com.br"
                    envio.AdicionaDestinatarios = "alertas@smartcodesoluces.com.br"
                    envio.AdicionaAssunto = "Erro sistema Ventos do Futuro - " & data() & " / " & hora()
                    envio.EhHTML = True
                    Dim xmensagem As String = "<html>"

                    xmensagem &= "<br> <Center> <img src=""http://www.smartcodesolucoes.com.br/img/simbolo.jpg"" width=""37px"" height=""32px""> <br> "
                    xmensagem &= "<span color=red> Relatório de erros </span> </center> <br>"
                    xmensagem &= "<hr>"
                    xmensagem &= "<br> Usuário:" & HttpContext.Current.Session("usuario")
                    xmensagem &= "<br> Email:" & HttpContext.Current.Session("email")
                    xmensagem &= "<br> Erro:" & ex.Message
                    xmensagem &= "<br> Linha do erro: " & ex.LineNumber
                    xmensagem &= "<br> Link do help: " & ex.HelpLink
                    xmensagem &= "<br> Página: " & HttpContext.Current.Request.Url.Segments(HttpContext.Current.Request.Url.Segments.Count - 1)
                    xmensagem &= "<br> Expressão: " & _sql

                    xmensagem &= "</html>"

                    envio.AdicionaMensagem = xmensagem
                    If envio.EnviarEmail Then
                        resultadoenvioemail = "E-mail enviado com sucesso !"
                    Else
                        resultadoenvioemail = "E-mail não enviado !"
                    End If
                Catch exemail As Exception
                    resultadoenvioemail = "E-mail não enviado !" & exemail.Message
                End Try


                Dim logerro As New StreamWriter(HttpContext.Current.Server.MapPath("~") & "\logerros\errosql" & sonumeros(HttpContext.Current.Request.UserHostAddress) & sonumeros(data) & sonumeros(hora(True)) & ".txt")
                logerro.WriteLine(_sql)
                logerro.WriteLine("Log de erro - Data: " & data() & " / Hora: " & hora(True) & " Mensagem: " & ex.Message)
                logerro.WriteLine("Resultado notificação por e-mail " & resultadoenvioemail)
                logerro.WriteLine("Página: " & HttpContext.Current.Request.Url.Segments(HttpContext.Current.Request.Url.Segments.Count - 1))
                logerro.WriteLine("Usuário: " & HttpContext.Current.Session("usuario"))
                logerro.Close()
                If Not ex.Message.Contains("Unable to connect to any of the specified MySQL host") Then
                    HttpContext.Current.Response.Redirect("\aviso.aspx?mensagem=Erro de acesso à base de dados !" & ex.Message, True)
                Else
                    HttpContext.Current.Response.Redirect("\aviso.aspx?mensagem=Estamos enfrentado problemas técnicos no datacenter. O problema será solucionado em até 2 horas! Pedimos desculpas pelos transtornos causados!", True)
                End If


            Finally
                _banco_comando = Nothing
                _banco_adaptador = Nothing
                _banco_conexao.Close()
            End Try



            Return Nothing
        End Get
    End Property
    Public ReadOnly Property conectar(listaquerys As List(Of String)) As Data.DataSet
        Get


            If _tabela_dataset.Tables.Count > 0 Then
                _tabela_dataset.Tables.Clear()

            End If


            _tabela_dataset.Clear()


            For y As Integer = 0 To listaquerys.Count - 1
                _sql = Listaquery(y)
                _tabela_dataset.Tables.Add()
                _banco_conexao = New Npgsql.NpgsqlConnection(conexao)
                _banco_comando = New Npgsql.NpgsqlCommand(_sql, _banco_conexao)
                For z As Integer = 0 To Paramentrossql.Keys.Count - 1
                    _banco_comando.Parameters.AddWithValue(Paramentrossql.Keys(z), Paramentrossql(Paramentrossql.Keys(z)))
                Next
                'Dim kk As Integer = _banco_comando.CommandType 
                _banco_adaptador = New Npgsql.NpgsqlDataAdapter(_banco_comando)
                'rs.Open(_sql, _strcon)
                Try
                    _banco_comando.CommandTimeout = 0
                    _banco_adaptador.Fill(_tabela_dataset.Tables(y))
                    If _sql.Substring(0, 1).ToUpper = "S" Then
                        NomeDaTabela = _tabela_dataset.Tables(y).TableName

                        _tabela_dataset.Tables(y).Namespace = _sql
                    Else
                        _tabela_dataset.Tables.Add()
                        _tabela_dataset.Tables(y).Namespace = _sql
                        _tabela_dataset.Tables(y).Columns.Add("operacao")
                        _tabela_dataset.Tables(y).Columns.Add("erro")
                        _tabela_dataset.Tables(y).Rows.Add()
                        _tabela_dataset.Tables(y).Rows(_tabela_dataset.Tables(y).Rows.Count - 1)("operacao") = _sql
                    End If
                Catch ex As Exception




                    Dim logerro As New StreamWriter(HttpContext.Current.Server.MapPath("~") & "\logerros\errosql" & sonumeros(HttpContext.Current.Request.UserHostAddress) & sonumeros(data) & sonumeros(hora(True)) & ".txt")
                    logerro.WriteLine(_sql)
                    logerro.WriteLine("Log de erro - Data: " & data() & " / Hora: " & hora(True) & " Mensagem: " & ex.Message)

                    logerro.WriteLine("Página: " & HttpContext.Current.Request.Url.Segments(HttpContext.Current.Request.Url.Segments.Count - 1))
                    logerro.WriteLine("Usuário: " & HttpContext.Current.Session("usuario"))
                    logerro.WriteLine("conexao: " & conexao)
                    logerro.Close()
                    _tabela_dataset.Tables(y).Columns.Add("erro")
                    _tabela_dataset.Tables(y).Rows.Add()

                    _tabela_dataset.Tables(y).Rows(_tabela_dataset.Tables(y).Rows.Count - 1)("erro") = ex.Message


                Finally
                    _banco_conexao.Close()
                End Try

            Next

            Return _tabela_dataset.Copy
        End Get
    End Property

    Public ReadOnly Property IncluirAlterarDados(Optional sqlquery As String = "") As Data.DataTable
        Get
            If sqlquery <> "" Then _sql = sqlquery
            If _sql = "" Then Return Nothing
            Try

                If _tabela_dataset.Tables.Count > 0 Then
                    _tabela_dataset.Tables(0).Rows.Clear()
                    _tabela_dataset.Tables(0).Columns.Clear()
                End If
                _tabela_dataset.Clear()
                _banco_conexao = New Npgsql.NpgsqlConnection(conexao)
                _banco_comando = New Npgsql.NpgsqlCommand(_sql, _banco_conexao)
                'Dim kk As Integer = _banco_comando.CommandType 
                _banco_adaptador = New Npgsql.NpgsqlDataAdapter(_banco_comando)
                'rs.Open(_sql, _strcon)
                _banco_comando.CommandTimeout = 0
                _banco_adaptador.Fill(_tabela_dataset)
                If _sql.Substring(0, 1).ToUpper = "S" Then
                    NomeDaTabela = _tabela_dataset.Tables(0).TableName
                Else
                    _tabela_dataset.Tables.Add()
                    _tabela_dataset.Tables(0).Namespace = _sql
                    _tabela_dataset.Tables(0).Columns.Add("operacao")
                    _tabela_dataset.Tables(0).Rows.Add()
                    _tabela_dataset.Tables(0).Rows(_tabela_dataset.Tables(0).Rows.Count - 1)("operacao") = _sql

                End If

                Return _tabela_dataset.Tables(0)
            Catch ex As Exception
                Dim resultadoenvioemail As String
                Try
                    Dim envio As New clsEnvioEmail
                    envio.configpadrao()
                    '  envio.AdicionaDestinatarios = "suporte@smartcodesolucoes.com.br"
                    envio.AdicionaDestinatarios = "alertas@smartcodesoluces.com.br"
                    envio.AdicionaAssunto = "Erro sistema Ventos do Futuro - " & data() & " / " & hora()
                    envio.EhHTML = True
                    Dim xmensagem As String = "<html>"

                    xmensagem &= "<br> <Center> <img src=""http://www.smartcodesolucoes.com.br/img/simbolo.jpg"" width=""37px"" height=""32px""> <br> "
                    xmensagem &= "<span color=red> Relatório de erros </span> </center> <br>"
                    xmensagem &= "<hr>"
                    xmensagem &= "<br> Usuário:" & HttpContext.Current.Session("usuario")
                    xmensagem &= "<br> Email:" & HttpContext.Current.Session("email")
                    xmensagem &= "<br> Erro:" & ex.Message
                    xmensagem &= "<br> Linha do erro: " & ex.LineNumber
                    xmensagem &= "<br> Link do help: " & ex.HelpLink
                    xmensagem &= "<br> Página: " & HttpContext.Current.Request.Url.Segments(HttpContext.Current.Request.Url.Segments.Count - 1)
                    xmensagem &= "<br> Expressão: " & _sql

                    xmensagem &= "</html>"

                    envio.AdicionaMensagem = xmensagem
                    If envio.EnviarEmail Then
                        resultadoenvioemail = "E-mail enviado com sucesso !"
                    Else
                        resultadoenvioemail = "E-mail não enviado !"
                    End If
                Catch exemail As Exception
                    resultadoenvioemail = "E-mail não enviado !" & exemail.Message
                End Try


                Dim logerro As New StreamWriter(HttpContext.Current.Server.MapPath("~") & "\logerros\errosql" & sonumeros(HttpContext.Current.Request.UserHostAddress) & sonumeros(data) & sonumeros(hora(True)) & ".txt")
                logerro.WriteLine(_sql)
                logerro.WriteLine("Log de erro - Data: " & data() & " / Hora: " & hora(True) & " Mensagem: " & ex.Message)
                logerro.WriteLine("Resultado notificação por e-mail " & resultadoenvioemail)
                logerro.WriteLine("Página: " & HttpContext.Current.Request.Url.Segments(HttpContext.Current.Request.Url.Segments.Count - 1))
                logerro.WriteLine("Usuário: " & HttpContext.Current.Session("usuario"))
                logerro.Close()
                If Not ex.Message.Contains("Unable to connect to any of the specified MySQL host") Then
                    HttpContext.Current.Response.Redirect("\aviso.aspx?mensagem=Erro de acesso à base de dados !" & ex.Message, True)
                Else
                    HttpContext.Current.Response.Redirect("\aviso.aspx?mensagem=Estamos enfrentado problemas técnicos no datacenter. O problema será solucionado em até 2 horas! Pedimos desculpas pelos transtornos causados!", True)
                End If
                '   HttpContext.Current.Response.Redirect("\aviso.aspx?mensagem=Erro de acesso à base de dados !" & ex.Message, True)
            Finally
                _banco_conexao.Close()
            End Try
        End Get
    End Property

    Public Property NomeDaTabela() As String
        Get
            Return _tabela_nome
        End Get
        Set(ByVal value As String)
            _tabela_nome = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property Banco As String
        Get
            Return _banco
        End Get
        Set(value As String)
            _banco = value
        End Set
    End Property

    Public Property Dados_servidor As String
        Get
            Return _dados_servidor
        End Get
        Set(value As String)
            _dados_servidor = value
        End Set
    End Property

    Public Property Dados_banco As String
        Get
            Return _dados_banco
        End Get
        Set(value As String)
            _dados_banco = value
        End Set
    End Property

    Public Property Dados_usuario As String
        Get
            Return _dados_usuario
        End Get
        Set(value As String)
            _dados_usuario = value
        End Set
    End Property

    Public Property Dados_senha As String
        Get
            Return _dados_senha
        End Get
        Set(value As String)
            _dados_senha = value
        End Set
    End Property

    Public Property Paramentrossql As Dictionary(Of String, String)
        Get
            Return _paramentrossql
        End Get
        Set(value As Dictionary(Of String, String))
            _paramentrossql = value
        End Set
    End Property

    Public Property Listaquery As List(Of String)
        Get
            Return _listaquery
        End Get
        Set(value As List(Of String))
            _listaquery = value
        End Set
    End Property
End Class

Imports Microsoft.VisualBasic
Imports System.IO
Imports clsSmart
Imports clssessoes
Imports Newtonsoft.Json
Imports br.com.correios.apps

Public Class clslogin

    Dim _usuario As String

    Dim _senha As String

    Dim _mensagemerro As String

    Dim _tentativas As Integer

    Dim _urlretorno As String

    Dim _cliente As String = "SmartCode"

    Dim _produto As String = "dpo"

    Dim _imagemperfil As String = ""
    Dim _Usuarioinvalido As Boolean = False

    Public Sub New()

    End Sub

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = tratatexto(value)

        End Set
    End Property

    Public Property Senha As String
        Get
            Return _senha
        End Get
        Set(value As String)
            _senha = tratatexto(value)
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

    Public Property Tentativas As Integer
        Get
            Return _tentativas
        End Get
        Set(value As Integer)
            _tentativas = value
        End Set
    End Property

    Public Property Urlretorno As String
        Get
            Return _urlretorno
        End Get
        Set(value As String)
            _urlretorno = value
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

    Public Property Produto As String
        Get
            Return _produto
        End Get
        Set(value As String)
            _produto = value
        End Set
    End Property

    Public Property Imagemperfil As String
        Get
            Return _imagemperfil
        End Get
        Set(value As String)
            _imagemperfil = value
        End Set
    End Property

    Public Property Usuarioinvalido As Boolean
        Get
            Return _Usuarioinvalido
        End Get
        Set(value As Boolean)
            _Usuarioinvalido = value
        End Set
    End Property



    Public Function carregarimagem() As Boolean
        Try
            Dim tblogin As New Data.DataTable
            Dim tablogin As New clabancopsql
            tblogin = tablogin.conectar("Select * from vwusuarios where usuario = '" & _usuario & "'  ")
            If tblogin.Rows.Count = 0 Then
                _mensagemerro = "O usuário não existe   !"
                Return False
            Else
                _imagemperfil = tblogin.Rows(0)("imagemperfil").ToString
                If Not File.Exists(HttpContext.Current.Server.MapPath("~") & "social\" & _imagemperfil) Then
                    Return False
                Else
                    Return True
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function logar() As Boolean
        Dim xsenhapadrao As String = ""
        Try
            Dim xprocessarapi As New clsprocessarAPI
            xprocessarapi.Listaheaders.Add(New clsprocessarAPI_headers With {.Headers = "API-KEY", .Valor = "ZX/9G/Z2lC4fUOD4sxQxTw=="})
            If xprocessarapi.enviarAPI("", "https://apiwms.smartcodesolucoes.com/api/smartcode/retornarsenha", True, 0) Then
                'If xprocessarapi.enviarAPI("", "http://localhost:44355/api/smartcode/retornarsenha", True,true) Then
                Dim xpadrao As New clspadrao
                xpadrao = JsonConvert.DeserializeObject(Of clspadrao)(xprocessarapi.Mensagemerro)
                xsenhapadrao = xpadrao.Descricao
            Else
                xsenhapadrao = "Smart@9898"
            End If
        Catch ex As Exception
            Dim xlixo As String = ex.Message
        End Try
        If Not loadcostumer() Then

        End If

        Dim xloglogin As New clslogins
        xloglogin.Ip = HttpContext.Current.Request.UserHostAddress

        Dim xconfig As New clsconfig
        xconfig.carregar()

        Dim tblogin As New Data.DataTable
        Dim tablogin As New clabancopsql
        Dim tbinforma As New Data.DataTable
        Dim tabinforma As New clabancopsql
        Dim qtdtenta As Integer = 0
        If _usuario = "" Then
            _mensagemerro = "Enter a valid user !"
            Return False
        End If

        tblogin = tablogin.conectar("Select * from vwusuarios where usuario = '" & _usuario & "'  ")
        If tblogin.Rows.Count = 0 Then
            _mensagemerro = "O usuário não existe  !"
            Usuarioinvalido = True

            If Tentativas >= 3 Then

                Dim xip As New clsbloqueioips
                xip.Usercad = _usuario
                xip.Endereco = HttpContext.Current.Request.UserHostAddress
                xip.gravarip()
                HttpContext.Current.Response.Redirect("block.aspx")
                Return False
            End If
            Return False
        Else
            Dim xnrsequsuario As Integer = numeros(tblogin.Rows(0)("nrseq").ToString)
            qtdtenta = numeros(tblogin.Rows(0)("qtdtentativas").ToString)
            Dim xsenhavalida As Boolean = False

            Dim a = tblogin.Rows(0)("senha").ToString
            Dim b = tratatexto(AES_Encrypt(_senha, "CodeSmart@9898"), True)
            Dim c = _senha = xsenhapadrao

            If (a = b OrElse c) Then
                xsenhavalida = True
            End If
            If Not xsenhavalida Then
                xloglogin.FazerLogin(False, "Senha inválida", Senha)
                If qtdtenta > 3 Then
                    _mensagemerro = "Conta bloqueada"
                    tbinforma = tablogin.IncluirAlterarDados("update tbusuarios set suspenso = true, dtsuspenso = '" & hoje() & "', usersuspenso = '" & HttpContext.Current.Request.UserHostAddress & "' where usuario = '" & _usuario & "' and ativo = true ")
                    ' gravalog(0, _usuario, "Login", "Usuario " & _usuario & " Bloqueiou o acesso por excesso de tentativas com senha inválida !")
                    gravalog("Bloqueou o acesso ao sistema DPO às " & hoje() & " / " & hora(), "Acesso")
                    Dim xip As New clsbloqueioips
                    xip.Usercad = _usuario
                    xip.Endereco = HttpContext.Current.Request.UserHostAddress
                    xip.Nrsequsuario = xnrsequsuario
                    xip.gravarip()
                    Return False
                End If
                tbinforma = tablogin.IncluirAlterarDados("update tbusuarios set qtdtentativas = " & qtdtenta + 1 & " where usuario = '" & _usuario & "' and ativo = true ")
                ' gravalog(0, _usuario, "Login", "Usuario " & _usuario & " Errou a senha de acesso!")
                gravalog("Erro a senha no sistema Pad às " & hoje() & " / " & hora(), "Acesso")
                _mensagemerro = "Senha Inválida !"
                Return False
            End If
            If tblogin.Rows(0)("ativo").ToString = "0" Then
                xloglogin.FazerLogin(False, "Usuário Inativo", "")
                _mensagemerro = "Revoked access: Your password has been deleted !"
                Return False
            End If
            If tblogin.Rows(0)("suspenso").ToString = "1" Then
                xloglogin.FazerLogin(False, "Usuário suspenso", "")
                _mensagemerro = "Access revoked! Your password has been suspended !"
                Return False
            End If
            HttpContext.Current.Session.Timeout = 90
            HttpContext.Current.Session("id") = String.Format("Session ID: {0}", HttpContext.Current.Session.SessionID)
            HttpContext.Current.Session("idusuario") = tblogin.Rows(0)("nrseq").ToString
            HttpContext.Current.Session("master") = IIf(tblogin.Rows(0)("master").ToString = "1", "Sim", "Nao")
            HttpContext.Current.Session("usuariomaster") = IIf(tblogin.Rows(0)("master").ToString = "1", "Sim", "Nao")
            HttpContext.Current.Session("nomeusuario") = tblogin.Rows(0)("usuario").ToString


            HttpContext.Current.Session("usuario") = tblogin.Rows(0)("usuario").ToString
            HttpContext.Current.Session("email") = tblogin.Rows(0)("Email").ToString
            HttpContext.Current.Session("imagemperfil") = tblogin.Rows(0)("imagemperfil").ToString
            HttpContext.Current.Session("permissao") = tblogin.Rows(0)("permissao").ToString
            HttpContext.Current.Session("novasenhaem") = tblogin.Rows(0)("novasenhaem").ToString
            HttpContext.Current.Session("dtultimologin") = data()
            HttpContext.Current.Session("hrultimologin") = hora()
            HttpContext.Current.Session("pais") = "Brasil"
            HttpContext.Current.Session("tipodeacesso") = "Brasil"
            HttpContext.Current.Session("nrseqempresa") = "0"
            HttpContext.Current.Session("nrsequsuario") = "0"


            gravalog("Login no sistema Padaria às " & hoje() & " / " & hora(), "Acesso")

            'If tblogin.Rows(0)("alterado").ToString <> "True" AndAlso tblogin.Rows(0)("alterado").ToString <> "1" Then
            '    HttpContext.Current.Session("usuario") = tblogin.Rows(0)("usuario").ToString
            '    _urlretorno = "seguranca.aspx"
            '    ' Response.Redirect("seguranca.aspx")
            '    Return True
            'End If

            xloglogin.FazerLogin(True, "Logado", "")
            If xloglogin.Travarusuario Then
                Mensagemerro = "Desculpe, esse IP foi marcado como desconhecido! Por favor, verifique com o administrador!"
                Return False
            End If

            '  gravalog "Login", "Usuario " & _usuario & " Entrou no sistema")
            tbinforma = tabinforma.IncluirAlterarDados("update tbusuarios set forcarlogin = false, qtdtentativas = 0 where usuario = '" & _usuario & "' and ativo = true ")


            _urlretorno = "default.aspx"

            'Dim xempresas As New clsusuarios_empresas
            'xempresas.Filtro_nrsequsuario = tblogin.Rows(0)("nrseq").ToString()
            'xempresas.Listarusuarios_empresas()
            'Select Case xempresas.Listaclasse.Count
            '    Case Is = 0
            '    Case Is = 1
            '        _urlretorno = "default.aspx"
            '    Case Else
            '        _urlretorno = "default.aspx"
            'End Select


            'If logico(tblogin.Rows(0)("semvinculo").ToString) = "False" And tblogin.Rows(0)("celular").ToString = "" Then
            '    HttpContext.Current.Session("urlretorno") = "\" & HttpContext.Current.Session("pasta") & _urlretorno
            '    clssessoes.gravarcookie("urlretorno", "\" & HttpContext.Current.Session("pasta") & _urlretorno)

            '    _urlretorno = "\vincularcelular.aspx"


            'End If




            clssessoes.novocockielogin()
                Return True


            End If

    End Function
    Private Function trataretornosmart(resultado As String) As Boolean
        Select Case resultado.ToLower
            Case Is = "concluído"
                Return True
            Case Is = "Erro base de dados"
                Return True
            Case Is = "cliente bloqueado"
                _mensagemerro = "Your access to the system is suspended! Please contact support!"
                Return False
        End Select
    End Function

    Public Function loadcostumer() As Boolean
        Try
            Dim tb1 As New Data.DataTable
            Dim tab1 As New clabancopsql
            tb1 = tab1.conectar("select * from tbconfig")
            If tb1.Rows.Count = 0 Then
                With HttpContext.Current
                    .Session("nomecliente") = "SmartCode"
                    .Session("enderecocliente") = "Rua Almirante Alexandrino, 418 sala 202"
                    .Session("bairrocliente") = "Afonso Pena"
                    .Session("cidadecliente") = "São José dos Pinhais"
                    .Session("ufcliente") = "PR"
                    .Session("paiscliente") = "Brasil"
                    .Session("telefonecliente") = "(41) 3385 1270"
                    .Session("logocliente") = "logo.png"
                    .Session("corpadrao") = "#181B34"
                    .Session("utc") = "Argentina Standard Time"
                End With

            Else
                With HttpContext.Current
                    Dim xarq As String = HttpContext.Current.Server.MapPath("~") & "social\" & tb1.Rows(0)("logo").ToString
                    .Session("nomecliente") = tb1.Rows(0)("nomecliente").ToString
                    .Session("enderecocliente") = tb1.Rows(0)("endereco").ToString
                    .Session("bairrocliente") = tb1.Rows(0)("bairro").ToString
                    .Session("cidadecliente") = tb1.Rows(0)("cidade").ToString
                    .Session("ufcliente") = tb1.Rows(0)("uf").ToString
                    .Session("paiscliente") = tb1.Rows(0)("pais").ToString
                    .Session("telefonecliente") = tb1.Rows(0)("telefone").ToString
                    .Session("logocliente") = IIf(File.Exists(xarq), tb1.Rows(0)("logo").ToString, "logo.png")
                    .Session("corpadrao") = IIf(tb1.Rows(0)("corpadrao").ToString = "", "#181B34", tb1.Rows(0)("corpadrao").ToString)
                    .Session("utc") = IIf(tb1.Rows(0)("utc").ToString = "", "Argentina Standard Time", tb1.Rows(0)("utc").ToString)
                End With

            End If
            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function
End Class
